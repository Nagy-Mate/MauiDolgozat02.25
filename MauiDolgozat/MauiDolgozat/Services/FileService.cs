using MauiDolgozat.Common;

namespace MauiDolgozat.Services;

public class FileService
{
    private readonly string _filePath = "tanulok.csv";
    public async Task<List<Student>> GetStudents()
    {
        var students = new List<Student>();
        var text = await File.ReadAllLinesAsync(_filePath);

        foreach (var line in text.Skip(1))
        {
            var content = line.Split(",");
            students.Add(new Student
            {
                Id = int.Parse(content[0]),
                Name = content[1],
                Gender = content[2],
                Height = int.Parse(content[3]),
                Weight = double.Parse(content[4].Replace(".", ",")),
                Class = content[5]
            });
        }

        return students;
    } 

    public async Task SaveStudents(List<Student> students)
    {
        using (var w = new StreamWriter(_filePath))
        {
            var header = "Id,Nev,Nem,Magassag_cm,Testsuly_kg,Osztaly";
            w.WriteLine(header);
            foreach (var item in students)
            {
                var line = $"{item.Id},{item.Name},{item.Gender},{item.Height},{item.Weight.ToString().Replace(",", ".")},{item.Class}";
                w.WriteLine(line);
                w.Flush();
            }            
        }
    }

}
