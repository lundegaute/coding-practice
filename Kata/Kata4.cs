
namespace CodingPractice.Kata;


public static class Kata4
{
    public static string Extract(int[] ints)
    {
        var list = new List<string>();
        int counter = 1;
        int? start = null;

        for (var i = 0; i < ints.Length - 1; i++)
        {
            if (ints[i + 1] == ints[i] + 1)
            {
                start = start == null ? ints[i] : start;
                Console.WriteLine($"Start: {start}");
                counter += 1;
                if (i == ints.Length - 2 && counter > 2)
                {
                    list.Add(start.ToString());
                    list.Add("-");
                    list.Add(ints[i + 1].ToString());
                }
                else if (i == ints.Length - 2)
                {
                    list.Add(ints[i].ToString());
                    list.Add(",");
                    list.Add(ints[i + 1].ToString());
                }
            }
            else if (counter > 2)
            {
                list.Add(start.ToString());
                list.Add("-");
                list.Add(ints[i].ToString());
                list.Add(",");
                start = null;
                counter = 1;
                if (i == ints.Length - 2) list.Add(ints[i + 1].ToString());
            }
            else
            {
                if ( start is not null )
                {
                    list.Add(start.ToString()!);
                    list.Add(",");
                    start = null;
                    counter = 1;
                };
                list.Add(ints[i].ToString());
                list.Add(",");
                if (i == ints.Length - 2) list.Add(ints[i + 1].ToString());
            }
        }
        return string.Concat(list);
    }
}