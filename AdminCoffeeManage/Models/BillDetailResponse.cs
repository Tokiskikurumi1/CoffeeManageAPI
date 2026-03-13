namespace AdminCoffeeManage.Models
{
    public class BillDetailResponse
    {
        public List<BillDetail> Products { get; set; }
        public List<BillLog> Logs { get; set; }
    }
}
