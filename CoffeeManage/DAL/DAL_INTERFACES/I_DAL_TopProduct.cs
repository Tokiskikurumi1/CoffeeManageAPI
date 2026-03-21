using CoffeeManage.Models.Respone;

namespace CoffeeManage.DAL.DAL_INTERFACES
{
    public interface I_DAL_TopProduct
    {
        List<TotalProduct> GetTopSellingCoffee();
    }
}
