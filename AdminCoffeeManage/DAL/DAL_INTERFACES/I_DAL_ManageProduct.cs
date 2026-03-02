using AdminCoffeeManage.Models;
using AdminCoffeeManage.Models.Request;

namespace AdminCoffeeManage.DAL.DAL_INTERFACES
{
    public interface I_DAL_ManageProduct
    {
        List<Category> GetAllCategory();
        List<Product> GetAllCoffee();
        bool AddProduct(ProductRequest req, out string mess);
        bool UpdateProduct(int id, ProductRequest req, out string mess);
        bool DeleteProduct(int id, out string mess);
        bool UpdateStatus(int coffeeID, out string message);
    }
}
