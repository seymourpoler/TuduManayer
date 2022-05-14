using System;

namespace TuduManayer.Domain.User
{
    public class User
    {
        public string Email { get; }
        public string Password { get; }
        public DateTime CreationDate { get; }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
            CreationDate = DateTime.UtcNow;
        }
    }
}