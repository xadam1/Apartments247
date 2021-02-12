﻿using BLL.DTOs;
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
            var costDTO = GetCostDTO(unitId, name, price, costType, date);

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

        [HttpPost]
        public async Task<IActionResult> EditCostInternal(int costId, int unitId, string name, int price, CostType costType, DateTime date)
        {
            var costDTO = GetCostDTO(unitId, name, price, costType, date, costId);

            await _costFacade.UpdateCostAsync(costId, costDTO);

            return RedirectToAction(nameof(ShowCosts), new { unitId });
        }

        [HttpGet]
        public IActionResult EditCost(int costId, int unitId, string name, int price, CostType costType, DateTime date)
        {
            var costWithCostTypesDTO = new CostWithCostTypesDTO
            {
                CostDTO = GetCostDTO(unitId, name, price, costType, date, costId),
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
            var costDTO = GetCostDTO(unitId, name, price, costType, date, costId);

            return View(costDTO);
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

        private CostDTO GetCostDTO(int unitId, string name, int price, CostType costType, DateTime date, int costId=-1)
        {
            return new CostDTO
            {
                Id = costId,
                UnitId = unitId,
                Price = price,
                CostType = costType,
                Date = date,
                Name = name,
            };
        }
    }
}
