using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Hostlify.API.Filter;
using Hostlify.API.Resource;
using Hostlify.Domain;
using Hostlify.Infraestructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hostlify.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryDomain _historyDomain;//Inyeccion
        private readonly IMapper _mapper;

        public HistoryController(IHistoryDomain historyDomain ,IMapper mapper)
        {
            _historyDomain = historyDomain;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get() 
        {
            try
            {
                var result = await _historyDomain.getAll();
                return Ok(_mapper.Map<List<History>, List<HistoryResource>>(result));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            finally
            {
            
            }
        }

        
        [HttpGet]
        [Route("byManagerId")]
        public  async Task<IActionResult> GetHistoryForManagerId(int managerId)
        {
            try
            {
                if (managerId == 0)
                {
                    return BadRequest("ManagerId");
                }

                var result = await _historyDomain.getHistoryForManagerId(managerId);
                return Ok(_mapper.Map<History, HistoryResource>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        } 
        
        [HttpPost] 
        [Route("byResource")]
        public async Task<IActionResult>  Post([FromBody] HistoryResource historyInput)
        {
            try
            {
              
               var history = _mapper.Map<HistoryResource, History>(historyInput); 
                var result = await _historyDomain.postHistory(history); 
                return StatusCode(StatusCodes.Status201Created, "history created");
            }
                                                                                                                
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar: "+ex);
            }
            finally
            {
                
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _historyDomain.deleteHistory(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }
    }
}
