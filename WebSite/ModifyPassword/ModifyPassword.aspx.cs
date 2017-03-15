using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BLL;


public partial class ModifyPassword_ModifyPassword : System.Web.UI.Page
{
    protected string user_name = string.Empty;
    LoginBLL loginBLL = new LoginBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        user_name = CommonFunc.SafeGetStringFromObj(Request.QueryString["username"]);
        if (string.IsNullOrEmpty(user_name))
        {
            ShowMessageBox.Showmessagebox(this.Page, "用户名不能为空", null);
            return;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string password = CommonFunc.FilterSpecialString(txtPassword.Text.Trim());

        string password2 = CommonFunc.FilterSpecialString(txtPassword2.Text.Trim());

        if (password.Length<6)
        {
            ShowMessageBox.Showmessagebox(this.Page, "密码长度不得小于六位", null);
            return;
        }
        if (password != password2)
        {
            ShowMessageBox.Showmessagebox(this.Page, "密码输入不一致，请重新输入", null);
            return;
        }
        if (string.IsNullOrEmpty(password))
        {
            ShowMessageBox.Showmessagebox(this.Page, "登录密码不能为空", null);
            return;
        }

        if (password.Length > 50)
        {
            ShowMessageBox.Showmessagebox(this.Page, "登录密码不能超过50个字符", null);
            return;
        }
        int n = loginBLL.UpdatePassword(user_name, password);
        if (n > 0)
        {
            ShowMessageBox.Showmessagebox(this.Page, "修改成功", null);
            return;

        }
    }
}