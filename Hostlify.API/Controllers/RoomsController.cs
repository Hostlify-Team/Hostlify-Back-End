using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security;
using System.Threading.Tasks;
using AutoMapper;
using Hostlify.API.Resource;
using Hostlify.Domain;
using Hostlify.Infraestructure;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get() 
        {
            try
            {
                var result = await _roomDomain.getAll();
                return Ok(result);
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
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        } 
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
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }        
               

        // POST: api/Rooms
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Room roomInput)
        {
            try
            {
                var result = await _roomDomain.updateroom(id, roomInput);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            finally
            {
            
            }
        }

        // DELETE: api/Rooms/5
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
