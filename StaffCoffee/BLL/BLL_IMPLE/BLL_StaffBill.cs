using StaffCoffee.BLL.BLL_INTERFACES;
using StaffCoffee.DAL.DAL_INTERFACES;
using StaffCoffee.Models;
namespace StaffCoffee.BLL.BLL_IMPLE
{
    public class BLL_StaffBill : I_BLL_StaffBill
    {
        private readonly I_DAL_StaffBill _billDAL;

        public BLL_StaffBill(I_DAL_StaffBill billDAL)
        {
            _billDAL = billDAL;
        }

        public List<StaffBill> GetAllBill()
        {
            return _billDAL.GetAllBill();
        }

        public List<StaffBillDetail> GetBillDetail(int billId)
        {
            return _billDAL.GetBillDetail(billId);
        }

        public bool UpdateBillStatus(int billId, int staffId, int status, out string mess)
        {
            return _billDAL.UpdateBillStatus(billId, staffId, status, out mess);
        }
    }
}
