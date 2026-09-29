using System;
using EmployeeManagementSystem.BLL;

namespace EmployeeManagementSystem.Pages
{
    public partial class Login : System.Web.UI.Page
    {


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            try
            {
                UserBLL userBLL = new UserBLL();

                int userId = userBLL.Login(username, password);

                if (userId > 0)
                {
                    Session["UserId"] = userId;
                    Session["Username"] = username;

                    Response.Redirect("~/Pages/Dashboard.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid username or password.";
                }
            }
            catch (Exception)
            {
                lblMessage.Text = "An error occurred while logging in.";
            }
        }
    }
}