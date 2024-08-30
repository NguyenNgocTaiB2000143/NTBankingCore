using SQLite;
using BCrypt.Net;
using System.ComponentModel.DataAnnotations;

namespace NTBanking.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        
        public string? PasswordHash { get; set; }
        
        public void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }
}
