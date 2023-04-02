namespace todo.Helpers
{
     public class Helper
    {
        static public object Responce(bool error, string message, object data)
        {
            return new { error, message, data };
        }
    }
}
