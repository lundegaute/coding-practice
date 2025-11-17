
namespace CodingPractice.Models;

public record User(
    int Id,
    string Name,
    string Username,
    string Email,
    Address Address,
    string Phone,
    string Website,
    Company Company
);

public record Address(
    string Street,
    string Suite,
    string City,
    string Zipcode,
    Geo Geo
);

public record Geo(string Lat, string Lng);

public record Company(string Name, string CatchPhrase, string Bs);

public record Post(int UserId, int Id, string Title, string Body);

public record Comment(int PostId, int Id, string Name, string Email, string Body);

public record Album(int UserId, int Id, string Title);

public record Photo(int AlbumId, int Id, string Title, string Url, string ThumbnailUrl);

public record Todo(int UserId, int Id, string Title, bool Completed);