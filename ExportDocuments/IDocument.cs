namespace ExportDocuments
{
  /// <summary>
  /// Документ.
  /// </summary>
  public interface IDocument
  {
    /// <summary>
    /// Идентификатор документа.
    /// </summary>
    int Id { get; }

    /// <summary>
    /// Наименование документа.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Получить описание документа.
    /// </summary>
    string Description { get; }
  }
}
