using CoffeeManage.Models.Request;
using CoffeeManage.Models.Respone;

namespace CoffeeManage.DAL.DAL_INTERFACES
{
    public interface I_DAL_Customer
    {
        ProfileResponse GetProfile(int userId);

        (bool Success, string Message) UpdateProfile(UpdateProfileRequest model);

        List<MyOrderResponse> GetMyOrders(int userId, string status);

        (bool Success, string Message) CancelOrder(int billId, int userId);
    }
}
