using CodingPractice.Kata6;

var kata6 = new Kata6();

var res = kata6.FindTheMissingLetter(['a', 'b', 'c', 'd', 'f']);
Console.WriteLine(res);
// check unicode for each
// If unicode increases with more than 1, we know which one we are missing
