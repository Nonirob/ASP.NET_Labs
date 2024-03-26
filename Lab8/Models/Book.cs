﻿namespace Lab8.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        
        public int? Price { get; set; }
        
        public DateTime PublishDate { get; set; }
    }
}