using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scrumptious.Data.Models;



namespace Scrumptious.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly scrumptiousdbContext sdb = new scrumptiousdbContext();
        private readonly User user = new User();

        [HttpGet]
        public string Get()
        {
            return user.FirstName + user.LastName + user.Email + user.Role;
        }

    }
}