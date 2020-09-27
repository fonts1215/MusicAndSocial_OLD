using MongoDB.Bson;
using MongoDB.Driver;
using MusicAndSocial.Common.Utils;
using MusicAndSocial.Models;
using System;
using System.Threading.Tasks;

namespace MusicAndSocial.Databases
{
    public class MongoDatabase : IMongoDatabase
    {
        private readonly IMongoClient client;

        public MongoDatabase(IMongoClient client)
        {
            this.client = client;
        }

        public async Task<User> FindUser(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            var db = client.GetDatabase("MusicAndSocial");
            var collection = db.GetCollection<User>("users");

            var filter = new BsonDocument("email", email);
            var result = await collection.FindAsync(filter);
            return result.FirstOrDefault();
        }

        public string GetToken(string email)
        {
            throw new System.NotImplementedException();
        }

        public MongoDBCode InsertUser(User user)
        {
            if (user != null && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password))
            {
                var db = client.GetDatabase("MusicAndSocial");
                var collection = db.GetCollection<User>("users");
                collection.InsertOne(user);
                return MongoDBCode.Success;
            }
            else
                return MongoDBCode.Failed;           
        }

        public MongoDBCode UpdateToken(string email, string token)
        {
            throw new System.NotImplementedException();
        }
    }
}