using Entity;
using Repository;

namespace Service
{
    public class userService : IuserService
    {

        private readonly IuserRepository _userRepository;

        public userService(IuserRepository userRepository)
        {
              _userRepository = userRepository;
        }

        public async Task<User> addUser(User user)
        {
            int res = checkPassword(user.Password);
            if (res > 2)
               return await _userRepository.addUser(user);
            else
                return null;
        }

        public async Task<User> getUserByEmailAndPassword(string userName, string password)
        {
            return await _userRepository.getUserByEmailAndPassword(userName, password);
        }

        public async Task<User> getUserById(int id)
        {
            return await _userRepository.getUserById(id);
        }

        public async Task updateUser(int id, User user)
        {
            int res = checkPassword(user.Password);
            if (res > 2)
                await _userRepository.updateUser(id, user);

        }

       

        public int checkPassword(string pwd)
        {
            if (pwd != "")
            {
                var result = Zxcvbn.Core.EvaluatePassword(pwd);
                return result.Score;
            }
            return -1;
        }
    }
}