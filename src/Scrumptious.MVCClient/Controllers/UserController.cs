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
    public class UserController : Controller
    {
        private readonly HttpClient http = new HttpClient();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var x = await http.GetAsync("http://localhost:62021/api/user/1");
            var content = JsonConvert.DeserializeObject<UserViewModel>(await x.Content.ReadAsStringAsync());
            ViewData["pagetitle"] = "List of Users";
            ViewBag.content = content;
            return View();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var x = await http.GetAsync("http://localhost:62021/api/user/" + id);
            var content = JsonConvert.DeserializeObject<UserViewModel>(await x.Content.ReadAsStringAsync());
            ViewData["pagetitle"] = "List of Users";
            ViewBag.content = content;
            return View();
        }

        [HttpPost]
        public void Post()
        {
            var pvm = new UserViewModel()
            {
                FirstName = "billy",
                LastName = "bob",
                Email = "billybob@revature.com",
                Role = "admin"
            };
            var content = JsonConvert.SerializeObject(pvm);
            http.PostAsync("http://localhost:62021/api/user", new StringContent(content, Encoding.UTF8, "application/json"));
        }

    }
}