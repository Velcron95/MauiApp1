using MauiApp1.ViewModels;
using System.Diagnostics;

namespace MauiApp1;

public partial class ItemDetailPage : ContentPage
{
    public ItemDetailPage(AddTaskViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

       
    }

}