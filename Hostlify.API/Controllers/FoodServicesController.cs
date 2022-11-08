using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Hostlify.API.Resource;
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
        [HttpGet("byALL")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _foodServicesDomain.getAll();
                return Ok(_mapper.Map<List<FoodServices>, List<FoodServices>>(result));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            finally
            {
            
            }
            
            //return await _foodServicesDomain.getAll();
        }

        // GET: api/FoodServices/5
        [HttpGet("{id}", Name = "Get1")]
        public async Task<FoodServices> Get(int RoomId)
        {
            return await _foodServicesDomain.getFoodServiceByRoomId(RoomId);
        }

        // POST: api/FoodServices
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FoodServicesResource foodServicesResource)
        {
            try
            {
                var foodServices = _mapper.Map<FoodServicesResource, FoodServices>(foodServicesResource);
                var result = await _foodServicesDomain.addFoodService(foodServices);
                return Ok(_mapper.Map<FoodServices, FoodServicesResource>(result));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            finally
            {
            
            }
        }

        // PUT: api/FoodServices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FoodServicesResource foodServicesResource)
        {
            try
            {
                var foodServices = _mapper.Map<FoodServicesResource, FoodServices>(foodServicesResource);
                var result = await _foodServicesDomain.updateFoodService(id, foodServices);
                return Ok(_mapper.Map<FoodServices, FoodServicesResource>(result));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            finally
            {
            
            }
        }

        // DELETE: api/FoodServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _foodServicesDomain.deleteFoodService(id);
                return Ok(_mapper.Map<FoodServices, FoodServicesResource>(result));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            finally
            {
            
            }
        }
    }
}
