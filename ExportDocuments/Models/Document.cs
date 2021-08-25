using System;
using ExportDocuments.Wrappers;

namespace ExportDocuments.Models
{
  public class Document : DocumentBase
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
  }
}
