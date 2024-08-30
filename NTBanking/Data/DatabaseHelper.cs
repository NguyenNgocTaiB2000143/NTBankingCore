using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using NTBanking.Models;

namespace NTBanking.Data
{
    public class DatabaseHelper
    {
        readonly SQLiteAsyncConnection _database;

        public DatabaseHelper(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
           
        }

       

        public async Task<int> SaveUserAsync(User user)
        {
            if (user == null || string.IsNullOrEmpty(user.PhoneNumber))
            {
                throw new ArgumentException("User or PhoneNumber cannot be null");
            }

            var existingUser = await GetUserByPhoneNumberAsync(user.PhoneNumber);
            if (existingUser != null)
            {
                user.Id = existingUser.Id; // Update existing user
                return await _database.UpdateAsync(user);
            }
            else
            {
                return await _database.InsertAsync(user); // Insert new user
            }
        }


        public Task<int> UpdateUserAsync(User user)
        {
            return _database.UpdateAsync(user);
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }

        public Task<User> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            return _database.Table<User>().Where(u => u.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public async Task<bool> LoginUserAsync(string phoneNumber, string password)
        {
            var user = await GetUserByPhoneNumberAsync(phoneNumber);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return true;
            }
            return false;
        }



        public Task<User> GetUserAsync(string phoneNumber)
        {
            return _database.Table<User>().Where(u => u.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }

       

    }
}
