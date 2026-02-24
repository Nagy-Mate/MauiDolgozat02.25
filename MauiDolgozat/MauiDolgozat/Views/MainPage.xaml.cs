using MauiDolgozat.ViewModels;

namespace MauiDolgozat.Views; 

public partial class MainPage : ContentPage
{
    public MainPageViewModel mainPageViewModel => BindingContext as MainPageViewModel;

    public MainPage(MainPageViewModel mainPageViewModel)
    {
        BindingContext = mainPageViewModel;
        InitializeComponent();
    }

   
}
