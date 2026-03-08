using AdminCoffeeManage.Models.StaffManage;
using System.Data.SqlClient;
using System.Data;
using QLY_Coffee.Data;
using AdminCoffeeManage.DAL.DAL_INTERFACES;

namespace AdminCoffeeManage.DAL.DAL_IMPLE_
{
    public class DAL_ManageStaff : I_DAL_ManageStaff
    {
        private readonly DBConnect _db;

        public DAL_ManageStaff(DBConnect db)
        {
            _db = db;
        }

        public List<Staff> GetAllStaff()
        {
            var list = new List<Staff>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_get_all_staff", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Staff
                            {
                                UserID = reader.GetInt32("UserID"),
                                FullName = reader.GetString("FullName"),
                                Gender = reader.GetString("Gender"),
                                Address = reader.GetString("Address"),
                                Phone = reader.GetString("Phone"),
                                Email = reader.GetString("Email"),
                                CreatedAt = reader.GetDateTime("CreatedAt"),
                                Status = Convert.ToInt32(reader["Status"])
                            });
                        }
                    }
                }
            }

            return list;
        }

        public List<Staff> GetStaffDetail(int id)
        {
            var list = new List<Staff>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_get_staff_detail", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", id);

                    conn.Open();

                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new Staff
                                {
                                    UserID = reader.GetInt32("UserID"),
                                    Username = reader.GetString("Username"),
                                    PasswordHash = reader.GetString("PasswordHash"),
                                    FullName = reader.GetString("FullName"),
                                    Gender = reader.GetString("Gender"),
                                    Address = reader.GetString("Address"),
                                    Phone = reader.GetString("Phone"),
                                    Email = reader.GetString("Email"),
                                    CreatedAt = reader.GetDateTime("CreatedAt"),
                                    Status = Convert.ToInt32(reader["Status"])
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return list;
        }

        public bool AddStaff(StaffRequest req, out string mess)
        {
            mess = "";

            try
            {
                using (SqlConnection conn = _db.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("ad_add_staff", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Username", req.Username);
                        cmd.Parameters.AddWithValue("@PasswordHash", req.PasswordHash);
                        cmd.Parameters.AddWithValue("@FullName", req.FullName);
                        cmd.Parameters.AddWithValue("@Gender", req.Gender);
                        cmd.Parameters.AddWithValue("@Phone", req.Phone);
                        cmd.Parameters.AddWithValue("@Email", req.Email);
                        cmd.Parameters.AddWithValue("@Address", req.Address);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                mess = ex.Message;
                return false;
            }
        }

        public bool UpdateStaff(int id, StaffRequest req, out string mess)
        {
            mess = "";

            try
            {
                using (SqlConnection conn = _db.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("ad_update_staff_account", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserID", id);
                        cmd.Parameters.AddWithValue("@Username", req.Username);
                        cmd.Parameters.AddWithValue("@PasswordHash", req.PasswordHash);
                        cmd.Parameters.AddWithValue("@FullName", req.FullName);
                        cmd.Parameters.AddWithValue("@Gender", req.Gender);
                        cmd.Parameters.AddWithValue("@Phone", req.Phone);
                        cmd.Parameters.AddWithValue("@Email", req.Email);
                        cmd.Parameters.AddWithValue("@Address", req.Address);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                mess = ex.Message;
                return false;
            }
        }

        public bool UpdateStatus(int id, int status, out string mess)
        {
            mess = "";

            try
            {
                using (SqlConnection conn = _db.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("ad_update_staff_status", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserID", id);
                        cmd.Parameters.AddWithValue("@Status", status);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                mess = ex.Message;
                return false;
            }
        }

        public bool DeleteStaff(int id, out string mess)
        {
            mess = "";

            try
            {
                using (SqlConnection conn = _db.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("ad_delete_staff", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserID", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                mess = ex.Message;
                return false;
            }
        }
    }
}
