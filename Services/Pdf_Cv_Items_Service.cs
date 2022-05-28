using MongoDB.Driver;
using PdfService.Models;

namespace PdfService.Services
{
    public class Pdf_Cv_Items_Service : IPdf_Cv_Items_Service
    {
        private readonly IMongoCollection<Pdf_Cv_Items> _pdf_cv_items_collection;
        //injections by the parameters
        public Pdf_Cv_Items_Service(IPdfCvItemsStoreDatabaseSettings settings, IMongoClient mongoClient)
        {   //getting db name from appsettings.json
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            //and the collection name
            _pdf_cv_items_collection = database.GetCollection<Pdf_Cv_Items>(settings.PdfCvItemsCollectionName);
        }
        // getting specific record from the collection by its id
        public Pdf_Cv_Items Get(string id)
        {
            return _pdf_cv_items_collection.Find(pdfitems => pdfitems.Id == id).FirstOrDefault();
        }
        //inserting a new record to the collection 
        public Pdf_Cv_Items Create(Pdf_Cv_Items pdf_cv_items)
        {
            _pdf_cv_items_collection.InsertOne(pdf_cv_items);
            return pdf_cv_items;
        }
    }
}
