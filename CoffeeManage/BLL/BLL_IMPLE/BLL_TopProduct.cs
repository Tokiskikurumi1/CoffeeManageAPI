using CoffeeManage.BLL.BLL_INTERFACES;
using CoffeeManage.DAL.DAL_INTERFACES;
using CoffeeManage.Models.Respone;

namespace CoffeeManage.BLL.BLL_IMPLE
{
    public class BLL_TopProduct : I_BLL_TopProduct
    {
        private readonly I_DAL_TopProduct _coffeeDAL;
        public BLL_TopProduct(I_DAL_TopProduct coffeeDAL)
        {
            _coffeeDAL = coffeeDAL;
        }
        public List<TotalProduct> GetTopSellingCoffee()
        {
            return _coffeeDAL.GetTopSellingCoffee();
        }
    }
}
