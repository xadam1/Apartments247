using DAL;
using DAL.Models;
using System.Linq;
using WebAppMVC.Areas.Identity.Data;

namespace WebAppMVC.Utils
{
    public static class UserInfoManager
    {
        public static int UserId { get; private set; }

        public static void SetUserIdByApplicationUser(ApplicationUser applicationUser)
        {
            var dbContext = new ApartmentsDbContext();

            var user = dbContext.Users.Where(user => user.Username == applicationUser.UserName).FirstOrDefault();
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
