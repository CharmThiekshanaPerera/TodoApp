using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoApp.Models;

namespace TodoApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<TodoItem> Todos { get; set; } = new();

        [ObservableProperty]
        private string newTodoText = string.Empty;

        public MainViewModel()
        {
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
// This code defines the MainViewModel class, which is responsible for managing the state and behavior of the main page in a Todo application using .NET MAUI and MVVM pattern.
// It uses CommunityToolkit.Mvvm for implementing the MVVM pattern, including observable properties and commands.