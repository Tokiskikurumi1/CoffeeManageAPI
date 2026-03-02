using CoffeeManage.DAL.DAL_INTERFACES;
using System.Data.SqlClient;
using System.Data;
using QLY_Coffee.Data;
using CoffeeManage.Models.Request;

namespace CoffeeManage.DAL.DAL_IMPLE
{
    public class DAL_Cart : I_DAL_Cart
    {
        private readonly DBConnect _db;

        public DAL_Cart(DBConnect db)
        {
            _db = db;
        }

        public bool AddToCart(AddToCartRequest req, out string mess)
        {
            mess = string.Empty;

            try
            {
                using var conn = _db.GetConnection();
                using var cmd = new SqlCommand("cf_add_to_cart", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", req.UserID);
                cmd.Parameters.AddWithValue("@CoffeeID", req.CoffeeID);
                cmd.Parameters.AddWithValue("@Quantity", req.Quantity);

                conn.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                mess = ex.Message;
                return false;
            }
        }

        public (bool Success, string Message) Checkout(int userId)
        {
            try
            {
                using var conn = _db.GetConnection();
                using var cmd = new SqlCommand("cf_checkout", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    bool success = Convert.ToInt32(reader["Success"]) == 1;
                    string message = reader["Message"].ToString();
                    return (success, message);
                }

                return (false, "Lỗi thanh toán");
            }
            catch (SqlException ex)
            {
                return (false, ex.Message);
            }
        }
    }
}

