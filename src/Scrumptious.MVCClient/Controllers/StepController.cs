using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Scrumptious.MVCClient.Models;
using System.Threading;
using System.Text;

namespace Scrumptious.MVCClient.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    public class StepController : Controller
    {
        private readonly HttpClient http = new HttpClient();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var x = await http.GetAsync("http://localhost:62021/api/step/1");
            var content = JsonConvert.DeserializeObject<StepViewModel>(await x.Content.ReadAsStringAsync());
            ViewData["pagetitle"] = "List of Steps";
            ViewBag.content = content;
            return View();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var x = await http.GetAsync("http://localhost:62021/api/step/" + id);
            var content = JsonConvert.DeserializeObject<StepViewModel>(await x.Content.ReadAsStringAsync());
            ViewData["pagetitle"] = "List of Steps";
            ViewBag.content = content;
            return View();
        }

        [HttpPost]
        public void Post()
        {
            var pvm = new StepViewModel()
            {
                Name = "step 1",
                StepDescription = "get the thing to work"
            };
            var content = JsonConvert.SerializeObject(pvm);
            http.PostAsync("http://localhost:62021/api/step", new StringContent(content, Encoding.UTF8, "application/json"));
        }

    }
}