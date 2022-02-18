using Geolocation.Logic.Api.Models;
using Geolocation.Logic.Api.Services;
using Geolocation.ObjectStorage.Api.Services;

namespace Geolocation.Logic.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IDataService dataService)
        {
            _userRepository = dataService.Users;
        }

        public User Get(string userId)
        {
            return _userRepository.Get(userId);
        }

        public string Create(User user)
        {
            return _userRepository.Create(user);
        }

        public string Delete(string userId)
        {
            return _userRepository.Delete(userId);
        }

        public User Edit(User user)
        {
            return _userRepository.Edit(user);
        }

        public List<User> List()
        {
            return _userRepository.GetAll().ToList();
        }
    }
}
