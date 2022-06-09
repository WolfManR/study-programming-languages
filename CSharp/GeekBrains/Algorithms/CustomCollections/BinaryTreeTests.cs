﻿using CustomCollections.Core.BinaryTree;
using Xunit.Abstractions;

namespace CustomCollections;

public class BinaryTreeTests
{
    private readonly ITestOutputHelper _helper;
    private MyBinaryTree _sob => new();

    public BinaryTreeTests(ITestOutputHelper helper) => _helper = helper;

    [Fact]
    public void GetRoot_ReturnRoot_WithNoBranchesInTreeWithOneElement()
    {
        var tree = _sob;
        tree.AddItem(1);
        var root = tree.GetRoot();

        Assert.Equal(1, root.Value);
        Assert.Null(root.Left);
        Assert.Null(root.Right);
    }

    [Fact]
    public void GetRoot_ReturnNull_InTreeWithNoElements()
    {
        var tree = _sob;
        var root = tree.GetRoot();

        Assert.Null(root);
    }

    [Fact]
    public void GetNodeByValue_ReturnNull_InTreeWithNoElements()
    {
        var tree = _sob;
        var node = tree.GetNodeByValue(1);

        Assert.Null(node);
    }

    [Fact]
    public void GetNodeByValue_ReturnNode_InTreeWithOneElements()
    {
        var tree = _sob;
        tree.AddItem(1);
        var node = tree.GetNodeByValue(1);

        Assert.NotNull(node);
        Assert.Equal(1, node.Value);
    }

    [Fact]
    public void GetNodeByValue_ReturnNode_InTreeWithManyElements()
    {
        var tree = _sob;
        tree.AddItem(1);
        tree.AddItem(2);
        tree.AddItem(3);
        tree.AddItem(4);
        var node = tree.GetNodeByValue(3);

        Assert.NotNull(node);
        Assert.Equal(3, node.Value);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, 3)]
    [InlineData(new[] { 1, 3, 2, 4 }, 3)]
    [InlineData(new[] { 5, 2, 4, 1 }, 5)]
    [InlineData(new[] { 10, 8, 9, 2, 1, 4, 13, 12, 15 }, 13)]
    [InlineData(new[] { 10, 8, 9, 2, 1, 4, 13, 12, 15 }, 10)]
    [InlineData(new[] { 10, 8, 9, 2, 1, 4, 13, 12, 15 }, 2)]
    [InlineData(new[] { 16, 8, 9, 2, 1, 4, 24, 26, 19, 21, 20, 23 }, 16)]
    public void RemoveItem_RemoveCorrectNode_InTreeWithManyElements(int[] values, int toRemove)
    {

        MyBinaryTree tree = new(false, values);
        _helper.WriteLine($"before:\n{tree.AsString()}");
        tree.RemoveItem(toRemove);
        var node = tree.GetNodeByValue(toRemove);

        _helper.WriteLine($"after:\n{tree.AsString()}");
        Assert.Null(node);
    }

    [Theory]
    [MemberData(nameof(_paramsForTestWithLineArray))]
    public void RemoveItem_RemoveCorrectNode_InTreeWithManyElements_WithLineArrayOnCheck(int[] values, int toRemove, (int, int)[] expected)
    {
        MyBinaryTree tree = new(false, values);

        _helper.WriteLine($"before:\n{tree.AsString()}");

        tree.RemoveItem(toRemove);

        _helper.WriteLine($"after:\n{tree.AsString()}");

        Assert.Equal(expected, tree.GetTreeInLineForTest());
    }


    public static IEnumerable<object[]> _paramsForTestWithLineArray()
    {
        yield return new object[]
        {
                new[] {10,8,9,2,1,4,13,12,15},
                13,
                new []{(0, 10), (1, 8), (1, 15), (2, 2), (2, 9), (2, 12), (3, 1), (3, 4)}
        };
        yield return new object[]
        {
                new[] {16, 8, 9, 2, 1, 4, 24, 26, 19, 21, 20, 23},
                16,
                new []{(0, 19), (1, 8), (1, 24), (2, 2), (2, 9), (2, 21), (2, 26), (3, 1), (3, 4), (3, 20), (3, 23)}
        };
    }
}