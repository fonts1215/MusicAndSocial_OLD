using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MusicAndSocial.Models
{
    public class User
    {
        [BsonId]
        public ObjectId UserId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("surname")]
        public string Surname { get; set; }

        [BsonElement("birth")]
        public DateTime Birth { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("token")]
        public string Token { get; set; }

        [BsonElement("genres")]
        public List<Genre> Genres { get; set; }
    }
}
