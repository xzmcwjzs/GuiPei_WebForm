using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Common;

public partial class students_PersonalInformation2_Main : System.Web.UI.Page
{
    protected string Name = string.Empty;
    protected string RealName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string TrainingBaseName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "../../Default.aspx");
            return;
        }

        LoginModel model = Session["loginModel"] as LoginModel;

        Name = CommonFunc.SafeGetStringFromObj(model.name);
        RealName = CommonFunc.SafeGetStringFromObj(model.real_name);
        TrainingBaseCode = CommonFunc.SafeGetStringFromObj(model.training_base_code);
        TrainingBaseName = CommonFunc.SafeGetStringFromObj(model.training_base_name);
    }
}