﻿using MySqlConnector;
using TrailTents.Database;

namespace TrailTents.Models
{
    public class Review
    {
        Data data = new Data();
        public int ID { get; private set; }
        public int CampsiteID { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public List<Review> GetAllReviews()
        {
            List<Review> reviews = new List<Review>();
            string query = "Select * From `review`";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                Review review = new Review();
                FillReview(reader, review);
                reviews.Add(review);
            }

            return reviews;
        }

        public Review GetReviewByID(int id)
        {
            Review review = new Review();
            string query = $"Select * From `review` Where ID = '{id}'";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                FillReview(reader, review: review); ;
            }
            return review;
        }
        public bool AddReview(Review review)
        {
            if (!review.CheckAllFields(review)) return false;
            string query = $"INSERT INTO `review` (`ID`, `Campsite_ID`, `User_ID`, `Rating`, `Comment`) VALUES (NULL, \"{review.CampsiteID}\", \"{review.UserID}\", \"{review.Rating}\", \"{review.Comment}\");";

            if (data.NotSelectQuery(query) == 1)
            {
                CampingSite campingSite = new CampingSite();
                campingSite.UpdateRating(review.CampsiteID);
                return true;
            }
            return false;
        }
        public Review FillReview(MySqlDataReader reader, Review review)
        {
            review.ID = reader.GetInt32(0);
            review.CampsiteID = reader.GetInt32(1);
            review.UserID = reader.GetInt32(2);
            review.Rating = reader.GetInt32(3); ;
            review.Comment = reader.GetString(4);
            return review;
        }
        public bool CheckAllFields(Review review)
        {
            if (review.UserID != null && review.CampsiteID != null && review.Rating != null && review.Comment != null) return true;
            return false;
        }

        public List<Review> GetReviewsByUserID(int id)
        {
            List<Review> reviews = new List<Review>();
            string query = $"SELECT * FROM `review` WHERE `User_ID` = {id};";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                Review review = new Review();
                FillReview(reader, review);
                reviews.Add(review);
            }

            return reviews;
        }
        public List<Review> GetReviewsByCampingSiteID(int id)
        {
            List<Review> reviews = new List<Review>();
            string query = $"SELECT * FROM `review` WHERE `Campsite_ID` = {id};";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                Review review = new Review();
                FillReview(reader, review);
                reviews.Add(review);
            }

            return reviews;
        }
        public string GetAvgRatingByID(int campsiteID)
        {
            string query = $"SELECT AVG(CAST(Rating AS FLOAT)) FROM `review` WHERE Campsite_ID = {campsiteID};";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                return (reader[0].ToString().Replace(",", "."));
            }
            return "0";
        }
    }
}
