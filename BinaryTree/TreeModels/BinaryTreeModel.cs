
namespace CodingPractice.Trees;

public class TreeNode
{
    public int Value { get; set;}
    public TreeNode? Left;
    public TreeNode? Right;

    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}