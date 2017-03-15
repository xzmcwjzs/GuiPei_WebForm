using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BLL;
using Model;


public partial class teachers_AppointInformation_Manage : System.Web.UI.Page
{
    LoginModel loginModel = new LoginModel();
    TeachersAppointInformationModel teachersAppointInformationModel = null;
    TeachersAppointInformationBLL teachersAppointInformationBLL = null;
    protected string id = string.Empty;
    protected string pi = string.Empty;
    protected string ispass = "未通过";
    protected string isReceive = "未接收";
    protected string typ = "指导医师";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }
        id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
        pi = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["pi"]));

        if (!IsPostBack)
        {
            loginModel = (LoginModel)Session["loginModel"];
            teachers_real_name.Text = loginModel.real_name.ToString();
            teachers_name.Value = loginModel.name.ToString();
            training_base_code.Value = loginModel.training_base_code.ToString();
            training_base_name.Value = loginModel.training_base_name.ToString();
            professional_base_code.Value = loginModel.professional_base_code;
            professional_base_name.Value = loginModel.professional_base_name;
            dept_code.Value = loginModel.dept_code;
            dept_name.Text = loginModel.dept_name;
            register_date.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

            if (!string.IsNullOrEmpty(id))
            {//如果不是表单提交，并且带了id值来做修改操作，则在界面上把值都呈现出来
                teachersAppointInformationModel = new TeachersAppointInformationModel();
                teachersAppointInformationBLL = new TeachersAppointInformationBLL();

                teachersAppointInformationModel = teachersAppointInformationBLL.SelectModelById(id);

                appoint_begin_time.Text = teachersAppointInformationModel.appoint_begin_time;
                appoint_end_time.Text = teachersAppointInformationModel.appoint_end_time;
                total_num.Text = teachersAppointInformationModel.total_num;
                class_num.Text = teachersAppointInformationModel.class_num;
                each_class_num.Text = teachersAppointInformationModel.each_class_num;
                training_content.Text = teachersAppointInformationModel.training_content;
                comment.Text = teachersAppointInformationModel.comment;
                register_date.Text = teachersAppointInformationModel.register_date;
                
            }

        }
        
         
    }
    protected void save_Click(object sender, EventArgs e)
    {
        teachersAppointInformationModel = new TeachersAppointInformationModel();
        teachersAppointInformationBLL = new TeachersAppointInformationBLL();

        teachersAppointInformationModel.appoint_begin_time = CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.FilterSpecialString(appoint_begin_time.Text.Trim()), "yyyy-MM-dd HH:mm");
        teachersAppointInformationModel.appoint_end_time = CommonFunc.SafeGetDateTimeStringFromObjectByFormat(CommonFunc.FilterSpecialString(appoint_end_time.Text.Trim()), "yyyy-MM-dd HH:mm");
        teachersAppointInformationModel.total_num = CommonFunc.FilterSpecialString(total_num.Text.Trim());
        teachersAppointInformationModel.class_num = CommonFunc.FilterSpecialString(class_num.Text.Trim());
        teachersAppointInformationModel.each_class_num = CommonFunc.FilterSpecialString(each_class_num.Text.Trim());
        teachersAppointInformationModel.training_content = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(training_content.Text.Trim()));
        teachersAppointInformationModel.comment = CommonFunc.FilterSpecialString(comment.Text.Trim());
        teachersAppointInformationModel.register_date = CommonFunc.FilterSpecialString(register_date.Text.Trim());
       
        

        if (string.IsNullOrEmpty(id))
        {
            teachersAppointInformationModel.id = Guid.NewGuid().ToString();
            teachersAppointInformationModel.teachers_name = CommonFunc.FilterSpecialString(teachers_name.Value.Trim());
            teachersAppointInformationModel.teachers_real_name = CommonFunc.FilterSpecialString(teachers_real_name.Text.Trim());
            teachersAppointInformationModel.training_base_code = CommonFunc.FilterSpecialString(training_base_code.Value.Trim());
            teachersAppointInformationModel.training_base_name = CommonFunc.FilterSpecialString(training_base_name.Value.Trim());
            teachersAppointInformationModel.professional_base_code = CommonFunc.FilterSpecialString(professional_base_code.Value.Trim());
            teachersAppointInformationModel.professional_base_name = CommonFunc.FilterSpecialString(professional_base_name.Value.Trim());
            teachersAppointInformationModel.dept_code = CommonFunc.FilterSpecialString(dept_code.Value.Trim());
            teachersAppointInformationModel.dept_name = CommonFunc.FilterSpecialString(dept_name.Text.Trim());

            teachersAppointInformationModel.IsReceive = isReceive;
            teachersAppointInformationModel.is_pass = ispass;
            teachersAppointInformationModel.type = typ;
            teachersAppointInformationModel.FileName = FileName.Value;
            teachersAppointInformationModel.FilePath = FilePath.Value;

            if (string.IsNullOrEmpty(teachersAppointInformationModel.appoint_begin_time) || string.IsNullOrEmpty(teachersAppointInformationModel.appoint_end_time))
            {
                ShowMessageBox.Showmessagebox(this, "预约时间不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(teachersAppointInformationModel.total_num))
            {
                ShowMessageBox.Showmessagebox(this, "培训总人数不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(teachersAppointInformationModel.training_content))
            {
                ShowMessageBox.Showmessagebox(this, "培训内容不能为空", null);
                return;
            }

            if (teachersAppointInformationBLL.Insert(teachersAppointInformationModel))
            {
                try
                {
                    //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>window.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);</script>", true);
                    //Response.Write("<script language='javascript'> alert('预约信息提交成功');window.opener.parent.frames.bodyFrame.frames.frmright.location.reload();window.close();</script>");
                    Response.Write("<script language='javascript'> alert('预约信息提交成功');window.opener.parent.frames.bodyFrame.frames.frmright.window.loadPageList(1);window.close();</script>");
                    Response.End();

                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }

        }
        else {

            teachersAppointInformationModel.id = id;
            if (string.IsNullOrEmpty(teachersAppointInformationModel.appoint_begin_time) || string.IsNullOrEmpty(teachersAppointInformationModel.appoint_end_time))
            {
                ShowMessageBox.Showmessagebox(this, "预约时间不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(teachersAppointInformationModel.total_num))
            {
                ShowMessageBox.Showmessagebox(this, "培训总人数不能为空", null);
                return;
            }
            if (string.IsNullOrEmpty(teachersAppointInformationModel.training_content))
            {
                ShowMessageBox.Showmessagebox(this, "培训内容不能为空", null);
                return;
            }

            if (teachersAppointInformationBLL.Update(teachersAppointInformationModel))
            {
                try
                {
                    Response.Write("<script language='javascript'> alert('预约信息修改成功'); window.opener.window.loadPageList('"+pi+"');window.close();</script>");
                    Response.End();

                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }
        }
        

     }
}