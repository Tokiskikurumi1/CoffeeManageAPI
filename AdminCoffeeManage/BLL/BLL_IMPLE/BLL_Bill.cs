using AdminCoffeeManage.BLL.BLL_INTERFACES;
using AdminCoffeeManage.DAL.DAL_INTERFACES;
using AdminCoffeeManage.Models;

namespace AdminCoffeeManage.BLL.BLL_IMPLE
{
    public class BLL_Bill : I_BLL_Bill
    {
        private readonly I_DAL_Bill _bill;
        public BLL_Bill(I_DAL_Bill bill)
        {
            _bill = bill;
        }
        public List<Bill> GetAllBill()
        {
            return _bill.GetAllBill();
        }

        public List<BillDetail> GetBillDetail(int billId)
        {
            return _bill.GetBillDetail(billId);
        }
    }
}
