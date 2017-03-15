using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;
using BLL;

public partial class teachers_StudentsBasicInformation_List : System.Web.UI.Page
{
    LoginModel loginModel = null;
    protected string training_base_code = string.Empty;
    protected string professional_base_code = string.Empty;
    protected string name, sex, minzu, high_education, high_school, identity_type, send_unit, collaborative_unit, training_time, plan_training_time;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请先重新登录", "../../Default.aspx");
            return;
        }
        if (!IsPostBack)
        {
            loginModel = new LoginModel();

            loginModel = (LoginModel)Session["loginModel"];
            training_base_code =loginModel.training_base_code==null?"":loginModel.training_base_code.ToString();
            professional_base_code = loginModel.professional_base_code == null ? "" : loginModel.professional_base_code.ToString();
        }

        name = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["name"]).Trim());
        sex = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["sex"]).Trim());
       
        minzu = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["minzu"]).Trim());
        high_education = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["high_education"]).Trim());
        high_school = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["high_school"]).Trim());
        identity_type = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["identity_type"]).Trim());
        send_unit = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["send_unit"]).Trim());
        collaborative_unit = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["collaborative_unit"]).Trim());
        training_time = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["training_time"]).Trim());
        plan_training_time = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.Form["plan_training_time"]).Trim());
        //xianshi.Text=name+sex+mingzu+high_education+high_school+identity_type+send_unit+collaborative_unit+training_time+plan_training_time;
        
    }
}