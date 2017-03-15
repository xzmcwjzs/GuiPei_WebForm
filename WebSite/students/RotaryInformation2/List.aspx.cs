using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class students_RotaryInformation2_List : System.Web.UI.Page
{
    LoginModel loginModel = null;
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

        if (!IsPostBack)
        {
            loginModel = new LoginModel();
            loginModel = (LoginModel)Session["loginModel"];
            Name = loginModel.name;
            RealName = loginModel.real_name;
            TrainingBaseCode = loginModel.training_base_code;
            TrainingBaseName = loginModel.training_base_name;
        }

        //rotary_dept = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["rotary_dept"]).Trim());
        //instructor = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["instructor"]).Trim());

        //rotary_begin_time = CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.SafeGetStringFromObj(Request.Form["rotary_begin_time"]), "yyyy-MM-dd");
        //rotary_end_time = CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.SafeGetStringFromObj(Request.Form["rotary_end_time"]), "yyyy-MM-dd");

    }
}