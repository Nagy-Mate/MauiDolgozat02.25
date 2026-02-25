using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiDolgozat.Common;
using MauiDolgozat.Services;
using System.Collections.ObjectModel;

namespace MauiDolgozat.ViewModels;

public partial class ReportViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Student> students;

    [ObservableProperty]
    private string avaragesOut;

    [ObservableProperty]
    private Student tallestGirl;

    [ObservableProperty]
    private Student heviestBoy;

    private readonly FileService fileService;
    public ReportViewModel(FileService fileService)
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
        GetAvarages();
        GetTallestGirl();
        GetHeviestBoy();
    }

    private void GetAvarages()
    {
        var grouped = Students.GroupBy(s => s.Class);
        AvaragesOut = "osztály, átlag magasság, átlag súly\n";
        foreach (var item in grouped)
        {
            AvaragesOut += $"{item.First().Class} ,\t{Math.Round(item.Average(c => c.Height))},\t\t {Math.Round(item.Average(c => c.Weight))} \n" ;
        }
    }

    private void GetTallestGirl()
    {
        TallestGirl = Students.Where(s => s.Gender == "Nõ").MaxBy(g => g.Height);
    }

    private void GetHeviestBoy()
    {
        HeviestBoy = Students.Where(s => s.Gender == "Férfi").MaxBy(g => g.Weight);
    }
}