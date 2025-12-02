
namespace CodingPractice.Syntax;

public class WhileSyntax
{
    public static void WhileStandard()
    {
        Console.WriteLine("Enter a number");
        int number = int.Parse(Console.ReadLine() ?? "10");
        int i = 0;
        while(i <= number)
        {
            Console.WriteLine($"Number: {i}");
            i++;
        }
    }
    public static void DoWhile()
    {
        int i = 0;
        // Executes the Do part of the code at least once before the while part
        do
        {
            Console.WriteLine("Value of i: " + i);
            i++;
        } while (i < 10);
    }
}