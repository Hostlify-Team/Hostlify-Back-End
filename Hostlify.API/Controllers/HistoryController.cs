using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
    [Filter.Authorize]
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
        [AllowAnonymous]
        public async Task<IActionResult> Get() 
        {
            try
            {
                var result = await _historyDomain.getAll();
                return Ok(_mapper.Map<List<History>, List<getHistoryResponse>>(result));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }

        
        [HttpGet]
        [Route("byManagerId")]
        [AllowAnonymous]
        public  async Task<IActionResult> GetHistoryForManagerId(int managerId)
        {
            try
            {
                if (managerId == 0)
                {
                    return BadRequest("ManagerId");
                }

                var result = await _historyDomain.getHistoryForManagerId(managerId);
                return Ok(_mapper.Map<List<History>, List<getHistoryResponse>>(result));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        } 
        
        [HttpPost] 
        [Route("byResource")]
        [AllowAnonymous]
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
        [AllowAnonymous]
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
