using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class managers_StudentsSkillRequirement_View : System.Web.UI.Page
{
    public string id = string.Empty;
    public string pi = string.Empty;
    protected string tag = string.Empty;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');window.close();</script>");
            return;

        }

        id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
        pi = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["pi"]));
        tag = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["tag"]));

    }
}