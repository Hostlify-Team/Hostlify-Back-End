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
    public class ServicesController : ControllerBase
    {
        private readonly IFoodServicesDomain _foodServicesDomain;//Inyeccion
        private readonly ICleaningServicesDomain _cleaningServicesDomain;//Inyeccion
        private readonly IMapper _mapper;
        
        public ServicesController(IFoodServicesDomain foodServicesDomain,ICleaningServicesDomain cleaningServicesDomain, IMapper mapper)
        {
            _foodServicesDomain = foodServicesDomain;
            _cleaningServicesDomain = cleaningServicesDomain;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        [Route ("GetAllFoodServices")]
        public async Task<IActionResult> GetAllFoodServices()
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
        [Route ("GetAllCleaningServices")]
        public async Task<IActionResult> GetAllCleaningServices()
        {
            try
            {
                var result = await _cleaningServicesDomain.getAll();
                return Ok(_mapper.Map<List<CleaningServices>, List<getCleaningServiceResponse>>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }

        }
        [Authorize]
        [HttpGet]
        [Route("FoodServicebyRoomId")]
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
        [HttpGet]
        [Route("CleaningServicebyRoomId")]
        public  async Task<IActionResult> GetCleaningServiceByRoomId(int roomId)
        {
            try
            {
                if (roomId == 0)
                {
                    return BadRequest("roomId");
                }

                var result = await _cleaningServicesDomain.getCleaningServiceByRoomId(roomId);
                return Ok(_mapper.Map<List<CleaningServices>, List<getCleaningServiceResponse>>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        } 
        [Authorize]
        [HttpPost] 
        [Route("FoodServiceByResource")]
        public async Task<IActionResult> PostFoodService([FromBody] FoodServicesResource foodServicesInput)
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
        
        [Authorize]
        [HttpPost] 
        [Route("CleaningServiceByResource")]
        public async Task<IActionResult> PostCleaningService([FromBody] PostCleaningServiceResource cleaningServicesInput)
        {
            try
            {
                if (cleaningServicesInput.instruction=="none"){cleaningServicesInput.instruction = null;}
                var cleanServices = _mapper.Map<PostCleaningServiceResource, CleaningServices>(cleaningServicesInput);
                var result = await _cleaningServicesDomain.postCleaningService(cleanServices);
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
        [HttpDelete("deleteFoodService/{id}")]
        public async Task<IActionResult> DeleteFoodServiceByid(int id)
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
        }
        [Authorize]
        [HttpDelete("deleteCleaningService/{id}")]
        public async Task<IActionResult> DeleteCleaningServiceByid(int id)
        {
            try
            {
                var result = await _cleaningServicesDomain.deletebyid(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }

    }
}
