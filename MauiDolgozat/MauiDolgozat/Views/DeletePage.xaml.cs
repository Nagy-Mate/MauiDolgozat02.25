using MauiDolgozat.ViewModels;

namespace MauiDolgozat.Views;

public partial class DeletePage : ContentPage
{
	public DeleteViewModel deleteViewModel => BindingContext as DeleteViewModel;
	public DeletePage(DeleteViewModel deleteViewModel)
	{
		BindingContext = deleteViewModel;
		InitializeComponent();
	}
}