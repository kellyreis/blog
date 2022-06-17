using System.Data;
using Blog.Models;
using System;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Blog.Repository;

namespace blog
{
    class Program
    {


        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            ReadUsers(connection);
            ReadRoles(connection);

            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var users = repository.GetAll();

            foreach (var item in users)
                Console.WriteLine(item.Name);

        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var roles = repository.GetAll();

            foreach (var item in roles)
                Console.WriteLine(item.Name);

        }
        //Busca Apenas um usuario


        public static void CreateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Bio = "Equipe BALTA.IO",
                Email = "teste@email.com",
                Image = "https://",
                Name = "Kelly teste",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };

            //Retorna long linhas afetadas
            var repository = new Repository<User>(connection);
            repository.Create(user);

            Console.WriteLine("cadastro realizado com sucesso");
        }
        public static void UpdateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Id = 1,
                Bio = "Equipe - BALTA.IO",
                Email = "teste@email.com",
                Image = "https://",
                Name = "Equipe de suporte",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };

            //Retorna long linhas afetadas
            connection.Update<User>(user);
            Console.WriteLine("Atualização realizada com sucesso");

        }
        public static void DeleteUser(SqlConnection connection)
        {
            var user = connection.Get<User>(1);
            //Retorna long linhas afetadas
            connection.Delete<User>(user);
            Console.WriteLine("Exclusão realizada com sucesso");
        }
    }
}
