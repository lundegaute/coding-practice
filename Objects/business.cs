
namespace CodingPractice.Objects.Business;

public class Company
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Section> Sections { get; set; } = new List<Section>();
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
public class Section
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CompanyId { get; set; }
    public required Company Company { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
public class Employee
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }

    public int CompanyId { get; set; }
    public required Company Company { get; set; }

    public int? SectionId { get; set; }
    public Section? Section { get; set; }
}


