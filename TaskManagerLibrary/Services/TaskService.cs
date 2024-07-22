using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaskManagerLibrary.Models;
using System.Collections.Generic;
namespace TaskManagerLibrary.Services;
public class TaskService
{
    private readonly HttpClient _httpClient;

    public TaskService()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7238/") };
    }

    public async Task<IEnumerable<TaskItem>> GetTasksAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<TaskItem>>("api/TaskItem");
    }

    public async Task<TaskItem> GetTaskByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<TaskItem>($"api/TaskItem/{id}");
    }

    public async Task CreateTaskAsync(TaskItem task)
    {
        var response = await _httpClient.PostAsJsonAsync("api/TaskItem", task);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateTaskAsync(TaskItem task)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/TaskItem/{task.Id}", task);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteTaskAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/TaskItem/{id}");
        response.EnsureSuccessStatusCode();
    }

}


