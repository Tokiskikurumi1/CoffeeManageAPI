using AdminCoffeeManage.Models.Report;
using System.Data.SqlClient;
using System.Data;
using AdminCoffeeManage.DAL.DAL_INTERFACES;
using QLY_Coffee.Data;
using System.Collections.Generic;

namespace AdminCoffeeManage.DAL.DAL_IMPLE_
{
    public class DAL_Report : I_DAL_Report
    {
        private readonly DBConnect _db;

        public DAL_Report(DBConnect db)
        {
            _db = db;
        }
        // ======================================================================================================
        // ================= SUMMARY =================
        public List<DashboardSummary> GetDashboardSummary()
        {
            var list = new List<DashboardSummary>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_dashboard_summary_all", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DashboardSummary
                            {
                                TotalRevenue = reader["TotalRevenue"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["TotalRevenue"]),
                                TotalBills = reader["TotalBills"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TotalBills"]),
                                AvgPerBill = reader["AvgPerBill"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["AvgPerBill"])
                            });
                            
                        }
                    }
                }
            }

            return list;
        }
        // ================ SUMMARY BY TIME RANGE =================
        public List<DashboardSummary> GetDashboardSummaryByDate(DateTime from, DateTime to)
        {
            var list = new List<DashboardSummary>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_dashboard_summary_range", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FromDate", from);
                    cmd.Parameters.AddWithValue("@ToDate", to);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DashboardSummary
                            {
                                TotalRevenue = reader["TotalRevenue"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["TotalRevenue"]),
                                TotalBills = reader["TotalBills"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TotalBills"]),
                                AvgPerBill = reader["AvgPerBill"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["AvgPerBill"])
                            });
                        }
                    }
                }
            }

            return list;
        }

        // ================ SUMMARY BY DAY/WEEK/MONTH =================
        public List<DashboardSummary> GetDashboardSummaryByType(string type)
        {
            var list = new List<DashboardSummary>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_dashboard_summary_type", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Type", type);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DashboardSummary
                            {
                                TotalRevenue = reader["TotalRevenue"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["TotalRevenue"]),
                                TotalBills = reader["TotalBills"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TotalBills"]),
                                AvgPerBill = reader["AvgPerBill"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["AvgPerBill"])
                            });
                        }
                    }
                }
            }

            return list;
        }
        // ======================================================================================================


        // ======================================================================================================
        // ================================================ TOP PRODUCT =========================================
        // ======================================================================================================

        public List<TopProduct> GetAllProduct()
        {
            var list = new List<TopProduct>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_top_products_all", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TopProduct
                            {
                                CoffeeName = reader["CoffeeName"].ToString(),
                                TotalQuantity = Convert.ToInt32(reader["TotalQuantity"]),
                                Revenue = Convert.ToDecimal(reader["Revenue"])
                            });
                        }
                    }
                }
            }

            return list;
        }
        // ================= TOP PRODUCTS DATE=================
        public List<TopProduct> GetTopProductsByDate(DateTime from, DateTime to)
        {
            var list = new List<TopProduct>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_top_products_range", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FromDate", from);
                    cmd.Parameters.AddWithValue("@ToDate", to);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TopProduct
                            {
                                CoffeeName = reader["CoffeeName"].ToString(),
                                TotalQuantity = Convert.ToInt32(reader["TotalQuantity"]),
                                Revenue = Convert.ToDecimal(reader["Revenue"])
                            });
                        }
                    }
                }
            }

            return list;
        }
        // ================= TOP PRODUCTS TYPE=================
        public List<TopProduct> GetTopProductsByType(string type)
        {
            var list = new List<TopProduct>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_top_products_type", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Type", type);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TopProduct
                            {
                                CoffeeName = reader["CoffeeName"].ToString(),
                                TotalQuantity = Convert.ToInt32(reader["TotalQuantity"]),
                                Revenue = Convert.ToDecimal(reader["Revenue"])
                            });
                        }
                    }
                }
            }

            return list;
        }


        // ======================================================================================================
        // ================================================ TOP CATEGORY =========================================
        // ======================================================================================================
        public List<TopCategory> GetAllCategory()
        {
            var list = new List<TopCategory>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_revenue_category_all", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TopCategory
                            {
                                CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                CategoryName = reader["CategoryName"].ToString(),
                                Revenue = Convert.ToDecimal(reader["Revenue"]),
                                PercentRevenue = Convert.ToInt32(reader["PercentRevenue"])
                            });
                        }
                    }
                }
            }

            return list;
        }
        // ================= TOP CATEGORY BY DATE=================
        public List<TopCategory> GetCategoryByDate(DateTime from, DateTime to)
        {
            var list = new List<TopCategory>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_revenue_category_range", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FromDate", from);
                    cmd.Parameters.AddWithValue("@ToDate", to);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TopCategory
                            {
                                CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                CategoryName = reader["CategoryName"].ToString(),
                                Revenue = Convert.ToDecimal(reader["Revenue"]),
                                PercentRevenue = Convert.ToInt32(reader["PercentRevenue"])
                            });
                        }
                    }
                }
            }

            return list;
        }
        // ================= TOP CATEGORY BY TYPE=================
        public List<TopCategory> GetCategoryByType(string type)
        {
            var list = new List<TopCategory>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_revenue_category_type", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Type", type);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TopCategory
                            {
                                CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                CategoryName = reader["CategoryName"].ToString(),
                                Revenue = Convert.ToDecimal(reader["Revenue"]),
                                PercentRevenue = Convert.ToInt32(reader["PercentRevenue"])
                            });
                        }
                    }
                }
            }

            return list;
        }


        // ======================================================================================================
        // ================================================ TOP CUSTOMER =========================================
        // ======================================================================================================

        public List<TopCustomer> GetAllCustomer()
        {
            var list = new List<TopCustomer>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_top_customers_all", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TopCustomer
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                FullName = reader["FullName"].ToString(),
                                TotalBills = Convert.ToInt32(reader["TotalBills"]),
                                TotalSpent = Convert.ToDecimal(reader["TotalSpent"]),
                            });
                        }
                    }
                }
            }

            return list;
        }
        // ================= TOP CUSTOMER BY DATE=================
        public List<TopCustomer> GetTopCustomersByDate(DateTime from, DateTime to)
        {
            var list = new List<TopCustomer>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_top_customers_range", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FromDate", from);
                    cmd.Parameters.AddWithValue("@ToDate", to);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TopCustomer
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                FullName = reader["FullName"].ToString(),
                                TotalBills = Convert.ToInt32(reader["TotalBills"]),
                                TotalSpent = Convert.ToDecimal(reader["TotalSpent"]),
                            });
                        }
                    }
                }
            }

            return list;
        }

        // ================= TOP CUSTOMER BY TYPE=================
        public List<TopCustomer> GetTopCustomerByType(string type)
        {
            var list = new List<TopCustomer>();

            using (SqlConnection conn = _db.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("ad_top_customers_type", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Type", type);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TopCustomer
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                FullName = reader["FullName"].ToString(),
                                TotalBills = Convert.ToInt32(reader["TotalBills"]),
                                TotalSpent = Convert.ToDecimal(reader["TotalSpent"]),
                            });
                        }
                    }
                }
            }

            return list;
        }

        
    }
}
