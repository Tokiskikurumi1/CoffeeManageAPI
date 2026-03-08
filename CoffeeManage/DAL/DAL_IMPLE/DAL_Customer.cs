using CoffeeManage.DAL.DAL_INTERFACES;
using System.Data.SqlClient;
using System.Data;
using QLY_Coffee.Data;
using CoffeeManage.Models.Respone;
using CoffeeManage.Models.Request;

namespace CoffeeManage.DAL.DAL_IMPLE
{
    public class DAL_Customer : I_DAL_Customer
    {
        private readonly DBConnect _db;

        public DAL_Customer(DBConnect db)
        {
            _db = db;
        }

        public ProfileResponse GetProfile(int userId)
        {
            using var conn = _db.GetConnection();
            using var cmd = new SqlCommand("cf_get_profile", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userId);

            conn.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new ProfileResponse
                {
                    UserID = Convert.ToInt32(reader["UserID"]),
                    Username = reader["Username"].ToString(),
                    FullName = reader["FullName"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Email = reader["Email"].ToString(),
                    Address = reader["Address"].ToString(),
                    Avatar = reader["Avatar"].ToString(),
                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                    Status = Convert.ToInt32(reader["Status"])
                };
            }

            return null;
        }

        public (bool Success, string Message) UpdateProfile(UpdateProfileRequest model)
        {
            using var conn = _db.GetConnection();
            using var cmd = new SqlCommand("cf_update_profile", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", model.UserID);
            cmd.Parameters.AddWithValue("@FullName", model.FullName);
            cmd.Parameters.AddWithValue("@Gender", model.Gender);
            cmd.Parameters.AddWithValue("@Phone", model.Phone);
            cmd.Parameters.AddWithValue("@Email", model.Email);
            cmd.Parameters.AddWithValue("@Address", model.Address);
            cmd.Parameters.AddWithValue("@Avatar", model.Avatar);

            conn.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                bool success = Convert.ToInt32(reader["Success"]) == 1;
                string message = reader["Message"].ToString();

                return (success, message);
            }

            return (false, "Lỗi cập nhật");
        }

        public List<MyOrderResponse> GetMyOrders(int userId, string status)
        {
            var list = new List<MyOrderResponse>();

            using var conn = _db.GetConnection();
            using var cmd = new SqlCommand("cf_get_my_orders", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@Status", status);

            conn.Open();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new MyOrderResponse
                {
                    BillID = Convert.ToInt32(reader["BillID"]),
                    BillDate = Convert.ToDateTime(reader["BillDate"]),
                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                    Status = Convert.ToInt32(reader["Status"]),
                    StatusName = reader["StatusName"].ToString(),
                    CoffeeName = reader["CoffeeName"].ToString(),
                    ImageURL = reader["ImageURL"].ToString(),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    SubTotal = Convert.ToDecimal(reader["SubTotal"])
                });
            }

            return list;
        }

        public (bool Success, string Message) CancelOrder(int billId, int userId)
        {
            using var conn = _db.GetConnection();
            using var cmd = new SqlCommand("cf_cancel_order", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BillID", billId);
            cmd.Parameters.AddWithValue("@UserID", userId);

            conn.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                bool success = Convert.ToInt32(reader["Success"]) == 1;
                string message = reader["Message"].ToString();

                return (success, message);
            }

            return (false, "Lỗi hủy đơn");
        }
    }
}
