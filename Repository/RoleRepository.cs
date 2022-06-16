using System.Collections.Generic;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repository
{
    public class RoleRepository
    {
        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection connection)
           => _connection = connection;


        public IEnumerable<Role> GetAll()
            => _connection.GetAll<Role>();

        public Role Get(int id)
            => _connection.Get<Role>(id);

        public void Create(Role role)
        {
            user.Id = 0;
            return _connection.Insert<Role>(role);
        }
        public void Update(Role role)
        {
            if (role.Id != 0)
                return _connection.Update<Role>(role);
        }
        public void Delete(Role role)
        {
            if (role.Id != 0)
                return _connection.Delete<Role>(role);
        }
        public void Delete(int id)
        {
            if (role.Id != 0)
                return;

            var role = _connection.Get<Role>(id);
            _connection.Delete<Role>(role);
        }

    }
}