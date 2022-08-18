using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace PrettoPall.Data.Models
{
	public class Player
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

    }
}
