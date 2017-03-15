using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BLL;

public partial class bases_ModifyPassword : System.Web.UI.Page
{
    protected string user_name = string.Empty;
    BasesBLL basesBLL = new BasesBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        user_name = CommonFunc.SafeGetStringFromObj(Request.QueryString["username"]);
        if (string.IsNullOrEmpty(user_name))
        {
            ShowMessageBox.Showmessagebox(this.Page, "工作人员账号不能为空", null);
            return;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string password = CommonFunc.FilterSpecialString(txtPassword.Text.Trim());
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
        int n = basesBLL.UpdatePassword(user_name, password);
        if (n > 0)
        {
            ShowMessageBox.Showmessagebox(this.Page, "修改成功", null);
            return;

        }
    }
}