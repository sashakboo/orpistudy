using System;
using ExportDocuments.Wrappers;

namespace ExportDocuments.Models
{
  public class Document : DocumentBase, IExporter
  {
    public string Text { get; set; }

    public Document(int id, string name, string text)
      : base(id, name)
    {
      this.Text = text;
    }

    public override string GetDescription(int hierarchyLevel = 0)
    {
      var padding = string.Empty.PadLeft(hierarchyLevel, PaddingLeftSymbol);
      return $"{padding}Документ {this.Name}";
    }
    
    public void Export(string path)
    {
      Console.WriteLine($"Документ {this.Name} экспортирован в папку {path}");

      var fileName = FileWriter.BuildFilePath(path, this.Name + ".txt");
      FileWriter.Export(fileName, this.Text);

      var descriptionFileName = FileWriter.BuildFilePath(path, $"{this.Name}_Description.txt");
      FileWriter.Export(descriptionFileName, this.GetDescription());
    }
  }
}
