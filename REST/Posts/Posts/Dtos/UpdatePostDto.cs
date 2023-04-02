using System.ComponentModel.DataAnnotations;

namespace Posts.Dtos
{
    public class UpdatePostDto
    {
        [Required]
        public Guid id { get; set; }
        [Required]
        public string postName { get; init; }
        [Required]
        public string postDescription { get; init; }
    }
}
