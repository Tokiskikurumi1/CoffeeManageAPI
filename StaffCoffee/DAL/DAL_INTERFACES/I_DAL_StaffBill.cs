using StaffCoffee.Models;

namespace StaffCoffee.DAL.DAL_INTERFACES
{
    public interface I_DAL_StaffBill
    {
        List<StaffBill> GetAllBill();

        List<StaffBillDetail> GetBillDetail(int billId);

        bool UpdateBillStatus(int billId, int staffId, int status, out string mess);
    }
}
