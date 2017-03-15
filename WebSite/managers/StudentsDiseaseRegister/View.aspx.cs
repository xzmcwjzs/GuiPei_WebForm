using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;
using BLL;

public partial class managers_StudentsDiseaseRegister_View : System.Web.UI.Page
{
    public string id = string.Empty;
    DiseaseRegister2Model diseaseRegister2Model = null;
    DiseaseRegister2BLL diseaseRegister2BLL = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            Response.Write("<script>alert('请重新登录');opener.top.location.href='../../Default.aspx';window.close();</script>");
            return;

        }

        id = CommonFunc.FilterSpecialString(CommonFunc.SafeGetStringFromObj(Request.QueryString["id"]));
        diseaseRegister2Model = new DiseaseRegister2Model();
        diseaseRegister2BLL = new DiseaseRegister2BLL();

        diseaseRegister2Model = diseaseRegister2BLL.GetModelById(id);
        disease_name.Text = diseaseRegister2Model.disease_name.ToString();
        patient_name.Text = diseaseRegister2Model.patient_name.ToString();
        case_num.Text = diseaseRegister2Model.case_num.ToString();
        main_diagnosis.Text = diseaseRegister2Model.main_diagnosis.ToString();
        secondary_diagnosis.Text = diseaseRegister2Model.secondary_diagnosis.ToString();
        is_charge.SelectedValue = diseaseRegister2Model.is_charge;
        is_rescue.SelectedValue = diseaseRegister2Model.is_rescue;
        cure_measure.Text = diseaseRegister2Model.cure_measure;
        visit_date.Text = diseaseRegister2Model.visit_date.ToString();
        comment.Text = diseaseRegister2Model.comment.ToString();
        condition.Text = diseaseRegister2Model.condition.ToString();
    }
}