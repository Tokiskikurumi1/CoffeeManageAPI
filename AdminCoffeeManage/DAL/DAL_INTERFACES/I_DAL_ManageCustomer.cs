using AdminCoffeeManage.Models;

namespace AdminCoffeeManage.DAL.DAL_INTERFACES
{
    public interface I_DAL_ManageCustomer
    {
        //List<BillDetail> GetBillDetail(int billID);
        List<Customer> GetAllCustomer();
        bool UpdateUserStatus(int userID, int status, out string mess);
        List<CustomerDetail> GetCustomerDetail(int userID);
    }
}
