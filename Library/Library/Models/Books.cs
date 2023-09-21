using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Books
    {
        [Key]

        public int BookId { set; get; }
        public string Name { set; get; }
        public double Price { set; get; }
        public string Serial { set; get; }
        public int SectionId { set; get; }
        public Section Section { set; get; }

    }
}
