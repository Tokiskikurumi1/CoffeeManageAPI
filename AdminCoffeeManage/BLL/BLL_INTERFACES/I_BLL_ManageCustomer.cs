using AdminCoffeeManage.Models;

namespace AdminCoffeeManage.BLL.BLL_INTERFACES
{
    public interface I_BLL_ManageCustomer
    {
        //List<BillDetail> GetBillDetail(int billID);
        List<Customer> GetAllCustomer();
        bool UpdateUserStatus(int userID, int status, out string mess);
        List<CustomerDetail> GetCustomerDetail(int userID);
    }
}
