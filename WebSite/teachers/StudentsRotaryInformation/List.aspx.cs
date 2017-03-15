using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;
using BLL;

public partial class teachers_StudentsBasicInformation_List : System.Web.UI.Page
{
    LoginModel loginModel = null;
    protected string training_base_code = string.Empty;
    protected string dept_code = string.Empty;
    protected string teachers_name = string.Empty;
    protected string name, sex, high_education, identity_type, send_unit, collaborative_unit, training_time, plan_training_time, rotary_begin_time, rotary_end_time, outdept_status;
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
            training_base_code = loginModel.training_base_code.ToString();
            dept_code = loginModel.dept_code.ToString();
            teachers_name = loginModel.name.ToString();
        }
        name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["name"]).Trim());
        sex = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["sex"]).Trim());
        high_education = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["high_education"]).Trim());
        identity_type = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["identity_type"]).Trim());
        send_unit = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["send_unit"]).Trim());
        collaborative_unit = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["collaborative_unit"]).Trim());
        training_time = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["training_time"]).Trim());
        plan_training_time = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["plan_training_time"]).Trim());
        rotary_begin_time = CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.SafeGetStringFromObj(Request.Form["rotary_begin_time"]),"yyyy-MM-dd");
        rotary_end_time = CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.SafeGetStringFromObj(Request.Form["rotary_end_time"]), "yyyy-MM-dd");
        outdept_status = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["outdept_status"]).Trim());
        //wo.Text = name + sex + high_education + identity_type + send_unit + collaborative_unit + training_time + plan_training_time + rotary_begin_time + rotary_end_time + outdept_status;
    }
}