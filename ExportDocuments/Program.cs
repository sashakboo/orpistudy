using System;
using System.Collections.Generic;
using ExportDocuments.Wrappers;

namespace ExportDocuments
{
  public class Program
  {
    public static void Main(string[] args)
    {

      var options = new StartOptions(args);

      foreach (var doc in DocumentStorage.Documents)
      {
        Console.WriteLine("-----");
        Console.WriteLine(doc.Description);

        string exportDir = FileWriter.BuildFilePath(options.Path, doc.Name);
        FileWriter.CreateFolder(exportDir);

        ExportService.Export(doc,
                             exportDir,
                             options.WithCompression,
                             options.WithEncryption);
      }

      foreach (var item in DocumentStorage.Documents)
      {
        Console.WriteLine(item.Description);
      }

      Console.ReadKey();
    }

    internal class StartOptions
    {
      private const string pathKey = "--path";

      private const string compressionKey = "--compress";

      private const string encryptKey = "--encrypt";

      internal string Path { get; }

      internal bool WithCompression { get; }

      internal bool WithEncryption { get; }

      internal StartOptions(string[] args)
      {
        var argsDict = new Dictionary<string, string>();

        foreach (var param in args)
        {
          var key = param.Split("=")[0];
          var value = param.Split("=")[1];
          argsDict.Add(key, value);
        }

        var withCompression = argsDict.GetValueOrDefault(compressionKey, "false");
        var withEncryption = argsDict.GetValueOrDefault(encryptKey, "false");

        var defaultPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Export");
        this.Path = argsDict.GetValueOrDefault(pathKey, defaultPath);
        this.WithCompression = bool.Parse(withCompression);
        this.WithEncryption = bool.Parse(withEncryption);
      }
    }
  }
}
