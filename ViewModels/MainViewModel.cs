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
        private string newTodoText = string.Empty;

        public MainViewModel()
        {
            Todos.Add(new TodoItem { Title = "Learn MAUI", IsCompleted = false });
            Todos.Add(new TodoItem { Title = "Do groceries", IsCompleted = true });
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

            // Optional: force refresh UI
            var index = Todos.IndexOf(item);
            Todos.RemoveAt(index);
            Todos.Insert(index, item);
        }

        [RelayCommand]
        private async Task EditTodo(TodoItem item)
        {
            if (item == null) return;

            var mainPage = Application.Current?.Windows.FirstOrDefault()?.Page;
            if (mainPage == null) return;

            string result = await mainPage.DisplayPromptAsync(
                "Edit Task",
                "Update the task title:",
                initialValue: item.Title
            );

            if (!string.IsNullOrWhiteSpace(result))
            {
                item.Title = result;

                // Optional: force UI update
                var index = Todos.IndexOf(item);
                Todos.RemoveAt(index);
                Todos.Insert(index, item);
            }
        }
    }
}
// Compare this snippet from AppShell.xaml.cs:
// using System;