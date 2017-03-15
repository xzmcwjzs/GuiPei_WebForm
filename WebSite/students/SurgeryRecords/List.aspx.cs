using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Common;


public partial class students_SurgeryRecords_List : System.Web.UI.Page
{
    LoginModel loginModel = null;
    protected string StudentsName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string DeptName = string.Empty;
    protected string PatientName = string.Empty;
    protected string CaseId = string.Empty;
    protected string SurgeryName = string.Empty;
    protected string IntraoperativePosition = string.Empty;
    protected string Emergency = string.Empty;
    protected string SurgeryDate = string.Empty;
    protected string SurgeryIsStop = string.Empty;
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
            StudentsName = loginModel.name;
            TrainingBaseCode = loginModel.training_base_code;

        }
        DeptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DeptName"]).Trim());
        PatientName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["PatientName"]).Trim());
        CaseId = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["CaseId"]).Trim());
        SurgeryName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["SurgeryName"]).Trim());
        IntraoperativePosition = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["IntraoperativePosition"]).Trim());
        Emergency = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["Emergency"]).Trim());
        SurgeryDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["SurgeryDate"]).Trim());
        SurgeryIsStop = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["SurgeryIsStop"]).Trim());
    }
}