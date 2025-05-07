using System.ComponentModel.DataAnnotations;

namespace TodoList.Model
{
    public class TodoItem
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(10, ErrorMessage = "Id is too long.")]
        public string? Title { get; set; }
        public bool IsDone { get; set; }
    }
}