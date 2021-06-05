using NomadDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NomadDashboardAPI.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> GetAllUsers();

        User GetUserByUserName(string userName);

        User GetUserById(string id);

        User GetUserByEmail(string email);


    }
}
