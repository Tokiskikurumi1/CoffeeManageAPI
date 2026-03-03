using AdminCoffeeManage.DAL.DAL_INTERFACES;
using AdminCoffeeManage.Models;
using System.Data.SqlClient;
using System.Data;
using QLY_Coffee.Data;

namespace AdminCoffeeManage.DAL.DAL_IMPLE_
{
    public class DAL_Bill : I_DAL_Bill
    {
        private readonly DBConnect _db;

        public DAL_Bill(DBConnect db)
        {
            _db = db;
        }

        // ================= GET ALL BILL =================
        public List<Bill> GetAllBill()
        {
            var list = new List<Bill>();

            using var conn = _db.GetConnection();
            using var cmd = new SqlCommand("ad_get_bill", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
                return list;

            while (reader.Read())
            {
                list.Add(new Bill
                {
                    BillID = Convert.ToInt32(reader["BillID"]),
                    UserID = Convert.ToInt32(reader["UserID"]),
                    FullName = reader["FullName"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Email = reader["Email"].ToString(),
                    BillDate = Convert.ToDateTime(reader["BillDate"]),
                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                    Status = Convert.ToInt32(reader["Status"]),
                    StatusName = reader["StatusName"].ToString()
                });
            }

            return list;
        }

        // ================= GET BILL DETAIL =================
        public List<BillDetail> GetBillDetail(int billId)
        {
            var list = new List<BillDetail>();

            using var conn = _db.GetConnection();
            using var cmd = new SqlCommand("ad_get_bill_detail", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BillID", billId);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
                return list;

            while (reader.Read())
            {
                list.Add(new BillDetail
                {
                    BillID = Convert.ToInt32(reader["BillID"]),
                    FullName = reader["FullName"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Address = reader["Address"].ToString(),
                    BillDate = Convert.ToDateTime(reader["BillDate"]),
                    CoffeeName = reader["CoffeeName"].ToString(),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"])
                });
            }

            return list;
        }
    }
}
