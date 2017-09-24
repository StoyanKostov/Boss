using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public interface IAppRepository
    {
        Task<bool> SaveChangesAsync();
        void UserAdd(User user);
    }
}