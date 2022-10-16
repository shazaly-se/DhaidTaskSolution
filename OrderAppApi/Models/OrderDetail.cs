using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderAppApi.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class OrderDetail
    {
        [BsonElement("product_id"), BsonRepresentation(BsonType.Int32)]
        public int ProductId { get; set; }
        [BsonElement("qty"), BsonRepresentation(BsonType.Int32)]
        public int Qty { get; set; }
        [BsonElement("price"), BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
    }
}
