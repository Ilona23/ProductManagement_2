using System.ComponentModel.DataAnnotations;

namespace ProductManagement_2.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
