using Entity;
using Repository;

namespace Service
{
    public class userService
    {

        userRepository userRepository = new userRepository();

        public User addUser(User user)
        {
            int res = checkPassword(user.Password);
            if (res > 2)
                return userRepository.addUser(user);
            else
                return null;
        }

        public User getUserByEmailAndPassword(string userName, string password)
        {
            return userRepository.getUserByEmailAndPassword(userName, password);
        }

        public User updateUser(int id, User user)
        {
            int res = checkPassword(user.Password);
            if (res > 2)
                return userRepository.updateUser(id, user);
            else
                return null;

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