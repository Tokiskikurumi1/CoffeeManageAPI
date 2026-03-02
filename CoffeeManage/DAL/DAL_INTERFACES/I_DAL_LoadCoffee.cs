using CoffeeManage.Models;
namespace CoffeeManage.DAL.DAL_INTERFACES
{
    public interface I_DAL_LoadCoffee
    {
        List<Category> GetAllCategory();
        List<Coffee> GetAllCoffee();
        List<Coffee> GetCoffeeByCategory(int categoryID);
        List<Coffee> GetCoffeeByID(int coffeeID);
    }
}