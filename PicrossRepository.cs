using System.Text.Json;

namespace PicrossSolver;

public class PicrossRepository
{
    public Picross GetPicrossFromFile(string filename)
    {
        string path = $"data/{filename}";
        string picrossJson = File.ReadAllText(path) ?? "";
        Picross? picross = JsonSerializer.Deserialize<Picross>(picrossJson);
        return picross ??= new Picross();
    }
}