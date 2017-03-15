using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class managers_ViewSchedule_Main : System.Web.UI.Page
{
    LoginModel model = new LoginModel();
    protected string ManagersName = string.Empty;
    protected string ManagersRealName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string TrainingBaseName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "../../Default.aspx");
            return;
        }

        model = Session["loginModel"] as LoginModel;

        ManagersName = CommonFunc.SafeGetStringFromObj(model.name.ToString());
        ManagersRealName = CommonFunc.SafeGetStringFromObj(model.real_name.ToString());
        TrainingBaseCode = CommonFunc.SafeGetStringFromObj(model.training_base_code);
        TrainingBaseName = CommonFunc.SafeGetStringFromObj(model.training_base_name.ToString());
    }
}