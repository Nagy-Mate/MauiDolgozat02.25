using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiDolgozat.Common;
using MauiDolgozat.Services;
using System.Collections.ObjectModel;

namespace MauiDolgozat.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
	[ObservableProperty]
	private ObservableCollection<Student> students;

	private readonly FileService fileService;
	public MainPageViewModel(FileService fileService)
	{
		this.fileService = fileService;
		Students = [];
		LoadStudents();	
	}

	private async void LoadStudents()
	{
		var data = await fileService.GetStudents();
		if (data == null)
			return;

		Students.Clear();
		Students = data.ToObservableCollection();	 
	}
}