using Microsoft.AspNetCore.Mvc;
using RandomUserAPI.Entities;
using System.Net.Http;
using System.Numerics;
using System.Text.Json;

namespace RandomUserAPI.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

       
        public async Task<UserDTO> GetRandomUserAsync()
        {
            var response = await _httpClient.GetAsync("https://randomuser.me/api/");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            UserResult? userResult = JsonSerializer.Deserialize<UserResult>(json);

            User? randomUser = userResult?.results[0];

            return new UserDTO
            {
                FirstName = randomUser.name.first,
                LastName = randomUser.name.last,
                email = randomUser.email,
                phone = randomUser.phone,
                // Add other properties as needed
            };
        }
       

    }
}
