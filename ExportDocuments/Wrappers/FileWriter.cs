using System.IO;

namespace ExportDocuments.Wrappers
{
  public class FileWriter
  {
    public static void Export(string path, string data)
    {
      File.WriteAllText(path, data);
    }

    public static string BuildFilePath(params string[] part)
    {
      return Path.Combine(part);
    }

    public static void CreateFolder(string path)
    {
      Directory.CreateDirectory(path);
    }
  }
}
