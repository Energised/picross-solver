using System.Text.Json;

using PicrossApp.Models;

namespace PicrossApp.Data.Repositories;

public class PicrossRepository
{
    public Picross GetPicrossFromFile(string filename)
    {
        string path = $"Data/Storage/{filename}";
        string picrossJson = File.ReadAllText(path) ?? "";
        Picross? picross = JsonSerializer.Deserialize<Picross>(picrossJson);
        return picross ??= new Picross();
    }
}