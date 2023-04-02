namespace todo.Services.Repository
{
    public class TodoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string UserCollection { get; set; }

        public string TodosCollection { get; set; }
    }
}
