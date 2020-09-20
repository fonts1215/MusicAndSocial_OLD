using MongoDB.Bson.Serialization.Attributes;

namespace MusicAndSocial.Models
{
    public class Genre
    {
        [BsonId]
        public int GenreId { get; set; }
        [BsonElement("")]
        public string GenreName { get; set; }
        public int MyProperty { get; set; }

    }
}
