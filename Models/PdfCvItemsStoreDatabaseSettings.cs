namespace PdfService.Models
{  // This is a container of data base details from the section in appsettings.json
    public class PdfCvItemsStoreDatabaseSettings : IPdfCvItemsStoreDatabaseSettings
    {
        public string PdfCvItemsCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
