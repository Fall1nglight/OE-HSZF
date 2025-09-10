namespace Delegates;

// Készíts el egy generikus tároló osztályt,
// ami a háttérben egy tömbbe menti a T típusú elemeket!

// Készíts el egy bejárást indító függvényt,
// amely végiglépked az elemeken és egy külső függvényt meghív
// delegáltton keresztül!

// Legyen lehetőség transzformációs
// függvények hozzáadására is, amelyeket a bejáráskor meghív
// egymás után az osztály, de az eredeti elemet nem mdosítja

// Módosítsd a Storage osztály delegáltjait beépített delegáltakra
// A külső függvényeket Lambda kifejezéssel add át!

public class Container<T>
{
    // fields
    private T[] _container;
    private int _count;
    private Func<T, T> _transformers;

    // constructors
    public Container(int size)
    {
        _container = new T[size];
    }

    // methods
    /// <summary>
    /// Adds the given item to the container.
    /// </summary>
    /// <param name="item">Item to add</param>
    /// <returns>The result of the operation.</returns>
    public bool Add(T item)
    {
        if (_count == _container.Length)
            return false;

        _container[_count++] = item;
        return true;
    }

    /// <summary>
    /// Adds a transformer method to the collection.
    /// </summary>
    /// <param name="transformer">
    /// The function to add, which takes an item of type `T`
    /// and returns a transformed item of type `T`.
    /// </param>
    public void AddTransformer(Func<T, T> transformer)
    {
        _transformers += transformer;
    }

    /// <summary>
    /// Deletes every item from the container.
    /// </summary>
    public void Clear()
    {
        _count = 0;
        _container = new T[_container.Length];
    }

    /// <summary>
    /// Removes the given item from the container.
    /// </summary>
    /// <param name="item">Item to remove</param>
    /// <returns>The result of the operation.</returns>
    public bool Remove(T item)
    {
        int foundIndex = -1;

        for (int i = 0; i < _count; i++)
        {
            if (_container[i]!.Equals(item))
                foundIndex = i;
        }

        if (foundIndex == -1)
            return false;

        for (int j = foundIndex; j < _count - 1; j++)
        {
            _container[foundIndex] = _container[j + 1];
        }

        _count--;
        return true;
    }

    /// <summary>
    /// Iterates through the container's elements, applies all registered transformers,
    /// and then invokes the provided delegate with the final, transformed item.
    /// The original elements in the container are not modified.
    /// </summary>
    /// <param name="traverser">
    /// A delegate (an Action) that takes a single transformed item of type `T`
    /// and performs an operation on it.
    /// </param>
    public void Traverse(Action<T> traverser)
    {
        for (int i = 0; i < _count; i++)
        {
            T originalItem = _container[i];

            foreach (var transformer in _transformers.GetInvocationList())
            {
                originalItem = (transformer as Func<T, T>)!.Invoke(originalItem);
            }

            traverser?.Invoke(originalItem);
        }
    }
}
