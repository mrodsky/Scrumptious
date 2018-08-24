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
            var x = await http.GetAsync("http://localhost:62021/api/project/1");
            var content = JsonConvert.DeserializeObject<ProjectViewModel>(await x.Content.ReadAsStringAsync());
            ViewData["pagetitle"] = "Scrumptious";
            ViewBag.Title = "Scrumptious, the Scrum Master Program!";
            ViewBag.content = content;
            return View();
        }

        [HttpGet("{sort}")]
        public IActionResult Get(string id)
        {
            ViewData["pagetitle"] = "Scrumptious";
            ViewBag.Title = "Scrumptious, the Scrum Master Program!";
            string s = Request.Query["ID"];
            return Redirect("/project/" + s);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var x = await http.GetAsync("http://localhost:62021/api/project/" + id);
            var content = JsonConvert.DeserializeObject<ProjectViewModel>(await x.Content.ReadAsStringAsync());
            ViewData["pagetitle"] = "Scrumptious";
            ViewBag.Title = "Scrumptious, the Scrum Master Program!";
            ViewBag.content = content;
            return View();
        }

        [HttpPost]
        public IActionResult Post(ProjectViewModel data)
        {
            data.active = false;
            data.sprint = null;
            var content = JsonConvert.SerializeObject(data);
            http.PostAsync("http://localhost:62021/api/project", new StringContent(content, Encoding.UTF8, "application/json"));
            return Redirect("/project");
        }

    }
}