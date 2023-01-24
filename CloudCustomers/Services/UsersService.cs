using CloudCustomers.Config;
using CloudCustomers.Models;
using CloudCustomers.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;

namespace CloudCustomers.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _httpClient;
        private readonly UsersApiOptions _apiConfig;

        public UsersService(HttpClient httpClient, IOptions<UsersApiOptions> apiConfig)
        {
            _httpClient = httpClient;
            _apiConfig = apiConfig.Value;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var userResponse = await _httpClient.GetAsync(_apiConfig.Endpoint);
            if(userResponse.StatusCode == HttpStatusCode.NotFound) {

                return new List<User>();
            }
                
            var responseContent = userResponse.Content;
            var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
            return allUsers.ToList();
        }
    }
}
