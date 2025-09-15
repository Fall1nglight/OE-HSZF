namespace EventHandling;

public class RowFullEventArgs<T> : EventArgs
{
    // fields
    public T Item;
    public int Index;

    // constructors
    public RowFullEventArgs(T item, int index)
    {
        Item = item;
        Index = index;
    }
}
