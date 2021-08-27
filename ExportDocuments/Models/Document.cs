using System;
using ExportDocuments.Wrappers;

namespace ExportDocuments.Models
{
  public class Document : DocumentBase
  {
    public string Text { get; set; }

    public override string Description => $"Документ {this.Name}";

    public Document(int id, string name, string text)
      : base(id, name)
    {
      this.Text = text;
    }
  }
}
