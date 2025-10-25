using CodingPractice.Kata6;

var kata6 = new Kata6();

var tower = kata6.TowerBuilder(3);
foreach(var floor in tower)
{
    Console.WriteLine(floor);
}
// check unicode for each
// If unicode increases with more than 1, we know which one we are missing
