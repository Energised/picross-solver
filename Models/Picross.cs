namespace PicrossApp.Models;

public class Picross
{
    public List<int> Size {get; set;} // SIZE[0] = ColumnSize/Length , SIZE[1] = RowSize/Height
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

    public int GetLongestColumnsHint()
    {
        return this.Columns.Select(x => x.Value.Count).Max();
    }

    public int GetLongestRowsHint()
    {
        return this.Rows.Select(x => x.Value.Count).Max();
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

    #region GetHints
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

    public bool IsHintAtColumnPositionAGivenValue(int position, int value)
    {
        return this.GetColumnHintsFromBoardArray(position).Exists(x => x == value); 
    }

    public bool IsHintAtRowPositionAGivenValue(int position, int value)
    {
        return this.GetRowHintsFromBoardArray(position).Exists(x => x == value);
    }

    #endregion

    #region Fill Squares

    public int InsertIntoBoardArray(int row, int column, string token)
    {
        if(this.BoardArray[row][column].Contains("O") || this.BoardArray[row][column].Contains("X")){
            return 0;
        }
        this.BoardArray[row][column] = token;
        return 1;
    }

    #endregion
}