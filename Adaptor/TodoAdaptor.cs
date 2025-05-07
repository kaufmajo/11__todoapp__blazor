using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;
using TodoList.Repository;
using TodoList.Model;

namespace TodoList.Adaptor
{
    public class TodoAdaptor : DataAdaptor
    {
        private TodoRepository _repository;
        public TodoAdaptor(TodoRepository todoRepository)
        {
            _repository = todoRepository;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            List<TodoItem> todoItems = await _repository.GetTodoItemsAsync();
            int count = await _repository.GetTodoItemsCountAsync();
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = todoItems, Count = count } : count;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _repository.AddTodoItemAsync(data as TodoItem);
            return data;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _repository.UpdateTodoItemAsync(data as TodoItem);
            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        {
            await _repository.RemoveTodoItemAsync(Convert.ToInt32(primaryKeyValue));
            return primaryKeyValue;
        }
    }

}