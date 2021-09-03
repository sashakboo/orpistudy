using ExportDocuments.ExternalLibs;

namespace ExportDocuments.Exporter
{
  public class EncryptAdapter : IEncryptor
  {
    private readonly Encryption encryptor;

    public EncryptAdapter(Encryption encryptor)
    {
      this.encryptor = encryptor;
    }

    public void Encrypt(string path)
    {
      byte[] data = new byte[0];

      this.encryptor.Encrypt(data, path);
    }
  }
}
