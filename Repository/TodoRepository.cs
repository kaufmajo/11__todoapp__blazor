using Dapper;
using System.Data;
using MySqlConnector;
using TodoList.Model;

namespace TodoList.Repository
{
    public class TodoRepository
    {
        private readonly string _connectionString;
        private IDbConnection Connection => new MySqlConnection(_connectionString);

        public TodoRepository(IConfiguration configuration)
        {
            _connectionString = DotEnv.Get(configuration.GetConnectionString("DefaultConnection") ?? "");
        }

        public async Task<List<TodoItem>> GetTodoItemsAsync()
        {
            using (var connection = Connection)
            {
                connection.Open();
                IEnumerable<TodoItem> result = await connection.QueryAsync<TodoItem>("select * from todoitems2");
                return result.ToList();
            }
        }

        public async Task<int> GetTodoItemsCountAsync()
        {
            using (var connection = Connection)
            {
                connection.Open();
                int result = await connection.ExecuteScalarAsync<int>("select count(*) from todoitems2");
                return result;
            }
        }

        public async Task AddTodoItemAsync(TodoItem todoItem)
        {
            using (var connection = Connection)
            {
                connection.Open();
                await connection.ExecuteAsync("insert into todoitems2 (Title, IsCompleted) values (@Title, @IsCompleted)", todoItem);
            }
        }

        public async Task UpdateTodoItemAsync(TodoItem todoItem)
        {
            using (var connection = Connection)
            {
                connection.Open();
                await connection.ExecuteAsync("update todoitems2 set Title=@Title, IsCompleted=@IsCompleted where Id=@Id", todoItem);
            }
        }

        public async Task RemoveTodoItemAsync(int todoItemId)
        {
            using (var connection = Connection)
            {
                connection.Open();
                await connection.ExecuteAsync("delete from todoitems2 where id=@TodoItemId", new { TodoItemId = todoItemId });
            }
        }
    }
}