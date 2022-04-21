using System;

namespace Dominio.Entidades
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Complete { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
