using BLL.DTOs;
using BLL.Facades;
using DAL.Extras;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Utils;

namespace WebMVC.Controllers
{
    public class CostsController : Controller
    {
        private readonly ICostFacade _costFacade;
        private readonly IUnitFacade _unitFacade;

        public CostsController(ICostFacade costFacade, IUnitFacade unitFacade)
        {
            this._costFacade = costFacade;
            this._unitFacade = unitFacade;
        }

        [HttpGet]
        public async Task<IActionResult> ShowCosts(int unitId, CostSort sortBy = CostSort.Date, bool isAscending = true)
        {
            if (!await CanUserVisitPage(unitId))
            {
                return RedirectToAction("AccessError", "Home");
            }

            // TODO filter by date - "Showing costs from x to y
            var fromDate = DateTime.MinValue;
            var toDate = DateTime.MaxValue;

            var costs = await _costFacade.GetCostsByUnitIdAsync<CostDTO>(unitId, fromDate, toDate);

            SortCosts(ref costs, sortBy, isAscending);

            var costWithUnitId = new CostsWithUnitIdDTO
            {
                CostsDTO = costs,
                UnitId = unitId
            };
            
            return View(costWithUnitId);
        }

        private void SortCosts(ref List<CostDTO> costs, CostSort sortBy = CostSort.Date, bool isAscending = true)
        {
            Func<CostDTO, object> sort;

            switch (sortBy)
            {
                case CostSort.Date:
                    sort = cost => cost.Date;
                    break;
                case CostSort.Name:
                    sort = cost => cost.Name;
                    break;
                case CostSort.Price:
                    sort = cost => cost.Price;
                    break;
                case CostSort.Type:
                    sort = cost => cost.CostType;
                    break;
                default:
                    return;
            }
            
            costs = (isAscending ? costs.OrderBy(sort) : costs.OrderByDescending(sort)).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCost(int unitId, string name, int price, CostType costType, DateTime date)
        {
            var costDTO = GetCostDTO(unitId, name, price, costType, date);

            await _costFacade.CreateCostAsync(costDTO);

            return RedirectToAction(nameof(ShowCosts), new { unitId });
        }

        [HttpGet]
        public async Task<IActionResult> CreateCost(int unitId)
        {
            if (!await CanUserVisitPage(unitId))
            {
                return RedirectToAction("AccessError", "Home");
            }

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
        public async Task<IActionResult> EditCost(int costId, int unitId, string name, int price, CostType costType, DateTime date)
        {
            if (!await CanUserVisitPage(unitId))
            {
                return RedirectToAction("AccessError", "Home");
            }

            var costWithCostTypesDTO = new CostWithCostTypesDTO
            {
                CostDTO = GetCostDTO(unitId, name, price, costType, date, costId),
                CostTypes = GetCostTypes()
            };

            return View(costWithCostTypesDTO);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCost(int costId, int unitId)
        {
            await _costFacade.DeleteCostAsync(costId);

            return RedirectToAction(nameof(ShowCosts), new { unitId });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCost(int costId, int unitId, string name, int price, CostType costType, DateTime date)
        {
            if (!await CanUserVisitPage(unitId))
            {
                return RedirectToAction("AccessError", "Home");
            }

            var costDTO = GetCostDTO(unitId, name, price, costType, date, costId);

            return View(costDTO);
        }

        private async Task<bool> CanUserVisitPage(int unitId)
        {
            var unit = await _unitFacade.GetUnitByIdAsync<UnitDTO>(unitId);
            return unit != null && UserInfoManager.CanUserAccessPage(unit.OwnerId);
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

        private CostDTO GetCostDTO(int unitId, string name, int price, CostType costType, DateTime date, int costId=0)
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
