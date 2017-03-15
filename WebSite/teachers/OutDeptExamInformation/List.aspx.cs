using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class teachers_OutDeptExam_List : System.Web.UI.Page
{
    LoginModel loginModel = new LoginModel();
    protected string teachers_name = string.Empty;
    protected string teachers_real_name = string.Empty;
    protected string training_base_code = string.Empty;
    protected string dept_code = string.Empty;
    protected string name, rotary_begin_time, rotary_end_time, total_score, is_pass;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请先重新登录", "../../Default.aspx");
            return;
        }

        loginModel = (LoginModel)Session["loginModel"];

        teachers_name = loginModel.name;
        teachers_real_name = loginModel.real_name;
        training_base_code = loginModel.training_base_code;
        dept_code = loginModel.dept_code;


        name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["name"]).Trim());
        rotary_begin_time = CommonFunc.FilterSpecialString(CommonFunc.SafeGetDateTimeStringFromObjectByFormat(Request.Form["rotary_begin_time"],"yyyy-MM-dd").Trim());
        rotary_end_time = CommonFunc.FilterSpecialString(CommonFunc.SafeGetDateTimeStringFromObjectByFormat(Request.Form["rotary_end_time"], "yyyy-MM-dd").Trim());
        total_score = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["total_score"]).Trim());
        is_pass = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["is_pass"]).Trim());
        //if (name == null) {
        //   xianshi.Text = name + rotary_begin_time + rotary_end_time + total_score + is_pass;
        //}
        

    }
}