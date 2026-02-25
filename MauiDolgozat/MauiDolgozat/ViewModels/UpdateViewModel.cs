using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiDolgozat.Common;
using MauiDolgozat.Services;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.DataTransfer;

namespace MauiDolgozat.ViewModels;

public partial class UpdateViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Student> students;

    [ObservableProperty]
    private Student selectedStudent;

    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private List<string> genders = ["Férfi", "Nõ"];

    [ObservableProperty]
    private string selectedGender;

    [ObservableProperty]
    private double weight;

    [ObservableProperty]
    private int height;

    [ObservableProperty]
    private string className;

    private readonly FileService fileService;
    public UpdateViewModel(FileService fileService)
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
    private async Task UpdateStudent()
    {
        if (string.IsNullOrWhiteSpace(Name) && SelectedGender == null && Weight == null && Weight <= 0 && Weight == null && Weight <= 0 && string.IsNullOrWhiteSpace(ClassName) && SelectedStudent == null)
            return;

       var student = Students.FirstOrDefault(s => s.Id == SelectedStudent.Id);
        if (student == null) 
            return;

        if (!string.IsNullOrWhiteSpace(Name))
            student.Name = Name;

        if (SelectedGender != null)
            student.Gender = SelectedGender;

        if (Weight != null && Weight >0)
            student.Weight = Weight;

        if (Height != null && Height > 0)
            student.Height = Height;

        if (!string.IsNullOrWhiteSpace(ClassName))
            student.Class = ClassName;

        await fileService.SaveStudents(Students.ToList());

        SelectedStudent = null;
        Name = null;
        SelectedGender = null;
        Weight = 0;
        Height = 0;
        ClassName = null;

    }
}