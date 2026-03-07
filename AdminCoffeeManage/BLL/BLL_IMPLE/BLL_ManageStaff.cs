using AdminCoffeeManage.BLL.BLL_INTERFACES;
using AdminCoffeeManage.DAL.DAL_INTERFACES;
using AdminCoffeeManage.Models.StaffManage;

namespace AdminCoffeeManage.BLL.BLL_IMPLE
{
    public class BLL_ManageStaff : I_BLL_ManageStaff
    {
        private readonly I_DAL_ManageStaff _staff;

        public BLL_ManageStaff(I_DAL_ManageStaff staffDAL)
        {
            _staff = staffDAL;
        }

        public List<Staff> GetAllStaff()
        {
            return _staff.GetAllStaff();
        }

        public List<Staff> GetStaffDetail(int id)
        {
            return _staff.GetStaffDetail(id);
        }

        public bool AddStaff(StaffRequest req, out string mess)
        {
            return _staff.AddStaff(req, out mess);
        }

        public bool UpdateStaff(int id, StaffRequest req, out string mess)
        {
            return _staff.UpdateStaff(id, req, out mess);
        }

        public bool UpdateStatus(int id, int status, out string mess)
        {
            return _staff.UpdateStatus(id, status, out mess);
        }

        public bool DeleteStaff(int id, out string mess)
        {
            return _staff.DeleteStaff(id, out mess);
        }
    }
}
