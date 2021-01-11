using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using MVC.Models;
using DAL.Extras;
using System.Net.Http;
using Newtonsoft.Json;
using WebAPI.Models;

namespace MVC.Controllers
{
    public class OverviewController : Controller
    {
        [HttpGet]
        public IActionResult Overview(int userId)
        {
            OverviewModel m = new OverviewModel()
            {
                UserId = userId
            };
            return View(m);
        }
    }
}
