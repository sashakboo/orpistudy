using System;
using System.Collections.Generic;
using System.Text;
using ExportDocuments.Wrappers;
namespace ExportDocuments.Models
{
  public class DocumentKit : DocumentBase
  {
    public List<IDocument> Documents { get; }

    public DocumentKit(int id, string name, List<IDocument> documents)
      : base(id, name)
    {
      this.Documents = documents;
    }

    public override string GetDescription(int hierarchyLevel = 0)
    {
      var padding = string.Empty.PadLeft(hierarchyLevel, PaddingLeftSymbol);

      var description = new StringBuilder();
      description.AppendLine($"{padding}Комплект {this.Name}");

      foreach (var document in this.Documents)
      {
        description.AppendLine(document.GetDescription(hierarchyLevel + 1));
      }

      return description.ToString();
    }
  }
}
