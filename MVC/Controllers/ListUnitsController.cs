using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;
using WebAPI.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class ListUnitsController : Controller
    {
        [HttpGet]
        public IActionResult ListUnits(int userId, int groupId=-1)
        {
            ListUnitsModel m = new ListUnitsModel()
            {
                UserId = userId
            };

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetUnitGroupNamesByUserId?userId={userId}").Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    m.Groups = JsonConvert.DeserializeObject<UnitGroupNameModel[]>(content);
                }

                if (groupId == -1 && m.Groups.Length > 0)
                {
                    groupId = m.Groups.First().Id;
                }
                m.UnitGroupId = groupId;

                using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetUnitsByUnitGroupId?groupId={groupId}").Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    m.Units = JsonConvert.DeserializeObject<UnitWithSpecificationModel[]>(content);
                }

                return View(m);
            }
        }
    }
}
