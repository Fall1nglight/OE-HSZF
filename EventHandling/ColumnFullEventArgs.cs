namespace EventHandling;

public class ColumnFullEventArgs<T> : EventArgs
{
    // fields
    public T Item;
    public int Index;

    // constructors
    public ColumnFullEventArgs(T item, int index)
    {
        Item = item;
        Index = index;
    }
}
