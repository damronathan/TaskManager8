using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaskManagerLibrary.Models;
using System.Collections.Generic;
namespace TaskManagerLibrary.Services;
public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7238/") };
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<User>>("api/User");
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<User>($"api/User/{id}");
    }

    public async Task CreateUserAsync(User user)
    {
        var response = await _httpClient.PostAsJsonAsync("api/User", user);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateUserAsync(User user)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/User/{user.UserId}", user);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteUserAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/User/{id}");
        response.EnsureSuccessStatusCode();
    }

}
