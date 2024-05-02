using TrailTents.Models;

namespace TrailTents.Database
{
    public class AnonymousDataContext:IAnonymousDataContext
    {
<<<<<<< HEAD
        // Admin
        public List<Admin> GetAllAdmins()
        {
            Admin admin = new Admin();
=======
        

        // Admin
        Admin admin = new Admin();
        public List<Admin> GetAllAdmins()
        {
            
>>>>>>> parent of 50d09b4 (get,getbyid.post converted to litedb)
            return admin.GetAllAdmins();
        }
        public Admin GetAdminByID(int id)
        {
<<<<<<< HEAD
            Admin admin = new Admin();
=======
>>>>>>> parent of 50d09b4 (get,getbyid.post converted to litedb)
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
<<<<<<< HEAD
        public List<Booking> GetAllBookings()
        {
            Booking booking = new Booking();
=======
        Booking booking = new Booking();
        public List<Booking> GetAllBookings()
        {
>>>>>>> parent of 50d09b4 (get,getbyid.post converted to litedb)
            return booking.GetAllBookings();
        }
        public Booking GetBookingByID(int id)
        {
<<<<<<< HEAD
            Booking booking = new Booking();
=======
>>>>>>> parent of 50d09b4 (get,getbyid.post converted to litedb)
            return booking.GetBookingByID(id);
        }
        public bool AddBooking(Booking booking)
        {
            return booking.AddBooking(booking);
        }


        // Camping Site
<<<<<<< HEAD
        public List<CampingSite> GetAllCampingSites()
        {
            CampingSite campingSite = new CampingSite();
=======
        CampingSite campingSite = new CampingSite();
        public List<CampingSite> GetAllCampingSites()
        {
>>>>>>> parent of 50d09b4 (get,getbyid.post converted to litedb)
            return campingSite.GetAllCampingSites();
        }
        public CampingSite GetCampingSiteByID(int id)
        {
<<<<<<< HEAD
            CampingSite campingSite = new CampingSite();
=======
>>>>>>> parent of 50d09b4 (get,getbyid.post converted to litedb)
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
<<<<<<< HEAD
        public List<Review> GetAllReviews()
        {
            Review review = new Review();
=======
        Review review = new Review();
        public List<Review> GetAllReviews()
        {
>>>>>>> parent of 50d09b4 (get,getbyid.post converted to litedb)
            return review.GetAllReviews();
        }
        public Review GetReviewByID(int id)
        {
<<<<<<< HEAD
            Review review = new Review();
=======
>>>>>>> parent of 50d09b4 (get,getbyid.post converted to litedb)
            return review.GetReviewByID(id);
        }
        public bool AddReview(Review review)
        {
            return review.AddReview(review);
        }
        public List<Review> GetReviewsByUserID(int id)
        {
<<<<<<< HEAD
            Review review = new Review();
=======
>>>>>>> parent of 50d09b4 (get,getbyid.post converted to litedb)
            return review.GetReviewsByUserID(id);
        }
        public List<Review> GetReviewsByCampingSiteID(int id)
        {
<<<<<<< HEAD
            Review review = new Review();
=======
>>>>>>> parent of 50d09b4 (get,getbyid.post converted to litedb)
            return review.GetReviewsByCampingSiteID(id);
        }


        // User
<<<<<<< HEAD
        public List<User> GetAllUsers()
        {
            User user = new User();
=======
        User user = new User();
        public List<User> GetAllUsers()
        {
>>>>>>> parent of 50d09b4 (get,getbyid.post converted to litedb)
            return user.GetAllUsers();
        }
        public User GetUserByID(int id)
        {
<<<<<<< HEAD
            User user= new User();
=======
>>>>>>> parent of 50d09b4 (get,getbyid.post converted to litedb)
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
