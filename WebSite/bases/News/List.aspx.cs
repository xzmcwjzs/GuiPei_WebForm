using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class students_News_List : System.Web.UI.Page
{
    LoginModel loginModel = new LoginModel();
    protected string ManagersName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string NewsTitle = string.Empty;
    protected string RegisterDate = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "../../Default.aspx");
            return;
        }


        loginModel = (LoginModel)Session["loginModel"];

        ManagersName = CommonFunc.SafeGetStringFromObj(loginModel.name);
        TrainingBaseCode = CommonFunc.SafeGetStringFromObj(loginModel.training_base_code);




        NewsTitle = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["NewsTitle"]));
        RegisterDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["RegisterDate"]));
    }
}