using CloudCustomers.Models;
using CloudCustomers.Services.Interfaces;
using System.Net;

namespace CloudCustomers.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _httpClient;
        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var userResponse = await _httpClient.GetAsync("https://exemple.com");
            if(userResponse.StatusCode == HttpStatusCode.NotFound) {

                return new List<User>();
            }
                
            var responseContent = userResponse.Content;
            var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
            return allUsers.ToList();
        }
    }
}
