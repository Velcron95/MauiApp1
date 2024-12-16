using SQLite;

namespace MauiApp1.Models
{
    public class ToDoList
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsEditing { get; set; } 
        public bool IsDone { get; set; } = false;

        public ToDoList() { }
    }
}
