using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Category]")]

    public class Category
    {
        public Category()
          => Categories = new List<Posts>();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public List<Posts> Categories { get; set; }

    }
}
