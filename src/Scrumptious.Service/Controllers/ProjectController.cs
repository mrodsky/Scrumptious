using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scrumptious.Data.Models;
using Newtonsoft.Json;
using System.Net;

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
        //[ProducesResponseType(typeof(HttpResponse), 200)]
        public async Task<HttpResponse> Post(HttpRequest req)
        {

            try
            {
                await System.Threading.Tasks.Task.Run(() =>
                {
                    var A = JsonConvert.SerializeObject(req.Body);
                    var content = JsonConvert.DeserializeObject<Project>(A);
                    data.SaveAsync<Project>(content);
                });

                Response.StatusCode = (int)HttpStatusCode.OK;
                return Response;

            } catch (Exception ex)
            {

                Response.StatusCode = 400;
                return Response;
            }
        }

    }
}