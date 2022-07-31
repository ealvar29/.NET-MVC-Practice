using System.ComponentModel.DataAnnotations;

namespace AnimeGirls.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int DiplayOrder { get; set; }
    }
}
