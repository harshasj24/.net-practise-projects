using Posts.models;

namespace Posts.repository
{
    public interface IPostRepository
    {
        Post GetOnePost(Guid id);
        IEnumerable<Post> GetPost();

        void Addpost(Post post);

        void Updatepost(Post post);

        void Deletepost(Guid id);
    }
}