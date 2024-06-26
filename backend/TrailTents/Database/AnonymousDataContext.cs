﻿using TrailTents.Models;

namespace TrailTents.Database
{
    public class AnonymousDataContext:IAnonymousDataContext
    {
        // Admin
        Admin admin = new Admin();
        public List<Admin> GetAllAdmins()
        {
            return admin.GetAllAdmins();
        }
        public Admin GetAdminByID(int id)
        {
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
        public Admin VerifyAdmin(string email, string password)
        {
            return admin.VerifyAdmin(email, password);
        }


        // Bookings
        Booking booking = new Booking();
        public List<Booking> GetAllBookings()
        {
            return booking.GetAllBookings();
        }
        public Booking GetBookingByID(int id)
        {
            return booking.GetBookingByID(id);
        }
        public bool AddBooking(Booking booking)
        {
            return booking.AddBooking(booking);
        }
        public List<Booking> GetBookingsByUserID(int id)
        {
            return booking.GetBookingsByUserID(id);
        }
        public List<Booking> GetBookingsByCampingSiteID(int id)
        {
            return booking.GetBookingsByCampingSiteID(id);
        }


        // Camping Site
        CampingSite campingSite = new CampingSite();
        public List<CampingSite> GetAllCampingSites()
        {
            return campingSite.GetAllCampingSites();
        }
        public CampingSite GetCampingSiteByID(int id)
        {
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
        Review review = new Review();
        public List<Review> GetAllReviews()
        {
            return review.GetAllReviews();
        }
        public Review GetReviewByID(int id)
        {
            return review.GetReviewByID(id);
        }
        public bool AddReview(Review review)
        {
            return review.AddReview(review);
        }
        public List<Review> GetReviewsByUserID(int id)
        {
            return review.GetReviewsByUserID(id);
        }
        public List<Review> GetReviewsByCampingSiteID(int id)
        {
            return review.GetReviewsByCampingSiteID(id);
        }


        // User
        User user = new User();
        public List<User> GetAllUsers()
        {
            return user.GetAllUsers();
        }
        public User GetUserByID(int id)
        {
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
        public User VerifyUser(string email, string password)
        {
            return user.VerifyUser(email,password);
        }
        public bool UniqueEmail(string email)
        {
            return user.UniqueEmail(email);
        }
    }
}
