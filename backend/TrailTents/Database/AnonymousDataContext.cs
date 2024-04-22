using TrailTents.Models;

namespace TrailTents.Database
{
    public class AnonymousDataContext:IAnonymousDataContext
    {
        // Admin
        public List<Admin> GetAllAdmins()
        {
            Admin admin = new Admin();
            return admin.GetAllAdmins();
        }
        public Admin GetAdminByID(int id)
        {
            Admin admin = new Admin();
            return admin.GetAdminByID(id);
        }
        public bool AddAdmin(Admin admin)
        {
            return admin.AddAdmin(admin);
        }
        public bool UpdateAdmin(Admin admin,int id)
        {
            return admin.UpdateAdmin(admin,id);
        }


        // Bookings
        public List<Booking> GetAllBookings()
        {
            Booking booking = new Booking();
            return booking.GetAllBookings();
        }
        public Booking GetBookingByID(int id)
        {
            Booking booking = new Booking();
            return booking.GetBookingByID(id);
        }
        public bool AddBooking(Booking booking)
        {
            return booking.AddBooking(booking);
        }


        // Camping Site
        public List<CampingSite> GetAllCampingSites()
        {
            CampingSite campingSite = new CampingSite();
            return campingSite.GetAllCampingSites();
        }
        public CampingSite GetCampingSiteByID(int id)
        {
            CampingSite campingSite = new CampingSite();
            return campingSite.GetCampingSiteByID(id);
        }
        public bool AddCampingSite(CampingSite campingSite)
        {
            return campingSite.AddCampingSite(campingSite);
        }
        public bool UpdateCampingSite(CampingSite campingSite, int id)
        {
            return campingSite.UpdateCampingSite(campingSite,id);
        }


        // Review
        public List<Review> GetAllReviews()
        {
            Review review = new Review();
            return review.GetAllReviews();
        }
        public Review GetReviewByID(int id)
        {
            Review review = new Review();
            return review.GetReviewByID(id);
        }
        public bool AddReview(Review review)
        {
            return review.AddReview(review);
        }
        public List<Review> GetReviewsByUserID(int id)
        {
            Review review = new Review();
            return review.GetReviewsByUserID(id);
        }
        public List<Review> GetReviewsByCampingSiteID(int id)
        {
            Review review = new Review();
            return review.GetReviewsByCampingSiteID(id);
        }


        // User
        public List<User> GetAllUsers()
        {
            User user = new User();
            return user.GetAllUsers();
        }
        public User GetUserByID(int id)
        {
            User user= new User();
            return user.GetUserByID(id);
        }
        public bool AddUser(User user)
        {
            return user.AddUser(user);
        }
        public bool UpdateUser(User user, int id)
        {
            return user.UpdateUser(user,id);
        }
    }
}
