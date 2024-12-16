using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;

namespace MauiApp1.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        
        [ObservableProperty]
        private ObservableCollection<ToDoList> listItem = new();

        
        [ObservableProperty]
        private ToDoList selectedTask;

        
        [ObservableProperty]
        private bool isEditModalVisible = false;  

        
        public IAsyncRelayCommand LoadItemsCommand { get; }
        public IAsyncRelayCommand DeleteAllCheckedCommand { get; }
        public IRelayCommand<ToDoList> EditTaskCommand { get; }  
        public IAsyncRelayCommand SaveEditCommand { get; }
        public IRelayCommand ClosePopupCommand { get; }

        public MainViewModel()
        {
            
            LoadItemsCommand = new AsyncRelayCommand(LoadItemsAsync);
            DeleteAllCheckedCommand = new AsyncRelayCommand(DeleteAllCheckedAsync);
            EditTaskCommand = new RelayCommand<ToDoList>(OpenEditPopup);
            SaveEditCommand = new AsyncRelayCommand(SaveEditedTask);
            ClosePopupCommand = new RelayCommand(ClosePopup);
        }

        
        public async Task LoadItemsAsync()
        {
            try
            {
                IsBusy = true;
                var items = await App.Database.GetItemsAsync();
                ListItem.Clear();
                foreach (var item in items)
                {
                    ListItem.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading items: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        
        private void OpenEditPopup(ToDoList task)
        {
            if (task != null)
            {
                SelectedTask = task;
                IsEditModalVisible = true; 
            }
        }


        
        public async Task DeleteAllCheckedAsync()
        {
            var tasksToDelete = ListItem.Where(task => task.IsDone).ToList();

            foreach (var task in tasksToDelete)
            {
                await App.Database.DeleteItemAsync(task);
                ListItem.Remove(task);
            }
        }

        
        private async Task SaveEditedTask()
        {
            if (SelectedTask != null)
            {
                
                if (SelectedTask.Id != 0)
                {
                    
                    var taskToUpdate = await App.Database.GetItemAsync(SelectedTask.Id);

                    if (taskToUpdate != null)
                    {
                        
                        taskToUpdate.Name = SelectedTask.Name;
                        taskToUpdate.Description = SelectedTask.Description;

                        
                        await App.Database.UpdateAsync(taskToUpdate);
                        await LoadItemsAsync(); 
                    }
                }
            }

            
            ClosePopup();
        }


        
        private void ClosePopup()
        {
            IsEditModalVisible = false;  
        }
    }
}
