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
    public class FoodServicesController : ControllerBase
    {
        private readonly IFoodServicesDomain _foodServicesDomain;//Inyeccion
        private readonly IMapper _mapper;
        
        public FoodServicesController(IFoodServicesDomain foodServicesDomain,IMapper mapper)
        {
            _foodServicesDomain = foodServicesDomain;
            _mapper = mapper;
        }

        // GET: api/FoodServices
        [HttpGet]
        public async Task<List<FoodServices>> Get()
        {
            return await _foodServicesDomain.getAll();
        }

        // GET: api/FoodServices/5
        [HttpGet("{id}", Name = "Get1")]
        public async Task<FoodServices> Get(int RoomId)
        {
            return await _foodServicesDomain.getFoodServiceByRoomId(RoomId);
        }

        // POST: api/FoodServices
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/FoodServices/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/FoodServices/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
