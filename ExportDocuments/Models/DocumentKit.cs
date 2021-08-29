using System.Collections.Generic;
using System.Linq;


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

    public override string Description => $"Комплект {this.Name}{this.GetChildDescription()}";

    private string GetChildDescription()
    {
      var segmentDelimiter = "\r\n\t";
      string addHierarchyLevel(string s) => segmentDelimiter + string.Join(segmentDelimiter, s.Split("\r\n"));

      return string.Concat(
        this.Documents.Select(x => addHierarchyLevel(x.Description))
      );
    }
  }
}
