
namespace CodingPractice.Yield;

public static class Practice
{
    public static IEnumerable<T> Yield<T>(IEnumerable<T> source)
    {
        foreach(var item in source)
        {
            yield return item;
        }
    }

    public static IEnumerable<int> YieldRange(int start = 0, int end = 10)
    {
        for(var i = 0; i < end; i++)
        {
            yield return start++;
        }
    }
}