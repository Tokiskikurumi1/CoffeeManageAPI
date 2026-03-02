using AdminCoffeeManage.BLL.BLL_INTERFACES;
using AdminCoffeeManage.DAL.DAL_INTERFACES;
using AdminCoffeeManage.Models;
using AdminCoffeeManage.Models.Request;

namespace AdminCoffeeManage.BLL.BLL_IMPLE
{
    public class BLL_ManageProduct : I_BLL_ManageProduct
    {
        private readonly I_DAL_ManageProduct _product;

        public BLL_ManageProduct(I_DAL_ManageProduct coffeeDAL)
        {
            _product = coffeeDAL;
        }

        public List<Category> GetAllCategory()
        {
            return _product.GetAllCategory();
        }

        public List<Product> GetAllCoffee()
        {
            return _product.GetAllCoffee();
        }
        public bool AddProduct(ProductRequest req, out string mess)
        {
            return _product.AddProduct(req, out mess);
        }

        public bool UpdateProduct(int id, ProductRequest req, out string mess)
        {
            return _product.UpdateProduct(id, req, out mess);
        }

        public bool DeleteProduct(int id, out string mess)
        {
            return _product.DeleteProduct(id, out mess);
        }
        public bool UpdateStatus(int coffeeID, out string message)
        {
            return _product.UpdateStatus(coffeeID, out message);
        }
    }
}
