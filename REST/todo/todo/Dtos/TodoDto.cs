using System.ComponentModel.DataAnnotations;

namespace todo.Dtos
{
    public class TodoDto
    {
        [Required]
        public string TodoName { get; set; }
        [Required]
        public string TodoDescription { get; set; }
    }
}
