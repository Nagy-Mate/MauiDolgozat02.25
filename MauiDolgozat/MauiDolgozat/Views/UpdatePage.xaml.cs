using MauiDolgozat.ViewModels;

namespace MauiDolgozat.Views;

public partial class UpdatePage : ContentPage
{
	public UpdateViewModel updateViewModel => BindingContext as UpdateViewModel;
	public UpdatePage(UpdateViewModel updateViewModel)
	{
		BindingContext = updateViewModel;
		InitializeComponent();
	}
}