using System;
using ExportDocuments.Wrappers;

namespace ExportDocuments
{
  public class Program
  {
    public static void Main(string[] args)
    {
      string directory = FileWriter.BuildFilePath(AppDomain.CurrentDomain.BaseDirectory, "Export");

      foreach (var doc in DocumentStorage.Documents)
      {
        Console.WriteLine("-----");
        Console.WriteLine(doc.GetDescription());

        string exportDir = FileWriter.BuildFilePath(directory, doc.Name);
        FileWriter.CreateFolder(exportDir);

        ExportService.Export(doc,
                             exportDir,
                             withCompression: true,
                             withEncryption: true);
      }

      Console.ReadKey();
    }
  }
}
