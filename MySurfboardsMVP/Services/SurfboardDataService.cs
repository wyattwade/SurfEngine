using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySurfboardsMVP.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MySurfboardsMVP.Services
{
    public class SurfboardDataService : ISurfboardDataService
    {
        public List<Surfboard> GetAllSurfboards()
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfboardDBConnection"].ConnectionString))
            {
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "Surfboard_GetAll";
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    var results = new List<Surfboard>();

                    while (reader.Read())
                    {

                        var mySurfBoard = new Surfboard();

                        if (reader["id"] != DBNull.Value)
                        {
                            mySurfBoard.Id = (int)reader["Id"];
                        }

                        if (reader["Brand"] != DBNull.Value)
                        {
                            mySurfBoard.Brand = (string)reader["Brand"];
                        }

                        if (reader["Name"] != DBNull.Value)
                        {
                            mySurfBoard.Name = (string)reader["Name"];
                        }

                        if (reader["Height"] != DBNull.Value)
                        {
                            mySurfBoard.Height = (decimal)reader["Height"];
                        }

                        if (reader["Width"] != DBNull.Value)
                        {
                            mySurfBoard.Width = (decimal)reader["Width"];
                        }

                        if (reader["Volume"] != DBNull.Value)
                        {
                            mySurfBoard.Volume = (decimal)reader["Volume"];
                        }


                        results.Add(mySurfBoard);
                    }

                    return results;
                }
            }
        }

        public Surfboard Get(int Id)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfboardDBConnection"].ConnectionString))
            {
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "Surfboard_GetById";
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;



                using (var reader = cmd.ExecuteReader())
                {
                    var mySurfBoard = new Surfboard();


                    while (reader.Read())
                    {
                        if (reader["id"] != DBNull.Value)
                        {
                            mySurfBoard.Id = (int)reader["Id"];
                        }

                        if (reader["Brand"] != DBNull.Value)
                        {
                            mySurfBoard.Brand = (string)reader["Brand"];
                        }

                        if (reader["Name"] != DBNull.Value)
                        {
                            mySurfBoard.Name = (string)reader["Name"];
                        }

                        if (reader["Height"] != DBNull.Value)
                        {
                            mySurfBoard.Height = (decimal)reader["Height"];
                        }

                        if (reader["Width"] != DBNull.Value)
                        {
                            mySurfBoard.Width = (decimal)reader["Width"];
                        }

                        if (reader["Volume"] != DBNull.Value)
                        {
                            mySurfBoard.Volume = (decimal)reader["Volume"];
                        }
                    }

                    return mySurfBoard;
                }
            }
        }

        public int Post(Surfboard surfboard)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfboardDBConnection"].ConnectionString))
            {
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "Surfboard_Post";
                cmd.CommandType = CommandType.StoredProcedure;


                {
                    cmd.Parameters.AddWithValue("@Brand", surfboard.Brand);
                    cmd.Parameters.AddWithValue("@Name", surfboard.Name);
                    cmd.Parameters.AddWithValue("@Height", surfboard.Height);
                    cmd.Parameters.AddWithValue("@Width", surfboard.Width);
                    cmd.Parameters.AddWithValue("@Volume", surfboard.Volume);

                    SqlParameter idParameter = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    idParameter.Direction = System.Data.ParameterDirection.Output;

                    cmd.Parameters.Add(idParameter);


                    cmd.ExecuteNonQuery();

                    return (int)idParameter.Value;
                }
            }
        }





        public void Update(Surfboard surfboard)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfboardDBConnection"].ConnectionString))
            {
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "Surfboard_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                {
                    cmd.Parameters.AddWithValue("@Id", surfboard.Id);
                    cmd.Parameters.AddWithValue("@Brand", surfboard.Brand);
                    cmd.Parameters.AddWithValue("@Name", surfboard.Name);
                    cmd.Parameters.AddWithValue("@Height", surfboard.Height);
                    cmd.Parameters.AddWithValue("@Width", surfboard.Width);
                    cmd.Parameters.AddWithValue("@Volume", surfboard.Volume);
                }
                cmd.ExecuteNonQuery();

            }
        }




        public void Delete(int id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfboardDBConnection"].ConnectionString))
            {
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "Surfboard_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                {
                    cmd.Parameters.AddWithValue("@Id", id);
                }
                cmd.ExecuteNonQuery();

            }



        }
    }
}