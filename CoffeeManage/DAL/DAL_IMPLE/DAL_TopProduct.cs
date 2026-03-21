using System.Data.SqlClient;
using System.Data;
using CoffeeManage.Models.Respone;
using QLY_Coffee.Data;
using CoffeeManage.DAL.DAL_INTERFACES;

namespace CoffeeManage.DAL.DAL_IMPLE
{
    public class DAL_TopProduct : I_DAL_TopProduct
    {
        private readonly DBConnect _db;

        public DAL_TopProduct(DBConnect db)
        {
            _db = db;
        }
        public List<TotalProduct> GetTopSellingCoffee()
        {
            var list = new List<TotalProduct>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("cf_top_10_best_selling", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TotalProduct
                            {
                                CoffeeID = reader.GetInt32("CoffeeID"),
                                CoffeeName = reader.GetString("CoffeeName"),
                                ImageURL = reader.IsDBNull("ImageURL")
                                            ? null
                                            : reader.GetString("ImageURL"),
                                TotalSold = reader.GetInt32("TotalSold")
                            });
                        }
                    }
                }
            }

            return list;
        }
    }
}
