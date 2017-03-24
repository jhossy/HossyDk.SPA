using HossyDk.Library.Account.Infrastructure;
using HossyDk.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HossyDk.Library.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private List<User> _db;

        public UserRepository()
        {
            _db = new List<User>();
        }

        public void Add(User entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            if(string.IsNullOrEmpty(entity.Username) ||
                string.IsNullOrEmpty(entity.Password))
            {
                throw new NullReferenceException("entity.Username and entity.Password cannot be NULL");
            }

            _db.Add(entity);
        }

        public IEnumerable<User> GetAll()
        {
            return _db.ToList();
        }
    }
}
