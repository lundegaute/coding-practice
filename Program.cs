using CodingPractice.Algorithms;
using CodingPractice.Kata6;
using CodingPractice.Objects.Business;

var kata6 = new Kata6();
var kata7 = new Kata7();

// Create 5 Companies
List<Company> companies = new List<Company>
{
    new Company { Id = 1, Name = "TechCorp" },
    new Company { Id = 2, Name = "InnovaSoft" },
    new Company { Id = 3, Name = "DataDyne" },
    new Company { Id = 4, Name = "CloudWorks" },
    new Company { Id = 5, Name = "CyberSolutions" }
};

// Create 5 Sections across multiple companies (more realistic)
List<Section> sections = new List<Section>
{
    // TechCorp sections
    new Section { Id = 1, Name = "Engineering", CompanyId = 1, Company = companies[0] },
    new Section { Id = 2, Name = "Sales", CompanyId = 1, Company = companies[0] },
    
    // InnovaSoft sections  
    new Section { Id = 3, Name = "Engineering", CompanyId = 2, Company = companies[1] },
    new Section { Id = 4, Name = "Marketing", CompanyId = 2, Company = companies[1] },
    
    // DataDyne sections
    new Section { Id = 5, Name = "HR", CompanyId = 3, Company = companies[2] },
    new Section { Id = 6, Name = "Finance", CompanyId = 3, Company = companies[2] },
    
    // CloudWorks sections
    new Section { Id = 7, Name = "Engineering", CompanyId = 4, Company = companies[3] },
    new Section { Id = 8, Name = "Sales", CompanyId = 4, Company = companies[3] },
    
    // CyberSolutions sections
    new Section { Id = 9, Name = "Marketing", CompanyId = 5, Company = companies[4] },
    new Section { Id = 10, Name = "Finance", CompanyId = 5, Company = companies[4] }
};

// Create 15 Employees distributed across different sections within companies
List<Employee> employees = new List<Employee>
{
    // TechCorp employees (3) - Engineering & Sales
    new Employee { Id = 1, Name = "Alice Johnson", Age = 28, CompanyId = 1, Company = companies[0], SectionId = 1, Section = sections[0] }, // Engineering
    new Employee { Id = 2, Name = "Bob Smith", Age = 32, CompanyId = 1, Company = companies[0], SectionId = 1, Section = sections[0] }, // Engineering
    new Employee { Id = 3, Name = "Carol Davis", Age = 26, CompanyId = 1, Company = companies[0], SectionId = 2, Section = sections[1] }, // Sales
    
    // InnovaSoft employees (3) - Engineering & Marketing
    new Employee { Id = 4, Name = "David Wilson", Age = 35, CompanyId = 2, Company = companies[1], SectionId = 3, Section = sections[2] }, // Engineering
    new Employee { Id = 5, Name = "Emma Brown", Age = 29, CompanyId = 2, Company = companies[1], SectionId = 4, Section = sections[3] }, // Marketing
    new Employee { Id = 6, Name = "Frank Miller", Age = 31, CompanyId = 2, Company = companies[1], SectionId = 4, Section = sections[3] }, // Marketing
    
    // DataDyne employees (3) - HR & Finance  
    new Employee { Id = 7, Name = "Grace Lee", Age = 27, CompanyId = 3, Company = companies[2], SectionId = 5, Section = sections[4] }, // HR
    new Employee { Id = 8, Name = "Henry Taylor", Age = 33, CompanyId = 3, Company = companies[2], SectionId = 6, Section = sections[5] }, // Finance
    new Employee { Id = 9, Name = "Iris Chen", Age = 30, CompanyId = 3, Company = companies[2], SectionId = 5, Section = sections[4] }, // HR
    
    // CloudWorks employees (3) - Engineering & Sales
    new Employee { Id = 10, Name = "Jack Anderson", Age = 25, CompanyId = 4, Company = companies[3], SectionId = 7, Section = sections[6] }, // Engineering
    new Employee { Id = 11, Name = "Kate Martinez", Age = 34, CompanyId = 4, Company = companies[3], SectionId = 8, Section = sections[7] }, // Sales
    new Employee { Id = 12, Name = "Luke Garcia", Age = 28, CompanyId = 4, Company = companies[3], SectionId = 7, Section = sections[6] }, // Engineering
    
    // CyberSolutions employees (3) - Marketing & Finance
    new Employee { Id = 13, Name = "Maya Rodriguez", Age = 29, CompanyId = 5, Company = companies[4], SectionId = 9, Section = sections[8] }, // Marketing
    new Employee { Id = 14, Name = "Nathan White", Age = 36, CompanyId = 5, Company = companies[4], SectionId = 10, Section = sections[9] }, // Finance
    new Employee { Id = 15, Name = "Olivia Thompson", Age = 24, CompanyId = 5, Company = companies[4], SectionId = 9, Section = sections[8] } // Marketing
};


// Query examples with the new structure
var sectionAge = employees.Where(emp => emp.Age > 30 && emp.Section.Name == "Marketing").Select(emp => new { Employee = emp.Name, Age = emp.Age, Company = emp.Company.Name });
var groupBySection = employees.GroupBy(emp => emp.Section.Name).Select(group => new { Section = group.Key, NumberOfEmployees = group.Count(), AvgAge = group.Average(emp => emp.Age) });
var companyComp = employees.GroupBy(emp => emp.Company.Name, emp => emp.Section.Name).ToDictionary(group => group.Key, group => group.Distinct());
var seniorEngineerReport = employees.Where(emp => emp.Section.Name == "Engineering").OrderByDescending(emp => emp.Age).Select(emp => new { Employee = emp.Name, Age = emp.Age, Company = emp.Company.Name });
var empDistributionPerComp = employees.GroupBy(emp => emp.Company).ToDictionary(group => group.Key, group => group.Count()).OrderBy(dict => dict.Value);
var crossCompSectionMatch = employees.Where(emp => emp.Section.Name == "Engineering" && emp.Company.Name != "TechCorp");
var nestedGroupBySection = employees.GroupBy(emp => new { Section = emp.Section.Name, Company = emp.Company.Name })
                                    .Select(group => new
                                    {
                                        Section = group.Key.Section,
                                        Company = group.Key.Company,
                                        EmployeeCount = group.Count(),
                                    });
var topPerformerReport = employees.GroupBy(emp => emp.Section.Name)
                                .Select(group => group.MaxBy(emp => emp.Age))
                                .ToList()
                                .Select(emp => new { Employee = emp.Name, Age = emp.Age, Section = emp.Section.Name });

var sectionAcrossCompanies = employees.GroupBy(emp => emp.Section.Name)
                                    .Where(group => group.Select(emp => emp.Company.Name).Distinct().Count() > 1)
                                    .Select(group => new
                                    {
                                        Section = group.Key,
                                        Companies = group.Select(emp => emp.Company.Name).Distinct().ToList(),
                                        Count = group.Select(emp => emp.Company.Name).Distinct().Count()
                                    });

var summaryReport = employees.GroupBy(emp => emp.Company.Name)
                            .OrderBy(companyGroup => companyGroup.Key)
                            .Select(companyGroup => new
                            {
                                Company = companyGroup.Key,
                                Sections = companyGroup.GroupBy(emp => emp.Section?.Name)
                                                    .OrderBy(sectionGroup => sectionGroup.Key)
                                                    .Select( sectionGroup => new
                                                    {
                                                        Section = sectionGroup.Key,
                                                        Employees = sectionGroup.Count(),
                                                        AvgAge = sectionGroup.Average(emp => emp.Age),
                                                    })
                                                    .ToList()
                            });

foreach (var data in summaryReport)
{
    Console.ForegroundColor = ConsoleColor.Green;  // Set color to green
    Console.WriteLine($"Company: {data.Company}");
    foreach(var section in data.Sections){
        Console.ForegroundColor = ConsoleColor.White;  // Set color to green
        Console.WriteLine($"{section.Section}: ({section.Employees} employees, Avg Age: {section.AvgAge})");
    }
    Console.WriteLine($"----------------");
}