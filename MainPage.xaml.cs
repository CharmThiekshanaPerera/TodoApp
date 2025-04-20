using TodoApp.Models;
using TodoApp.ViewModels;

namespace TodoApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.BindingContext is TodoItem item)
        {
            var viewModel = BindingContext as MainViewModel;
            viewModel?.ToggleCompleteCommand.Execute(item);
        }
    }
}
