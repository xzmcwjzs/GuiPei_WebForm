using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;


public partial class managers_StudentsAttendanceManagement_List : System.Web.UI.Page
{
    protected string StudentsRealName, DeptName, TeachersRealName;
    protected string TrainingBaseCode = string.Empty;
    protected string ProfessionalBaseCode = string.Empty;
    protected string AttendanceCategory = string.Empty;
    protected string FirstDate = string.Empty;
    protected string LastDate = string.Empty;
    protected string Days = string.Empty;
    protected string ProfessionalBaseName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "../../Default.aspx");
            return;
        }
        if (!IsPostBack)
        {
            LoginModel loginModel = new LoginModel();
            loginModel = (LoginModel)Session["loginModel"];
            TrainingBaseCode = CommonFunc.SafeGetStringFromObj(loginModel.training_base_code);

        }
        StudentsRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["StudentsRealName"]).Trim());
        DeptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DeptName"]).Trim());
        TeachersRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["TeachersRealName"]).Trim());
        AttendanceCategory = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["AttendanceCategory"]));
        FirstDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["FirstDate"]));
        LastDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["LastDate"]));
        Days = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["Days"]));
        ProfessionalBaseName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ProfessionalBaseName"]).Trim());
    }
}