namespace EventHandling;

// Készítsünk egy generikus MatrixStorage<T> osztályt,
// amelynek konstruktorában lehessen megadni a sorok és oszlopok számát!

// Amikor be szeretnénk szúrni egy elemet, akkor egy random helyre jöjjön létre!

// Az alábbi eseményeket biztosítsa a mátrix:
// -RowFull => beszúrás után ha betelik az adott sor, meghívjuk
// -ColumnFull => beszúrás után, ha betelik az adott oszlop, meghívjuk
// -MatrixFull => ha betelet a mátrix meghívjuk

public class MatrixStorage<T>
{
    // fields
    public event EventHandler<RowFullEventArgs<T>> RowFull;
    public event EventHandler<ColumnFullEventArgs<T>> ColumnFull;
    public event Action MatrixFull;

    private T[,] _matrix;
    private readonly Random _random;
    private readonly int _capacity;
    private int _count;

    // constructors
    public MatrixStorage(int rows, int cols)
    {
        _matrix = new T[rows, cols];
        _random = new Random();
        _capacity = rows * cols;
    }

    // methods
    public bool Add(T item)
    {
        // ha be van telve a mátrix, meghívjuk a MatrixFull eventet
        if (_capacity == _count)
        {
            MatrixFull?.Invoke();
            return false;
        }

        // generálunk egy random helyet a mátrixban,
        // majd elhelyezzük ide a beszúrni kívánt elemet
        int[] place = FindPlace();
        int rowIdx = place[0];
        int colIdx = place[1];
        _matrix[rowIdx, colIdx] = item;

        // növeljük a count értékét egyel
        _count++;

        // ha betelt a mátrix az elem hozzáadását követően
        // meghívjuk a MatrixFull event-et
        if (_capacity == _count)
            MatrixFull?.Invoke();

        if (IsRowFull(rowIdx))
            RowFull?.Invoke(this, new RowFullEventArgs<T>(item, rowIdx));

        if (IsColumnFull(colIdx))
            ColumnFull?.Invoke(this, new ColumnFullEventArgs<T>(item, colIdx));

        // ellenőrizzük az adott oszlopot, amibe beszúrtuk az elemet, hogy betelt-e

        return true;
    }

    private int[] FindPlace()
    {
        int randRow;
        int randCol;

        do
        {
            // _random.Next(0, _matrix.GetLength(0)) is használható lenne
            randRow = _random.Next(_matrix.GetLength(0));
            randCol = _random.Next(_matrix.GetLength(1));

            // A ciklusnak akkor kell ismétlődnie,
            // amikor a _matrix[randRow, randCol] értéke nem egyenlő null-lal
            // "amíg a mátrix adott eleme nem null"
        } while (_matrix[randRow, randCol] != null);

        return [randRow, randCol];
    }

    private bool IsRowFull(int rowNum)
    {
        int numOfCols = _matrix.GetLength(1);
        int x = 0;

        // addig megy a ciklus ameddig x kisebb mint numOfCols
        // és az adott elem nem nulla, azaz foglalt
        while (x < numOfCols && _matrix[rowNum, x] != null)
            x++;

        return x == numOfCols;
    }

    private bool IsColumnFull(int colNum)
    {
        int numOfRows = _matrix.GetLength(0);
        int x = 0;

        // addig megy a ciklus ameddig x kisebb mint numOfCols
        // és az adott elem nem nulla, azaz foglalt
        while (x < numOfRows && _matrix[x, colNum] != null)
            x++;

        return x == numOfRows;
    }
}
