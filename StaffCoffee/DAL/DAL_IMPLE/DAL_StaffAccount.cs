using StaffCoffee.DAL.DAL_INTERFACES;
using System.Data.SqlClient;
using System.Data;
using StaffCoffee.Data;
using StaffCoffee.Models;

namespace StaffCoffee.DAL.DAL_IMPLE
{
    public class DAL_StaffAccount : I_DAL_StaffAccount
    {
        private readonly DBConnect _db;

        public DAL_StaffAccount(DBConnect db)
        {
            _db = db;
        }

        // ================= GET PROFILE =================
        public StaffProfile GetProfile(int userId)
        {
            using var conn = _db.GetConnection();
            using var cmd = new SqlCommand("st_get_profile", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userId);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new StaffProfile
                {
                    UserID = Convert.ToInt32(reader["UserID"]),
                    Username = reader["Username"].ToString(),
                    FullName = reader["FullName"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Email = reader["Email"].ToString(),
                    Address = reader["Address"].ToString()
                };
            }

            return null;
        }

        // ================= CHANGE PASSWORD =================
        public bool ChangePassword(int userId, string oldPass, string newPass, out string mess)
        {
            mess = "";
            try
            {
                using var conn = _db.GetConnection();
                using var cmd = new SqlCommand("st_change_password", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@OldPassword", oldPass);
                cmd.Parameters.AddWithValue("@NewPassword", newPass);

                conn.Open();

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var success = Convert.ToInt32(reader["Success"]);
                    mess = reader["Message"].ToString();
                    return success == 1;
                }

                return false;
            }
            catch (SqlException ex)
            {
                mess = ex.Message;
                return false;
            }
        }

        // ================= UPDATE PROFILE =================
        public bool UpdateProfile(int userId, UpdateProfile model, out string mess)
        {
            mess = "";
            try
            {
                using var conn = _db.GetConnection();
                using var cmd = new SqlCommand("st_update_profile", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@FullName", model.FullName);
                cmd.Parameters.AddWithValue("@Gender", model.Gender);
                cmd.Parameters.AddWithValue("@Phone", model.Phone);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Address", model.Address);

                conn.Open();

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var success = Convert.ToInt32(reader["Success"]);
                    mess = reader["Message"].ToString();
                    return success == 1;
                }

                return false;
            }
            catch (SqlException ex)
            {
                mess = ex.Message;
                return false;
            }
        }
    }
}
