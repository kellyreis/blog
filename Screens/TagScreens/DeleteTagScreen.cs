using System;
using Blog.Models;
using Blog.Repository;

namespace Blog.Screens.TagScreens
{
    public static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma tag");
            Console.WriteLine("-------------");
            Console.Write("Qual o id da Tag que deseja exluir? ");
            var id = Console.ReadLine();
            Delete(int.Parse(id));
            Console.ReadKey();
            MenuTagScreen.Load();
        }
        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);

                Console.WriteLine("Tag deletada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel deletar a tag");
                Console.WriteLine(ex.Message);
            }

        }
    }
}