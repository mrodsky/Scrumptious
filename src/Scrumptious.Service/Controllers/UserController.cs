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
    public class UserController : Controller
    {
        private EntityData data;

        public UserController()
        {
            data = new EntityData();
        }

        [HttpGet("{ID:int}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        public async Task<IActionResult> Get(int ID)
        {
            return await System.Threading.Tasks.Task.Run(() =>
            {
                return Ok(data.ReadList<User>(ID));
            });
        }


        [HttpPost]
        public async System.Threading.Tasks.Task Post([FromBody] User P)
        {
            await System.Threading.Tasks.Task.Run(() =>
            {
                data.SaveAsync(P);
            });
        }
    }
}