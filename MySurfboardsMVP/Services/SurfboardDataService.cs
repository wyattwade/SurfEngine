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
    public class SurfboardDataService
    {
        //public List<Surfboard> GetAllSurfboards()
        //{

        //    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfboardDBConnection"].ConnectionString))
        //    {
        //        con.Open();

        //        var cmd = con.CreateCommand();
        //        cmd.CommandText = "Surfboard_GetAll";
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            var results = new List<Surfboard>();

        //            while (reader.Read())
        //            {

        //                var mySurfBoard = new Surfboard();

        //                if (reader["id"] != DBNull.Value)
        //                {
        //                    mySurfBoard.Id = (int)reader["Id"];
        //                }

        //                if (reader["Brand"] != DBNull.Value)
        //                {
        //                    mySurfBoard.Brand = (string)reader["Brand"];
        //                }

        //                if (reader["Name"] != DBNull.Value)
        //                {
        //                    mySurfBoard.Name = (string)reader["Name"];
        //                }

        //                if (reader["Height"] != DBNull.Value)
        //                {
        //                    mySurfBoard.Height = (int)reader["Height"];
        //                }

        //                if (reader["Width"] != DBNull.Value)
        //                {
        //                    mySurfBoard.Width = (int)reader["Width"];
        //                }

        //                if (reader["Volume"] != DBNull.Value)
        //                {
        //                    mySurfBoard.Volume = (int)reader["Volume"];
        //                }

        //                if (reader["Image"] != DBNull.Value)
        //                {
        //                    mySurfBoard.Image = (string)reader["Image"];
        //                }
        //                else
        //                {
        //                    mySurfBoard.Image = "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg";
        //                }


        //                if (reader["Link"] != DBNull.Value)
        //                {
        //                    mySurfBoard.Link = (string)reader["Link"];
        //                }

        //                if (reader["Price"] != DBNull.Value)
        //                {
        //                    mySurfBoard.Price = (int)reader["Price"];
        //                }

        //                if (reader["FromInternalUser"] != DBNull.Value)
        //                {
        //                    mySurfBoard.FromInternalUser = (bool)reader["FromInternalUser"];
        //                }


        //                results.Add(mySurfBoard);
        //            }

        //            return results;
        //        }
        //    }
        //}

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
                    var surfboard = new Surfboard();


                    while (reader.Read())
                    {
                        if (reader["Id"] != DBNull.Value)
                        {
                            surfboard.Id = (int)reader["Id"];
                        }

                        if (reader["Brand"] != DBNull.Value)
                        {
                            surfboard.Brand = (string)reader["Brand"];
                        }

                        if (reader["Name"] != DBNull.Value)
                        {
                            surfboard.Name = (string)reader["Name"];
                        }

                        if (reader["Description"] != DBNull.Value)
                        {
                            surfboard.Description = (string)reader["Description"];
                        }

                        if (reader["Shape"] != DBNull.Value)
                        {
                            surfboard.Shape = (string)reader["Shape"];
                        }


                        if (reader["Height"] != DBNull.Value)
                        {
                            surfboard.Height = (int)reader["Height"];
                        }

                        if (reader["Width"] != DBNull.Value)
                        {
                            surfboard.Width = (double)reader["Width"];
                        }

                        if (reader["Volume"] != DBNull.Value)
                        {
                            surfboard.Volume = (double)reader["Volume"];
                        }

                        if (reader["Price"] != DBNull.Value)
                        {
                            surfboard.Price = (int)reader["Price"];
                        }

                        if (reader["Link"] != DBNull.Value)
                        {
                            surfboard.Link = (string)reader["Link"];
                        }

                        if (reader["Image"] != DBNull.Value)
                        {
                            surfboard.Image = (string)reader["Image"];
                        }

                        if (reader["Image1"] != DBNull.Value)
                        {
                            surfboard.Image1 = (string)reader["Image1"];
                        }

                        if (reader["Image2"] != DBNull.Value)
                        {
                            surfboard.Image2 = (string)reader["Image2"];
                        }

                        if (reader["Image3"] != DBNull.Value)
                        {
                            surfboard.Image3 = (string)reader["Image3"];
                        }

                        if (reader["Image4"] != DBNull.Value)
                        {
                            surfboard.Image4 = (string)reader["Image4"];
                        }

                        //if (reader["Email"] != DBNull.Value)
                        //{
                        //    surfboard.Email = (string)reader["Email"];
                        //}

                        if (reader["FromInternalUser"] != DBNull.Value)
                        {
                            surfboard.FromInternalUser = (bool)reader["FromInternalUser"];
                        }

                        if (reader["Location"] != DBNull.Value)
                        {
                            surfboard.Location = (string)reader["Location"];
                        }

                        if (reader["Zip"] != DBNull.Value)
                        {
                            surfboard.Zip = int.Parse((string)reader["Zip"]);
                        }
                    }

                    return surfboard;
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
                    cmd.Parameters.AddWithValue("@Description", surfboard.Description);
                    cmd.Parameters.AddWithValue("@Shape", surfboard.Shape);
                    cmd.Parameters.AddWithValue("@Height", surfboard.Height);
                    cmd.Parameters.AddWithValue("@Width", surfboard.Width);
                    cmd.Parameters.AddWithValue("@Volume", surfboard.Volume);
                    cmd.Parameters.AddWithValue("@Price", surfboard.Price);
                    cmd.Parameters.AddWithValue("@Location", surfboard.City);
                    cmd.Parameters.AddWithValue("@Zip", surfboard.Zip);
                    cmd.Parameters.AddWithValue("@FromInternalUser", true); // this should always be true since its from an internal user posting (rather than a scrape)
                    cmd.Parameters.AddWithValue("@Image1", surfboard.Image1);
                    cmd.Parameters.AddWithValue("@Image2", surfboard.Image2);
                    cmd.Parameters.AddWithValue("@Image3", surfboard.Image3);
                    cmd.Parameters.AddWithValue("@Image4", surfboard.Image4);




                    SqlParameter idParameter = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    idParameter.Direction = System.Data.ParameterDirection.Output;

                    //cmd.Parameters.Add(idParameter);
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
                    cmd.Parameters.AddWithValue("@Description", surfboard.Description);
                    cmd.Parameters.AddWithValue("@Height", surfboard.Height);
                    cmd.Parameters.AddWithValue("@Width", surfboard.Width);
                    cmd.Parameters.AddWithValue("@Volume", surfboard.Volume);
                    cmd.Parameters.AddWithValue("@Shape", surfboard.Shape);
                    cmd.Parameters.AddWithValue("@Price", surfboard.Price);
                    cmd.Parameters.AddWithValue("@Location", surfboard.City);
                    cmd.Parameters.AddWithValue("@Zip", surfboard.Zip);
                    cmd.Parameters.AddWithValue("@Image1", surfboard.Image1);
                    cmd.Parameters.AddWithValue("@Image2", surfboard.Image2);
                    cmd.Parameters.AddWithValue("@Image3", surfboard.Image3);
                    cmd.Parameters.AddWithValue("@Image4", surfboard.Image4);






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




        public List<Surfboard> Search(BoardSearchParams bsp)
        {

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfboardDBConnection"].ConnectionString))
            {
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "dbo.Surfboard_Search";
                cmd.Parameters.AddWithValue("@Brand", bsp.Brand);
                cmd.Parameters.AddWithValue("@Name", bsp.Name);
                cmd.Parameters.AddWithValue("@Location", bsp.Location);
                cmd.Parameters.AddWithValue("@MinHeight", bsp.MinHeight);
                cmd.Parameters.AddWithValue("@MaxHeight", bsp.MaxHeight);
                cmd.Parameters.AddWithValue("@MinWidth", bsp.MinWidth);
                cmd.Parameters.AddWithValue("@MaxWidth", bsp.MaxWidth);
                cmd.Parameters.AddWithValue("@MinVolume", bsp.MinVolume);
                cmd.Parameters.AddWithValue("@MaxVolume", bsp.MaxVolume);
                cmd.Parameters.AddWithValue("@MinPrice", bsp.MinPrice);
                cmd.Parameters.AddWithValue("@MaxPrice", bsp.MaxPrice);
                cmd.Parameters.AddWithValue("@CurrentPage", bsp.CurrentPage);
                cmd.Parameters.AddWithValue("@ItemsPerPage", 20); // making it fixed so the user can't change it

                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    var mySurfBoards = new List<Surfboard>();
                    while (reader.Read())
                    {
                        var surfboard = new Surfboard();

                        if (reader["Id"] != DBNull.Value)
                        {
                            surfboard.Id = (int)reader["Id"];
                        }

                        if (reader["Brand"] != DBNull.Value)
                        {
                            surfboard.Brand = (string)reader["Brand"];
                        }

                        if (reader["Name"] != DBNull.Value)
                        {
                            surfboard.Name = (string)reader["Name"];
                        }

                        if (reader["Shape"] != DBNull.Value)
                        {
                            surfboard.Shape = (string)reader["Shape"];
                        }


                        if (reader["Height"] != DBNull.Value)
                        {
                            surfboard.Height = (int)reader["Height"];
                        }

                        if (reader["Width"] != DBNull.Value)
                        {
                            surfboard.Width = (double)reader["Width"];
                        }

                        if (reader["Volume"] != DBNull.Value)
                        {
                            surfboard.Volume = (double)reader["Volume"];
                        }

                        if (reader["Price"] != DBNull.Value)
                        {
                            surfboard.Price = (int)reader["Price"];
                        }

                        if (reader["Link"] != DBNull.Value)
                        {
                            surfboard.Link = (string)reader["Link"];
                        }

                        if (reader["Image"] != DBNull.Value)
                        {
                            surfboard.Image = (string)reader["Image"];
                        }

                        if (reader["Image1"] != DBNull.Value)
                        {
                            surfboard.Image1 = (string)reader["Image1"];
                        }

                        if (reader["Image2"] != DBNull.Value)
                        {
                            surfboard.Image2 = (string)reader["Image2"];
                        }

                        if (reader["Image3"] != DBNull.Value)
                        {
                            surfboard.Image3 = (string)reader["Image3"];
                        }

                        if (reader["Image4"] != DBNull.Value)
                        {
                            surfboard.Image4 = (string)reader["Image4"];
                        }

                        //if (reader["Email"] != DBNull.Value)
                        //{
                        //    surfboard.Email = (string)reader["Email"];
                        //}

                        if (reader["FromInternalUser"] != DBNull.Value)
                        {
                            surfboard.FromInternalUser = (bool)reader["FromInternalUser"];
                        }

                        if (reader["TotalRows"] != DBNull.Value)
                        {
                            surfboard.TotalRows = (int)reader["TotalRows"];
                        }

                        if (reader["Location"] != DBNull.Value)
                        {
                            surfboard.Location = (string)reader["Location"];
                        }


                        mySurfBoards.Add(surfboard);
                    }

                    return mySurfBoards;
                }
            }
        }



    }
}