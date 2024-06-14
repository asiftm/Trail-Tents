using Microsoft.AspNetCore.Components.Forms;
using MySqlConnector;
using TrailTents.Database;

namespace TrailTents.Models
{
    public class Booking
    {
        //CREATE TABLE `trailtents`.`booking` (`ID` INT NOT NULL AUTO_INCREMENT , `Campsite_ID` INT NOT NULL , `User_ID` INT NOT NULL , `Booking_Start_Date` DATE NOT NULL , `Booking_End_Date` DATE NOT NULL , PRIMARY KEY (`ID`)) ENGINE = InnoDB;

        Data data = new Data();
        public int ID { get; private set; }
        public int CampsiteID { get; set; }
        public int UserID { get; set; }
        public string BookingStartDate { get; set; }
        public string BookingEndDate { get; set; }
        public List<Booking> GetAllBookings()
        {
            List<Booking> bookings = new List<Booking>();
            string query = "Select * From `booking`";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                Booking booking = new Booking();
                FillBooking(reader, booking);
                bookings.Add(booking);
            }
            return bookings;
        }
        public Booking GetBookingByID(int id)
        {
            Booking booking = new Booking();
            string query = $"Select * From `booking` Where ID = '{id}'";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                FillBooking(reader, booking);
            }
            return booking;
        }
        public bool AddBooking(Booking booking)
        {
            DateTime parsedDate = DateTime.ParseExact(booking.BookingStartDate, "dd/MM/yyyy", null);
            booking.BookingStartDate = parsedDate.ToString("yyyy/MM/dd");
            parsedDate = DateTime.ParseExact(booking.BookingEndDate, "dd/MM/yyyy", null);
            booking.BookingEndDate = parsedDate.ToString("yyyy/MM/dd");

            if (!booking.CheckAllFields(booking)) return false;
            if (booking.CheckBooking(booking)) return false;
            string query = $"INSERT INTO `booking` (`ID`, `Campsite_ID`, `User_ID`, `Booking_Start_Date`, `Booking_End_Date`) VALUES (NULL, '{booking.CampsiteID}', '{booking.UserID}', '{booking.BookingStartDate}', '{booking.BookingEndDate}');";
            if (data.NotSelectQuery(query) == 1)
            {
                return true;
            }
            return false;
        }
        public Booking FillBooking(MySqlDataReader reader, Booking booking)
        {
            booking.ID = reader.GetInt32(0);
            booking.CampsiteID = reader.GetInt32(1);
            booking.UserID = reader.GetInt32(2);
            booking.BookingStartDate = reader[3].ToString().Substring(0,10);
            booking.BookingEndDate = reader[4].ToString().Substring(0,10);
            return booking;
        }
        public bool CheckAllFields(Booking booking)
        {
            if (booking.CampsiteID != null && booking.UserID != null && booking.BookingStartDate != null && booking.BookingEndDate != null ) return true;
            return false;
        }
        public bool CheckBooking(Booking booking)
        {
            string query = $"SELECT * FROM Booking WHERE \"{booking.BookingEndDate}\" >= Booking_Start_Date AND \"{booking.BookingStartDate}\" <= Booking_End_Date AND Campsite_ID = {booking.CampsiteID};";
            MySqlDataReader reader = data.SelectQuery(query);
            if (reader.HasRows) return true; ;
            return false;
        }
        public List<Booking> GetBookingsByUserID(int id)
        {
            List<Booking> bookings = new List<Booking>();
            string query = $"SELECT booking.ID, booking.Campsite_ID, booking.User_ID, Booking_Start_Date, Booking_End_Date FROM Booking JOIN user ON booking.User_ID = user.ID JOIN campsite on booking.Campsite_ID = campsite.ID WHERE booking.`User_ID` = {id} ORDER BY Booking_Start_Date DESC, Booking_End_Date DESC;";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                Booking booking = new Booking();
                FillBooking(reader, booking);
                bookings.Add(booking);
            }
            return bookings;
        }
        public List<Booking> GetBookingsByCampingSiteID(int id)
        {
            List<Booking> bookings = new List<Booking>();
            string query = $"SELECT booking.ID, booking.Campsite_ID, booking.User_ID, Booking_Start_Date, Booking_End_Date FROM Booking JOIN campsite ON booking.Campsite_ID = campsite.ID WHERE booking.`Campsite_ID` = {id} ORDER BY Booking_Start_Date DESC, Booking_End_Date DESC LIMIT 10;";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                Booking booking = new Booking();
                FillBooking(reader, booking);
                bookings.Add(booking);
            }
            return bookings;
        }
    }
}
