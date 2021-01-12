using DAL.Models;
using Newtonsoft.Json;
using System.Net.Http;
using WebAPI.Models;
// To delete
using DAL;
using System.Linq;

namespace WebAppMVC.Utils
{
    public static class Utils
    {
        public static int GetFirstUnitGroupIdByUserId(int userId)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.GetAsync(ApiConnectionUrls.API_URL + $"GetFirstUnitGroupIdByUserId?userId={userId}").Result)
            {
                if (!response.IsSuccessStatusCode)
                {
                    return -1;
                }

                string content = response.Content.ReadAsStringAsync().Result;
                int groupId = JsonConvert.DeserializeObject<int>(content);
                return groupId;
            }
        }

        public static UnitGroupWithSpecificationModel[] GetUnitGroupsByUserId(int userId)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respond = client.GetAsync(ApiConnectionUrls.API_URL + $"GetUnitGroupsByUserId?userId={userId}").Result)
            {
                string content = respond.Content.ReadAsStringAsync().Result;
                UnitGroupWithSpecificationModel[] groups = JsonConvert.DeserializeObject<UnitGroupWithSpecificationModel[]>(content);
                return groups;
            }
        }

        public static UnitGroupNameModel[] GetUnitGroupNamesByUserId(int userId)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respond = client.GetAsync(ApiConnectionUrls.API_URL + $"GetUnitGroupNamesByUserId?userId={userId}").Result)
            {
                string content = respond.Content.ReadAsStringAsync().Result;
                UnitGroupNameModel[] unitGroupNames = JsonConvert.DeserializeObject<UnitGroupNameModel[]>(content);
                return unitGroupNames;
            }
        }

        public static UnitWithSpecificationModel[] GetUnitsByUnitGroupId(int groupId)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respond = client.GetAsync(ApiConnectionUrls.API_URL + $"GetUnitsByUnitGroupId?groupId={groupId}").Result)
            {
                string content = respond.Content.ReadAsStringAsync().Result;
                UnitWithSpecificationModel[] units = JsonConvert.DeserializeObject<UnitWithSpecificationModel[]>(content);
                return units;
            }
        }

        public static UnitGroupWithSpecificationModel GetUnitGroupById(int groupId)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respond = client.GetAsync(ApiConnectionUrls.API_URL + $"GetUnitGroupById?groupId={groupId}").Result)
            {
                string content = respond.Content.ReadAsStringAsync().Result;
                UnitGroupWithSpecificationModel group = JsonConvert.DeserializeObject<UnitGroupWithSpecificationModel>(content);
                return group;
            }
        }

        public static Color[] GetColors()
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respond = client.GetAsync(ApiConnectionUrls.API_URL + $"GetColors").Result)
            {
                string content = respond.Content.ReadAsStringAsync().Result;
                Color[] colors = JsonConvert.DeserializeObject<Color[]>(content);
                return colors;
            }
        }

        public static UnitWithSpecificationModel GetUnitById(int unitId)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respond = client.GetAsync(ApiConnectionUrls.API_URL + $"GetUnitById?unitId={unitId}").Result)
            {
                string content = respond.Content.ReadAsStringAsync().Result;
                UnitWithSpecificationModel unit = JsonConvert.DeserializeObject<UnitWithSpecificationModel>(content);
                return unit;
            }
        }

        public static UnitTypeModel[] GetUnitTypes()
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respond = client.GetAsync(ApiConnectionUrls.API_URL + $"GetUnitTypes").Result)
            {
                string content = respond.Content.ReadAsStringAsync().Result;
                UnitTypeModel[] unitTypes = JsonConvert.DeserializeObject<UnitTypeModel[]>(content);
                return unitTypes;
            }
        }

        public static int GetUnitGroupCount(int userId)
        {
            ApartmentsDbContext con = new ApartmentsDbContext();
            return con.UnitGroups.Where(unitGroup => unitGroup.UserId == userId).Count();
        }

        public static int GetUnitCount(int userId)
        {
            ApartmentsDbContext con = new ApartmentsDbContext();
            return con.Units.Where(unit => unit.UnitGroup.UserId == userId).Count();
        }
    }
}
