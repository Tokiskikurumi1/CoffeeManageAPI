using CoffeeManage.BLL.BLL_INTERFACES;
using CoffeeManage.DAL.DAL_INTERFACES;
using CoffeeManage.Models.Request;
using CoffeeManage.Models.Respone;

namespace CoffeeManage.BLL.BLL_IMPLE
{
    public class BLL_Customer : I_BLL_Customer
    {
        private readonly I_DAL_Customer _customerDAL;

        public BLL_Customer(I_DAL_Customer dal)
        {
            _customerDAL = dal;
        }

        public ProfileResponse GetProfile(int userId)
        {
            return _customerDAL.GetProfile(userId);
        }

        public (bool Success, string Message) UpdateProfile(UpdateProfileRequest model)
        {
            return _customerDAL.UpdateProfile(model);
        }

        public List<MyOrderResponse> GetMyOrders(int userId, string status)
        {
            return _customerDAL.GetMyOrders(userId, status);
        }

        public (bool Success, string Message) CancelOrder(int billId, int userId)
        {
            return _customerDAL.CancelOrder(billId, userId);
        }
    }
}