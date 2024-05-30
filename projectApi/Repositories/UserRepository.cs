using Microsoft.EntityFrameworkCore;
using projectApi.Data;
using projectApi.Models;
using projectApi.Repositories.Interfaces;

namespace projectApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;
        public UserRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            var allUsers = await _dbContext.Users.ToListAsync();

            return allUsers;
        }
        public async Task<UserModel> GetUserById(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }
        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            
            return user;
        }
        public async Task<UserModel> UpdateUser(UserModel user, int id) 
        {
            var userById = await GetUserById(id); 

            if(userById == null)
            {
                throw new Exception($"User not found for ID:{id}");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return user;
        }
        public async Task<bool> DeleteUser(int id)
        {
            var userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception($"User not found for ID:{id}");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
