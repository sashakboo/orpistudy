using System.IO.Compression;

namespace ExportDocuments.ExternalLibs
{
  public class Compression
  {
    public void Compress(string sourceDirectoryName, string destinationArchiveFileName)
    {
      ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName, CompressionLevel.Fastest, false);
    }
  }
}
