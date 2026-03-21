using CoffeeManage.Models.Respone;

namespace CoffeeManage.BLL.BLL_INTERFACES
{
    public interface I_BLL_TopProduct
    {
        List<TotalProduct> GetTopSellingCoffee();
    }
}
