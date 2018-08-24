using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Scrumptious.MVCClient.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scrumptious.MVCClient.Controllers
{
    public class TaskController : Controller
    {
        private readonly HttpClient client = new HttpClient();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

       [HttpGet]
       public async Task<IActionResult> Get()
        { 
            {
                var x = await client.GetAsync("http://localhost:62020/api/task");
                var content = JsonConvert.DeserializeObject<ProjectViewModel>( await x.Content.ReadAsStringAsync());
                ViewData["Pagetitle"] = "list of Tasks";
                ViewBag.content = content;
                return View();
            }
        }
    }
}
