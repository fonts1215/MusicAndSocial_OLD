using MongoDB.Driver;
using MusicAndSocial.Common.Utils;

namespace MusicAndSocial.Databases
{
    public class MongoDatabase : IMongoDatabase
    {
        private readonly IMongoClient client;

        public MongoDatabase(IMongoClient client)
        {
            this.client = client;
        }

        public MongoDBCode InsertUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
