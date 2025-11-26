using System.Text;

namespace CodingPractice.Kata;
public abstract class AbstractKata7
{
    public abstract string BinaryToText(string binaryString);
}

public class Kata7 : AbstractKata7
{
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