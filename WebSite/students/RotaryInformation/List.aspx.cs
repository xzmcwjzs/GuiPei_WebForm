using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class students_RotaryInformation_List : System.Web.UI.Page
{
    protected DataTable dt = null;
    LoginModel loginModel = null;
    protected string students_name = string.Empty;
    protected string training_base_code = string.Empty;
    protected string rotary_dept, instructor, rotary_begin_time, rotary_end_time;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "../../Default.aspx");
            return;
        }

        if (!IsPostBack) {
            loginModel = new LoginModel();
            loginModel = (LoginModel)Session["loginModel"];
            students_name = loginModel.name;
            training_base_code = loginModel.training_base_code;
        
        }
            
        rotary_dept = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["rotary_dept"]).Trim());
        instructor = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["instructor"]).Trim());

        rotary_begin_time = CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.SafeGetStringFromObj(Request.Form["rotary_begin_time"]),"yyyy-MM-dd");
        rotary_end_time = CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.SafeGetStringFromObj(Request.Form["rotary_end_time"]), "yyyy-MM-dd");

    }
}