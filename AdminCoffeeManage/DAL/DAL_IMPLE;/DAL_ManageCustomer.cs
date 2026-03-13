using AdminCoffeeManage.DAL.DAL_INTERFACES;
using System.Data.SqlClient;
using System.Data;
using QLY_Coffee.Data;
using AdminCoffeeManage.Models;

namespace AdminCoffeeManage.DAL.DAL_IMPLE_
{
    public class DAL_ManageCustomer : I_DAL_ManageCustomer
    {
        private readonly DBConnect _db;

        public DAL_ManageCustomer(DBConnect db)
        {
            _db = db;
        }

        // ================= BILL DETAIL =================
        //public List<BillDetail> GetBillDetail(int billID)
        //{
        //    var list = new List<BillDetail>();

        //    using (SqlConnection conn = _db.GetConnection())
        //    {
        //        using (SqlCommand cmd = new SqlCommand("ad_get_bill_detail", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@BillID", billID);

        //            conn.Open();
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    list.Add(new BillDetail
        //                    {
        //                        BillID = reader.GetInt32("BillID"),
        //                        FullName = reader.GetString("FullName"),
        //                        Phone = reader.GetString("Phone"),
        //                        Address = reader.GetString("Address"),
        //                        BillDate = reader.GetDateTime("BillDate"),
        //                        CoffeeName = reader.GetString("CoffeeName"),
        //                        Quantity = reader.GetInt32("Quantity"),
        //                        UnitPrice = reader.GetDecimal("UnitPrice"),
        //                        TotalAmount = reader.GetDecimal("TotalAmount")
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    return list;
        //}

        // ================= ALL CUSTOMER =================
        public List<Customer> GetAllCustomer()
        {
            var list = new List<Customer>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_get_all_customers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Customer
                            {
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),

                                FullName = reader["FullName"] == DBNull.Value
                                            ? ""
                                            : reader["FullName"].ToString(),

                                Phone = reader["Phone"] == DBNull.Value
                                            ? ""
                                            : reader["Phone"].ToString(),

                                Email = reader["Email"] == DBNull.Value
                                            ? ""
                                            : reader["Email"].ToString(),

                                Address = reader["Address"] == DBNull.Value
                                            ? ""
                                            : reader["Address"].ToString(),
                                Status = reader["Status"] == DBNull.Value
                                            ? (int?)null
                                            : Convert.ToInt32(reader["Status"]),
                                TotalSpent = reader["TotalSpent"] == DBNull.Value
                                            ? (decimal?)null
                                            : Convert.ToDecimal(reader["TotalSpent"]),
                            });
                        }
                    }
                }
            }

            return list;
        }
        // ================= GET CUSTOMER DETAIL =================
        public List<CustomerDetail> GetCustomerDetail(int userID)
        {
            var list = new List<CustomerDetail>();
            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_get_customer_detail", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            list.Add(new CustomerDetail
                            {
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                FullName = reader["FullName"]?.ToString(),
                                Gender = reader["Gender"]?.ToString(),
                                Address = reader["Address"]?.ToString(),
                                Phone = reader["Phone"]?.ToString(),
                                Email = reader["Email"]?.ToString(),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                                Status = Convert.ToInt32(reader["Status"]),
                                StatusName = reader["StatusName"]?.ToString()
                            });
                        }
                    }
                }
            }

            return list;
        }

        // ================= UPDATE STATUS =================
        public bool UpdateUserStatus(int userID, int status, out string mess)
        {
            mess = "";

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_update_user_status", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@Status", status);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool success = Convert.ToInt32(reader["Success"]) == 1;
                            mess = reader["Message"].ToString();
                            return success;
                        }
                    }
                }
            }

            mess = "Không xác định";
            return false;
        }
    }
}