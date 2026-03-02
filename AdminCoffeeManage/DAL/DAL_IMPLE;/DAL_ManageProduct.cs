using System.Data.SqlClient;
using System.Data;
using AdminCoffeeManage.DAL.DAL_INTERFACES;
using AdminCoffeeManage.Models;
using QLY_Coffee.Data;
using AdminCoffeeManage.Models.Request;

namespace AdminCoffeeManage.DAL
{
    public class DAL_ManageProduct : I_DAL_ManageProduct
    {
        private readonly DBConnect _db;

        public DAL_ManageProduct(DBConnect db)
        {
            _db = db;
        }

        // ================= LOAD CATEGORY =================
        public List<Category> GetAllCategory()
        {
            var list = new List<Category>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_get_categories", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Category
                            {
                                CategoryID = reader.GetInt32("CategoryID"),
                                CategoryName = reader.GetString("CategoryName")
                            });
                        }
                    }
                }
            }
            return list;
        }

        // ================= LOAD ALL PRODUCT =================
        public List<Product> GetAllCoffee()
        {
            var list = new List<Product>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_get_all_coffee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Product
                            {
                                CoffeeID = reader.GetInt32("CoffeeID"),
                                CoffeeName = reader.GetString("CoffeeName"),
                                Price = reader.GetDecimal("Price"),
                                ImageURL = reader.IsDBNull("ImageURL") ? null : reader.GetString("ImageURL"),
                                CategoryID = reader.GetInt32("CategoryID"),
                                Status = Convert.ToInt32(reader["Status"])
                            });
                        }
                    }
                }
            }
            return list;
        }
        // ================= LOAD BY IDCOFFEE =================
        //public List<ProductDetail> GetCoffeeByID(int coffeeID)
        //{
        //    var list = new List<ProductDetail>();

        //    using (SqlConnection conn = _db.GetConnection())
        //    {
        //        using (SqlCommand cmd = new SqlCommand("cf_get_coffee_detail", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@CoffeeID", coffeeID);

        //            conn.Open();
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    list.Add(new Coffee
        //                    {
        //                        CoffeeID = reader.GetInt32("CoffeeID"),
        //                        CoffeeName = reader.GetString("CoffeeName"),
        //                        Price = reader.GetDecimal("Price"),
        //                        ImageURL = reader.IsDBNull("ImageURL") ? null : reader.GetString("ImageURL"),
        //                        CategoryID = reader.GetInt32("CategoryID")
        //                    });
        //                }
        //            }
        //        }
        //    }
        //    return list;
        //}
        // ================= ADD NEW PRODUCT =================
        public bool AddProduct(ProductRequest req, out string mess)
        {
            mess = string.Empty;
            try
            {
                using (var conn = _db.GetConnection())
                {
                    using (var cmd = new SqlCommand("ad_add_coffee", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CoffeeName", req.CoffeeName);
                        cmd.Parameters.AddWithValue("@Price", req.Price);
                        cmd.Parameters.AddWithValue("@ImageURL", req.ImageURL ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CategoryID", req.CategoryID);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                mess = ex.Message;
                return false;
            }
        }

        public bool UpdateProduct(int id, ProductRequest req, out string mess)
        {
            mess = string.Empty;
            try
            {
                using (var conn = _db.GetConnection())
                {
                    using (var cmd = new SqlCommand("ad_update_coffee", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CoffeeID", id);
                        cmd.Parameters.AddWithValue("@CoffeeName", req.CoffeeName);
                        cmd.Parameters.AddWithValue("@Price", req.Price);
                        cmd.Parameters.AddWithValue("@ImageURL", req.ImageURL ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CategoryID", req.CategoryID);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                mess = ex.Message;
                return false;
            }
        }

        public bool DeleteProduct(int id, out string mess)
        {
            mess = string.Empty;
            try
            {
                using (var conn = _db.GetConnection())
                {
                    using (var cmd = new SqlCommand("ad_delete_coffee", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CoffeeID", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                mess = ex.Message;
                return false;
            }
        }
        public bool UpdateStatus(int coffeeID, out string message)
        {
            message = "";

            try
            {
                using (var conn = _db.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("ad_update_status_coffee", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CoffeeID", coffeeID);

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool success = Convert.ToInt32(reader["Success"]) == 1;
                                message = reader["Message"].ToString();
                                return success;
                            }
                        }
                    }
                }

                message = "Không xác định";
                return false;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
    }
}
