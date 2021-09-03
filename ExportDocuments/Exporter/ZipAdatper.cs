using ExportDocuments.ExternalLibs;

namespace ExportDocuments.Exporter
{
  public class ZipAdatper : IZipper
  {
    private readonly Compression compression;

    public ZipAdatper(Compression comp)
    {
      this.compression = comp;
    }

    public void Zip(string sourceDirectoryName, string destinationArchiveFileName)
    {
      this.compression.Compress(sourceDirectoryName, destinationArchiveFileName);
    }
  }
}
