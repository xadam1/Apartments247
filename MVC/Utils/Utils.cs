using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using WebAPI.Models;
using DAL.Models;

namespace MVC.Controllers
{
    public static class Utils
    {
        //public const string apiUrl = "https://localhost:44306/Sigma/";
        public const string apiUrl = "http://cassiopeia.serveirc.com:5000/Sigma/";

        public static int GetFirstUnitGroupIdByUserId(int userId)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.GetAsync(Utils.apiUrl + $"GetFirstUnitGroupIdByUserId?userId={userId}").Result)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                int groupId = JsonConvert.DeserializeObject<int>(content);
                return groupId;
            }
        }

        public static UnitGroupWithSpecificationModel[] GetUnitGroupsByUserId(int userId)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetUnitGroupsByUserId?userId={userId}").Result)
            {
                string content = respond.Content.ReadAsStringAsync().Result;
                UnitGroupWithSpecificationModel[] groups = JsonConvert.DeserializeObject<UnitGroupWithSpecificationModel[]>(content);
                return groups;
            }
        }

        public static UnitGroupNameModel[] GetUnitGroupNamesByUserId(int userId)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetUnitGroupNamesByUserId?userId={userId}").Result)
            {
                string content = respond.Content.ReadAsStringAsync().Result;
                UnitGroupNameModel[] unitGroupNames = JsonConvert.DeserializeObject<UnitGroupNameModel[]>(content);
                return unitGroupNames;
            }
        }

        public static UnitWithSpecificationModel[] GetUnitsByUnitGroupId(int groupId)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetUnitsByUnitGroupId?groupId={groupId}").Result)
            {
                string content = respond.Content.ReadAsStringAsync().Result;
                UnitWithSpecificationModel[] units = JsonConvert.DeserializeObject<UnitWithSpecificationModel[]>(content);
                return units;
            }
        }

        public static UnitGroupWithSpecificationModel GetUnitGroupById(int groupId)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetUnitGroupById?groupId={groupId}").Result)
            {
                string content = respond.Content.ReadAsStringAsync().Result;
                UnitGroupWithSpecificationModel group = JsonConvert.DeserializeObject<UnitGroupWithSpecificationModel>(content);
                return group;
            }
        }

        public static Color[] GetColors()
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetColors").Result)
            {
                string content = respond.Content.ReadAsStringAsync().Result;
                Color[] colors = JsonConvert.DeserializeObject<Color[]>(content);
                return colors;
            }
        }

        public static UnitWithSpecificationModel GetUnitById(int unitId)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetUnitById?unitId={unitId}").Result)
            {
                string content = respond.Content.ReadAsStringAsync().Result;
                UnitWithSpecificationModel unit = JsonConvert.DeserializeObject<UnitWithSpecificationModel>(content);
                return unit;
            }
        }

        public static UnitTypeModel[] GetUnitTypes()
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetUnitTypes").Result)
            {
                string content = respond.Content.ReadAsStringAsync().Result;
                UnitTypeModel[] unitTypes = JsonConvert.DeserializeObject<UnitTypeModel[]>(content);
                return unitTypes;
            }
        }
    }
}
