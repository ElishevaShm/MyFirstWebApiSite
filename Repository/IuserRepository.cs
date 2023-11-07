using Entity;
using System.ComponentModel;

namespace Repository
{
    public interface IuserRepository
    {
        Task<User> addUser(User user);
        Task<User> getUserByEmailAndPassword(string userName, string password);
        Task updateUser(int id, User userToUpdate);
        Task<User> getUserById(int id);
    }
}