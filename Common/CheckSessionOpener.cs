using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CheckSessionOpener : System.Web.UI.Page
    {

        public void Page_Init(object sender, EventArgs e)
        {
            if (Session["loginModel"] == null)
            {
                Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
                return;

            }
        }
    }
}
