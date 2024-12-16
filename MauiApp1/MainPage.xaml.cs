using MauiApp1.ViewModels;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _viewModel;

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            
            if (_viewModel.LoadItemsCommand.CanExecute(null))
            {
                await _viewModel.LoadItemsCommand.ExecuteAsync(null);
            }
        }
    }
}
