﻿using GestaoLivraria.Enumeration;

namespace GestaoLivraria.Communication
{
    public class BookRequestJson
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; } 
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
