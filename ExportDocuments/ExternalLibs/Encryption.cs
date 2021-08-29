using System.IO;

namespace ExportDocuments.ExternalLibs
{
  public class Encryption
  {
    public void Encrypt(byte[] data, string destinationPath)
    {
      string encryptFileMark = Path.Combine(destinationPath, "encrypt");
      using (File.Create(encryptFileMark))
      { };
    }
  }
}
