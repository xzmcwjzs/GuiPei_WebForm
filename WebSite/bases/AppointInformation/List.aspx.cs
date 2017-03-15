using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;


public partial class bases_AppointInformation_List : System.Web.UI.Page
{
    LoginModel loginModel = new LoginModel();
    protected string BasesName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string ProfessionalBaseCode = string.Empty;
    protected string AppointBeginTime,AppointEndTime,IsPass;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "../../Default.aspx");
            return;
        }


        loginModel = (LoginModel)Session["loginModel"];

        BasesName = CommonFunc.SafeGetStringFromObj(loginModel.name);
        TrainingBaseCode = CommonFunc.SafeGetStringFromObj(loginModel.training_base_code);
        ProfessionalBaseCode = CommonFunc.SafeGetStringFromObj(loginModel.professional_base_code);


        AppointBeginTime = CommonFunc.FilterSpecialString(CommonFunc.SafeGetDateTimeStringFromObjectByFormat(Request.Form["AppointBeginTime"], "yyyy-MM-dd HH:mm").Trim());
        AppointEndTime = CommonFunc.FilterSpecialString(CommonFunc.SafeGetDateTimeStringFromObjectByFormat(Request.Form["AppointEndTime"], "yyyy-MM-dd HH:mm").Trim());
        IsPass = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["IsPass"]).Trim());
        
    }
}