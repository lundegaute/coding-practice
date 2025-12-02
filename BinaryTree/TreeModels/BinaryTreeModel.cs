
namespace CodingPractice.Trees;

public class TreeNode
{
    public int Value { get; init;}
    public TreeNode? Left;
    public TreeNode? Right;

    public TreeNode(int value)
    {
        Value = value;
    }
}

public class Tree
{
    public TreeNode? Root { get; set;}

    public TreeNode? GetRoot()
    {
        return Root;
    }

    public IEnumerable<int> InOrderYield(TreeNode node)
    {
        if ( node is null) yield break;

        foreach( var item in InOrderYield(node.Left)) yield return item;

        yield return node.Value;

        foreach( var item in InOrderYield(node.Right)) yield return item;
    }
    public List<int> InOrderTraverse()
    {
        List<int> ints = new List<int>();
        InOrderTraverse(Root, ints);
        return ints;
    }
    private void InOrderTraverse(TreeNode node, List<int> ints)
    {
        if ( node is null ) return;
        InOrderTraverse(node.Left, ints);
        ints.Add(node.Value);
        InOrderTraverse(node.Right, ints);
    }

    public void AddNode(int value)
    {
        if ( Root is null ) Root = new TreeNode(value);
        else AddNode(Root, value);
    }
    private void AddNode(TreeNode node, int value)
    {
        if ( value > node.Value)
        {
            if ( node.Right is null ) node.Right = new TreeNode(value);
            else AddNode(node.Right, value);
        }
        else if ( value < node.Value )
        {
            if ( node.Left is null ) node.Left = new TreeNode(value);
            else AddNode(node.Left, value);
        }
    }
}