using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class teachers_Frame : System.Web.UI.Page
{
    protected LoginModel loginModel = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Redirect("../Default.aspx");
            Response.End();
        }
        loginModel = (LoginModel)Session["loginModel"];
        ltRealName.Text = loginModel.real_name.ToString();
        training_base.Text = loginModel.training_base_name.ToString();
        ltDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
        professional_base.Text = loginModel.professional_base_name.ToString();
        dept.Text = loginModel.dept_name.ToString();

    }
}