using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class CostsController : Controller
    {
        public IActionResult Costs()
        {
            CostsModel m = new CostsModel()
            {

            };
            return View(m);
        }
    }
}
