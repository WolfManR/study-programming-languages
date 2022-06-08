using CustomCollections.Core.BinaryTree;
using CustomCollections.Core.Graph;
using CustomCollections.TraverseAlgorithms.BinaryTreeTraverse;
using CustomCollections.TraverseAlgorithms.GraphTraverse;

using binaryTree = CustomCollections.TraverseAlgorithms.BinaryTreeTraverse;
using graph = CustomCollections.TraverseAlgorithms.GraphTraverse;

Console.WriteLine("Binary Tree");
TraverseBinaryTreeTest();

Console.WriteLine("Graph");
TraverseGraphTest();

// Program Stop
Console.WriteLine("Work Done");
Console.ReadLine();


void TraverseBinaryTreeTest()
{
    var tree = new MyBinaryTree(true, 16, 8, 9, 2, 1, 4, 24, 26, 19, 21, 20, 23);

    var logger = new binaryTree::Logger(delayInSeconds: 0);

    logger.LogInfo($"Tree:\n{tree.AsString()}");

    Console.WriteLine();

    var dfs = tree.TraverseDFS(19, logger);
    logger.LogInfo($"TraverseDFS found value is {dfs}");

    Console.WriteLine();

    var bfs = tree.TraverseBFS(19, logger);
    logger.LogInfo($"TraverseDFS found value is {bfs}");
}

void TraverseGraphTest()
{
    var graph = BuildDemoGraph();
    graph::Logger logger = new();

    graph.TraverseDFS(logger);
    Console.WriteLine("Check All visited");
    foreach (var node in graph.Nodes)
        Console.WriteLine($"{node.Value} {node.IsVisited}");

    Console.WriteLine("\n\n");

    graph = BuildDemoGraph();
    graph.TraverseBFS(logger);
    Console.WriteLine("Check All visited");
    foreach (var node in graph.Nodes)
        Console.WriteLine($"{node.Value} {node.IsVisited}");
}

static MyGraph BuildDemoGraph()
{
    MyGraph graph = new();

    var node1 = graph.AddNode(3);
    var node3 = graph.AddNode(5);
    var node4 = graph.AddNode(4);
    var node5 = graph.AddNode(2);
    var node6 = graph.AddNode(8);
    var node7 = graph.AddNode(7);

    graph.ConnectNodes(node1, node3, false, 3);
    graph.ConnectNodes(node4, node3, true, 2);
    graph.ConnectNodes(node1, node5, false, 7);
    graph.ConnectNodes(node5, node4, false, 5);
    graph.ConnectNodes(node7, node3, false, 9);
    graph.ConnectNodes(node6, node3, true, 4);
    graph.ConnectNodes(node1, node6, false, 1);
    graph.ConnectNodes(node6, node4, false, 2);

    return graph;
}