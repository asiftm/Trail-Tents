using TrailTents.Models;

namespace TrailTents.Database
{
    public interface DataInterface
    {
        // Admin
        void AddAdmin(Admin admin);
        IEnumerable<Admin> GetAllAdmins();
        Admin GetAdminByID(int id);
        //bool UpdateAdmin(Admin admin, int id);


        // Booking
        void AddBooking(Booking booking);
        IEnumerable<Booking> GetAllBookings();
        Booking GetBookingByID(int id);
        

        // CampingSite
        void AddCampingSite(CampingSite campingSite);
        IEnumerable<CampingSite> GetAllCampingSites();
        CampingSite GetCampingSiteByID(int id);
        //bool UpdateCampingSite(CampingSite campingSite, int id);


        // Review
        void AddReview(Review review);
        IEnumerable<Review> GetAllReviews();
        Review GetReviewByID(int id);
        
        //List<Review> GetReviewsByUserID(int id);
        //List<Review> GetReviewsByCampingSiteID(int id);


        // User
        void AddUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUserByID(int id);
        
        //bool UpdateUser(User user, int id);
    }
}
