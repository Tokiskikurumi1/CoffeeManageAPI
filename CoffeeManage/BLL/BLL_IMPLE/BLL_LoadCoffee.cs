using CoffeeManage.BLL.BLL_INTERFACES;
using CoffeeManage.DAL.DAL_INTERFACES;
using CoffeeManage.Models;

namespace CoffeeManage.BLL.BLL_IMPLE
{
    public class BLL_LoadCoffee : I_BLL_LoadCoffee
    {
        private readonly I_DAL_LoadCoffee _coffeeDAL;

        public BLL_LoadCoffee(I_DAL_LoadCoffee coffeeDAL)
        {
            _coffeeDAL = coffeeDAL;
        }

        public List<Category> GetAllCategory()
        {
            return _coffeeDAL.GetAllCategory();
        }

        public List<Coffee> GetAllCoffee()
        {
            return _coffeeDAL.GetAllCoffee();
        }

        public List<Coffee> GetCoffeeByCategory(int categoryID)
        {
            return _coffeeDAL.GetCoffeeByCategory(categoryID);
        }
        public List<CoffeeDetail> GetCoffeeByID(int coffeeID)
        {
            return _coffeeDAL.GetCoffeeByID(coffeeID);
        }
    }
}
