using AdminCoffeeManage.Models.StaffManage;

namespace AdminCoffeeManage.BLL.BLL_INTERFACES
{
    public interface I_BLL_ManageStaff
    {
        List<Staff> GetAllStaff();
        List<Staff> GetStaffDetail(int id);
        bool AddStaff(StaffRequest req, out string mess);
        bool UpdateStaff(int id, StaffRequest req, out string mess);
        bool UpdateStatus(int id, int status, out string mess);
        bool DeleteStaff(int id, out string mess);
    }
}
