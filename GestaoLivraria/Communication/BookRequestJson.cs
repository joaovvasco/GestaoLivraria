using GestaoLivraria.Enumeration;

namespace GestaoLivraria.Communication
{
    public class BookRequestJson
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public Genre Genre { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
