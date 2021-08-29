using System;

namespace ExportDocuments.Exporter
{
  /// <summary>
  /// Декоратор для экспорта с шифрованием.
  /// </summary>
  public class DocumentExporterWithEncrypt : ExporterDecoratorBase
  {
    private IEncryptor encryptor;

    public DocumentExporterWithEncrypt(IExporter exported, IEncryptor encryptor)
      : base(exported)
    {
      this.encryptor = encryptor;
    }

    public override void Export(string path)
    {
      base.Export(path);
      this.Encrypt(path);
    }

    private void Encrypt(string path)
    {
      Console.WriteLine($"Файлы в папке {path} зашифрованы");
      this.encryptor.Encrypt(path);
    }
  }
}
