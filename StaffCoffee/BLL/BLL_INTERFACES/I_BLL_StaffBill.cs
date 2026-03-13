using StaffCoffee.Models;

namespace StaffCoffee.BLL.BLL_INTERFACES
{
    public interface I_BLL_StaffBill
    {
        List<StaffBill> GetAllBill();

        List<StaffBillDetail> GetBillDetail(int billId);

        bool UpdateBillStatus(int billId, int staffId, int status,out string mess);
    }
}
