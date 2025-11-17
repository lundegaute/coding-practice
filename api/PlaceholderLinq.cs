using CodingPractice.Services;
using CodingPractice.Models;
using CodingPractice.DTO;

namespace CodingPractice.Api;

public class PlaceholderLinqExamples
{
    private readonly JsonPlaceholderService _jsonPlaceholderService;

    public PlaceholderLinqExamples( )
    {
        _jsonPlaceholderService = new JsonPlaceholderService();
    }
    public async Task<List<User>> ShowUsers()
    {
        var users = await _jsonPlaceholderService.GetUsersAsync();
        return users;
    }
    public async Task PostAnalysis()
    {
        var userData = await _jsonPlaceholderService.GetUsersAsync();
        var postData = await _jsonPlaceholderService.GetPostsAsync();
        var usersWithMoreThan8Posts = postData
                        .GroupBy(post => post.UserId)
                        .Where(group => group.Count() > 8)
                        .Select(users =>  new
                        {
                            UserId = users.Key,
                            PostCount = users.Count(),
                            User = userData.FirstOrDefault(user => user.Id == users.Key)
                        })
                        .OrderByDescending(users => users.PostCount)
                        .ToList(); // Calling to list to snapshot the data.

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("--------------------");
        foreach(var user in usersWithMoreThan8Posts)
        {
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Name: {user.User?.Name}, Email: {user.User?.Email}, Company: {user.User?.Company?.Name}, PostCount: {user.PostCount}");
        }
    }

    public async Task GeographicUserDistribution()
    {
        var userData = await _jsonPlaceholderService.GetUsersAsync();
        var groupedByCity = userData
                    .GroupBy(user => user.Address.City)
                    .Where(city => city.Count() >= 1) // This does nothing now, but since no city have more than 1 user, i need >= to display data.
                    .Select(cityGroup => new GeographicUserDistributionDTO
                    (
                        City: cityGroup.Key,
                        CityUsers: cityGroup.Count(),
                        CityCompanies: cityGroup.Select(cityUser => cityUser.Company.Name).Distinct().ToList() // Preventing duplicate company names
                    )).ToList();

        foreach(var city in groupedByCity)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"City: {city.City}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Count: {city.CityUsers}");
            Console.Write("Companies: ");
            Console.WriteLine(string.Join(", ", city.CityCompanies));
            Console.WriteLine("-----------------");
        }
    }
}