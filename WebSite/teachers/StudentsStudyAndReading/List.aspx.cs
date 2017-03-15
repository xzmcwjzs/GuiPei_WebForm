using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Common;

public partial class teachers_StudentsStudyAndReading_List : System.Web.UI.Page
{
    LoginModel loginModel = null;
    protected string StudentsRealName = string.Empty;
    protected string TeachersName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string ProfessionalBaseCode = string.Empty;
    protected string DeptCode = string.Empty;
    protected string ActivityForm = string.Empty;
    protected string ActivityDate = string.Empty;
    protected string LanguageType = string.Empty;
    protected string SuperiorDoctor = string.Empty;
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
            TeachersName = loginModel.name;
            TrainingBaseCode = loginModel.training_base_code;
            ProfessionalBaseCode = loginModel.professional_base_code;
            DeptCode = loginModel.dept_code;


        }
        StudentsRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["StudentsRealName"]));
        ActivityForm = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ActivityForm"]));
        ActivityDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ActivityDate"]));
        LanguageType = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["LanguageType"]));
        SuperiorDoctor = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["SuperiorDoctor"]));

    }
}