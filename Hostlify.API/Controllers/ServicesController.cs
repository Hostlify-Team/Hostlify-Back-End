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
                var errorResponse = new
                {
                    Message = "Error al procesar la solicitud",
                    ExceptionType = ex.GetType().FullName,
                    ExceptionMessage = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
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
                var errorResponse = new
                {
                    Message = "Error al procesar la solicitud",
                    ExceptionType = ex.GetType().FullName,
                    ExceptionMessage = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
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
                var errorResponse = new
                {
                    Message = "Error al procesar la solicitud",
                    ExceptionType = ex.GetType().FullName,
                    ExceptionMessage = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        } 
        [Authorize]
        [HttpGet]
        [Route("FoodServiceAttendedByRoomId")]
        public  async Task<IActionResult> GetFoodServiceAttendedByRoomId(int roomId)
        {
            try
            {
                if (roomId == 0)
                {
                    return BadRequest("roomId");
                }

                var result = await _foodServicesDomain.getFoodServiceAttendedByRoomId(roomId);
                return Ok(_mapper.Map<List<FoodServices>, List<GetFoodServiceResponse>>(result));
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Error al procesar la solicitud",
                    ExceptionType = ex.GetType().FullName,
                    ExceptionMessage = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        } 
        [Authorize]
        [HttpGet]
        [Route("FoodServiceUnAttendedByRoomId")]
        public  async Task<IActionResult> GetFoodServiceUnAttendedByRoomId(int roomId)
        {
            try
            {
                if (roomId == 0)
                {
                    return BadRequest("roomId");
                }

                var result = await _foodServicesDomain.getFoodServiceUnAttendedByRoomId(roomId);
                return Ok(_mapper.Map<List<FoodServices>, List<GetFoodServiceResponse>>(result));
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Error al procesar la solicitud",
                    ExceptionType = ex.GetType().FullName,
                    ExceptionMessage = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
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
                var errorResponse = new
                {
                    Message = "Error al procesar la solicitud",
                    ExceptionType = ex.GetType().FullName,
                    ExceptionMessage = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        } 
        [Authorize]
        [HttpGet]
        [Route("CleaningServiceAttendedByRoomId")]
        public  async Task<IActionResult> GetCleaningServiceAttendedByRoomId(int roomId)
        {
            try
            {
                if (roomId == 0)
                {
                    return BadRequest("roomId");
                }

                var result = await _cleaningServicesDomain.getCleaningServiceAttendedByRoomId(roomId);
                return Ok(_mapper.Map<List<CleaningServices>, List<getCleaningServiceResponse>>(result));
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Error al procesar la solicitud",
                    ExceptionType = ex.GetType().FullName,
                    ExceptionMessage = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [Authorize]
        [HttpGet]
        [Route("CleaningServiceUnAttendedByRoomId")]
        public  async Task<IActionResult> GetCleaningServiceUnAttendedByRoomId(int roomId)
        {
            try
            {
                if (roomId == 0)
                {
                    return BadRequest("roomId");
                }

                var result = await _cleaningServicesDomain.getCleaningServiceUnAttendedByRoomId(roomId);
                return Ok(_mapper.Map<List<CleaningServices>, List<getCleaningServiceResponse>>(result));
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Error al procesar la solicitud",
                    ExceptionType = ex.GetType().FullName,
                    ExceptionMessage = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [Authorize]
        [HttpPost] 
        [Route("FoodServiceByResource")]
        public async Task<IActionResult> PostFoodService([FromBody] FoodServicesResource foodServicesInput)
        {
            try
            {
                if (foodServicesInput.instruction=="none"){foodServicesInput.instruction = "";}
                var foodServices = _mapper.Map<FoodServicesResource, FoodServices>(foodServicesInput);
                var result = await _foodServicesDomain.postfoodservice(foodServices);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Error al procesar la solicitud",
                    ExceptionType = ex.GetType().FullName,
                    ExceptionMessage = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
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
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Error al procesar la solicitud",
                    ExceptionType = ex.GetType().FullName,
                    ExceptionMessage = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        
        
        // DELETE: api/FoodServices/5                 
        [Authorize]
        [HttpDelete("deleteAllFoodServicesByRoomId/{id}")]
        public async Task<IActionResult> DeleteAllFoodServicesByRoomId(int id)
        {
            try
            {
                var result = await _foodServicesDomain.deleteAllFoodServicesByRoomId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Error al procesar la solicitud",
                    ExceptionType = ex.GetType().FullName,
                    ExceptionMessage = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        
        // DELETE: api/FoodServices/5                 
        [Authorize]
        [HttpDelete("attendFoodService/{id}")]
        public async Task<IActionResult> AttendFoodServiceByid(int id)
        {
            try
            {
                var result = await _foodServicesDomain.attendByid(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Error al procesar la solicitud",
                    ExceptionType = ex.GetType().FullName,
                    ExceptionMessage = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        
        [Authorize]
        [HttpDelete("deleteAllCleaningServiceByRoomId/{id}")]
        public async Task<IActionResult> DeleteAllCleaningServiceByRoomId(int id)
        {
            try
            {
                var result = await _cleaningServicesDomain.deleteAllCleaningServiceByRoomId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Error al procesar la solicitud",
                    ExceptionType = ex.GetType().FullName,
                    ExceptionMessage = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        
        [Authorize]
        [HttpDelete("attendCleaningService/{id}")]
        public async Task<IActionResult> AttendCleaningServiceByid(int id)
        {
            try
            {
                var result = await _cleaningServicesDomain.attendByid(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Error al procesar la solicitud",
                    ExceptionType = ex.GetType().FullName,
                    ExceptionMessage = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

    }
}
