using todo.Models;

namespace todo.Services.Repository
{
    public interface ITodoRepository
    {
        void RegisterUser(TodoUser todoUser);
       TodoUser GetOneUser(string email);

        //todo
        List<Todo> GetAllTodo(string Email);
        void AddTodo(Todo todo);
    }
}