using System.Net.Mime;
using AutoMapper;
using Hostlify.API.Resource;
using Hostlify.Domain;
using Hostlify.Infraestructure;
using Microsoft.AspNetCore.Mvc;
using Hostlify.API.Filter;


namespace Hostlify.API.Controllers
{
    [Authorize]
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

        [Authorize]
        [HttpGet]
          [Route ("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _foodServicesDomain.getAll();
                return Ok(_mapper.Map<List<FoodServices>, List<GetFoodServiceResponse>>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            finally
            {
            
            }
            
        }
        [Authorize]
        [HttpGet]
        [Route("byRoomId")]
        public  async Task<IActionResult> GetFoodServiceByRoomId(int roomId)
        {
            try
            {
                if (roomId == 0)
                {
                    return BadRequest("roomId");
                }

                var result = await _foodServicesDomain.getFoodServiceByRoomId(roomId);
                return Ok(_mapper.Map<List<FoodServices>, List<GetFoodServiceResponse>>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        } 
        [Authorize]
        [HttpPost] 
        [Route("byResource")]
        public async Task<IActionResult> Post([FromBody] FoodServicesResource foodServicesInput)
        {
            try
            {
                if (foodServicesInput.instruction=="none"){foodServicesInput.instruction = null;}
                var foodServices = _mapper.Map<FoodServicesResource, FoodServices>(foodServicesInput);
                var result = await _foodServicesDomain.postfoodservice(foodServices);
                return StatusCode(StatusCodes.Status201Created, "foodservices created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar: "+ex);
            }
            finally
            {
            
            }
        }
        
        
        // DELETE: api/FoodServices/5                 
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletebyid(int id)
        {
            try
            {
                var result = await _foodServicesDomain.deletebyid(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            finally
            {
            
            }
        }

    }
}
