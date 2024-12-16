using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiApp1.ViewModels
{
   
    public partial class AddTaskViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<ToDoList> listItem = new ObservableCollection<ToDoList>();

        [ObservableProperty]
        private string? newTask = "";

        [ObservableProperty]
        private string? newDescription = "";

        public IAsyncRelayCommand LoadItemsCommand { get; }

        [RelayCommand]
        async Task Add()
        {
            if (!string.IsNullOrEmpty(NewTask))
            {
                var newItem = new ToDoList
                {
                    Name = NewTask,
                    Description = NewDescription
                };

                await App.Database.SaveItemAsync(newItem);
                ListItem.Add(newItem);

                NewTask = "";
                NewDescription = "";
            }
        }

    }


}
