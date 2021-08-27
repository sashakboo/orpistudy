using System;
using System.Collections.Generic;
using System.Text;

namespace ExportDocuments.Models
{
  public abstract class DocumentBase : IDocument
  {
    public string Name { get; set; }

    public int Id { get; }

    public DocumentBase (int id, string name)
    {
      this.Id = id;
      this.Name = name;
    }

    public abstract string Description { get; }
  }
}
