using BLL.DTOs;
using BLL.Facades;
using DAL.Extras;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    public class CostsController : Controller
    {
        private readonly ICostFacade _costFacade;

        public CostsController(ICostFacade costFacade)
        {
            this._costFacade = costFacade;
        }

        [HttpGet]
        public async Task<IActionResult> ShowCosts(int unitId)
        {
            // TODO filter by date
            var fromDate = DateTime.MinValue;
            var toDate = DateTime.MaxValue;

            var costs = await _costFacade.GetCostsByUnitIdAsync<CostDTO>(unitId, fromDate, toDate);

            var costWithUnitId = new CostsWithUnitIdDTO
            {
                CostsDTO = costs,
                UnitId = unitId
            };

            return View(costWithUnitId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCost(int unitId, string name, int price, CostType costType, DateTime date)
        {
            var costDTO = new CostDTO
            {
                UnitId = unitId,
                Name = name,
                Price = price,
                CostType = costType,
                Date = date,
            };

            await _costFacade.CreateCostAsync(costDTO);

            return RedirectToAction(nameof(ShowCosts), new { unitId });
        }

        [HttpGet]
        public IActionResult CreateCost(int unitId)
        {
            var costWithCostTypesDTO = new CostWithCostTypesDTO
            {
                CostDTO = new CostDTO { UnitId = unitId },
                CostTypes = GetCostTypes(),
            };

            return View(costWithCostTypesDTO);
        }

        private List<SelectListItem> GetCostTypes()
        {
            var costTypes = new List<SelectListItem>();

            foreach (var costType in Enum.GetValues(typeof(CostType)))
            {
                var costTypeStr = costType.ToString();
                costTypes.Add(new SelectListItem
                {
                    Value = costTypeStr,
                    Text = costTypeStr
                });
            }

            return costTypes;
        }

        [HttpPost]
        public async Task<IActionResult> EditCost(int unitId, string name, int price, CostType costType, DateTime date)
        {
            /*var costDTO = new CostDTO();

            await _costFacade.UpdateCostAsync(id, costDTO);*/

            return RedirectToAction(nameof(ShowCosts), new { unitId });
        }

        [HttpGet]
        public IActionResult EditCost(int costId)
        {
            // get cost
            var cost = new CostDTO
            {
                UnitId = 3,
                Price = 9,
                CostType = DAL.Extras.CostType.Income,
                Date = DateTime.Now,
                Name = "caluj somar",
            };

            var costWithCostTypesDTO = new CostWithCostTypesDTO
            {
                CostDTO = cost,
                CostTypes = GetCostTypes()
            };

            return View(costWithCostTypesDTO);
        }

        [HttpPost]
        public IActionResult DeleteCost(int costId, int unitId)
        {
            // TODO delete
            return RedirectToAction(nameof(ShowCosts), new { unitId });
        }

        [HttpGet]
        public IActionResult DeleteCost(int costId, int unitId, string name, int price, CostType costType, DateTime date)
        {
            var costDTO = new CostDTO
            {
                Id = costId,
                Name = name,
                Price = price,
                CostType = costType,
                Date = date,
                UnitId = unitId
            };

            return View(costDTO);
        }
    }
}
