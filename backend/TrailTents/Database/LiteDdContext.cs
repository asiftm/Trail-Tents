using LiteDB;
using TrailTents.Models;

namespace TrailTents.Database
{
    public class LiteDdContext:DataInterface
    {
        LiteDatabase db = new LiteDatabase(@"data.db");

        //Admin
        public void AddAdmin(Admin admin)
        {
            db.GetCollection<Admin>("Admin").Insert(admin);
        }
        public IEnumerable<Admin> GetAllAdmins()
        {
            return db.GetCollection<Admin>("Admin").FindAll();
        }
        public Admin GetAdminByID(int id)
        {
            return db.GetCollection<Admin>("Admin").FindById(id);
        }

        //Booking
        public void AddBooking(Booking booking)
        {
            db.GetCollection<Booking>("Booking").Insert(booking);
        }
        public IEnumerable<Booking> GetAllBookings()
        {
            return db.GetCollection<Booking>("Booking").FindAll();
        }
        public Booking GetBookingByID(int id)
        {
            return db.GetCollection<Booking>("Booking").FindById(id);
        }

        //CampingSite
        public void AddCampingSite(CampingSite campingSite)
        {
            db.GetCollection<CampingSite>("CampingSite").Insert(campingSite);
        }
        public IEnumerable<CampingSite> GetAllCampingSites()
        {
            return db.GetCollection<CampingSite>("CampingSite").FindAll();
        }
        public CampingSite GetCampingSiteByID(int id)
        {
            return db.GetCollection<CampingSite>("CampingSite").FindById(id);
        }

        //Review
        public void AddReview(Review review)
        {
            db.GetCollection<Review>("Review").Insert(review);
        }
        public IEnumerable<Review> GetAllReviews()
        {
            return db.GetCollection<Review>("Review").FindAll();
        }
        public Review GetReviewByID(int id)
        {
            return db.GetCollection<Review>("Review").FindById(id);
        }

        //User

        public void AddUser(User user)
        {
            db.GetCollection<User>("User").Insert(user);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return db.GetCollection<User>("User").FindAll();
        }
        public User GetUserByID(int id)
        {
            return db.GetCollection<User>("User").FindById(id);

        }

    }
}
