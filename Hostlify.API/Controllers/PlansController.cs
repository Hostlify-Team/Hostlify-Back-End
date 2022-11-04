using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Hostlify.Domain;
using Hostlify.Infraestructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hostlify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class PlansController : ControllerBase
    {
        private IPlanDomain _planDomain;//Inyeccion
        
        public PlansController(IPlanDomain planDomain)
        {
            _planDomain = planDomain;
        }
        
        // GET: api/Plans
        [HttpGet]
        public async Task<List<Plan>> Get()
        {
            return await _planDomain.getAll();
        }

        // PUT: api/Plans/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        
    }
}
