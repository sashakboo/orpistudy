using System.IO;

namespace ExportDocuments.Wrappers
{
  public class FileEncryptor
  {
    public static void Encrypt(string path)
    {
      string encryptFileMark = Path.Combine(path, "encrypt");
      using (File.Create(encryptFileMark))
      { };
    }
  }
}
