using Microsoft.Maui.Controls;
using TodoApp.Models;
using TodoApp.ViewModels;

namespace TodoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender is CheckBox checkbox && checkbox.BindingContext is TodoItem item)
            {
                var viewModel = BindingContext as MainViewModel;
                viewModel?.ToggleCompleteCommand.Execute(item);
            }
        }
    }
}
// This code is part of a simple Todo application using .NET MAUI and MVVM pattern.
// It defines the MainPage class, which is the main user interface of the application.