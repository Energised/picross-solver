namespace PicrossSolver;

public class Picross
{
    public List<int> Size {get; set;} // SIZE[0] = Horizontal, SIZE[1] = VERTICAL
    public Dictionary<string, List<int>> Columns {get; set;}
    public Dictionary<string, List<int>> Rows {get; set;}
    // TODO: Write a custom deserialiser to convert the list of lists to an array rather than doing it manually
    public List<List<string>> Board {get; set;}
    public string[][] BoardArray {get; set;}

    // TODO: Look at how JsonSerializer.Deserialize uses object constructors
    // public Picross(string errorMessage)
    // {
    //     throw new Exception(errorMessage);
    // }

    public int GetLength()
    {
        return this.Size[0];
    }

    public int GetHeight()
    {
        return this.Size[1];
    }

    public int GetLongestRowsHint()
    {
        var allHints = this.Rows.Select(x => x.Value.Count);
        return allHints.Max();
    }

    public int GetLongestColumnsHint()
    {
        return this.Columns.Select(x => x.Value.Count).Max();
    }

    public void InitBoardArray()
    {
        // TODO: Look at the difference between a 2D array and an array of arrays (which this is)
        BoardArray = Board.Select(c => c.ToArray()).ToArray();
    }

    // Get the hints from a column on the board
    // Can access the board with indexes from 0, and let this automatically get the correct one
    // By adding 1 to the array index, to match the columns in the JSON
    // OR: I could just have the JSON index from 0 also
    public List<int> GetColumnHintsFromBoardArray(int column)
    {
        var HintPosition = column.ToString();
        var ColumnPositionHints = Columns.GetValueOrDefault(HintPosition) ?? new List<int>();
        return ColumnPositionHints;
    }

    public List<int> GetRowHintsFromBoardArray(int row)
    {
        var HintPosition = row.ToString();
        var RowPositionHints = Rows.GetValueOrDefault(HintPosition) ?? new List<int>();
        return RowPositionHints;
    }

    // public void PrintPicrossToConsole()
    // {
    //     // TODO: Display board with horizontal and verticals displaying
    //     // This will get me a better idea on iterating through their values
    //     // and will be used for debugging
    // }
}

// public class PicrossHeader
// {
//     public string? Index {get; set;}
//     public int? OrderedValues {get; set;}
// }