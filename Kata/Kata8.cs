
namespace CodingPractice.Kata;

public static class Kata8
{
    public static string Initials(string name)
    {
        return string.Join(".", name.ToUpper().Split(" ").Select(word => word.First()));
    }
    public static long[] Digitize(long n) // 35231
    {
      return string.Join("", n).ToCharArray().Reverse().Select(c => (long) int.Parse(c.ToString())).ToArray();
    }
    public static string FindNeedle(object[] haystack)
    {
        var index = Array.IndexOf(haystack, "needle");
        return $"found the needle at position {index}";
    }
    public static int[] CountBy(int x, int n)
  {
    var list = new List<int>();
    
    for(var i = x; i <= (x * n); i += x){
      list.Add(i);
    }
    return list.ToArray();
  }
}