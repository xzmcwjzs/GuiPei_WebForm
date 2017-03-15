using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class managers_Frame : System.Web.UI.Page
{
    protected ManagersModel managersModel = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["managersModel"] == null)
        {
            Response.Write("<script>alert('尚无该成员信息！');</script>");
        }
        managersModel = (ManagersModel)Session["managersModel"];
        ltRealName.Text = managersModel.managers_real_name.ToString();
        ltDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");

    }
}