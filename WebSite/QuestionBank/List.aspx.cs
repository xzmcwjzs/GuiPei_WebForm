using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Common;

public partial class QuestionBank_List : System.Web.UI.Page
{
    LoginModel model = new LoginModel();
    protected string StudentsName = string.Empty;
    protected string StudentsRealName = string.Empty;
    protected string TrainingBaseCode = string.Empty;
    protected string TrainingBaseName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请重新登录", "../../Default.aspx");
            return;
        }

        model=Session["loginModel"] as LoginModel;

        StudentsName = CommonFunc.SafeGetStringFromObj(model.name.ToString());
        StudentsRealName = CommonFunc.SafeGetStringFromObj(model.real_name.ToString());
        TrainingBaseCode = CommonFunc.SafeGetStringFromObj(model.training_base_code.ToString());
        TrainingBaseName = CommonFunc.SafeGetStringFromObj(model.training_base_name.ToString());

    }
}