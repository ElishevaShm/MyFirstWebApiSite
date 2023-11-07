using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Text.Json;

namespace Repository
{
    public class userRepository : IuserRepository
    {
        private readonly WebElectricStore1Context _webElectricStore1Context;

        public userRepository(WebElectricStore1Context webElectricStore1Context)
        {
            _webElectricStore1Context = webElectricStore1Context;
        }

        //private readonly string filePath = "../Users.txt";
        public async Task<User> getUserByEmailAndPassword(string userName, string password)
        {
            return await _webElectricStore1Context.Users.Where(user => user.UserName == userName && user.Password == password).FirstOrDefaultAsync();
            
        }


        public async Task<User> getUserById(int id)
        { 
            return await _webElectricStore1Context.Users.FindAsync(id);
        }

        public async Task<User> addUser(User user)
        {

            await _webElectricStore1Context.Users.AddAsync(user);
            await _webElectricStore1Context.SaveChangesAsync();

            return user;
        }


        public async Task updateUser(int id, User user)
        {
            _webElectricStore1Context.Update(user);
            await _webElectricStore1Context.SaveChangesAsync();
        }
    }
}