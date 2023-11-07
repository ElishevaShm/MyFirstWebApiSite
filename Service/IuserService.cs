using Entity;

namespace Service
{
    public interface IuserService
    {
        Task<User> addUser(User user);
        int checkPassword(string pwd);
        Task<User> getUserByEmailAndPassword(string userName, string password);
        Task updateUser(int id, User user);
        Task<User> getUserById(int id);
    }
}