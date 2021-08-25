using System;
using System.IO.Compression;

namespace ExportDocuments.Exporter
{
  /// <summary>
  /// Декоратор для экспорта с архивированием.
  /// </summary>
  public class DocumentExporterWithZip : DocumentExporterBase
  {
    public DocumentExporterWithZip(IExporter exported)
      : base(exported)
    {

    }

    public override void Export(string path)
    {
      base.Export(path);
      this.Zip(path);
    }

    private void Zip(string path)
    {
      string zipName = path + ".zip";
      ZipFile.CreateFromDirectory(path, zipName);
      Console.WriteLine($"Файлы в папке {path} упакованы в архив с именем \"{zipName}\"");
    }
  }
}
