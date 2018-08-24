using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Scrumptious.MVCClient.Models;
using System.Threading;
using System.Text;
using System;

namespace Scrumptious.MVCClient.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    public class SprintController : Controller
    {
        private readonly HttpClient http = new HttpClient();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var x = await http.GetAsync("http://localhost:62021/api/sprint/1"); 
            var content = JsonConvert.DeserializeObject<SprintViewModel>(await x.Content.ReadAsStringAsync());
            ViewData["pagetitle"] = "List of Sprints";
            ViewBag.content = content;
            return View();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var x = await http.GetAsync("http://localhost:62021/api/sprint/" + id);
            var content = JsonConvert.DeserializeObject<SprintViewModel>(await x.Content.ReadAsStringAsync());
            ViewData["pagetitle"] = "List of Sprints";
            ViewBag.content = content;
            return View();
        }

        [HttpPost]
        public void Post()
        {
            var pvm = new SprintViewModel()
            {
                SprintName= "billy bob",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,                
                SprintDescription = "some desc",
            };
            var content = JsonConvert.SerializeObject(pvm);
            http.PostAsync("http://localhost:62021/api/sprint", new StringContent(content, Encoding.UTF8, "application/json"));
        }

    }
}