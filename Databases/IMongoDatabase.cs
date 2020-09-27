using MusicAndSocial.Common.Utils;
using MusicAndSocial.Models;
using System.Threading.Tasks;

namespace MusicAndSocial.Databases
{
    public interface IMongoDatabase
    {
        public MongoDBCode InsertUser(User user);
        public Task<User> FindUser(string email);
        public string GetToken(string email);
        public MongoDBCode UpdateToken(string email, string token);
    }
}
