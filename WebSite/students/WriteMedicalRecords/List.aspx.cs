using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Common;

public partial class students_WriteMedicalRecords_List : System.Web.UI.Page
{
    LoginModel loginModel = null;
    protected string StudentsName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string DeptName = string.Empty;
    protected string PatientName = string.Empty;
    protected string CaseId = string.Empty;
    protected string IsBigCase = string.Empty;
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
        IsBigCase = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["IsBigCase"]).Trim());

    }
}