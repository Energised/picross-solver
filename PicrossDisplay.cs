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
        var LongestHorizontalHint = picross.GetLongestHorizontalHint();
        var LongestVerticalHint = picross.GetLongestVertialHint();

        int LENGTH = LongestVerticalHint + HintBoardSpacerLength + picross.GetWidth();
        int HEIGHT = LongestHorizontalHint + HintBoardSpacerLength + picross.GetHeight();

        // offsets are not indexes, they just define how many spaces there are between
        // use these as part of a sum to get the index
        // BUT - coincidentally these are the board starting indexes
        int INITIAL_X_INDEX_OFFSET = LongestVerticalHint + HintBoardSpacerLength;
        int INITIAL_Y_INDEX_OFFSET = LongestHorizontalHint + HintBoardSpacerLength;

        string[,] DisplayBoard = new string[LENGTH, HEIGHT];

        // Add Horizontal Hints to the DisplayBoard

        foreach(var hint in picross.Horizontal)
        {
            var HeightValueIndex = 0;
            foreach(var hintValue in hint.Value)
            {
                // The key starts from 1 so -1, then add the x offset
                var XPosition = Int32.Parse(hint.Key) - 1 + INITIAL_X_INDEX_OFFSET;
                DisplayBoard[XPosition, HeightValueIndex] = hintValue.ToString();
                HeightValueIndex++;
            }
        }

        // Add Vertical Hints to the DisplayBoard

        foreach(var hint in picross.Vertical)
        {
            var WidthValueIndex = 0;
            foreach(var hintValue in hint.Value)
            {
                var YPosition = Int32.Parse(hint.Key) - 1 + INITIAL_Y_INDEX_OFFSET;
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

        // TODO: Add Rest of Board

        int BOARD_X_INDEX = 0;

        for(int x = INITIAL_X_INDEX_OFFSET; x < LENGTH; x++)
        {
            int BOARD_Y_INDEX = 0;
            for(int y = INITIAL_Y_INDEX_OFFSET; y < HEIGHT; y++)
            {
                DisplayBoard[x,y] = picross.BoardArray[BOARD_X_INDEX][BOARD_Y_INDEX];
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