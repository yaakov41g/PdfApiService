namespace PdfService.Models
{
    public interface IPdfCvItemsStoreDatabaseSettings
    {
        string PdfCvItemsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
