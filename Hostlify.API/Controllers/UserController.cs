using AutoMapper;
using Hostlify.API.Resource;
using Hostlify.Domain;
using Hostlify.Infraestructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hostlify.API.Controllers
{
    [Authorize]
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
        [HttpPost] 
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginResource LoginResource)
        { 
            var user = _mapper.Map<LoginResource,User>(LoginResource);
            var result = await _userDomain.Login(user);
            return Ok(result);
        }   
        
        // GET: api/User
        [HttpPost]
        [AllowAnonymous]
        [Route("Signup")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> Signup(UserResource userResource)
        {
            var user = _mapper.Map<UserResource,User>(userResource);
            var result = await _userDomain.Signup(user);
            return Ok();
        }
        
        // GET: api/User
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public async Task<List<User>> Get()
        {
            return await _userDomain.GetAllUsers();
        }
        

        // GET: api/User/5
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), 200)]
        [HttpGet("{id}", Name = "Get")]
        public async Task<User> Get(int id)
        {
            return await _userDomain.GetByUserId(id);
        }
        

        // PUT: api/User/5
        /*[AllowAnonymous]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(void), 200)]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE: api/User/5
        [AllowAnonymous]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 200)]
        public async Task<bool> Delete(int id)
        {
            return await _userDomain.DeleteUser(id);
        }
    }
}
