using EmployeeManagementSystem.DAL;

namespace EmployeeManagementSystem.BLL
{
    public class UserBLL
    {
        private readonly UserDAL userDAL = new UserDAL();

        public int Login(string username, string password)
        {
            return userDAL.Login(username, password);
        }
    }
}