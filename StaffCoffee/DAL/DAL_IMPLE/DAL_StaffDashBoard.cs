using StaffCoffee.Models.DashBoard;
using StaffCoffee.Models;
using System.Data.SqlClient;
using System.Data;
using StaffCoffee.DAL.DAL_INTERFACES;
using StaffCoffee.Data;

namespace StaffCoffee.DAL.DAL_IMPLE
{
    public class DAL_StaffDashBoard : I_DAL_StaffDashBoard
    {
        private readonly DBConnect _db;

        public DAL_StaffDashBoard(DBConnect db)
        {
            _db = db;
        }

        public DashboardResponse GetDashboard(int userId, string type, DateTime? fromDate, DateTime? toDate)
        {
            var result = new DashboardResponse();

            using var conn = _db.GetConnection();
            using var cmd = new SqlCommand("st_dashboard_summary", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@Type", type);

            cmd.Parameters.AddWithValue("@FromDate", (object?)fromDate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ToDate", (object?)toDate ?? DBNull.Value);

            conn.Open();

            using var reader = cmd.ExecuteReader();

            // 1. SUMMARY
            if (reader.Read())
            {
                result.Summary = new DashboardSummary
                {
                    TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                    Pending = Convert.ToInt32(reader["Pending"]),
                    Shipping = Convert.ToInt32(reader["Shipping"]),
                    Completed = Convert.ToInt32(reader["Completed"]),
                    Cancelled = Convert.ToInt32(reader["Cancelled"])
                };
            }

            // 2. STATUS CHART
            reader.NextResult();
            result.StatusChart = new List<StatusChart>();

            while (reader.Read())
            {
                result.StatusChart.Add(new StatusChart
                {
                    Status = Convert.ToInt32(reader["Status"]),
                    StatusName = reader["StatusName"].ToString(),
                    Total = Convert.ToInt32(reader["Total"])
                });
            }

            // 3. REVENUE CHART
            reader.NextResult();
            result.RevenueChart = new List<RevenueChart>();

            while (reader.Read())
            {
                result.RevenueChart.Add(new RevenueChart
                {
                    CategoryName = reader["CategoryName"].ToString(),
                    Revenue = Convert.ToDecimal(reader["Revenue"])
                });
            }

            return result;
        }
    }
}
