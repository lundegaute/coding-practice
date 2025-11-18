using CodingPractice.Services;
using CodingPractice.Models;
using CodingPractice.DTO;

namespace CodingPractice.Api;

public class PlaceholderLinqExamples
{
    private readonly JsonPlaceholderService _jsonPlaceholderService;

    public PlaceholderLinqExamples()
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
        var userDict = userData.ToDictionary(user => user.Id);
        var usersWithMoreThan8Posts = postData
                        .GroupBy(post => post.UserId)
                        .Where(group => group.Count() > 8)
                        .Select(user => new
                        {
                            UserId = user.Key,
                            PostCount = user.Count(),
                            User = userDict[user.Key]
                        })
                        .OrderByDescending(user => user.PostCount)
                        .ToList(); // Calling to list to snapshot the data.

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("--------------------");
        foreach (var user in usersWithMoreThan8Posts)
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

        foreach (var city in groupedByCity)
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

    public async Task ContentEngagementReport()
    {
        var userData = await _jsonPlaceholderService.GetUsersAsync();
        var postData = await _jsonPlaceholderService.GetPostsAsync();
        var todoData = await _jsonPlaceholderService.GetTodosAsync();
        var albumData = await _jsonPlaceholderService.GetAlbumsAsync();

        var groupByPostUserId = postData.GroupBy(post => post.UserId);
        var groupByAlbumUserId = albumData.GroupBy(album => album.UserId);
        var groupByTodoUserId = todoData.GroupBy(todo => todo.UserId);

        var userScore = userData
            .GroupBy(user => user.Id)
            .Select(userGroup => new
            {
                User = userGroup.FirstOrDefault(), // There should only be one user per id
                EngagementScore = groupByPostUserId
                    .First(postGroup => postGroup.Key == userGroup.Key)
                    .Count() * 2
                    + groupByAlbumUserId
                    .First(albumGroup => albumGroup.Key == userGroup.Key)
                    .Count()
                    + groupByTodoUserId
                    .First(todoGroup => todoGroup.Key == userGroup.Key)
                    .Where(todo => todo.Completed)
                    .Count()
            }).ToList();

        foreach (var user in userScore)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"User: {user.User?.Name ?? "No User"}, Engagement Score: {user.EngagementScore}");
        }
    }

    public async Task TopContentCreators()
    {
        var userData = await _jsonPlaceholderService.GetUsersAsync();
        var postData = await _jsonPlaceholderService.GetPostsAsync();
        var commentData = await _jsonPlaceholderService.GetCommentsAsync();

        // All users by Id
        var userDict = userData.ToDictionary(user => user.Id, user => user);

        // All posts for each user
        var postsByUserId = postData
            .GroupBy(post => post.UserId)
            .ToDictionary(group => group.Key, group => group.ToList());

        // All comments for each post
        var commentsByPostId = commentData
            .GroupBy(comment => comment.PostId)
            .ToDictionary(group => group.Key, group => group.ToList());

        var contentCreators = userData
            .GroupBy(user => user.Id)
            .Select(group => new
            {
                User = userDict[group.Key],
                Posts = postsByUserId[group.Key],
                PostsWithComments = postsByUserId[group.Key]
                    .ToDictionary(post => post.Id, post => commentsByPostId[post.Id].ToList())
            })
            .ToList();

        foreach (var creator in contentCreators)
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Creator Name: {creator.User.Name}, Posts: {creator.Posts.Count}");
            foreach (var post in creator.PostsWithComments)
            {
                Console.WriteLine($"PostId: {post.Key}, Nr of comments: {post.Value.Count}");
            }

        }
    }

}