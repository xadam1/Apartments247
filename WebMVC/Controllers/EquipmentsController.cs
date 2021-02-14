using BLL.DTOs;
using BLL.Facades;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Utils;

namespace WebMVC.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly IEquipmentFacade _equipmentFacade;
        private readonly IUnitFacade _unitFacade;

        public EquipmentsController(IEquipmentFacade equipmentFacade, IUnitFacade unitFacade)
        {
            this._equipmentFacade = equipmentFacade;
            this._unitFacade = unitFacade;
        }

        [HttpGet]
        public async Task<IActionResult> ShowEquipments(int unitId)
        {
            var unit = await _unitFacade.GetUnitByIdAsync<UnitDTO>(unitId);
            if (unit != null && !UserInfoManager.CanUserAccessPage(unit.OwnerId))
            {
                return RedirectToAction("AccessError", "Home");
            }

            ViewBag.UnitName = unit.Specification.Name;

            var equipments = await _equipmentFacade.GetEquipmentsByUnitIdAsync<EquipmentDTO>(unitId);

            var equipmentsWithUnitId = new EquipmentsWithUnitIdDTO
            {
                EquipmentsDTO = equipments,
                UnitId = unitId
            };

            return View(equipmentsWithUnitId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipment(int unitId, string type)
        {
            // TODO specify amount of items to be created
            var dbContext = new ApartmentsDbContext();
            var equipments = dbContext.Equipments.Where(equipment => equipment.Type == type).ToList();

            var equipmentDTO = new EquipmentDTO();
            if (equipments.Count == 0)
            {
                equipmentDTO.Type = type;
                equipmentDTO.UnitEquipments = new List<UnitEquipment>();

                await _equipmentFacade.CreateEquipmentAsync(equipmentDTO);

                equipments = dbContext.Equipments.Where(equipment => equipment.Type == type).ToList();
            }

            var equipment = equipments.First();
            equipmentDTO.Type = equipment.Type;
            equipmentDTO.UnitEquipments = equipment.UnitEquipments;
            equipmentDTO.Id = equipment.Id;

            var unitEquipment = new UnitEquipment
            {
                EquipmentId = equipment.Id,
                UnitId = unitId
            };

            equipmentDTO.UnitEquipments.Add(unitEquipment);

            await _equipmentFacade.UpdateEquipmentAsync(equipmentDTO);

            return RedirectToAction(nameof(ShowEquipments), new { unitId });
        }

        [HttpGet]
        public async Task<IActionResult> CreateEquipment(int unitId)
        {
            if (!await CanUserVisitPage(unitId))
            {
                return RedirectToAction("AccessError", "Home");
            }

            var equipmentWithUnitId = new EquipmentWithUnitIdDTO
            {
                EquipmentDTO = new EquipmentDTO(),
                UnitId = unitId
            };

            return View(equipmentWithUnitId);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEquipment(int equipmentId, int unitId)
        {
            var dbContext = new ApartmentsDbContext();
            var equipments = await _equipmentFacade.GetEquipmentsByUnitIdAsync<EquipmentDTO>(unitId);
            var equipment = equipments.Where(e => e.Id == equipmentId).FirstOrDefault();
            // TODO specify amount of items to be deleted
            equipment.UnitEquipments = new List<UnitEquipment>();
            var equipmentDTO = new EquipmentDTO
            {
                Id = equipment.Id,
                Type = equipment.Type,
                UnitEquipments = equipment.UnitEquipments
            };

            await _equipmentFacade.UpdateEquipmentAsync(equipmentDTO);

            await _equipmentFacade.DeleteEquipmentAsync(equipmentId);

            return RedirectToAction(nameof(ShowEquipments), new { unitId });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEquipment(int equipmentId, int unitId, string type)
        {
            if (!await CanUserVisitPage(unitId))
            {
                return RedirectToAction("AccessError", "Home");
            }

            var equipmentDTO = new EquipmentDTO
            {
                Id = equipmentId,
                Type = type
            };

            var equipmentWithUnit = new EquipmentWithUnitIdDTO
            {
                UnitId = unitId,
                EquipmentDTO = equipmentDTO
            };

            return View(equipmentWithUnit);
        }

        private async Task<bool> CanUserVisitPage(int unitId)
        {
            var unit = await _unitFacade.GetUnitByIdAsync<UnitDTO>(unitId);
            return unit != null && UserInfoManager.CanUserAccessPage(unit.OwnerId);
        }
    }
}
