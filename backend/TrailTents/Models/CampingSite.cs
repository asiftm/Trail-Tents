using Microsoft.AspNetCore.Mvc.ViewEngines;
using MySqlConnector;
using TrailTents.Database;

namespace TrailTents.Models
{
    public class CampingSite
    {
        Data data = new Data();
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int PricePerDay { get; set; }
        public float Rating { get; set; }

        public List<CampingSite> GetAllCampingSites()
        {
            List<CampingSite> campingSites = new List<CampingSite>();
            string query = "Select * From `campsite`";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                CampingSite campingSite = new CampingSite();
                FillCampingSite(reader, campingSite);
                campingSites.Add(campingSite);
            }
            return campingSites;
        }
        public CampingSite GetCampingSiteByID(int id)
        {
            CampingSite campingSite = new CampingSite();
            string query = $"Select * From `campsite` Where ID = '{id}'";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                FillCampingSite(reader, campingSite); ;
            }
            return campingSite;
        }
        public CampingSite FillCampingSite(MySqlDataReader reader, CampingSite campingSite)
        {
            campingSite.ID = reader.GetInt32(0);
            campingSite.Name = reader.GetString(1);
            campingSite.Location = reader.GetString(2);
            campingSite.Description = reader.GetString(3);
            campingSite.PricePerDay = reader.GetInt32(4);
            campingSite.Rating = reader.GetFloat(5);
            return campingSite;
        }
        public bool AddCampingSite(CampingSite campingSite)
        {
            if (!campingSite.CheckAllFields(campingSite)) return false;
            string query = $"INSERT INTO `campsite` (`ID`, `Name`, `Location`, `Description`, `Price_per_Day`, `Rating`) VALUES (NULL, \"{campingSite.Name}\",  \"{campingSite.Location}\",  \"{campingSite.Description}\", '{campingSite.PricePerDay}', '0');";
            if (data.NotSelectQuery(query) == 1)
            {
                return true;
            }
            return false;
        }

        public bool CheckAllFields(CampingSite campingSite)
        {
            if (campingSite.Name != null && campingSite.Location != null && campingSite.Description != null && campingSite.PricePerDay != null) return true;
            return false;
        }
        public bool UpdateRating(int campsiteID)
        {
            Review review = new Review();
            string query = $"UPDATE `campsite` SET `Rating` = '{review.GetAvgRatingByID(campsiteID)}' WHERE `ID` = {campsiteID};";

            if (data.NotSelectQuery(query) == 1)
            {
                return true;
            }
            return false;
        }
        public bool UpdateCampingSite(CampingSite campingSite, int id)
        {
            if (!campingSite.CheckAllFields(campingSite)) return false;
            Review review = new Review();
            string query = $"UPDATE `campsite` SET `Name` = \"{campingSite.Name}\", `Location` = \"{campingSite.Location}\", `Description` = \"{campingSite.Description}\", `Price_per_Day` = '{campingSite.PricePerDay}', `Rating` = '{review.GetAvgRatingByID(campingSite.ID)}' WHERE `campsite`.`ID` = {id};";
            if (data.NotSelectQuery(query) == 1)
            {
                return true;
            }
            return false;
        }
    }
}
