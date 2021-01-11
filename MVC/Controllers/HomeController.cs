using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int userId = 1; // TODO
            int groupId = -1;

            using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = client.GetAsync(Utils.apiUrl + $"GetFirstUnitGroupIdByUserId?userId={userId}").Result)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                groupId = JsonConvert.DeserializeObject<int>(content);
            }
            return RedirectToAction("Overview", "Overview", new { userId = userId, groupId = groupId });
        }
    }
}
