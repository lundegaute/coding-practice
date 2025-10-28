using CodingPractice.Kata6;

var kata6 = new Kata6();

int[] list = [3, 2, 1];
kata6.QuickSort(list, 0, list.Length - 1);
Console.WriteLine(string.Join(",", list));