using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Scrumptious.MvcClient.Models;
using System.Threading;

namespace Scrumptious.MVCClient.Controllers
{
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private readonly HttpClient http = new HttpClient();

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var x = await http.GetAsync("http://localhost:62021/api/project/6");
            var content = JsonConvert.DeserializeObject<ProjectViewModel>(await x.Content.ReadAsStringAsync());

            ViewBag.content = content;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
    }
}