using Entity;

namespace Repository
{
    public interface IuserRepository
    {
        User addUser(User user);
        User getUserByEmailAndPassword(string userName, string password);
        User updateUser(int id, User userToUpdate);
    }
}