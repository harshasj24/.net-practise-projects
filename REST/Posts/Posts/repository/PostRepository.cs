using Microsoft.Extensions.Hosting;
using Posts.models;
using System.Collections.Immutable;

namespace Posts.repository
{
    public class PostRepository : IPostRepository
    {
        public readonly List<Post> Posts = new()
        {
           new Post{id=Guid.NewGuid(),postName="my post 1",postDescription="HELLO ASDW QJUDEDDHJDKJJK JBDBHJDH JHBFJHDBFDFB JFJDHFDH "},
           new Post{id=Guid.NewGuid(),postName="my post 2",postDescription="HELLO ASDW QJUDEDDHJDKJJK JBDBHJDH JHBFJHDBFDFB JFJDHFDH "},
           new Post{id=Guid.NewGuid(),postName="my post 3",postDescription="HELLO ASDW QJUDEDDHJDKJJK JBDBHJDH JHBFJHDBFDFB JFJDHFDH "},
           new Post{id=Guid.NewGuid(),postName="my post 4",postDescription="HELLO ASDW QJUDEDDHJDKJJK JBDBHJDH JHBFJHDBFDFB JFJDHFDH "},
        };
        readonly string myname = "harsha";

        public IEnumerable<Post> GetPost()
        {
          return Posts;
        }

        public Post GetOnePost(Guid id)
        {
            return Posts.Where<Post>(post => post.id == id).SingleOrDefault();
        }

        public void Addpost(Post post)
        {
            Posts.Add(post);
        }

        public void Updatepost(Post post)
        {
            var index = Posts.FindIndex(currentPost=>currentPost.id == post.id);
            Posts[index] = post;
        }

        public void Deletepost(Guid id)
        {   
            var index = Posts.FindIndex(currentPost => currentPost.id == id);
            Posts.RemoveAt(index);
        }
    }
}
