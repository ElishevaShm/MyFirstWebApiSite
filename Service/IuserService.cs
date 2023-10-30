using Entity;

namespace Service
{
    public interface IuserService
    {
        User addUser(User user);
        int checkPassword(string pwd);
        Task<User> getUserByEmailAndPassword(string userName, string password);
        Task<User> updateUser(int id, User user);
        Task<User> getUserById(int id);
    }
}