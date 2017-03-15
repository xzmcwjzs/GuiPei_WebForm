using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class students_Frame : System.Web.UI.Page
{
    protected LoginModel loginModel = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            //Response.Write("<script>alert('尚无该成员信息！');</script>");
            Response.Redirect("../Default.aspx");
            Response.End();

        }
        loginModel = (LoginModel)Session["loginModel"];
        training_base.Text = loginModel.training_base_name.ToString();
        ltRealName.Text = loginModel.real_name.ToString();
        ltDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");

    }
}