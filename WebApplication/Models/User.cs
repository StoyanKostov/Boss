using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        // Unique constraint here
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime lastLogin { get; set; }
        public string PaswordHash { get; set; }
        public string PasswordSalt { get; set; }
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }
        public int Socks { get; set; }
    }
}
