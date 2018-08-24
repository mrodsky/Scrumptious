using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Scrumptious.MVCClient.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    { 
        public IActionResult Get()
        {
            ViewData["pagetitle"] = "Scrumptious";
            ViewBag.Title = "Scrumptious, the Scrum Master Program!";
            return View();
        }
    }
}