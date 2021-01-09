using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAPI.Extras;
using WebAPI.Models;

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
