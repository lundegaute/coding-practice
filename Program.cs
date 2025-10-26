using CodingPractice.Kata6;

var kata6 = new Kata6();

var res = kata6.AllwaysStartWithABC(["ab", "bc", "cd", "ef", "ko"]);
foreach(var word in res)
{
    Console.WriteLine(word);
}