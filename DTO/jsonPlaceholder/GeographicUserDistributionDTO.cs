
namespace CodingPractice.DTO;

public record GeographicUserDistributionDTO (
    string City,
    int CityUsers,
    List<string> CityCompanies
);