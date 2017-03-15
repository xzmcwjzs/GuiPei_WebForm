using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;

public partial class managers_AdviceFeedback_List : System.Web.UI.Page
{
    protected string TrainingBaseCode = string.Empty;
    protected string StudentsRealName = string.Empty;
    protected string ProfessionalBaseName = string.Empty;

    protected string DeptName = string.Empty;
    protected string ManagerHandle = string.Empty;
    protected string RegisterDate = string.Empty;
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
        StudentsRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["StudentsRealName"]));
        ProfessionalBaseName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ProfessionalBaseName"]));
        DeptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["DeptName"]));
        ManagerHandle = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ManagerHandle"]));
        RegisterDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["RegisterDate"]));
    }
}