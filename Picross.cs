namespace PicrossSolver;

public class Picross
{
    public List<int>? Size {get; set;} // SIZE[0] = Horizontal, SIZE[1] = VERTICAL
    public Dictionary<string, List<int>>? Horizontal {get; set;}
    public Dictionary<string, List<int>>? Vertical {get; set;}
    private Dictionary<int, int>? Board {get; set;}

    // TODO: Look at how JsonSerializer.Deserialize uses object constructors
    // public Picross(string errorMessage)
    // {
    //     throw new Exception(errorMessage);
    // }

    public void PrintPicrossToConsole()
    {
        // TODO: Display board with horizontal and verticals displaying
        // This will get me a better idea on iterating through their values
        // and will be used for debugging
    }
}

public class PicrossHeader
{
    public string? Index {get; set;}
    public int? OrderedValues {get; set;}
}