using MongoDB.Driver;
using MusicAndSocial.Common.Utils;
using MusicAndSocial.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicAndSocial.Databases
{
    public interface IMongoDatabase
    {
        public MongoDBCode InsertUser(User user);
        public Task<User> FindUser(string email);
        public Task<User> FindUserById(Guid guid);
        public string GetToken(string email);
        public MongoDBCode UpdateToken(string email, string token);
        public MongoDBCode UserIsPresent(string email);
        public Task<List<Genre>> GetAllGenre();
        public MongoDBCode UserUpdateGenres(string email, List<Genre> genres);
        public Task<List<Genre>> GetGenre(Guid id_user);
    }
}
