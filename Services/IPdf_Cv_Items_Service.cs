using PdfService.Models;

namespace PdfService.Services
{
    public interface IPdf_Cv_Items_Service
    {
        Pdf_Cv_Items Get(string id);
        Pdf_Cv_Items Create(Pdf_Cv_Items pdf_cv_items);
    }
}
