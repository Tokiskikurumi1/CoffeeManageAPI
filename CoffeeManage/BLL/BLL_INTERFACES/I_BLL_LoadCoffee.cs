using CoffeeManage.Models;

namespace CoffeeManage.BLL.BLL_INTERFACES
{
    public interface I_BLL_LoadCoffee
    {
        List<Category> GetAllCategory();
        List<Coffee> GetAllCoffee();
        List<Coffee> GetCoffeeByCategory(int categoryID);
        List<CoffeeDetail> GetCoffeeByID(int coffeeID);
    }
}
