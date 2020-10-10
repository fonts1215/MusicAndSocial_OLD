using MongoDB.Bson;
using MongoDB.Driver;
using MusicAndSocial.Common.Utils;
using MusicAndSocial.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MusicAndSocial.Common.Constants.Database;
using static MusicAndSocial.Common.Constants.DatabaseLabels;


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

            var db = client.GetDatabase(DatabaseName);
            var collection = db.GetCollection<User>(UserCollection);

            var filter = new BsonDocument("email", email);
            var result = await collection.FindAsync(filter);
            return result.FirstOrDefault();
        }

        public async Task<User> FindUserById(Guid guid)
        {
            if (guid == null)
                return null;

            var db = client.GetDatabase(DatabaseName);
            var collection = db.GetCollection<User>(UserCollection);

            var filter = new BsonDocument("id", guid);
            var result = await collection.FindAsync(filter);
            return result.FirstOrDefault();
        }

        public async Task<List<Genre>> GetAllGenre()
        {
            var db = client.GetDatabase(DatabaseName);
            var collection = db.GetCollection<Genre>(GenreCollection);
            var result = await collection.FindAsync(new BsonDocument());

            return result.ToList();
        }

        public async Task<List<Genre>> GetGenre(Guid id_user)
        {
            User user = await FindUserById(id_user);

            if (user == null)
                return null;

            return user.Genres;
        }

        public string GetToken(string email)
        {
            throw new System.NotImplementedException();
        }

        public MongoDBCode InsertUser(User user)
        {
            if (user != null && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password))
            {
                var db = client.GetDatabase(DatabaseName);
                var collection = db.GetCollection<User>(UserCollection);

                var filter = new BsonDocument("email", user.Email);
                var result = collection.Find(filter);

                if (result.FirstOrDefault() != null)
                    return MongoDBCode.DataIsPresent;

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

        public MongoDBCode UserIsPresent(string email)
        {
            if (string.IsNullOrEmpty(email))
                return MongoDBCode.Failed;

            var db = client.GetDatabase(DatabaseName);
            var collection = db.GetCollection<User>(UserCollection);

            var filter = new BsonDocument("email", email);
            var result = collection.Find(filter);

            if (result.FirstOrDefault() != null)
                return MongoDBCode.DataIsPresent;
            else
                return MongoDBCode.DataNotPresent;
        }

        public MongoDBCode UserUpdateGenres(string email, List<Genre> genres)
        {
            if (genres != null && !string.IsNullOrEmpty(email))
            {
                var db = client.GetDatabase(DatabaseName);
                var collection = db.GetCollection<User>(UserCollection);

                var update = Builders<User>.Update.Set(Genres, genres);
                var filter = new BsonDocument("email", email);

                var updateResult = collection.UpdateOne(filter, update);
                if (updateResult.IsAcknowledged)
                    return MongoDBCode.Success;
                else
                    return MongoDBCode.Failed;
            }
            else
                return MongoDBCode.Failed;
        }           
        
    }
}