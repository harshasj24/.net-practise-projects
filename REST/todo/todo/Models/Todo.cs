using MongoDB.Bson.Serialization.Attributes;

namespace todo.Models
{
    public class Todo
    {
   
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Email { get; set; }
        public string TodoName { get; set; }
        public string TodoDescription { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
