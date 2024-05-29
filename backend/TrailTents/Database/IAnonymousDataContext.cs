using TrailTents.Models;

namespace TrailTents.Database
{
    public interface IAnonymousDataContext
    {
        // Admin
        List<Admin> GetAllAdmins();
        Admin GetAdminByID(int id);
        bool AddAdmin(Admin admin);
        bool UpdateAdmin(Admin admin,int id);


        // Booking
        List<Booking> GetAllBookings();
        Booking GetBookingByID(int id);
        bool AddBooking(Booking booking);


        // CampingSite
        List<CampingSite> GetAllCampingSites();
        CampingSite GetCampingSiteByID(int id);
        bool AddCampingSite(CampingSite campingSite);
        bool UpdateCampingSite(CampingSite campingSite, int id);


        // Review
        List<Review> GetAllReviews();
        Review GetReviewByID(int id);
        bool AddReview(Review review);
        List<Review> GetReviewsByUserID(int id);
        List<Review> GetReviewsByCampingSiteID(int id);


        // User
        List<User> GetAllUsers();
        User GetUserByID(int id);
        bool AddUser(User user);
        bool UpdateUser(User user, int id);
        User VerifyUser(string email, string password);
        bool UniqueEmail(string email);
    }
}
