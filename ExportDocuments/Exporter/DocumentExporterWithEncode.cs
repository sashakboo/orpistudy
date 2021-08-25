using System;
using ExportDocuments.Wrappers;

namespace ExportDocuments.Exporter
{
  /// <summary>
  /// Декоратор для экспорта с шифрованием.
  /// </summary>
  public class DocumentExporterWithEncrypt : DocumentExporterBase
  {
    public DocumentExporterWithEncrypt(IExporter exported)
      : base(exported)
    {

    }

    public override void Export(string path)
    {
      base.Export(path);
      this.Encrypt(path);
    }

    private void Encrypt(string path)
    {
      Console.WriteLine($"Файлы в папке {path} зашифрованы");
      FileEncryptor.Encrypt(path);
    }
  }
}
