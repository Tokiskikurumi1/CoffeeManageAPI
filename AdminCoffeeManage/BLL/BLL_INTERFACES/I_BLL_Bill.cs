using AdminCoffeeManage.Models;

namespace AdminCoffeeManage.BLL.BLL_INTERFACES
{
    public interface I_BLL_Bill
    {
        List<Bill> GetAllBill();
        List<BillDetail> GetBillDetail(int billId);
    }

}
