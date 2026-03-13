using AdminCoffeeManage.BLL.BLL_INTERFACES;
using AdminCoffeeManage.DAL.DAL_INTERFACES;
using AdminCoffeeManage.Models;

namespace AdminCoffeeManage.BLL.BLL_IMPLE
{
    public class BLL_ManageCustomer : I_BLL_ManageCustomer
    {
        private readonly I_DAL_ManageCustomer _dal;

        public BLL_ManageCustomer(I_DAL_ManageCustomer dal)
        {
            _dal = dal;
        }

        //public List<BillDetail> GetBillDetail(int billID)
        //{
        //    return _dal.GetBillDetail(billID);
        //}

        public List<Customer> GetAllCustomer()
        {
            return _dal.GetAllCustomer();
        }

        public bool UpdateUserStatus(int userID, int status, out string mess)
        {
            return _dal.UpdateUserStatus(userID, status, out mess);
        }
        public List<CustomerDetail> GetCustomerDetail(int userID)
        {
            return _dal.GetCustomerDetail(userID);
        }
    }
}
