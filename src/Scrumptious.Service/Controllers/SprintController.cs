using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scrumptious.Data.Models;


namespace Scrumptious.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SprintController : Controller
    {
        private EntityData data;

        public SprintController()
        {
            data = new EntityData();
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        public async Task<IActionResult> Get()
        {
            return await System.Threading.Tasks.Task.Run(() =>
            {
                return Ok(data.ReadAll<Sprint>());
            });
        }

        [HttpGet("{ID:int}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        public async Task<IActionResult> Get(int ID)
        {
            return await System.Threading.Tasks.Task.Run(() =>
            {
                return Ok(data.ReadList<Sprint>(ID));
            });
        }

        [HttpPost]
        public async System.Threading.Tasks.Task Post([FromBody] Sprint P)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                data.SaveAsync(P);
            });
            
    
        }
    }
}