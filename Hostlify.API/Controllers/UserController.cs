using AutoMapper;
using Hostlify.API.Resource;
using Hostlify.Domain;
using Hostlify.Infraestructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Hostlify.API.Controllers
{   
    [Filter.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;
        
        public UserController(IUserDomain userDomain,IMapper mapper)
        {
            _userDomain = userDomain;
            _mapper = mapper;
        }
        // GET: api/User
        [AllowAnonymous]
        [HttpPost] 
        [Route("Login")]
        public async Task<LoginUserResponse> Login(LoginResource loginResource)
        {
            var user = _mapper.Map<LoginResource, User>(loginResource);
            var result = await _userDomain.Login(user);
            var LoginResult = await _userDomain.GetByEmail(user.Email);
            var userResponse = _mapper.Map<User, LoginUserResponse>(LoginResult);
            userResponse.Jwt = result;
            return userResponse;
        }   
        
        // GET: api/User
        [AllowAnonymous]
        [HttpPost]
        [Route("Signup")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> Signup(UserResource userResource)
        {
            var user = _mapper.Map<UserResource,User>(userResource);
            if (userResource.Plan == "none") {user.Plan = null;}
            var result = await _userDomain.Signup(user);
            return Ok(result);
        }

        // GET: api/User
        [Filter.Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _userDomain.GetAllUsers();
                return Ok(_mapper.Map<List<User>, List<GetUserResponse>>(result));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }
        

        // GET: api/User/5
        [Filter.Authorize]
        [ProducesResponseType(typeof(string), 200)]
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(_mapper.Map<User, GetUserResponse>( await _userDomain.GetByUserId(id)));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }

        }
        
        [Filter.Authorize]
        [ProducesResponseType(typeof(string), 200)]
        [HttpGet("GetByEmail/{email}", Name = "GetByEmail")]
        public async Task<IActionResult> Get(string email)
        {
            try
            {
                return Ok(_mapper.Map<User, GetUserResponse>( await _userDomain.GetByEmail(email)));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }

        }
        
        [Filter.Authorize]
        [ProducesResponseType(typeof(string), 200)]
        [HttpGet("GetRoomsLimit/{id}", Name = "GetId")]
        public async Task<IActionResult> GetRoomsLimit(int id)
        {
            try
            {
                return Ok(await _userDomain.GetRoomsLimitByUserId(id));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }

        }
        //[Filter.Authorize]
        [AllowAnonymous]
        [HttpPost]
        [Route("PostRoomsLimit")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> postRoomlimit(postRoomLimitResource roomLimit)
        {
            var result = await _userDomain.PostPersonalPlan(roomLimit.email,roomLimit.roomsLimit);
            return Ok(result);
        }

        // DELETE: api/User/5
        //[Filter.Authorize]
        [AllowAnonymous]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 200)]
        public async Task<bool> Delete(int id)
        {
            return await _userDomain.DeleteUser(id);
        }
    }
}
