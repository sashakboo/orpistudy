using System;
using ExportDocuments.Models;
using ExportDocuments.Wrappers;

namespace ExportDocuments.Exporter
{
  public class DocumentExporter : IExporter
  {
    private readonly IDocument document;

    public DocumentExporter(IDocument document)
    {
      this.document = document;
    }

    public void Export(string path)
    {
      if (this.document is Document)
        this.ExportSimpleDocument(path);

      if (this.document is DocumentKit)
        this.ExportKit(path);
    }

    private void ExportSimpleDocument(string path)
    {
      Console.WriteLine($"Документ {this.document.Name} экспортирован в папку {path}");

      var fileName = FileWriter.BuildFilePath(path, this.document.Name + ".txt");
      FileWriter.Export(fileName, (this.document as Document).Text);

      this.ExportDescription(path);
    }

    private void ExportKit(string path)
    {
      this.ExportDescription(path);

      string childrenPath = FileWriter.BuildFilePath(path, this.document.Name);
      FileWriter.CreateFolder(childrenPath);

      foreach (var doc in (this.document as DocumentKit).Documents)
      {
        var exporter = new DocumentExporter(doc);
        exporter.Export(childrenPath);
      }
    }

    private void ExportDescription(string path)
    {
      var descriptionFileName = FileWriter.BuildFilePath(path, $"{this.document.Name}_Description.txt");
      FileWriter.Export(descriptionFileName, this.document.GetDescription());
    }
  }
}
