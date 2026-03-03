namespace AdminCoffeeManage.Models
{
    public class Bill
    {
        public int BillID { get; set; }
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BillDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
    }
}
