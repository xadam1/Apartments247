using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using WebAPI.Extras;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SigmaController : Controller
    {
        private readonly ApartmentsDbContext con;

        public SigmaController()
        {
            con = new ApartmentsDbContext();
        }

        [HttpGet]
        [Route("GetUnitGroupsByUserId")]
        public UnitGroupWithSpecificationModel[] Get(int userId)
        {
            UnitGroup[] groups = con.UnitGroups.Where(group => group.Id == userId).ToArray();
            return groups.Select(group => Utils.Convert(group)).ToArray();
        }
    }
}
