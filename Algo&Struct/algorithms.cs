
namespace CodingPractice.Algorithms;

public interface IAlgorithms
{
    public int BinarySearch(int[] ints, int left, int right, int target);
}

public class Algorithms : IAlgorithms
{
    // Target = 2
    // [ 1,2,3,4,5,6] mid => 7 / 2 = 3.5 => 3
    public int BinarySearch(int[] ints, int left, int right, int target)
    {
        if ( left > right) throw new IndexOutOfRangeException("Target not foud");
        var mid = (left + right) / 2; // if this returns a decimal, it will round down
        if (ints[mid] == target) return mid;

        if (target > ints[mid]) return BinarySearch(ints, (mid + 1), right, target);
        else return BinarySearch(ints, left, mid - 1, target);
    }
}