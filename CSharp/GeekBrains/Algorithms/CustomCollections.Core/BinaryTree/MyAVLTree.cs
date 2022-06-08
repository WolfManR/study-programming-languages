namespace CustomCollections.Core.BinaryTree;

public class MyAVLTree : ITree
{
    private TreeNode root;
    
    public TreeNode GetRoot() => root;
    
    public void AddItem(int value)
    {
    }
    
    public void RemoveItem(int value)
    {
    }
    
    public TreeNode GetNodeByValue(int value)
    {
        GetNodeWithParent(value, out _, out var result);
        return result;
    }

    public void PrintTree() => Console.WriteLine(this.AsString());
    
    private void LowRotate(Side side, TreeNode node)
    {
        TreeNode newRoot;

        if (side == Side.Left)
        {
            newRoot = node.Right;
            node.Right = newRoot.Left;
            newRoot.Left = node;
        }
        else
        {
            newRoot = node.Left;
            node.Left = newRoot.Right;
            newRoot.Right = node;
        }

        CalcHeight(node);
        CalcHeight(newRoot);
    }

    private void BigRotate(Side side, TreeNode node)
    {
        if (side == Side.Left)
        {
            LowRotate(Side.Right, node.Right);
            LowRotate(Side.Left, node);
        }
        else
        {
            LowRotate(Side.Left, node.Left);
            LowRotate(Side.Right, node);
        }
    }

    private void CalcHeight(TreeNode node)
    {
        // ???
    }

    private void GetNodeWithParent(int value, out TreeNode parent, out TreeNode searched)
    {
        parent = searched = null;
        if (root is null) return;
        if (root.Value == value)
        {
            searched = root;
            return;
        }

        searched = parent = root;
        while (true)
        {
            if (value > searched.Value)
            {
                if (searched.Right is null)
                {
                    parent = searched = null;
                    return;
                }
                parent = searched;
                searched = searched.Right;
                continue;
            }

            if (value < searched.Value)
            {
                if (searched.Left is null)
                {
                    parent = searched = null;
                    return;
                }
                parent = searched;
                searched = searched.Left;
                continue;
            }

            if (searched.Value == value) return;
        }
    }

    private enum Side { Left, Right }
}