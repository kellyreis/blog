using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[User]")]

    public class User
    {

        public User()
        => roles = new List<Role>();


        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }

        //Para n incluir no crud Insert
        [Write(false)]
        public List<Role> roles { get; set; }
    }
}
