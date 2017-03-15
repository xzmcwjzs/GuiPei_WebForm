using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;

public partial class Statics_Managers_IdentityType_List : System.Web.UI.Page
{
    LoginModel model = new LoginModel();
    protected string Name = string.Empty;
    protected string TrainingBaseCode = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "../../../Default.aspx");
            return;
        }

        model = Session["loginModel"] as LoginModel;

        Name = CommonFunc.SafeGetStringFromObj(model.name);
        TrainingBaseCode = CommonFunc.SafeGetStringFromObj(model.training_base_code);

    }
}