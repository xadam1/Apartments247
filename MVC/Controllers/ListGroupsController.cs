using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using WebAPI.Models;
using Newtonsoft.Json;
using MVC.Models;

namespace MVC.Controllers
{
    public class ListGroupsController : Controller
    {
        [HttpGet]
        public IActionResult ListGroups(int userId, int groupId)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetUnitGroupsByUserId?userId={userId}").Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    UnitGroupWithSpecificationModel[] groups = JsonConvert.DeserializeObject<UnitGroupWithSpecificationModel[]>(content);
                    ListGroupsModel m = new ListGroupsModel()
                    {
                        UserId = userId,
                        GroupId = groupId,
                        Groups = groups,
                    };
                    return View(m);
                }
            }
        }
    }
}
