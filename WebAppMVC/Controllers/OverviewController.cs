using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models;
using WebAppMVC.Utils;

namespace WebAppMVC.Controllers
{
    public class OverviewController : Controller
    {
        [HttpGet]
        public IActionResult Overview()
        {
            OverviewModel m = new OverviewModel()
            {
                UnitGroupCount = Utils.Utils.GetUnitGroupCount(0), // TODO
                UnitCount = Utils.Utils.GetUnitCount(0), // TODO
            };
            return View(m);
        }
    }
}
