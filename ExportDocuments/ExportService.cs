using System;
using System.IO;
using ExportDocuments.Exporter;
using ExportDocuments.Models;

namespace ExportDocuments
{
  public class ExportService
  {
    /// <summary>
    /// Экспортировать документ в папку.
    /// </summary>
    /// <param name="document">Документ</param>
    /// <param name="path">Путь к папке экспорта</param>
    /// <param name="withCompression">Признак необходимости архивирования после</param>
    /// <param name="withEncryption">Признак необходимости шифрования после экспорта</param>
    public static void Export(IDocument document,
                              string path,
                              bool withCompression = false,
                              bool withEncryption = false)
    {
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      IExporter exporter= new DocumentExporter(document);

      if (withEncryption)
        exporter = new DocumentExporterWithEncrypt(exporter);

      if (withCompression)
        exporter = new DocumentExporterWithZip(exporter);

      exporter.Export(path);
    }
  }
}
