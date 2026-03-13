using StaffCoffee.DAL.DAL_INTERFACES;
using System.Data.SqlClient;
using System.Data;
using StaffCoffee.Models;
using StaffCoffee.Data;
namespace StaffCoffee.DAL.DAL_IMPLE
{
    public class DAL_StaffBill : I_DAL_StaffBill
    {
        private readonly DBConnect _db;

        public DAL_StaffBill(DBConnect db)
        {
            _db = db;
        }

        // ================= GET ALL BILL =================
        public List<StaffBill> GetAllBill()
        {
            var list = new List<StaffBill>();

            using var conn = _db.GetConnection();
            using var cmd = new SqlCommand("st_get_all_bill", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new StaffBill
                {
                    BillID = Convert.ToInt32(reader["BillID"]),
                    CustomerName = reader["CustomerName"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    BillDate = Convert.ToDateTime(reader["BillDate"]),
                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                    Status = Convert.ToInt32(reader["Status"]),
                    StatusName = reader["StatusName"].ToString()
                });
            }

            return list;
        }

        // ================= GET BILL DETAIL =================
        public List<StaffBillDetail> GetBillDetail(int billId)
        {
            var list = new List<StaffBillDetail>();

            using var conn = _db.GetConnection();
            using var cmd = new SqlCommand("st_get_bill_detail", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BillID", billId);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new StaffBillDetail
                {
                    CoffeeName = reader["CoffeeName"].ToString(),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    SubTotal = Convert.ToDecimal(reader["SubTotal"])
                });
            }

            return list;
        }

        // ================= UPDATE BILL STATUS =================
        public bool UpdateBillStatus(int billId, int staffId, int status, out string messs)
        {
            messs = string.Empty;
            try
            {
                using var conn = _db.GetConnection();
                using var cmd = new SqlCommand("st_update_bill", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BillID", billId);
                cmd.Parameters.AddWithValue("@StaffID", staffId);
                cmd.Parameters.AddWithValue("@Status", status);

                conn.Open();

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                messs = ex.Message;
                return false;
            }
        }
    }
}
