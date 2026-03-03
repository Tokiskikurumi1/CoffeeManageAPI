using AdminCoffeeManage.Models;

namespace AdminCoffeeManage.DAL.DAL_INTERFACES
{
    public interface I_DAL_Bill
    {
        List<Bill> GetAllBill();
        List<BillDetail> GetBillDetail(int billId);
    }
}
