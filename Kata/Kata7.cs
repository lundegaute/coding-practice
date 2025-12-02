using System.Text;

namespace CodingPractice.Kata;
public abstract class AbstractKata7
{
    public abstract string BinaryToText(string binaryString);
    public abstract long FibNumberRecursion(int n);
    public abstract long FibNumberNoRecursion(int n);
    public abstract long FibNumberNoRecNoDict(int n);

}

public class Kata7 : AbstractKata7
{
    public override long FibNumberNoRecNoDict(int n)
    {
        long prev = 1, current = 1;
        if ( n <= 2 ) return current;

        for(var i = 3; i <= n; i++)
        {
            long next = prev + current;
            prev = current;
            current = next;
        }
        return current;
    }
    public override long FibNumberNoRecursion(int n)
    {
        var fibDict = new Dictionary<int, long>()
        {
            {1, 1}, // FibDict starting values
            {2, 1}
        };
        if ( n <= 2) return fibDict[n];

        for(var i = 3; i <= n; i++)
        {
            fibDict.Add(i, fibDict[i-1] + fibDict[i-2]);
        }
        return fibDict[n];
    }
    public override long FibNumberRecursion(int n)
    {
        if ( n <= 2 ) return 1;
        return FibNumberRecursion(n - 1) + FibNumberRecursion(n - 2);
    }
    public override string BinaryToText(string binaryString)
    {
        // Input looks like "01001001 01101110 01100110" with spaces inbetween
        // So i use Split(" ") To get each byte as a string
        // Then i select each word and convert it from base 2 to byte
        byte[] bytes = binaryString.Split(" ").Select(word => Convert.ToByte(word, 2))
                                 .ToArray();

        // Then i convert the byte array to a string using ASCII encoding
        string text = Encoding.ASCII.GetString(bytes); 

        Console.WriteLine($"Binary String: {binaryString}");
        Console.WriteLine($"Converted Text: {text}");

        return text;
    }
}