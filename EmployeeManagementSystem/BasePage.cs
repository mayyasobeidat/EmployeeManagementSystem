using System;
using System.Web.UI;

namespace EmployeeManagementSystem
{
    public class BasePage : Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Pages/Login.aspx");
                return;
            }

            base.OnInit(e);
        }
    }
}