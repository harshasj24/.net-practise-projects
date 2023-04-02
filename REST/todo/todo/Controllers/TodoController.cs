using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using todo.Dtos;
using todo.Helpers;
using todo.Models;
using todo.Services.Repository;

namespace todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        ITodoRepository _Reppo;
        public TodoController(ITodoRepository Reppo)
        {
            _Reppo= Reppo;  
        }

        [Authorize]

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllTodo()
        {
            if (GetCurrentUserEmail() == String.Empty)
            {
                return NotFound("Cannot able to reterive the data");
            }
            List<Todo> todos=_Reppo.GetAllTodo(GetCurrentUserEmail());
            return Ok(Helper.Responce(false, "All todos of an user", todos));
        }



        //add todo

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public IActionResult Add(TodoDto todo)
        {
            Todo NewTodo = new()
            {
                TodoName=todo.TodoName,
                TodoDescription=todo.TodoDescription,
                CreatedDateTime=DateTime.Now,
                Email=GetCurrentUserEmail()
            };

            _Reppo.AddTodo(NewTodo);
            return Ok(Helper.Responce(false,"Todo Added Successfully",NewTodo));
        }

        //private methods
        private string GetCurrentUserEmail()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                var email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email).Value;
                return email;
            }
            return string.Empty;
        }
    }
}
