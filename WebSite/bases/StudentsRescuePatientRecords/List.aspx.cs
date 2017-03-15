using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Common;


public partial class bases_StudentsRescuePatientRecords_List : System.Web.UI.Page
{
    LoginModel loginModel = null;
    protected string StudentsRealName = string.Empty;
    protected string TeachersName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string ProfessionalBaseCode = string.Empty;
    protected string DeptCode = string.Empty;
    protected string PatientName = string.Empty;
    protected string CaseId = string.Empty;
    protected string DiseaseName = string.Empty;
    protected string Condition = string.Empty;

    protected string DeptName = string.Empty;
    protected string TeachersRealName = string.Empty;
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
            TrainingBaseCode = loginModel.training_base_code;
            ProfessionalBaseCode = loginModel.professional_base_code;

        }
        StudentsRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["StudentsRealName"]));
        PatientName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["PatientName"]).Trim());
        CaseId = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["CaseId"]).Trim());
        DiseaseName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DiseaseName"]).Trim());
        Condition = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["Condition"]).Trim());
        DeptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DeptName"]).Trim());
        TeachersRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["TeachersRealName"]).Trim());

    }
}