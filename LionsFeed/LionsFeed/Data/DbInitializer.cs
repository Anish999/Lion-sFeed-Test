using CryptoHelper;
using LionsFeed.Models;
using System.Linq;

namespace LionsFeed.Data
{
    public class DbInitializer
    {
        public static void SeedData(LionsContext _context)
        {
            _context.Database.EnsureCreated();

            if (_context.Users.Any())
            {
                return;
            }

            var Users = new ApplicationUser[]
            {
                new ApplicationUser
                {
                    FirstName="Nishma",
                    LastName="Maskey",
                    Email = "admin@domain.com",
                    Password = Crypto.HashPassword("password"),
                    Role = "Admin",
                    Gender="Female",
                    ImageUrl="~/upload/img/default.png"
                },
                new ApplicationUser
                {
                    FirstName="Saugat",
                    LastName="Thapa",
                    Email = "user@domain.com",
                    Password = Crypto.HashPassword("password"),
                    Role = "User",
                    Gender="Male",
                    ImageUrl="~/upload/img/default.png"

                }
            };
            foreach (ApplicationUser u in Users)
            {
                _context.Users.Add(u);

            }
            _context.SaveChanges();

        }
    }
}
