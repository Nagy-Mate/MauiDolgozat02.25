using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiDolgozat.Common;
using MauiDolgozat.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MauiDolgozat.ViewModels;

public partial class AddViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Student> students;

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
    public AddViewModel(FileService fileService)
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
    private async Task AddStudent()
    {
        if (string.IsNullOrWhiteSpace(Name) || SelectedGender == null || Weight == null || Weight <= 0 || Weight == null || Weight <= 0 || string.IsNullOrWhiteSpace(ClassName))
            return;

        Students.Add(new Student
        {
            Id = Students.Count == 0 ? 1 : Students.Last().Id + 1,
            Name = Name,
            Gender = SelectedGender,
            Weight = Weight,
            Height = Height,
            Class = ClassName
        });

        await fileService.SaveStudents(Students.ToList());

        Name = null;
        SelectedGender = null;
        Weight = 0;
        Height= 0;
        ClassName = null;

    }
}