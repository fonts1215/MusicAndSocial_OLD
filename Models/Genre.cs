using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MusicAndSocial.Models
{
    public class Genre
    {
        [BsonId]
        public ObjectId GenreId { get; set; }

        [BsonElement("name")]
        public string GenreName { get; set; }

        [BsonElement("index_nopopularity")]
        public int IndexNopopularity { get; set; }

    }
}
