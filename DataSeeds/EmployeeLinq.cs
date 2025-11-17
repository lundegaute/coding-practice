using CodingPractice.DTO;
using CodingPractice.Objects.Business;

namespace CodingPractice.DataSeeds;

public static class EmployeeLinq
{
    public static void ShowAllEmployeeLinq(List<Employee> employees)
    {
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

        var summaryReport = employees
                                .GroupBy(emp => emp.Company.Name)
                                .OrderBy(companyGroup => companyGroup.Key)
                                .Select(companyGroup => new SummaryReportDTO
                                (
                                    Company: companyGroup.Key,
                                    Sections: companyGroup
                                                .GroupBy(emp => emp.Section?.Name)
                                                .OrderBy(sectionGroup => sectionGroup.Key)
                                                    .Select(sectionGroup => new SummarySectionDTO
                                                        (
                                                            Section: sectionGroup.Key,
                                                            Employees: sectionGroup.Count(),
                                                            AvgAge: sectionGroup.Average(emp => emp.Age)
                                                        ))
                                                        .ToList()
                                ));

        foreach (var data in summaryReport)
        {
            Console.ForegroundColor = ConsoleColor.Green;  // Set color to green
            Console.WriteLine($"Company: {data.Company}");
            foreach (var section in data.Sections)
            {
                Console.ForegroundColor = ConsoleColor.White;  // Set color to green
                Console.WriteLine($"{section.Section}: ({section.Employees} employees, Avg Age: {section.AvgAge})");
            }
            Console.WriteLine($"----------------");
        }
    }
}