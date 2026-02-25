using MauiDolgozat.ViewModels;

namespace MauiDolgozat.Views;

public partial class AddPage : ContentPage
{
	public AddViewModel viewModel => BindingContext as AddViewModel;
	public AddPage(AddViewModel addViewModel)
	{
		BindingContext = addViewModel;
		InitializeComponent();
	}
}