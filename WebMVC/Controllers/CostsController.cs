using BLL.DTOs;
using BLL.Facades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    public class CostsController : Controller
    {
        private readonly ICostFacade _monthlyCostFacade;

        public CostsController(ICostFacade monthlyCostFacade)
        {
            this._monthlyCostFacade = monthlyCostFacade;
        }

        [HttpGet]
        public async Task<IActionResult> ShowCosts(int unitId)
        {
            // TODO filter by date
            var fromDate = DateTime.MinValue;
            var toDate = DateTime.MaxValue;

            var costs = await _monthlyCostFacade.GetCostsByUnitIdAsync<CostDTO>(unitId, fromDate, toDate);

            return View(costs);
        }
    }
}
