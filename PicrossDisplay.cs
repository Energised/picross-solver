namespace PicrossSolver;

public static class PicrossDisplay
{

    public static int HintBoardSpacerLength = 1;

    public static void DisplayPicross(Picross picross)
    {
        string[,] DisplayBoard = GeneratePicrossDisplayBoard(picross);
        PrintDisplayBoardToConsole(DisplayBoard);
    }

    public static string[,] GeneratePicrossDisplayBoard(Picross picross)
    {
        var LongestColumnsHint = picross.GetLongestColumnsHint();
        var LongestRowsHint = picross.GetLongestRowsHint();

        int LENGTH = LongestRowsHint + HintBoardSpacerLength + picross.GetLength();
        int HEIGHT = LongestColumnsHint + HintBoardSpacerLength + picross.GetHeight();

        // offsets are not indexes, they just define how many spaces there are between
        // use these as part of a sum to get the index
        // BUT - coincidentally these are the board starting indexes
        int INITIAL_X_INDEX_OFFSET = LongestRowsHint + HintBoardSpacerLength;
        int INITIAL_Y_INDEX_OFFSET = LongestColumnsHint + HintBoardSpacerLength;

        string[,] DisplayBoard = new string[LENGTH, HEIGHT];

        // Add Column Hints to the DisplayBoard

        foreach(var hint in picross.Rows)
        {
            var HeightValueIndex = 0;
            foreach(var hintValue in hint.Value)
            {
                var XPosition = Int32.Parse(hint.Key) + INITIAL_X_INDEX_OFFSET;
                DisplayBoard[XPosition, HeightValueIndex] = hintValue.ToString();
                HeightValueIndex++;
            }
        }

        // Add Vertical Hints to the DisplayBoard

        foreach(var hint in picross.Columns)
        {
            var WidthValueIndex = 0;
            foreach(var hintValue in hint.Value)
            {
                var YPosition = Int32.Parse(hint.Key) + INITIAL_Y_INDEX_OFFSET;
                DisplayBoard[WidthValueIndex, YPosition] = hintValue.ToString();
                WidthValueIndex++;
            }
        }

        // Add Spacer Lines

        for(int spacerIndex = 0; spacerIndex < HEIGHT; spacerIndex++)
        {
            DisplayBoard[3, spacerIndex] = "-";
        }

        for(int spacerIndex = 0; spacerIndex < LENGTH; spacerIndex++)
        {
            DisplayBoard[spacerIndex, 3] = "|";
        }

        // Add Rest of Board
        // TODO: Rewrite this, and check that BoardArray is how I want it, becasue x and y don't
        // line up correctly, still seem to be addressing the wrong row/column in BoardArray

        int BOARD_X_INDEX = 0;

        for(int x = INITIAL_X_INDEX_OFFSET; x < LENGTH; x++)
        {
            int BOARD_Y_INDEX = 0;
            for(int y = INITIAL_Y_INDEX_OFFSET; y < HEIGHT; y++)
            {
                DisplayBoard[y,x] = picross.BoardArray[BOARD_X_INDEX][BOARD_Y_INDEX];
                BOARD_Y_INDEX++;
            }
            BOARD_X_INDEX++;
        }

        return DisplayBoard;
    }

    public static void PrintDisplayBoardToConsole(string[,] DisplayBoard)
    {
        for(int i = 0; i < DisplayBoard.GetLength(0); i++)
        {
            for(int j = 0; j < DisplayBoard.GetLength(1); j++)
            {
                var value = DisplayBoard[i,j] ??= " ";
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
    }
}