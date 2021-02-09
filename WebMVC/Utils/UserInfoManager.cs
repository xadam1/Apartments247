using DAL;
using DAL.Models;
using System.Linq;
using WebMVC.Areas.Identity.Data;

namespace WebMVC.Utils
{
    public static class UserInfoManager
    {
        public static int UserId { get; private set; }

        public static void SetUserIdByApplicationUser(ApplicationUser applicationUser)
        {
            var dbContext = new ApartmentsDbContext();

            //TODO Metoda z repa, pokud zustanou dve DB
            var user = dbContext.Users.FirstOrDefault(usr => usr.Username == applicationUser.UserName);
            if (user == null)   // does not exist yet
            {
                user = new User
                {
                    Username = applicationUser.UserName,
                    Email = applicationUser.Email,
                    IsAdmin = false,
                    Password = "Unknown"
                };

                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }

            UserId = user.Id;
        }
    }
}
