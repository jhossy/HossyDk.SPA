using System;

namespace HossyDk.Library.Account.Infrastructure
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string userName, string password)
        {
            if(userName == null)
            {
                throw new ArgumentNullException(userName);
            }

            if(password == null)
            {
                throw new ArgumentNullException(password);
            }

            Username = userName;
            Password = password;
        }
    }
}
