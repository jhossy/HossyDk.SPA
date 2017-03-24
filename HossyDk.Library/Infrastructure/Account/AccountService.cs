using HossyDk.Library.Account.Infrastructure;
using HossyDk.Library.Interfaces;
using System;
using System.Linq;

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
    }
}
