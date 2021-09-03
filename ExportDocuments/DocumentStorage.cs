using ExportDocuments.Models;
using System.Collections.Generic;

namespace ExportDocuments
{
  public static class DocumentStorage
  {
    public static List<IDocument> Documents = new List<IDocument>();

    static DocumentStorage()
    {
      var doc1 = new Document(1, $"name-{1}", "");
      var doc2 = new Document(2, $"name-{2}", "");
      var doc3 = new Document(3, $"name-{3}", "");

      var kit3 = new DocumentKit(34,
                                 "kit-3",
                                 new List<IDocument>() { new Document(43, "name-43", ""), doc3 });

      var kit1 = new DocumentKit(4, "kit-1", new List<IDocument>() { doc2, kit3 });

      var kit2 = new DocumentKit(4, "kit-2", new List<IDocument>() { kit1, doc1 });

      Documents.Add(kit1);
      Documents.Add(kit2);
      Documents.Add(kit3);
      Documents.Add(doc1);
    }
  }
}
