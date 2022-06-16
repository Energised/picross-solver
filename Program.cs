namespace PicrossSolver;

public class Program
{
    public static void DisplayPicrossFromFile(string filename)
    {
        PicrossRepository picrossRepository = new PicrossRepository();
        var picross = picrossRepository.GetPicrossFromFile(filename);
        picross.InitBoardArray(); // have to do this for now
        PicrossDisplay.DisplayPicross(picross);
        Console.WriteLine("DONE");
    }

    public static void Main()
    {
        PicrossRepository picrossRepository = new PicrossRepository();
        Picross picross = picrossRepository.GetPicrossFromFile("puzzle1.json");
        picross.InitBoardArray();
        PicrossSolver solver = new PicrossSolver(picross);
        solver.Solve();
        PicrossDisplay.DisplayPicross(solver._picross);
        //DisplayPicrossFromFile("puzzle1.json");
    }
}