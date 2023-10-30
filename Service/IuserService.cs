using Entity;

namespace Service
{
    public interface IuserService
    {
        User addUser(User user);
        int checkPassword(string pwd);
        User getUserByEmailAndPassword(string userName, string password);
        User updateUser(int id, User user);
    }
}