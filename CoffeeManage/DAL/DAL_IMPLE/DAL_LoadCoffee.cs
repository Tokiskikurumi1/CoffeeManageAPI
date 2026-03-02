using static CoffeeManage.DAL.DAL_IMPLE.DAL_LoadCoffee;
using System.Data.SqlClient;
using System.Data;
using CoffeeManage.DAL.DAL_INTERFACES;
using CoffeeManage.Models;
using QLY_Coffee.Data;

namespace CoffeeManage.DAL.DAL_IMPLE
{
    public class DAL_LoadCoffee : I_DAL_LoadCoffee
    {
        private readonly DBConnect _db;

        public DAL_LoadCoffee(DBConnect db)
        {
            _db = db;
        }

        // ================= LOAD CATEGORY =================
        public List<Category> GetAllCategory()
        {
            var list = new List<Category>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("cf_get_categories", conn))
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
        public List<Coffee> GetAllCoffee()
        {
            var list = new List<Coffee>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("cf_get_all_coffee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Coffee
                            {
                                CoffeeID = reader.GetInt32("CoffeeID"),
                                CoffeeName = reader.GetString("CoffeeName"),
                                Price = reader.GetDecimal("Price"),
                                ImageURL = reader.IsDBNull("ImageURL") ? null : reader.GetString("ImageURL"),
                                CategoryID = reader.GetInt32("CategoryID")
                            });
                        }
                    }
                }
            }
            return list;
        }

        // ================= LOAD BY CATEGORY =================
        public List<Coffee> GetCoffeeByCategory(int categoryID)
        {
            var list = new List<Coffee>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("cf_get_coffee_by_category", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Coffee
                            {
                                CoffeeID = reader.GetInt32("CoffeeID"),
                                CoffeeName = reader.GetString("CoffeeName"),
                                Price = reader.GetDecimal("Price"),
                                ImageURL = reader.IsDBNull("ImageURL") ? null : reader.GetString("ImageURL"),
                                CategoryID = reader.GetInt32("CategoryID")
                            });
                        }
                    }
                }
            }
            return list;
        }

        // ================= LOAD BY IDCOFFEE =================
        public List<Coffee> GetCoffeeByID(int coffeeID)
        {
            var list = new List<Coffee>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("cf_get_coffee_detail", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CoffeeID", coffeeID);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Coffee
                            {
                                CoffeeID = reader.GetInt32("CoffeeID"),
                                CoffeeName = reader.GetString("CoffeeName"),
                                Price = reader.GetDecimal("Price"),
                                ImageURL = reader.IsDBNull("ImageURL") ? null : reader.GetString("ImageURL"),
                                CategoryID = reader.GetInt32("CategoryID")
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
