using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Common
{
    public class ShowMessageBox
    {

        public static void Showmessagebox(Page page, string message, string newLocation)
        {

            if (string.IsNullOrEmpty(newLocation))
            {
                string hfResumeID = ""; 
                page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + message.ToString() + "');</script>");
                return;

            }

            //page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language=javascript> alert('" + message.ToString() + "');window.location='" + newLocation + "' </script>");
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", message);
            Builder.AppendFormat("top.location.href='{0}'", newLocation);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());
            

        }


     
    }
}

