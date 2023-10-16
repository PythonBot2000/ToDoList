using System.ComponentModel.DataAnnotations;

namespace ToDoList
{
    public class MyTask
    {
        [Key]
        public int id { get; set; }
        public DateTime dateTime { get; set; }
        public string taskText { get; set; } = "";
    }
}