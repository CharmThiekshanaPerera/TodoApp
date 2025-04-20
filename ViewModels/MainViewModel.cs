using System.Collections.ObjectModel;
using System.Windows.Input;
using TodoApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TodoApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<TodoItem> Todos { get; set; } = new();

        [ObservableProperty]
        private string newTodoText;

        public MainViewModel()
        {
            // Initialize newTodoText to avoid nullability issues
            newTodoText = string.Empty;

            // Sample data
            Todos.Add(new TodoItem { Title = "Learn MAUI", IsCompleted = false });
        }

        [RelayCommand]
        private void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(NewTodoText))
            {
                Todos.Add(new TodoItem { Title = NewTodoText });
                NewTodoText = string.Empty;
            }
        }

        [RelayCommand]
        private void DeleteTodo(TodoItem item)
        {
            Todos.Remove(item);
        }

        [RelayCommand]
        private void ToggleComplete(TodoItem item)
        {
            item.IsCompleted = !item.IsCompleted;
        }
    }
}
