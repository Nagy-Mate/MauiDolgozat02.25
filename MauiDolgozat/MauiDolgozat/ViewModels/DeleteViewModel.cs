using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiDolgozat.Common;
using MauiDolgozat.Services;
using System.Collections.ObjectModel;

namespace MauiDolgozat.ViewModels;

public partial class DeleteViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Student> students;

    [ObservableProperty]
    private Student selectedStudent;

    private readonly FileService fileService;
    public DeleteViewModel(FileService fileService)
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

    [RelayCommand]
    private async void DeletStudent()
    {
        if (SelectedStudent == null)
            return;

        Students.Remove(SelectedStudent);

        await fileService.SaveStudents(Students.ToList());

        SelectedStudent = null;
    }
}