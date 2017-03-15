using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Common
{
    public class CheckSessionTop:System.Web.UI.Page
    {
        public void Page_Init(object sender, EventArgs e)
        {
            if (Session["loginModel"] == null)
            {
                ShowMessageBox.Showmessagebox(this, "请重新登录", "../../Default.aspx");
                return;
            }
        }
        

    }
}
