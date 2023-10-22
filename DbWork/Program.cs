using Data.DataBase;
using DbWork;

var db = new Database<Human>();
var testHuman = new Human("name", "surname", 18, "+79999999999");
db.Insert(testHuman);

var humansInDb = db.GetAll();
Console.WriteLine("После insert");
foreach (var human in humansInDb)
{
    Console.WriteLine("{0}, {1}, {2}, {3}, {4}",human.Id,human.Name,human.Surname,human.Age,human.PhoneNumber);
}

db.Delete(1);

humansInDb = db.GetAll();
Console.WriteLine("После delete");
foreach (var human in humansInDb)
{
    Console.WriteLine("{0}, {1}, {2}, {3}, {4}",human.Id,human.Name,human.Surname,human.Age,human.PhoneNumber);
}