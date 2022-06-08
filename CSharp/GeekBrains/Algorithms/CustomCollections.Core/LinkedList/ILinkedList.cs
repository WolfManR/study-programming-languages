namespace CustomCollections.Core.LinkedList;

/// <summary>
/// Начальную и конечную ноду нужно хранить в самой реализации интерфейса
/// </summary>
public interface ILinkedList
{
    /// <summary>
    /// возвращает количество элементов в списке
    /// </summary>
    /// <returns></returns>
    int GetCount();

    /// <summary>
    /// добавляет новый элемент списка
    /// </summary>
    /// <param name="value"></param>
    void AddNode(int value);

    /// <summary>
    /// добавляет новый элемент списка после определённого элемента
    /// </summary>
    /// <param name="node"></param>
    /// <param name="value"></param>
    void AddNodeAfter(Node node, int value);

    /// <summary>
    /// удаляет элемент по порядковому номеру
    /// </summary>
    /// <param name="index"></param>
    void RemoveNode(int index);

    /// <summary>
    /// удаляет указанный элемент
    /// </summary>
    /// <param name="node"></param>
    void RemoveNode(Node node);

    /// <summary>
    /// ищет элемент по его значению
    /// </summary>
    /// <param name="searchValue"></param>
    /// <returns></returns>
    Node FindNode(int searchValue);
}