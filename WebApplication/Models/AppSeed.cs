using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class AppSeed
    {
        private ApplicationContext _context;

        public AppSeed(ApplicationContext context)
        {
            _context = context;
        }

        public async Task SeedData()
        {
            if (!_context.Users.Any())
            {
                var user = new User()
                {
                    UserName = "Archeo",
                    FirstName = "Sto",
                    LastName = "Kos",
                    Email = "stokos@gmail.com",
                    PasswordSalt = "sadfsadf",
                    PaswordHash = "asdfsdfsadf",
                    lastLogin = DateTime.UtcNow,
                    Balance = 2000,
                    Socks = 20
                };

                _context.Users.Add(user);

                await _context.SaveChangesAsync();
            }
        }
    }
}
