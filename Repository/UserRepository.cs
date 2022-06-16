using System.Collections.Generic;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repository
{
    public class UserRepository
    {

        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
           => _connection = connection;


        public IEnumerable<User> GetAll()
            => _connection.GetAll<User>();

        public User Get(int id)
            => _connection.Get<User>(id);

        public void Create(User user)
        {
            user.Id = 0;
            return _connection.Insert<User>(user);
        }
        public void Update(User user)
        {
            if (user.Id != 0)
                return _connection.Update<User>(user);
        }
        public void Delete(User user)
        {
            if (user.Id != 0)
                return _connection.Delete<User>(user);
        }
        public void Delete(int id)
        {
            if (user.Id != 0)
                return;
            var user = _connection.Get<User>(id);
            _connection.Delete<User>(user);
        }
    }

}