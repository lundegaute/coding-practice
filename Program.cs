using CodingPractice.Algorithms;
using CodingPractice.Kata6;

var kata6 = new Kata6();
var kata7 = new Kata7();

Dictionary<char, int> dict = kata6.Count("aba");

foreach(var elem in dict)
{
    Console.WriteLine("----- Key Value Pair -----");
    Console.WriteLine(elem.Key);
    Console.WriteLine(elem.Value);
}