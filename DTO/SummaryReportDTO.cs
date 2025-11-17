using CodingPractice.Objects.Business;

namespace CodingPractice.DTO;


public record SummarySectionDTO(
    string Section,
    int Employees,
    double AvgAge
);
public record SummaryReportDTO (
    string Company,
    List<SummarySectionDTO> Sections
);


