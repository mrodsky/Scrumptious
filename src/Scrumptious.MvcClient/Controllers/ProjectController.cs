using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Scrumptious.MvcClient.Models;
using System.Threading;
using System.Text;

namespace Scrumptious.MVCClient.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    public class ProjectController : Controller
    {
        private readonly HttpClient http = new HttpClient();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var x = await http.GetAsync("http://localhost:62021/api/project/6");
            var content = JsonConvert.DeserializeObject<ProjectViewModel>(await x.Content.ReadAsStringAsync());

            ViewBag.content = content;
            return View();
        }

        [HttpPost]
        public void Post()
        {
            var pvm = new ProjectViewModel() { projectName = "billy bob", active = false, projectDescription = "some desc",
            projectRequirements = "something works"} ;
            var content = JsonConvert.SerializeObject(pvm);
            http.PostAsync("http://localhost:62021/api/project", new StringContent(content, Encoding.UTF8, "application/json"));
        }

    }
}