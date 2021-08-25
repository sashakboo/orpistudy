namespace ExportDocuments
{
  /// <summary>
  /// Экспортер.
  /// </summary>
  public interface IExporter
  {
    /// <summary>
    /// Выполнить экспорт по заданному пути.
    /// </summary>
    /// <param name="path">Путь к файлу.</param>
    void Export(string path);
  }
}
