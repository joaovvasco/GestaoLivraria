using GestaoLivraria.Enumeration;

namespace GestaoLivraria.Entities
{
    public class Book
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; } = 0;
    }
}
