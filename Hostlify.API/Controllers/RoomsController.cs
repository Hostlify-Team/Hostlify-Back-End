using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Hostlify.Domain;
using Hostlify.Infraestructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hostlify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomDomain _roomDomain;
        private readonly IMapper _mapper;
        
        public RoomsController(IRoomDomain roomDomain,IMapper mapper)
        {
            _roomDomain = roomDomain;
            _mapper = mapper;
        }
        // GET: api/Rooms
        [HttpGet]
        public async Task<List<Room>> Get() 
        {
            return await _roomDomain.getAll();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}", Name = "Get1")]
        public  Task<Room> Get(int id)
        {
            return _roomDomain.getRoombyId(id);
        }        

        // POST: api/Rooms
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
