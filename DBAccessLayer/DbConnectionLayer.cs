using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MVCADOAssessment.Models;
using MySql.Data.MySqlClient;
namespace MVCADOAssessment.DBAccessLayer
{
    public static class DbConnectionLayer
    {
        public static bool Add(Training TrainingInfo)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);

            conn.Open();
            //MySqlCommand cmd = new MySqlCommand("UPDATE laptop SET  LaptopBrand = @laptopbrand, LaptopModel = @laptopmodel, LaptopGen=@laptopgen,LaptopRam=@laptopram, WHERE laptoId = @laptopid", conn);
            string insertQuery = "INSERT INTO TrainingInfo (TrainingID, TrainingName,TrainingMode ,Domain,TrainingDuration,Location) VALUES (@TrainingID, @TrainingName, @TrainingMode,@Domain,@TrainingDuration,@Location)";
            MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@TrainingID", TrainingInfo.TrainingID);
            cmd.Parameters.AddWithValue("@TrainingName", TrainingInfo.TrainingName);
            cmd.Parameters.AddWithValue("@TrainingMode", TrainingInfo.TrainingMode);
            cmd.Parameters.AddWithValue("@Domain", TrainingInfo.Domain);
            cmd.Parameters.AddWithValue("@TrainingDuration", TrainingInfo.TrainingDuration);
            cmd.Parameters.AddWithValue("@Location", TrainingInfo.Location);

            int i = cmd.ExecuteNonQuery();
           


            if (i > 0)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        public static List<Training> GetAllTraining()
        {
            List<Training> training = new List<Training>();
            string constr = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM TrainingInfo", con))
                {


                    // Open the connection
                    con.Open();

                    // Create a data reader object
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Loop through the rows
                        while (reader.Read())
                        {
                            // Create a Teacher object
                            Training TrainingInfo = new Training();

                            // Assign the properties from the reader
                            TrainingInfo.TrainingID = reader.GetInt32(0);
                            TrainingInfo.TrainingName = reader.GetString(1);
                            TrainingInfo.TrainingMode = reader.GetString(2);
                            TrainingInfo.Domain = reader.GetString(3);
                            TrainingInfo.TrainingDuration = reader.GetString(4);
                            TrainingInfo.Location = reader.GetString(5);


                            // Add the Teacher object to the list
                            training.Add(TrainingInfo);
                        }
                    }

                }
            }

            // Return the view with the list of Teacher objects
            return training;



        }
        public static Training GetIndividualTraining(int id)
        {

            string constr = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM TrainingInfo where TrainingID={id}", con))
                {


                    // Open the connection
                    con.Open();

                    // Create a data reader object
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Loop through the rows
                        while (reader.Read())
                        {
                            // Create a Teacher object
                            Training TrainingInfo = new Training();

                            // Assign the properties from the reader
                            TrainingInfo.TrainingID = reader.GetInt32(0);
                            TrainingInfo.TrainingName = reader.GetString(1);
                            TrainingInfo.TrainingMode = reader.GetString(2);
                            TrainingInfo.Domain = reader.GetString(3);
                            TrainingInfo.TrainingDuration = reader.GetString(4);
                            TrainingInfo.Location = reader.GetString(5);


                            // Add the Teacher object to the list
                            return TrainingInfo;

                        }
                    }

                }
            }

            // Return the view with the list of Teacher objects
            return null;


        }
        public static bool Update(Training TrainingInfo)
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);

            conn.Open();
            //MySqlCommand cmd = new MySqlCommand("UPDATE laptop SET  LaptopBrand = @laptopbrand, LaptopModel = @laptopmodel, LaptopGen=@laptopgen,LaptopRam=@laptopram, WHERE laptoId = @laptopid", conn);
            MySqlCommand cmd = new MySqlCommand("UPDATE TrainingInfo SET TrainingName = @TrainingName, TrainingMode= @TrainingMode,Domain=@Domain,TrainingDuration=@TrainingDuration,Location=@Location WHERE TrainingID = @TrainingID", conn);
            cmd.Parameters.AddWithValue("@TrainingID", TrainingInfo.TrainingID);
            cmd.Parameters.AddWithValue("@TrainingName", TrainingInfo.TrainingName);
            cmd.Parameters.AddWithValue("@TrainingMode", TrainingInfo.TrainingMode);
            cmd.Parameters.AddWithValue("@Domain", TrainingInfo.Domain);
            cmd.Parameters.AddWithValue("@TrainingDuration", TrainingInfo.TrainingDuration);
            cmd.Parameters.AddWithValue("@Location", TrainingInfo.Location);

            int i = cmd.ExecuteNonQuery();
            conn.Close();


            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Delete(int id)
        {

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("Delete from TrainingInfo WHERE TrainingID = @TrainingID", conn);
            cmd.Parameters.AddWithValue("@TrainingID", id);
            int i = cmd.ExecuteNonQuery();
            conn.Close();




            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}