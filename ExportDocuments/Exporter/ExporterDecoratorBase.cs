namespace ExportDocuments.Exporter
{
  /// <summary>
  /// Базовый декоратор для экспортируемых документов.
  /// </summary>
  public abstract class ExporterDecoratorBase : IExporter
  {
    protected IExporter exported;

    protected ExporterDecoratorBase(IExporter exported)
    {
      this.exported = exported;
    }

    public virtual void Export(string path)
    {
      this.exported.Export(path);
    }
  }
}
