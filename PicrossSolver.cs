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
        HandleHintSumCase();
        // handle next solvable cases
        // iteration until solved

        //GetAllHints();
    }

    public void HandleMaxSizeHints()
    {
        int LENGTH = _picross.GetLength();
        int HEIGHT = _picross.GetHeight();

        for(int i = 0; i < LENGTH; i++)
        {
            if(_picross.IsHintAtColumnPositionAGivenValue(i, 0) || _picross.IsHintAtColumnPositionAGivenValue(i, _picross.Size[0]))
            {
                Console.WriteLine($"MATCH FOUND AT COLUMN INDEX ${i}");
                for(int pos = 0; pos < HEIGHT; pos++)
                {
                    _picross.InsertIntoBoardArray(pos, i, "O");
                }
            }
        }

        for(int j = 0; j < HEIGHT; j++)
        {
            if(_picross.IsHintAtRowPositionAGivenValue(j, 0) || _picross.IsHintAtRowPositionAGivenValue(j, _picross.Size[1]))
            {
                for(int pos = 0; pos < LENGTH; pos++)
                {
                    _picross.InsertIntoBoardArray(j, pos, "O");
                }
            }
        }
    }

    public void HandleHintSumCase()
    {

    }

    public void GetAllHints()
    {
        Console.WriteLine("HORIZONTAL HINTS: ");
        for(int x = 0; x < _picross.Size[0]; x++)
        {
            _picross.GetColumnHintsFromBoardArray(x).ForEach(v => Console.WriteLine(v));
        }

        Console.WriteLine("VERICAL HINTS: ");
        for(int y = 0; y < _picross.Size[1]; y++)
        {
            _picross.GetRowHintsFromBoardArray(y).ForEach(v => Console.WriteLine(v));
        }
    }
}