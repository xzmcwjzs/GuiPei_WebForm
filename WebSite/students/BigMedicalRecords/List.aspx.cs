using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Common;

public partial class students_BigMedicalRecords_List : Common.CheckSessionTop
{
    protected string StudentsName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string DeptName = string.Empty;
    protected string TeacherName = string.Empty;
    protected string RegisterDate = string.Empty;
    protected string PatientNo = string.Empty;
    protected string InhospitalNo = string.Empty;
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
           StudentsName = loginModel.name;
            TrainingBaseCode = loginModel.training_base_code;

        }
       DeptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DeptName"]));
       TeacherName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["TeacherName"]));
       RegisterDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["RegisterDate"]));
       PatientNo = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["PatientNo"]));
        InhospitalNo = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["InhospitalNo"]));

    }
}