using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;

public partial class teachers_StudentsDiseaseRegister_List : System.Web.UI.Page
{
    LoginModel loginModel = null;
    protected string StudentsRealName = string.Empty;
    protected string TeachersName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string ProfessionalBaseCode = string.Empty;
    protected string DeptCode = string.Empty;
    protected string DiseaseName = string.Empty;
    protected string RequiredNum = string.Empty;
    protected string MasterDegree = string.Empty;
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
            TeachersName = loginModel.name;
            TrainingBaseCode = loginModel.training_base_code;
            ProfessionalBaseCode = loginModel.professional_base_code;
            DeptCode = loginModel.dept_code;

        }
        StudentsRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["StudentsRealName"]));
        DiseaseName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["disease_name"]).Trim());
        RequiredNum = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["required_num"]).Trim());
        MasterDegree = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["master_degree"]).Trim());

    }

}