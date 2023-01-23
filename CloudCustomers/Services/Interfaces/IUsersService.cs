using CloudCustomers.Models;

namespace CloudCustomers.Services.Interfaces
{
    public interface IUsersService
    {
        public Task<List<User>> GetAllUsers();
    }
}
