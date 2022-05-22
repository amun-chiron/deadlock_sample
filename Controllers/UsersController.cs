
using Newtonsoft.Json;
using SampleWebApp.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SampleWebApp.Controllers
{
    public class UsersController : Controller
    {
        private const int MaxDelaySeconds = 3;
        // GET: Users
        public ActionResult Index()
        {
            // DEADLOCK
            var users = GetUsers().Result;

            // NO-DEADLOCK
            //var users = Task.Run(GetUsers).Result;
            return PartialView("~/Views/Shared/_Users.cshtml", users.Data);
        }

        /*
         ***** NO-DEADLOCK
         */

        //public async Task<ActionResult> Index()
        //{
        //    var users = await GetUsers();
        //    return PartialView("~/Views/Shared/_Users.cshtml", users.Data);
        //}

        private async Task<UserResponse> GetUsers()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://reqres.in/api/users?delay={MaxDelaySeconds}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserResponse>(responseBody);
            }
        }
    }
}