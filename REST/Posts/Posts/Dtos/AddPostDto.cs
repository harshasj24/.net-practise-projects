using System.ComponentModel.DataAnnotations;

namespace Posts.Dtos
{
    public class AddPostDto
    {
        [Required]
        public string postName { get; init; }
        [Required]
        public string postDescription { get; init; }
    }
}
 