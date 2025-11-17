using CodingPractice.Algorithms;
using CodingPractice.Kata6;
using CodingPractice.Objects.Business;
using CodingPractice.DTO;
using CodingPractice.DataSeeds;
using CodingPractice.Api;

//var companies = EmployeeDataSeed.GetCompanies();
//var sections = EmployeeDataSeed.GetSections(companies);
//var employees = EmployeeDataSeed.GetEmployees(sections, companies);
// Run Linq queries on Employee data from EmployeeDataSeeds.cs
//EmployeeLinq.ShowAllEmployeeLinq(employees);


// Running Linq queries on JsonPlaceholderApi data
var apiLinq = new PlaceholderLinqExamples();
await apiLinq.GeographicUserDistribution();
