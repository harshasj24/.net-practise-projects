using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Posts.Dtos;
using Posts.models;
using Posts.repository;

namespace Posts.Controllers
{
    [Route("[controller]")]
    [EnableCors("*")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly IPostRepository _reppo;
        public PostsController(IPostRepository reppo)
        {
            this._reppo = reppo;
        }
        [HttpGet]
        public IEnumerable<PostDto> getPosts()

        {
            var posts = _reppo.GetPost();
            return posts.Select(post => post.AsDto());
        }

        [HttpGet("{id}")]
        public ActionResult<PostDto> getOnePost(Guid id)
        {
            var post = _reppo.GetOnePost(id);
            if (post is null)
            {
                return NotFound();
            }
            return post.AsDto();
        }
        [HttpPost]
        public ActionResult AddPost(AddPostDto post)
        {
            Post newPost = new Post {
                id = Guid.NewGuid(),
                postName = post.postName,
                postDescription = post.postDescription,
            };
            _reppo.Addpost(newPost);
            return CreatedAtAction(nameof(getOnePost), new { id = newPost.id }, newPost.AsDto());
        }
        [HttpPut]
        public ActionResult<UpdatePostDto> UpdatePost(UpdatePostDto post) {


            var ExistingPost = getOnePost(post.id);
            if (ExistingPost is null)
            {
                return NotFound();
            }
            Post UpdatedPost = new()
            {
                id = post.id,
                postName = post.postName,
                postDescription = post.postDescription,

            };
            _reppo.Updatepost(UpdatedPost);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Post> DeletePost(Guid id)
        {
            var isItemExists=getOnePost(id);
            if (isItemExists is null)
            {
                return NotFound();
            }
            _reppo.Deletepost(id);
            return NoContent();
        }
    }
} 
