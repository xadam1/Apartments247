using System.Linq;
using DAL;
using DAL.Extras;
using DAL.Models;
using WebMVC.Areas.Identity.Data;

namespace WebMVC.Utils
{
    public static class UserInfoManager
    {
        public static int UserId { get; private set; } = Constants.NO_ID;

        public static void SetUserIdByApplicationUser(ApplicationUser applicationUser)
        {
            var dbContext = new ApartmentsDbContext();

            //TODO Metoda z repa, pokud zustanou dve DB
            var user = dbContext.Users.FirstOrDefault(usr => usr.Username == applicationUser.UserName);
            if (user == null) // does not exist yet
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

        public static void SetUserIdByUsername(string username)
        {
            using (var dbContext = new ApartmentsDbContext())
            {
                var user = dbContext.Users.FirstOrDefault(usr => usr.Username == username);
                UserId = user.Id;
            }
        }
    }
}