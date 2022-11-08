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
    public class HistoryController : ControllerBase
    {
        private IHistoryDomain _historyDomain;//Inyeccion

        public HistoryController(IHistoryDomain historyDomain)
        {
            _historyDomain = historyDomain;
        }

        // GET
        [HttpGet]
        public async Task<List<History>> Get()
        {
            return await _historyDomain.getAll();
        }
        
        /*[HttpGet("{id}", Name = "Get")]
        public History Get(int id)
        {
            return _historyDomain.getHistoryById(id);
        }*/
        
        [HttpGet]
        [Route("GetByManagerId")]
        public async Task<History> GetByManagerId(int id)
        {
            return await _historyDomain.getHistoryForManager(id);
        }

        // POST
        [HttpPost]
        public async Task<bool> Post([FromBody] History historyinput)
        {
            Console.WriteLine("Hello World");
            return await _historyDomain.post(historyinput);
        }

        // PUT
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _historyDomain.deleteHistory(id);
        }
    }
}
