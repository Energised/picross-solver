namespace PicrossSolver;

public class PicrossSolver
{
    public Picross _picross;

    public PicrossSolver(Picross picross)
    {
        _picross = picross;
    }

    public void Solve()
    {
        HandleMaxSizeHints();
        // handle next solvable cases
        // iteration until solved
    }

    public void HandleMaxSizeHints()
    {
        int WIDTH = _picross.GetWidth();
        int HEIGHT = _picross.GetHeight();

        // this will get us an answer to IF this case exists
        // but not the column where it does exist
        var HorizontalHints = _picross.Horizontal.SelectMany(x => x.Value)
                                                 .Select(x => x)
                                                 .Where(y => (y == HEIGHT) || (y == 0));

        var hints = _picross.Horizontal.SelectMany(x => x.Value);
        // - get all values (List<int>)
        // - if any List<int> contains 0 or HEIGHT then
        // - return that List<int>
        // - _picross.Horizontal.ContainsValue(each of those List<int>) and get key from there
    }
}