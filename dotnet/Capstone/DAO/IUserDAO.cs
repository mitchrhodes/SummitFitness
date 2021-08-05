using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IUserDAO
    {
        User GetUser(string username);
        List<User> GetUsers();
        User AddUser(string username, string password, string role, string email);

        bool ChangeUserPassword(UpdatedPasswordUser user);
        bool UpdateToAdmin(string username);
    }
}
