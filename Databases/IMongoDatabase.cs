using MusicAndSocial.Common.Utils;

namespace MusicAndSocial.Databases
{
    public interface IMongoDatabase
    {
        public MongoDBCode InsertUser(User user);
    }
}
