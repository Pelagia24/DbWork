using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbWork;

[Table("Humans")]
public class Human
{
    public Human()
    {
    }

    public Human(string name, string surname, int age, string phoneNumber)
    {
        Name = name;
        Surname = surname;
        Age = age;
        PhoneNumber = phoneNumber;
    }
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
}