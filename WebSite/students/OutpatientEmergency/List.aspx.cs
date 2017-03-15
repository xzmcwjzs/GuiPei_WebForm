using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Common;

public partial class students_OutpatientEmergency_List : System.Web.UI.Page
{
    LoginModel loginModel = null;
    protected string StudentsName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string DeptName = string.Empty;
    protected string RecordType = string.Empty;
    protected string DiseaseName = string.Empty;
    protected string DiseaseNum = string.Empty;
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
        RecordType = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["RecordType"]).Trim());
        DiseaseName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DiseaseName"]).Trim());
        DiseaseNum = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DiseaseNum"]).Trim());

    }
}