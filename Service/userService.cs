using Entity;
using Repository;

namespace Service
{
    public class userService : IuserService
    {

        private readonly IuserRepository userRepository;

        public userService(IuserRepository iuserRepository)
        {
              userRepository = iuserRepository;
        }

        public async Task<User> addUser(User user)
        {
            int res = checkPassword(user.Password);
            if (res > 2)
               return await userRepository.addUser(user);
            else
                return null;
        }

        public async Task<User> getUserByEmailAndPassword(string userName, string password)
        {
            return await userRepository.getUserByEmailAndPassword(userName, password);
        }

        public async Task<User> getUserById(int id)
        {
            return await userRepository.getUserById(id);
        }

        public async Task updateUser(int id, User user)
        {
            int res = checkPassword(user.Password);
            if (res > 2)
                await userRepository.updateUser(id, user);

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