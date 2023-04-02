using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Diagnostics;
using System.Security.Claims;
using todo.Models;

namespace todo.Services.Repository
{
    public class TodoRepository : ITodoRepository
    {
        IMongoCollection<TodoUser> _TodoUser;
        IMongoCollection<Todo> _Todo;
        public TodoRepository(IMongoClient mongoClient, IOptions<TodoDbSettings> options)
        {
            var databse = mongoClient.GetDatabase(options.Value.DatabaseName);
            _TodoUser = databse.GetCollection<TodoUser>(options.Value.UserCollection);
             _Todo = databse.GetCollection<Todo>(options.Value.TodosCollection);
        }

        
        //auth
        public TodoUser GetOneUser(string email)
        {
            Debug.WriteLine(email+ " from repppsitory");
            return  _TodoUser.Find<TodoUser>(u => u.Email == email).FirstOrDefault();
        }

        async public void RegisterUser(TodoUser todoUser)
        {
            await _TodoUser.InsertOneAsync(todoUser);
        }

        //todo
        public List<Todo> GetAllTodo(string Email)
        {
          return  _Todo.Find<Todo>(u=>u.Email==Email).ToList();
        }

        public void AddTodo(Todo todo)
        {
           _Todo.InsertOne(todo);
        }
    }
}
