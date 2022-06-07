namespace CustomCollections.MyCollections;

public class MyLinkedList : ILinkedList
{
    private int _counter;
    private Node _startPoint;
    private Node _lastNode;
    public int Length => _counter;

    public MyLinkedList() { }
    public MyLinkedList(int value)
    {
        _startPoint = _lastNode = new() { Value = value };
        _counter++;
    }

    public MyLinkedList(params int[] values)
    {
        _startPoint = _lastNode = new() { Value = values[0] };
        _counter++;
        for (; _counter < values.Length; _counter++)
        {
            var next = new Node() { Value = values[_counter], PrevNode = _lastNode };
            _lastNode.NextNode = next;
            _lastNode = next;
        }
    }

    private Node GetNodeOnIndex(int index)
    {
        if (IsIndexNotInRange(index)) return null;

        Node needed;

        if (_counter - 1 / 2 >= index)
        {
            needed = _startPoint;
            for (var i = 1; i <= index; i++)
            {
                needed = needed.NextNode;
            }
        }
        else
        {
            needed = _lastNode;
            for (var i = _counter - 1; i > index; i--)
            {
                needed = needed.PrevNode;
            }
        }

        return needed;
    }

    private bool IsNodeExistInCurrentList(Node node) => AsIEnumerable().Any(current => current == node);
    private bool IsIndexNotInRange(int index) => index < 0 || index >= _counter;
    public int this[int index]
    {
        get => GetNodeOnIndex(index)?.Value ?? throw new IndexOutOfRangeException();
        set
        {
            var needed = GetNodeOnIndex(index) ?? throw new IndexOutOfRangeException();
            if (needed.Value == value) return;
            needed.Value = value;
        }
    }

    public int[] Slice(int start, int last)
    {
        if (IsIndexNotInRange(start) || last < start)
            throw new("There must be custom exception about not existing node in current collection");
        if (last > _counter || start + last > _counter)
            throw new("There must be custom exception about not existing node in current collection");

        var result = new int[last];
        var startNode = _startPoint;
        for (var i = 0; i < start; i++)
        {
            startNode = startNode.NextNode;
        }

        result[0] = startNode.Value;
        for (var i = 1; i < last; i++)
        {
            startNode = startNode.NextNode;
            result[i] = startNode.Value;
        }

        return result;
    }

    public IEnumerator<Node> GetEnumerator()
    {
        var current = _startPoint;
        do
        {
            yield return current;
            current = current.NextNode;
        } while (current is not null);
    }

    public IEnumerable<Node> AsIEnumerable()
    {
        foreach (var node in this)
            yield return node;
    }

    
    public int GetCount() => _counter;
    
    public void AddNode(int value)
    {
        if (_startPoint == null)
        {
            _startPoint = _lastNode = new() { Value = value };
        }
        else
        {
            var newOne = new Node() { Value = value, PrevNode = _lastNode };
            _lastNode.NextNode = newOne;
            _lastNode = newOne;
        }

        _counter++;
    }
    
    public void AddNodeAfter(Node node, int value)
    {
        if (!IsNodeExistInCurrentList(node))
            throw new("There must be custom exception about not existing node in current collection");

        var next = node.NextNode;
        var newOne = new Node() { Value = value, NextNode = next, PrevNode = node };
        node.NextNode = newOne;
        if (next is not null) next.PrevNode = newOne;
        _counter++;
    }
    
    public void RemoveNode(int index)
    {
        if (IsIndexNotInRange(index))
            throw new("There must be custom exception about not existing node in current collection");

        if (index == 0)
        {
            if (_startPoint.NextNode is { } node)
            {
                _startPoint = node;
                node.PrevNode = null;
            }
            else _startPoint = _lastNode = null;
        }
        else
        {
            var toRemove = GetNodeOnIndex(index);

            if (toRemove.NextNode is not null)
                toRemove.NextNode.PrevNode = toRemove.PrevNode;
            toRemove.PrevNode.NextNode = toRemove.NextNode;
            toRemove.NextNode = toRemove.PrevNode = null;
        }

        _counter--;
    }
    
    public void RemoveNode(Node node)
    {
        if (!IsNodeExistInCurrentList(node))
            throw new("There must be custom exception about not existing node in current collection");
        if (_startPoint == node)
        {
            if (_startPoint == _lastNode)
            {
                _startPoint = _lastNode = null;
            }
            else
            {
                _startPoint = node.NextNode;
                node.NextNode = null;
                _startPoint.PrevNode = null;
            }
        }
        else
        {
            if (node.NextNode is not null)
                node.NextNode.PrevNode = node.PrevNode;
            node.PrevNode.NextNode = node.NextNode;
            node.NextNode = node.PrevNode = null;
        }

        _counter--;
    }
    
    public Node FindNode(int searchValue)
    {
        var current = _startPoint;
        while (current is not null)
        {
            if (current.Value == searchValue) return current;
            current = current.NextNode;
        }

        return null;
    }
}