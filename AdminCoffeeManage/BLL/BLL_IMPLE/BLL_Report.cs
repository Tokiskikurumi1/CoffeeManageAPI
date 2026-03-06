using AdminCoffeeManage.BLL.BLL_INTERFACES;
using AdminCoffeeManage.DAL.DAL_INTERFACES;
using AdminCoffeeManage.Models.Report;

namespace AdminCoffeeManage.BLL.BLL_IMPLE
{
    public class BLL_Report : I_BLL_Report
    {
        private readonly I_DAL_Report _dal;

        public BLL_Report(I_DAL_Report dal)
        {
            _dal = dal;
        }

        // ======= SUMARY REVENUE =======
        public List<DashboardSummary> GetDashboardSummary()
        {
            return _dal.GetDashboardSummary();
        }
        public List<DashboardSummary> GetDashboardSummaryByDate(DateTime from, DateTime to)
        {
            return _dal.GetDashboardSummaryByDate(from, to);
        }
        public List<DashboardSummary> GetDashboardSummaryByType(string type)
        {
            return _dal.GetDashboardSummaryByType(type);
        }

        // ============ TOP PRODUCT ======================
        public List<TopProduct> GetAllProduct()
        {
            return _dal.GetAllProduct();
        }
        public List<TopProduct> GetTopProductsByDate(DateTime from, DateTime to)
        {
            return _dal.GetTopProductsByDate(from, to);
        }
        public List<TopProduct> GetTopProductsByType(string type)
        {
            return _dal.GetTopProductsByType(type);
        }

        // ============= TOP CATEGORY ===================================
        public List<TopCategory> GetAllCategory()
        {
            return _dal.GetAllCategory();
        }
        public List<TopCategory> GetCategoryByDate(DateTime from, DateTime to)
        {
            return _dal.GetCategoryByDate(from, to);
        }
        public List<TopCategory> GetCategoryByType(string type)
        {
            return _dal.GetCategoryByType(type);
        }

        // ============== TOP CUSTOMER ==================================
        public List<TopCustomer> GetAllCustomer()
        {
            return _dal.GetAllCustomer();
        }
        public List<TopCustomer> GetTopCustomersByDate(DateTime from, DateTime to)
        {
            return _dal.GetTopCustomersByDate(from, to);
        }
        public List<TopCustomer> GetTopCustomerByType(string type)
        {
            return _dal.GetTopCustomerByType(type);
        }
        
    }
}
