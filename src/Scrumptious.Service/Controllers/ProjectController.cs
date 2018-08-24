using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Scrumptious.Data.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace Scrumptious.Service.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private EntityData data;

        public ProjectController()
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
                return Ok(data.ReadAll<Project>());
            });
        }

        [HttpGet("{ID:int}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        public async Task<IActionResult> Get(int ID)
        {
            return await System.Threading.Tasks.Task.Run(() =>
            {
                return Ok(data.ReadList<Project>(ID));
            });
        }

        [HttpPost]
        public async System.Threading.Tasks.Task Post([FromBody] Project P)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                data.SaveAsync(P);
            });
            
    
        }
    }
}