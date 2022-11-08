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
        public async Task<IActionResult> Login(UserResource userResource)
        { 
            var user = _mapper.Map<UserResource,User>(userResource);
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
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        // GET: api/User
        [HttpGet]
        [AllowAnonymous]
        [Route("GetByUsername")]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public async Task<User> GetByUsername(string username)
        {
            return await _userDomain.GetByUsername(username);
        }

        // GET: api/User/5
        [ProducesResponseType(typeof(string), 200)]
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        

        // PUT: api/User/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(void), 200)]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 200)]
        public void Delete(int id)
        {
        }
    }
}
