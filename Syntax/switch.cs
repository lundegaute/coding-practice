
namespace CodingPractice.Syntax;

public static class SwitchSyntax
{
    
    public static void SwitchStatement(int Age)
    {
        switch(Age)
        {
            case < 10:
                Console.WriteLine($"Age: {Age}, is less than 10");
                break;
            case < 20 and > 10:
                Console.WriteLine($"Age: {Age}, is less than 20");
                break;
            default:
                Console.WriteLine($"Age: {Age} is bigger than 20");
                break;
        }
    }

    // Must return a value
    public static string SwitchExpression(string name)
    {
        return name switch
        {
            "Batman" => "Bruce Wayne",
            "Superman" => "Clark Kent",
            "Spiderman" => "Peter Parker",
            _ => "",
        };
    }
    public static string SwitchOr(string color)
    {
        return color switch
        {
            "Blue" or "Gold" or "Cyan" => "Favourite Colors",
            _ => "Not favourite colors",
        };
    }
    public static string SwitchAnd(int age)
    {
        return age switch
        {
            > 18 and <= 30 => "Young adult",
            > 30 and <= 50 => "Adult",
            _ => "Old",
        };
    }
}