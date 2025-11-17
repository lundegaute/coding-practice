using System.Text.Json;
using CodingPractice.Models;

namespace CodingPractice.Services;

public class JsonPlaceholderService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://jsonplaceholder.typicode.com";
    public JsonPlaceholderService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<User>> GetUsersAsync()
    {
        var response = await _httpClient.GetStringAsync($"{BaseUrl}/users");
        return JsonSerializer.Deserialize<List<User>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        }) ?? new List<User>();
    }
    public async Task<List<Post>> GetPostsAsync()
    {
        var response = await _httpClient.GetStringAsync($"{BaseUrl}/posts");
        return JsonSerializer.Deserialize<List<Post>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new List<Post>();
    }
    public async Task<List<Comment>> GetCommentsAsync()
    {
        var response = await _httpClient.GetStringAsync($"{BaseUrl}/comments");
        return JsonSerializer.Deserialize<List<Comment>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new List<Comment>();
    }
    public async Task<List<Album>> GetAlbumsAsync()
    {
        var response = await _httpClient.GetStringAsync($"{BaseUrl}/albums");
        return JsonSerializer.Deserialize<List<Album>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new List<Album>();
    }
    public async Task<List<Todo>> GetTodosAsync()
    {
        var response = await _httpClient.GetStringAsync($"{BaseUrl}/todos");
        return JsonSerializer.Deserialize<List<Todo>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new List<Todo>();
    }
    
}