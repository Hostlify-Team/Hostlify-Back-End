using System.Net.Mime;
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
        [Filter.Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get() 
        {
            try
            {
                var result = await _roomDomain.getAll();
                return Ok(_mapper.Map<List<Room>,List<GetRoomResponse>>(result));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            finally
            {
            
            }
        }

        // GET: api/Rooms/5
        [Filter.Authorize]
        [HttpGet]
        [Route("byManagerId")]
        public  async Task<IActionResult> GetRoomforManagerId(int managerId)
        {
            try
            {
                if (managerId == 0)
                {
                    return BadRequest("ManagerId");
                }

                var result = await _roomDomain.getRoomforManagerId(managerId);
                return Ok(_mapper.Map<List<Room>,List<GetRoomResponse>>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        } 
        [Filter.Authorize]
        [HttpGet]
        [Route("byGuestId")]
        public  async Task<IActionResult> GetRoomforGuestId(int guestId)
        {
            try
            {
                if (guestId == 0)
                {
                    return BadRequest("GuestId");
                }

                var result = await _roomDomain.getRoomforGuestId(guestId);
                return Ok(_mapper.Map<Room,GetRoomResponse>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }     
        
        [Filter.Authorize]
        [HttpGet]
        [Route("byRoomName")]
        public  async Task<IActionResult> GetRoomByRoomName(string roomName)
        {
            try
            {

                var result = await _roomDomain.getRoombyRoomName(roomName);
                return Ok(_mapper.Map<Room,GetRoomResponse>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }   
               

        // POST: api/Rooms
        [Filter.Authorize]
        [HttpPost]
        public async Task<IActionResult>  Post([FromBody] RoomResource roomInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("error de formato");
                }
                var room = _mapper.Map<RoomResource, Room>(roomInput); //Aqui hago la conversion
                var result = await _roomDomain.postroom(room); //Agrego await para que sea sincrona
                return StatusCode(StatusCodes.Status201Created, "room created");
            }
                                                                                                                
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar: "+ex);
            }
            finally
            {
                
            }
        }

        // PUT: api/Rooms/5
        [Filter.Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmptyRoom(int id, [FromBody] UpdateRoomRegisteredResource roomInput)
        {
            if (roomInput.Status)
            {
                try
                {
                    UpdateRoomEmptyResource roomResource = new UpdateRoomEmptyResource();
                    roomResource.RoomName = roomInput.RoomName;
                    roomResource.ManagerId = roomInput.ManagerId;
                    roomResource.Description = roomInput.Description;
                    roomResource.Status = true;
                    var result = await _roomDomain.updateroom(id, _mapper.Map<UpdateRoomEmptyResource,Room>(roomResource));
                    return Ok(result);
                }
                catch (Exception exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
                }
            }
            else
            {
                try
                {
                    var result = await _roomDomain.updateroom(id, _mapper.Map<UpdateRoomRegisteredResource,Room>(roomInput));
                    return Ok(result);
                }
                catch (Exception exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
                }
            }
        }
        

        // DELETE: api/Rooms/5
        [Filter.Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _roomDomain.deleteroom(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }
    }
}
