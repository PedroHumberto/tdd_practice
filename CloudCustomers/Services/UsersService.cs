using CloudCustomers.Models;
using CloudCustomers.Services.Interfaces;

namespace CloudCustomers.Services
{
    public class UsersService : IUsersService
    {
        public UsersService()
        {

        }

        public Task<List<Users>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
