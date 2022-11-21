using System.Net.Mime;
using AutoMapper;
using Hostlify.API.Filter;
using Hostlify.API.Resource;
using Hostlify.Domain;
using Hostlify.Infraestructure;
using Microsoft.AspNetCore.Mvc;

namespace Hostlify.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class PlansController : ControllerBase
    {
        private readonly IPlanDomain _planDomain;//Inyeccion
        private readonly IMapper _mapper;
        
        public PlansController(IPlanDomain planDomain,IMapper mapper)
        {
            _planDomain = planDomain;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlanResource planInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("error de formato");
                }

                var category = _mapper.Map<PlanResource, Plan>(planInput); //Aqui hago la conversion
                var result = await _planDomain.post(category); //Agrego await para que sea sincrona
                return StatusCode(StatusCodes.Status201Created, "category created");
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar: "+ex);
            }
            finally
            {
                
            }
        }
        
        // GET: api/Plans
        [HttpGet]
        public async Task<List<Plan>> Get()
        {
            return await _planDomain.getAll();
        }

        // PUT: api/Plans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PlanResource planInput)
        {
            try
            {
                var plan = _mapper.Map<PlanResource, Plan>(planInput);
                var result = await _planDomain.update(id, plan);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar: "+ex);
            }
        }
        
    }
}
