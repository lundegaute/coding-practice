using CodingPractice.Objects.Business;

namespace CodingPractice.DataSeeds;

public static class EmployeeDataSeed
{
    public static List<Company> GetCompanies()
    {
        return new List<Company>
        {
            new Company { Id = 1, Name = "TechCorp" },
            new Company { Id = 2, Name = "InnovaSoft" },
            new Company { Id = 3, Name = "DataDyne" },
            new Company { Id = 4, Name = "CloudWorks" },
            new Company { Id = 5, Name = "CyberSolutions" }
        };
    }
    public static List<Section> GetSections(List<Company> companies)
    {
        return new List<Section>
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
    }
    public static List<Employee> GetEmployees(List<Section> sections, List<Company> companies)
    {
        return new List<Employee>
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
    }
}