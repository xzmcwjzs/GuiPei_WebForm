using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;

public partial class students_PublishArticalRecords_List : System.Web.UI.Page
{
    protected string StudentsName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string DeptName = string.Empty;
    protected string ArticalTitle = string.Empty;
    protected string ArticalCategory = string.Empty;
    protected string Author = string.Empty;
    protected string PublishDate = string.Empty;
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
        ArticalTitle = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ArticalTitle"]));
        ArticalCategory = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["ArticalCategory"]));
        Author = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["Author"]));
        PublishDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["PublishDate"]));
    }
}