using System;

namespace ExportDocuments.Exporter
{
  /// <summary>
  /// Декоратор для экспорта с архивированием.
  /// </summary>
  public class DocumentExporterWithZip : ExporterDecoratorBase
  {
    private readonly IZipper zipper;

    public DocumentExporterWithZip(IExporter exporter, IZipper zipper)
      : base(exporter)
    {
      this.zipper = zipper;
    }

    public override void Export(string path)
    {
      base.Export(path);
      this.Zip(path);
    }

    private void Zip(string path)
    {
      var zipName = path + ".zip";
      this.zipper.Zip(path, zipName);
      Console.WriteLine($"Файлы в папке {path} упакованы в архив с именем \"{zipName}\"");
    }
  }
}
