using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Common;
using BLL;
using Model;


public partial class _Default : System.Web.UI.Page
{
    protected string area = "";
    protected string s = "";
    protected DataTable dt = null;
    protected string tag = null;
    protected void Page_Load(object sender, EventArgs e)
    {

        this.Page.SetFocus(txtUserName);
        form1.Target = "_self";
        if (!IsPostBack)
        {
            Image1.ImageUrl = "ValidateImg.aspx";
        }
        area = Request.QueryString["s"];
        if (string.IsNullOrEmpty(area))
        {
            s = "zyys";
        }
        else
        {
            s = area;
        }

    }

    #region
    //protected void Login_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (studentsradio.Checked == false && teachersradio.Checked == false && basesradio.Checked == false && managersradio.Checked == false)
    //    {
    //        ShowMessageBox.Showmessagebox(this.Page, "请选择对应的人员登录", "Default.aspx");


    //    }
    //    else
    //    {
    //        try
    //        {
    //            string Code = Session["CheckCode"].ToString().Trim();
    //            string Txtbox = this.txtCode.Text.ToString().Trim();

    //        if (string.Compare(Txtbox.ToUpper(), Code) != 0)
    //        {
    //            ShowMessageBox.Showmessagebox(this.Page, "验证码输入错误", null);
    //            return;
    //        }

    //        if (string.IsNullOrEmpty(txtUserName.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
    //        {
    //            ShowMessageBox.Showmessagebox(this.Page, "账号和密码不能为空", "Default.aspx");
    //            return;
    //        }
    //        if (txtUserName.Text.Trim().Length > 50 || txtPassword.Text.Trim().Length > 50)
    //        {
    //            ShowMessageBox.Showmessagebox(this.Page, "账号和密码不能超过50个字符", "Default.aspx");
    //            return;
    //        }
    //        if (studentsradio.Checked == true)
    //        {
    //            StudentsModel entity = new StudentsModel();
    //            entity.students_name = txtUserName.Text.Trim();
    //            entity.students_password = txtPassword.Text.Trim();

    //            StudentsBLL studentsBLL = new StudentsBLL();

    //            dt = studentsBLL.GetDataTable(entity);
    //            StudentsModel studentsModel = new StudentsModel();
    //            studentsModel = (StudentsModel)ConvertTo.convertToModel(dt, studentsModel);
    //            if (studentsModel != null)
    //            {
    //                Session.Add("studentsModel", studentsModel);
    //               //Response.Write("<script> alert('学员你好！');</script>");
    //                Response.Redirect("~/students/Frame.aspx");
    //            }
    //            else
    //            {
    //                ShowMessageBox.Showmessagebox(this.Page, "用户名或密码有误，请重新输入！", "Default.aspx");
    //            }
    //        }else if(teachersradio.Checked==true){
    //            TeachersModel entity = new TeachersModel();
    //            entity.teachers_name = txtUserName.Text.Trim();
    //            entity.teachers_password = txtPassword.Text.Trim();

    //            TeachersBLL teachersBLL = new TeachersBLL();

    //            dt = teachersBLL.GetDataTable(entity);
    //            TeachersModel teachersModel = new TeachersModel();
    //            teachersModel = (TeachersModel)ConvertTo.convertToModel(dt, teachersModel);
    //            if (teachersModel != null)
    //            {
    //                Session.Add("teachersModel", teachersModel);
    //                //Response.Write("<script> alert('老师你好！');</script>");
    //                Response.Redirect("~/teachers/Frame.aspx");
    //            }
    //            else
    //            {
    //                ShowMessageBox.Showmessagebox(this.Page, "用户名或密码有误，请重新输入！", "Default.aspx");
    //            }

    //        }
    //        else if (basesradio.Checked == true)
    //        {
    //            BasesModel entity = new BasesModel();
    //            entity.bases_name = txtUserName.Text.Trim();
    //            entity.bases_password = txtPassword.Text.Trim();

    //            BasesBLL basesBLL = new BasesBLL();

    //            dt = basesBLL.GetDataTable(entity);
    //            BasesModel basesModel = new BasesModel();
    //            basesModel = (BasesModel)ConvertTo.convertToModel(dt, basesModel);
    //            if (basesModel != null)
    //            {
    //                Session.Add("basesModel", basesModel);
    //                //Response.Write("<script> alert('基地你好！');</script>");
    //                Response.Redirect("~/bases/Frame.aspx");
    //            }
    //            else
    //            {
    //                ShowMessageBox.Showmessagebox(this.Page, "用户名或密码有误，请重新输入！", "Default.aspx");
    //            }

    //        }
    //        else if(managersradio.Checked==true)
    //        {
    //            ManagersModel entity = new ManagersModel();
    //            entity.managers_name = txtUserName.Text.Trim();
    //            entity.managers_password = txtPassword.Text.Trim();

    //            ManagersBLL managersBLL = new ManagersBLL();

    //            dt = managersBLL.GetDataTable(entity);
    //            ManagersModel managersModel = new ManagersModel();
    //            managersModel = (ManagersModel)ConvertTo.convertToModel(dt, managersModel);
    //            if (managersModel != null)
    //            {
    //                Session.Add("managersModel", managersModel);
    //                //Response.Write("<script> alert('管理员你好！');</script>");
    //                Response.Redirect("~/managers/Frame.aspx");
    //            }
    //            else
    //            {
    //                ShowMessageBox.Showmessagebox(this.Page, "用户名或密码有误，请重新输入！", "Default.aspx");
    //            }

    //        }
    //        }
    //        catch (Exception)
    //        {

    //            ShowMessageBox.Showmessagebox(this, "验证码已过期，请重新登录", "Default.aspx");
    //        }






    //     }

    //}
    #endregion
    #region
    // protected void Login_Click(object sender, ImageClickEventArgs e)
    // {
    //     try
    //         {
    //             string Code = Session["CheckCode"].ToString().Trim();
    //             string Txtbox = this.txtCode.Text.ToString().Trim();

    //             if (string.Compare(Txtbox.ToUpper(), Code) != 0)
    //             {
    //                 ShowMessageBox.Showmessagebox(this.Page, "验证码输入错误", null);
    //                 return;
    //             }

    //             if (string.IsNullOrEmpty(txtUserName.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
    //             {
    //                 ShowMessageBox.Showmessagebox(this.Page, "账号和密码不能为空", "Default.aspx");
    //                 return;
    //             }
    //             if (txtUserName.Text.Trim().Length > 50 || txtPassword.Text.Trim().Length > 50)
    //             {
    //                 ShowMessageBox.Showmessagebox(this.Page, "账号和密码不能超过50个字符", "Default.aspx");
    //                 return;
    //             }

    //                 StudentsModel model1 = new StudentsModel();
    //                 model1.students_name = txtUserName.Text.Trim();
    //                 model1.students_password = txtPassword.Text.Trim();

    //                 StudentsBLL studentsBLL = new StudentsBLL();

    //                 dt = studentsBLL.GetDataTable(model1);
    //                 StudentsModel studentsModel = new StudentsModel();
    //                 studentsModel = (StudentsModel)ConvertTo.convertToModel(dt, studentsModel);
    //                 if (studentsModel != null)

    //                 {

    //                     Session.Add("studentsModel", studentsModel);

    //                     //Response.Redirect("Index.aspx");
    //                 }



    //                TeachersModel model2 = new TeachersModel();
    //                 model2.teachers_name = txtUserName.Text.Trim();
    //                 model2.teachers_password = txtPassword.Text.Trim();

    //                 TeachersBLL teachersBLL = new TeachersBLL();

    //                 dt = teachersBLL.GetDataTable(model2);
    //                 TeachersModel teachersModel = new TeachersModel();
    //                 teachersModel = (TeachersModel)ConvertTo.convertToModel(dt, teachersModel);
    //                 if (teachersModel != null)
    //                 {

    //                     Session.Add("teachersModel", teachersModel);
    //                     //Response.Redirect("Index.aspx");
    //                 }



    //                 BasesModel model3 = new BasesModel();
    //                 model3.bases_name = txtUserName.Text.Trim();
    //                 model3.bases_password = txtPassword.Text.Trim();

    //                 BasesBLL basesBLL = new BasesBLL();

    //                 dt = basesBLL.GetDataTable(model3);
    //                 BasesModel basesModel = new BasesModel();
    //                 basesModel = (BasesModel)ConvertTo.convertToModel(dt, basesModel);
    //                 if (basesModel != null)
    //                 {
    //                     Session.Add("basesModel", basesModel);
    //                     //Response.Redirect("Index.aspx");
    //                 }




    //                 ManagersModel model4 = new ManagersModel();
    //                 model4.managers_name = txtUserName.Text.Trim();
    //                 model4.managers_password = txtPassword.Text.Trim();

    //                 ManagersBLL managersBLL = new ManagersBLL();

    //                 dt = managersBLL.GetDataTable(model4);
    //                 ManagersModel managersModel = new ManagersModel();
    //                 managersModel = (ManagersModel)ConvertTo.convertToModel(dt, managersModel);
    //                 if (managersModel != null)
    //                 {
    //                     Session.Add("managersModel", managersModel);
    //                     //Response.Write("<script> alert('管理员你好！');</script>");
    //                     //Response.Redirect("Index.aspx");
    //                 }

    //                 Response.Redirect("Index.aspx");


    //         }
    //         catch (Exception)
    //         {

    //             ShowMessageBox.Showmessagebox(this, "验证码已过期，请重新登录", "Default.aspx");
    //         }

    //}
    #endregion

    protected void Login_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string Code = Session["CheckCode"].ToString().Trim();
            string Txtbox = this.txtCode.Text.ToString().Trim();

            if (string.Compare(Txtbox.ToUpper(), Code) != 0)
            {
                ShowMessageBox.Showmessagebox(this.Page, "验证码输入错误", null);
                return;
            }

            if (string.IsNullOrEmpty(txtUserName.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                ShowMessageBox.Showmessagebox(this.Page, "账号和密码不能为空", "Default.aspx");
                return;
            }
            if (txtUserName.Text.Trim().Length > 50 || txtPassword.Text.Trim().Length > 50)
            {
                ShowMessageBox.Showmessagebox(this.Page, "账号和密码不能超过50个字符", "Default.aspx");
                return;
            }
            LoginModel entity = new LoginModel();
            entity.name = txtUserName.Text.Trim();
            entity.password = txtPassword.Text.Trim();

            LoginBLL loginBLL = new LoginBLL();

            dt = loginBLL.GetDataTable(entity);
            LoginModel loginModel = new LoginModel();
            loginModel = (LoginModel)ConvertTo.convertToModel(dt, loginModel);
            if (loginModel != null)
            {
                if (loginModel.LoginState == "1")
                {
                    Session.Add("loginModel", loginModel);

                    Response.Redirect("Index.aspx");
                }
                else
                {
                    ShowMessageBox.Showmessagebox(this.Page, "该账号已锁定，需管理员进行解锁登录", "Default.aspx");
                }

            }
            else
            {
                ShowMessageBox.Showmessagebox(this.Page, "用户名或密码有误，请重新输入！", "Default.aspx");
            }


        }
        catch (Exception)
        {

            ShowMessageBox.Showmessagebox(this, "验证码已过期，请重新登录", "Default.aspx");
        }

    }
    protected void Registe_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ForgetPassword_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void Dowload_Click(object sender, ImageClickEventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>window.open('http://www.chinancd.net/index/download.html');</script>");
        

    }
    protected void Registe_Click1(object sender, ImageClickEventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>window.open('Register/RegisterMain.aspx');</script>");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>window.open('ForgetPassword/Main.aspx');</script>");
    }
}