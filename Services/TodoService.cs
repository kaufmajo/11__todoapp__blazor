using Dapper;
using MySqlConnector;
using System.Data;
using TodoList.Model;

namespace TodoList.Services
{
    public class TodoService
    {
        private readonly string _connectionString;

        public TodoService(IConfiguration configuration)
        {
            _connectionString = DotEnv.Get(configuration.GetConnectionString("DefaultConnection") ?? "");
        }

        private IDbConnection Connection => new MySqlConnection(_connectionString);

        // Alle To-Do-Elemente abrufen
        public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
        {
            using (var connection = Connection)
            {
                connection.Open();
                return await connection.QueryAsync<TodoItem>("SELECT * FROM TodoItems");
            }
        }

        // Ein neues To-Do-Element hinzufügen
        public async Task AddTodoItemAsync(TodoItem item)
        {
            using (var connection = Connection)
            {
                connection.Open();
                var query = "INSERT INTO TodoItems (Title, IsCompleted) VALUES (@Title, @IsCompleted); SELECT CAST(LAST_INSERT_ID() AS UNSIGNED INTEGER);";
                var lastInsertedId = await connection.QuerySingleAsync<int>(query, new { item.Title, item.IsDone });
                item.Id = lastInsertedId;
            }
        }

        // Ein To-Do-Element aktualisieren
        public async Task UpdateTodoItemAsync(TodoItem item)
        {
            using (var connection = Connection)
            {
                connection.Open();
                var query = "UPDATE TodoItems SET Title = @Title, IsCompleted = @IsCompleted WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { item.Title, item.IsDone, item.Id });
            }
        }

        // Ein To-Do-Element löschen
        public async Task DeleteTodoItemAsync(int id)
        {
            using (var connection = Connection)
            {
                connection.Open();
                var query = "DELETE FROM TodoItems WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
