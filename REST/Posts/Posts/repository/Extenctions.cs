using Posts.Dtos;
using Posts.models;

namespace Posts.repository
{
    public static class Extenctions
    {

        public static PostDto AsDto( this Post post) {
            return new PostDto
            {
                id = post.id,
                postName=post.postName,
                postDescription=post.postDescription
            };
        }
    }
}
