namespace PicrossSolver;

public class Picross
{
    public List<int> Size {get; set;} // SIZE[0] = Horizontal, SIZE[1] = VERTICAL
    public Dictionary<string, List<int>> Horizontal {get; set;}
    public Dictionary<string, List<int>> Vertical {get; set;}
    // TODO: Write a custom deserialiser to convert the list of lists to an array rather than doing it manually
    public List<List<string>> Board {get; set;}
    public string[][] BoardArray {get; set;}

    // TODO: Look at how JsonSerializer.Deserialize uses object constructors
    // public Picross(string errorMessage)
    // {
    //     throw new Exception(errorMessage);
    // }

    public int GetWidth()
    {
        return this.Size[0];
    }

    public int GetHeight()
    {
        return this.Size[1];
    }

    public int GetLongestHorizontalHint()
    {
        var allHints = this.Horizontal.Select(x => x.Value.Count);
        return allHints.Max();
    }

    public int GetLongestVertialHint()
    {
        return this.Vertical.Select(x => x.Value.Count).Max();
    }

    public void InitBoardArray()
    {
        // TODO: Look at the difference between a 2D array and an array of arrays (which this is)
        BoardArray = Board.Select(c => c.ToArray()).ToArray();
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