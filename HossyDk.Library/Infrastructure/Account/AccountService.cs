using HossyDk.Library.Account.Infrastructure;
using HossyDk.Library.Interfaces;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HossyDk.Library.Infrastructure.Account
{
    public class AccountService
    {
        private IRepository<User> _userRepository;

        public AccountService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Login(User user)
        {
            if(user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return false;
            }

            User userFound = _userRepository
                .GetAll()
                .SingleOrDefault(usr =>
                    usr.Username.Equals(user.Username, StringComparison.InvariantCultureIgnoreCase) &&
                    usr.Password.Equals(user.Password, StringComparison.InvariantCultureIgnoreCase)
                );

            return userFound != null;
        }

        public string GenerateSaltedHash(string plainText, string salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextArray = Encoding.UTF8.GetBytes(plainText);
            byte[] saltArray = Encoding.UTF8.GetBytes(salt);

            byte[] plainTextWithSaltBytes = new byte[plainTextArray.Length + saltArray.Length];

            for (int i = 0; i < plainTextArray.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainTextArray[i];
            }
            for (int i = 0; i < saltArray.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = saltArray[i];
            }

            return Convert.ToBase64String(algorithm.ComputeHash(plainTextWithSaltBytes));
        }

        public bool ComparePasswords(string password, string validPassword)
        {
            return password.Equals(validPassword, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
