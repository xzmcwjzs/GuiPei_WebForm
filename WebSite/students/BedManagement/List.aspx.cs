using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;

public partial class students_BedManagement_List : System.Web.UI.Page
{
    
    LoginModel loginModel = null;
    protected string students_name = string.Empty;
    protected string training_base_code = string.Empty;
    protected string dept_name=string.Empty;
    protected string patient_name = string.Empty;
    protected string bed_id = string.Empty;
    protected string bed_status = string.Empty;
    protected string room_id = string.Empty;
    protected string building_id = string.Empty;
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
            students_name = loginModel.name;
            training_base_code = loginModel.training_base_code;

        }
        dept_name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["dept_name"]).Trim());
        patient_name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["patient_name"]).Trim());
        bed_id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["bed_id"]).Trim());
        bed_status = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["bed_status"]).Trim());
        room_id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["room_id"]).Trim());
        building_id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["building_id"]).Trim());

    }
}