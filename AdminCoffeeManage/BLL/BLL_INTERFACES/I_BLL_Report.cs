using AdminCoffeeManage.Models.Report;

namespace AdminCoffeeManage.BLL.BLL_INTERFACES
{
    public interface I_BLL_Report
    {
        // ======= SUMARY REVENUE =======
        List<DashboardSummary> GetDashboardSummary();
        List<DashboardSummary> GetDashboardSummaryByDate(DateTime from, DateTime to);
        List<DashboardSummary> GetDashboardSummaryByType(string type);

        // ============ TOP PRODUCT ======================
        List<TopProduct> GetAllProduct();
        List<TopProduct> GetTopProductsByDate(DateTime from, DateTime to);
        List<TopProduct> GetTopProductsByType(string type);

        // ============= TOP CATEGORY ===================================
        List<TopCategory> GetAllCategory();
        List<TopCategory> GetCategoryByDate(DateTime from, DateTime to);
        List<TopCategory> GetCategoryByType(string type);

        // ============== TOP CUSTOMER ==================================
        List<TopCustomer> GetAllCustomer();
        List<TopCustomer> GetTopCustomersByDate(DateTime from, DateTime to);
        List<TopCustomer> GetTopCustomerByType(string type);
    }
}
