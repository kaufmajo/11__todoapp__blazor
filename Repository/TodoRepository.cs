using System.Data;
using TodoList.Model;

namespace TodoList.Repository
{
    public class TodoRepository
    {
        private readonly string _connectionString;
        private const string TODOITEM_DATABASE = "TodoItemDatabase";
        private const string SELECT_TODOITEMS = "select * from todoitem";
        public TodoRepository(IConfiguration configuration)
        {
            _connectionString = DotEnv.Get(configuration.GetConnectionString("DefaultConnection") ?? "");
        }

        public async Task<List<TodoItem>> GetBugsAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
            {
                db.Open();
                IEnumerable<TodoItem> result = await db.QueryAsync<Bug>(SELECT_BUG);
                return result.ToList();
            }
        }

        public async Task<int> GetBugCountAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
            {
                db.Open();
                int result = await db.ExecuteScalarAsync<int>("select count(*) from bugs");
                return result;
            }
        }

        public async Task AddBugAsync(TodoItem todoItem)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("insert into bugs (Summary, BugPriority, Assignee, BugStatus) values (@Summary, @BugPriority, @Assignee, @BugStatus)", bug);
            }
        }

        public async Task UpdateBugAsync(TodoItem todoItem)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("update bugs set Summary=@Summary, BugPriority=@BugPriority, Assignee=@Assignee, BugStatus=@BugStatus where id=@Id", bug);
            }
        }

        public async Task RemoveBugAsync(int todoItemId)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BUGTRACKER_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("delete from bugs Where id=@BugId", new { BugId = bugid });
            }
        }
    }
}