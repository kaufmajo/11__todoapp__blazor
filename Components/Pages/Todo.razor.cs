using TodoList.Model;
using TodoList.Services;

namespace TodoList.Components.Pages;

public partial class Todo
{
    private List<TodoItem> todoItems = new List<TodoItem>();
    private string newTodoTitle = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override async Task OnInitializedAsync()
    {
        todoItems = (await TodoService.GetTodoItemsAsync()).ToList();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private async Task AddTodoItem()
    {
        string newTodoTitle = Model?.Title ?? string.Empty;

        if (!string.IsNullOrWhiteSpace(newTodoTitle))
        {
            var newItem = new TodoItem { Title = newTodoTitle, IsDone = false };
            await TodoService.AddTodoItemAsync(newItem);
            todoItems.Add(newItem);
            newTodoTitle = string.Empty;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private async Task UpdateTodoItem(TodoItem item)
    {
        await TodoService.UpdateTodoItemAsync(item);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private async Task DeleteTodoItem(int id)
    {
        await TodoService.DeleteTodoItemAsync(id);
        todoItems.RemoveAll(item => item.Id == id);
    }
}