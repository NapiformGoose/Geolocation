using Geolocation.Logic.Api.Models;
using Geolocation.ObjectStorage.Api.Services;
using MongoDB.Driver;

namespace Geolocation.ObjectStorage.Core.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoDatabase database)
        {
            _users = database.GetCollection<User>("Users");
        }

        public string Create(User scenario)
        {
            _users.InsertOne(scenario);
            return scenario.Id;
        }

        public string Delete(string id)
        {
            _users.DeleteOne(s => s.Id == id);
            return id;
        }

        public User Edit(User user)
        {
            var filter = Builders<User>.Filter.Where(s => s.Id == user.Id);
            _users.ReplaceOne(filter, user);
            return user; //todo протестировать изменение
        }

        public User Get(string id)
        {
            var filter = Builders<User>.Filter.Where(s => s.Id == id);
            return _users.Find(filter).FirstOrDefault();
        }

        public IQueryable<User> GetAll()
        {
            return _users.AsQueryable();
        }
    }
}
