using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class students_SkillRequirement_Register : System.Web.UI.Page
{

    public string id = string.Empty;
    public string pi = string.Empty;
    protected string tag = string.Empty;
    public string StudentsName = string.Empty;
    public string StudentsRealName = string.Empty;
    public string TrainingBaseCode = string.Empty;
    public string TrainingBaseName = string.Empty;
    public string ProfessionalBaseCode = string.Empty;
    public string ProfessionalBaseName = string.Empty;
    public string DeptCode = string.Empty;
    public string DeptName = string.Empty;
    public string TeacherId = string.Empty;
    public string TeacherName = string.Empty;
    public string RequiredNum = string.Empty;
    public string MasterDegree = string.Empty;
    public string Writor = string.Empty;
    public string RegisterDate = string.Empty;
    public string SkillName = string.Empty;
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

        if (!IsPostBack)
        {
            StudentsName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["StudentsName"]));
            StudentsRealName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["StudentsRealName"]));
            TrainingBaseCode = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["TrainingBaseCode"]));
            TrainingBaseName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["TrainingBaseName"]));
            ProfessionalBaseCode = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["ProfessionalBaseCode"]));
            ProfessionalBaseName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["ProfessionalBaseName"]));
            DeptCode = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["DeptCode"]));
            DeptName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["DeptName"]));
            TeacherId = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["TeacherId"]));
            TeacherName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["TeacherName"]));
            RequiredNum = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["RequiredNum"]));
            MasterDegree = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["MasterDegree"]));
            Writor = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["Writor"]));
            RegisterDate = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["RegisterDate"]));
            SkillName = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["SkillName"]));
        }

    }
}