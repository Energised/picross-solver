namespace PicrossSolver;

public class PicrossSolver
{

    private readonly PicrossRepository _picrossRepository;

    public PicrossSolver(PicrossRepository picrossRepository)
    {
        _picrossRepository = picrossRepository;
    }

    public void DisplayPicrossFromFile(string filename)
    {
        Picross? picross = _picrossRepository.GetPicrossFromFile(filename);
        Console.Write("DONE");
    }

    public static int Main()
    {
        PicrossRepository picrossRepository = new PicrossRepository();
        PicrossSolver solver = new PicrossSolver(picrossRepository);
        solver.DisplayPicrossFromFile("puzzle1.json");
        return 1;
    }
}