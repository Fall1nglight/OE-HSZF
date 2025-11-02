using EntityFramework.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Repository;

public class RatingRepository
{
    private readonly AppDbContext _db;

    public RatingRepository(AppDbContext db)
    {
        _db = db;
    }

    public bool CreatePerson(Person p)
    {
        _db.People.Add(p);
        _db.SaveChanges();

        return true;
    }

    public bool DeletePerson(int id)
    {
        var rowsDeleted = _db.People.Where(x => x.Id == id).ExecuteDelete();
        _db.SaveChanges();

        return rowsDeleted == 1;
    }

    public Person? GetPerson(int id)
    {
        return _db.People.FirstOrDefault(x => x.Id == id);
    }

    public List<Person> GetPeople()
    {
        return _db.People.ToList();
    }

    public bool UpdatePerson(int id, Person p)
    {
        var person = _db.People.FirstOrDefault(x => x.Id == id);

        if (person == null)
            return false;

        person.Name = p.Name;
        person.Job = p.Job;
        person.Age = p.Age;

        _db.SaveChanges();
        return true;
    }
}
