using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PdfService.Models
{
    [BsonIgnoreExtraElements]// Used where a record has extra fields over those of this class
    // This is the entity class to use by mongodb tools (get , insert, update etc') for records
    public class Pdf_Cv_Items
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("phone")]
        public string Phone { get; set; } = String.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = String.Empty;

        [BsonElement("linkedin")]
        public string LinkedIn { get; set; } = String.Empty;

        [BsonElement("entirefile")]
        public string EntireFile { get; set; } = String.Empty;

    }
}
