using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class bases_Frame : System.Web.UI.Page
{
    protected BasesModel basesModel = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["basesModel"] == null)
        {
            Response.Write("<script>alert('尚无该成员信息！');</script>");
        }
        basesModel = (BasesModel)Session["basesModel"];
        ltRealName.Text = basesModel.bases_real_name.ToString();
        ltDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");

    }
}