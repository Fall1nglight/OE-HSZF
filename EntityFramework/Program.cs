using EntityFramework.Data;
using EntityFramework.Repository;

namespace EntityFramework;

class Program
{
    static void Main(string[] args)
    {
        AppDbContext db = new AppDbContext();

        db.Seed();

        RatingRepository ratingRepository = new RatingRepository(db);

        var people = ratingRepository.GetPeople();
        ;
        // ratingRepository.DeletePerson(people[0].Id);
        ;
    }
}
