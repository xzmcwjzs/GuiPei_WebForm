using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;
using System.Web.Services;

public partial class teachers_QuestionnaireInformation_List : System.Web.UI.Page
{
    public string json = "";
    public int sum = 0;
    public int one_a = 0; public int one_b = 0; public int one_c = 0; public int one_d = 0; public int one_e = 0;
    public int two_a = 0; public int two_b = 0; public int two_c = 0; public int two_d = 0; public int two_e = 0;
    public int three_a = 0; public int three_b = 0; public int three_c = 0; public int three_d = 0; public int three_e = 0;
    public int four_a = 0; public int four_b = 0; public int four_c = 0; public int four_d = 0; public int four_e = 0;
    public int five_a = 0; public int five_b = 0; public int five_c = 0; public int five_d = 0; public int five_e = 0;
    public int six_a = 0; public int six_b = 0; public int six_c = 0; public int six_d = 0; public int six_e = 0;
    public int seven_a = 0; public int seven_b = 0; public int seven_c = 0; public int seven_d = 0; public int seven_e = 0;
    public int eight_a = 0; public int eight_b = 0; public int eight_c = 0; public int eight_d = 0; public int eight_e = 0;
    public int nine_a = 0; public int nine_b = 0; public int nine_c = 0; public int nine_d = 0; public int nine_e = 0;
    public int ten_a = 0; public int ten_b = 0; public int ten_c = 0; public int ten_d = 0; public int ten_e = 0;
    public int eleven_a = 0; public int eleven_b = 0; public int eleven_c = 0; public int eleven_d = 0; public int eleven_e = 0;
    public int twelve_a = 0; public int twelve_b = 0; public int twelve_c = 0; public int twelve_d = 0; public int twelve_e = 0;
    public int thirteen_a = 0; public int thirteen_b = 0; public int thirteen_c = 0; public int thirteen_d = 0; public int thirteen_e = 0;

    protected LoginModel loginModel = null;
    protected string training_base_code = string.Empty;
    protected string professional_base_code = string.Empty;
    protected string dept_code = string.Empty;
    protected string instructor = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loginModel"] == null)
        {
            ShowMessageBox.Showmessagebox(this, "请先重新登录", "../../Default.aspx");
            return;
        }
        
            loginModel = new LoginModel();

            loginModel = (LoginModel)Session["loginModel"];
            training_base_code = loginModel.training_base_code.ToString();
            dept_code = loginModel.dept_code.ToString();
            professional_base_code = loginModel.professional_base_code.ToString();
            instructor = loginModel.real_name.ToString();
        
        RunQuestionnaireChart("QuestionnaireChart", out sum, out one_a, out  one_b, out  one_c, out  one_d, out  one_e,
         out  two_a, out  two_b, out  two_c, out  two_d, out  two_e,
         out  three_a, out  three_b, out  three_c, out  three_d, out  three_e,
         out  four_a, out  four_b, out  four_c, out  four_d, out  four_e,
         out  five_a, out  five_b, out  five_c, out  five_d, out  five_e,
         out  six_a, out  six_b, out  six_c, out  six_d, out  six_e,
         out  seven_a, out  seven_b, out  seven_c, out  seven_d, out  seven_e,
         out  eight_a, out  eight_b, out  eight_c, out  eight_d, out  eight_e,
         out  nine_a, out  nine_b, out  nine_c, out  nine_d, out  nine_e,
         out  ten_a, out  ten_b, out  ten_c, out  ten_d, out  ten_e,
         out  eleven_a, out  eleven_b, out  eleven_c, out  eleven_d, out  eleven_e,
         out  twelve_a, out  twelve_b, out  twelve_c, out  twelve_d, out  twelve_e,
         out  thirteen_a, out  thirteen_b, out  thirteen_c, out  thirteen_d, out  thirteen_e, training_base_code, professional_base_code, dept_code, instructor);

        StringBuilder jsonData = new StringBuilder();

        jsonData.Append("{" +
            "'chart':{" +
                "'caption': '满意度调查反馈'," +
                "'subCaption': 'By Students'," +
                "'xaxisname':'调查项目'," +
                "'yaxisname':'比例'," +
                "'showvalues':'1'," +
                "'numberSuffix':'%25'," +
                "'labelDisplay':'Rotate'," +
                "'slantLabels':'1'," +
                "'outCnvbaseFontSize':'13'," +
                "'baseFontSize':'12'," +
                "'plotGradientColor':''," +
                "'useRoundEdges':'1'," +
                "'showtooltip':'1'," +
                "'showtooltipshadow':'1'" +
            "},");

        jsonData.Append("'categories':[" +
            "{" +
                "'category': [" +
        "{'label':'敬业精神'}," +
        "{'label':'工作作风'}," +
        "{'label':'理论水平'}," +
        "{'label':'疑难病症处理'}," +
        "{'label':'临床操作技能'}," +
        "{'label':'交流能力'}," +
        "{'label':'学科进展了解'}," +
        "{'label':'纠纷防范意识'}," +
        "{'label':'科研能力'}," +
        "{'label':'外语运用水平'}," +
        "{'label':'带教经验'}," +
        "{'label':'表达能力'}," +
        "{'label':'放手能力'}]}],");

        jsonData.Append("'dataset':[");
        jsonData.Append("{" +
                    "'seriesname':'A.非常满意'," +
                    "'data':[");

        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)one_a / sum, 2) * 100).ToString() + "'" +
                    "},");
        //jsonData.AppendFormat("{" +
        //            "'value':'{0}'" +
        //            "},",Math.Round((double)one_a/sum,2).ToString());
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)two_a / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)three_a / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)four_a / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)five_a / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)six_a / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)seven_a / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)eight_a / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)nine_a / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)ten_a / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)eleven_a / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)twelve_a / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)thirteen_a / sum, 2) * 100).ToString() + "'" +
                    "}]},");

        jsonData.Append("{" +
                    "'seriesname':'B.比较满意'," +
                    "'data':[");

        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)one_b / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)two_b / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)three_b / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)four_b / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)five_b / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)six_b / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)seven_b / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)eight_b / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)nine_b / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)ten_b / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)eleven_b / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)twelve_b / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)thirteen_b / sum, 2) * 100).ToString() + "'" +
                    "}]},");

        jsonData.Append("{" +
                    "'seriesname':'C.一般'," +
                    "'data':[");

        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)one_c / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)two_c / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)three_c / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)four_c / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)five_c / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)six_c / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)seven_c / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)eight_c / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)nine_c / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)ten_c / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)eleven_c / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)twelve_c / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)thirteen_c / sum, 2) * 100).ToString() + "'" +
                    "}]},");

        jsonData.Append("{" +
                    "'seriesname':'D.不满意'," +
                    "'data':[");

        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)one_d / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)two_d / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)three_d / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)four_d / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)five_d / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)six_d / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)seven_d / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)eight_d / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)nine_d / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)ten_d / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)eleven_d / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)twelve_d / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)thirteen_d / sum, 2) * 100).ToString() + "'" +
                    "}]},");

        jsonData.Append("{" +
                    "'seriesname':'E.不清楚'," +
                    "'data':[");

        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)one_e / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)two_e / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)three_e / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)four_e / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)five_e / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)six_e / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)seven_e / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)eight_e / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)nine_e / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)ten_e / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)eleven_e / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)twelve_e / sum, 2) * 100).ToString() + "'" +
                    "},");
        jsonData.Append("{" +
                    "'value':'" + (Math.Round((double)thirteen_e / sum, 2) * 100).ToString() + "'" +
                    "}]}]");

        jsonData.Append("}");
        json = jsonData.ToString();
       
    }

   

  

    #region   static void RunQuestionnaireChart
    public static void RunQuestionnaireChart(string proName, out int sum, out int one_a, out int one_b, out int one_c, out int one_d, out int one_e,
        out int two_a, out int two_b, out int two_c, out int two_d, out int two_e,
        out int three_a, out int three_b, out int three_c, out int three_d, out int three_e,
        out int four_a, out int four_b, out int four_c, out int four_d, out int four_e,
        out int five_a, out int five_b, out int five_c, out int five_d, out int five_e,
        out int six_a, out int six_b, out int six_c, out int six_d, out int six_e,
        out int seven_a, out int seven_b, out int seven_c, out int seven_d, out int seven_e,
        out int eight_a, out int eight_b, out int eight_c, out int eight_d, out int eight_e,
        out int nine_a, out int nine_b, out int nine_c, out int nine_d, out int nine_e,
        out int ten_a, out int ten_b, out int ten_c, out int ten_d, out int ten_e,

        out int eleven_a, out int eleven_b, out int eleven_c, out int eleven_d, out int eleven_e,
        out int twelve_a, out int twelve_b, out int twelve_c, out int twelve_d, out int twelve_e,
        out int thirteen_a, out int thirteen_b, out int thirteen_c, out int thirteen_d, out int thirteen_e, string training_base_code, string professional_base_code, string dept_code, string instructor)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["strConn"].ConnectionString);

        sum = 0; one_a = 0; one_b = 0; one_c = 0; one_d = 0; one_e = 0;
        two_a = 0; two_b = 0; two_c = 0; two_d = 0; two_e = 0;
        three_a = 0; three_b = 0; three_c = 0; three_d = 0; three_e = 0;
        four_a = 0; four_b = 0; four_c = 0; four_d = 0; four_e = 0;
        five_a = 0; five_b = 0; five_c = 0; five_d = 0; five_e = 0;
        six_a = 0; six_b = 0; six_c = 0; six_d = 0; six_e = 0;
        seven_a = 0; seven_b = 0; seven_c = 0; seven_d = 0; seven_e = 0;
        eight_a = 0; eight_b = 0; eight_c = 0; eight_d = 0; eight_e = 0;
        nine_a = 0; nine_b = 0; nine_c = 0; nine_d = 0; nine_e = 0;
        ten_a = 0; ten_b = 0; ten_c = 0; ten_d = 0; ten_e = 0;
        eleven_a = 0; eleven_b = 0; eleven_c = 0; eleven_d = 0; eleven_e = 0;
        twelve_a = 0; twelve_b = 0; twelve_c = 0; twelve_d = 0; twelve_e = 0;
        thirteen_a = 0; thirteen_b = 0; thirteen_c = 0; thirteen_d = 0; thirteen_e = 0;
        

        SqlParameter[] prams = { 
                                   new SqlParameter("@sum",sum),
                                   new SqlParameter("@one_a",one_a),
                                   new SqlParameter("@one_b",one_b),
                                   new SqlParameter("@one_c",one_c),
                                   new SqlParameter("@one_d",one_d),
                                   new SqlParameter("@one_e",one_e),
                                   
                                   new SqlParameter("@two_a",two_a),
                                   new SqlParameter("@two_b",two_b),
                                   new SqlParameter("@two_c",two_c),
                                   new SqlParameter("@two_d",two_d),
                                   new SqlParameter("@two_e",two_e),
                                   
                                   new SqlParameter("@three_a",three_a),
                                   new SqlParameter("@three_b",three_b),
                                   new SqlParameter("@three_c",three_c),
                                   new SqlParameter("@three_d",three_d),
                                   new SqlParameter("@three_e",three_e),
                                  
                                   new SqlParameter("@four_a",four_a),
                                   new SqlParameter("@four_b",four_b),
                                   new SqlParameter("@four_c",four_c),
                                   new SqlParameter("@four_d",four_d),
                                   new SqlParameter("@four_e",four_e),
                                  
                                   new SqlParameter("@five_a",five_a),
                                   new SqlParameter("@five_b",five_b),
                                   new SqlParameter("@five_c",five_c),
                                   new SqlParameter("@five_d",five_d),
                                   new SqlParameter("@five_e",five_e),
                                  
                                   new SqlParameter("@six_a",six_a),
                                   new SqlParameter("@six_b",six_b),
                                   new SqlParameter("@six_c",six_c),
                                   new SqlParameter("@six_d",six_d),
                                   new SqlParameter("@six_e",six_e),
                                  
                                   new SqlParameter("@seven_a",seven_a),
                                   new SqlParameter("@seven_b",seven_b),
                                   new SqlParameter("@seven_c",seven_c),
                                   new SqlParameter("@seven_d",seven_d),
                                   new SqlParameter("@seven_e",seven_e),
                                  
                                   new SqlParameter("@eight_a",eight_a),
                                   new SqlParameter("@eight_b",eight_b),
                                   new SqlParameter("@eight_c",eight_c),
                                   new SqlParameter("@eight_d",eight_d),
                                   new SqlParameter("@eight_e",eight_e),
                                  
                                   new SqlParameter("@nine_a",nine_a),
                                   new SqlParameter("@nine_b",nine_b),
                                   new SqlParameter("@nine_c",nine_c),
                                   new SqlParameter("@nine_d",nine_d),
                                   new SqlParameter("@nine_e",nine_e),
                                  
                                   new SqlParameter("@ten_a",ten_a),
                                   new SqlParameter("@ten_b",ten_b),
                                   new SqlParameter("@ten_c",ten_c),
                                   new SqlParameter("@ten_d",ten_d),
                                   new SqlParameter("@ten_e",ten_e),
                                  
                                   new SqlParameter("@eleven_a",eleven_a),
                                   new SqlParameter("@eleven_b",eleven_b),
                                   new SqlParameter("@eleven_c",eleven_c),
                                   new SqlParameter("@eleven_d",eleven_d),
                                   new SqlParameter("@eleven_e",eleven_e),
                                  
                                   new SqlParameter("@twelve_a",twelve_a),
                                   new SqlParameter("@twelve_b",twelve_b),
                                   new SqlParameter("@twelve_c",twelve_c),
                                   new SqlParameter("@twelve_d",twelve_d),
                                   new SqlParameter("@twelve_e",twelve_e),
                                  
                                   new SqlParameter("@thirteen_a",thirteen_a),
                                   new SqlParameter("@thirteen_b",thirteen_b),
                                   new SqlParameter("@thirteen_c",thirteen_c),
                                   new SqlParameter("@thirteen_d",thirteen_d),
                                   new SqlParameter("@thirteen_e",thirteen_e),
                                   new SqlParameter("@training_base_code",training_base_code),
                                   new SqlParameter("@professional_base_code",professional_base_code),
                                   new SqlParameter("@dept_code",dept_code),
                                   new SqlParameter("@instructor",instructor)
                                  };

        //必须为连个存储过程输出参数 设置方向为 输出
        prams[0].Direction = ParameterDirection.Output;
        prams[1].Direction = ParameterDirection.Output;
        prams[2].Direction = ParameterDirection.Output;
        prams[3].Direction = ParameterDirection.Output;
        prams[4].Direction = ParameterDirection.Output;
        prams[5].Direction = ParameterDirection.Output;
        prams[6].Direction = ParameterDirection.Output;
        prams[7].Direction = ParameterDirection.Output;
        prams[8].Direction = ParameterDirection.Output;
        prams[9].Direction = ParameterDirection.Output;
        prams[10].Direction = ParameterDirection.Output;
        prams[11].Direction = ParameterDirection.Output;
        prams[12].Direction = ParameterDirection.Output;
        prams[13].Direction = ParameterDirection.Output;
        prams[14].Direction = ParameterDirection.Output;
        prams[15].Direction = ParameterDirection.Output;
        prams[16].Direction = ParameterDirection.Output;
        prams[17].Direction = ParameterDirection.Output;
        prams[18].Direction = ParameterDirection.Output;
        prams[19].Direction = ParameterDirection.Output;
        prams[20].Direction = ParameterDirection.Output;
        prams[21].Direction = ParameterDirection.Output;
        prams[22].Direction = ParameterDirection.Output;
        prams[23].Direction = ParameterDirection.Output;
        prams[24].Direction = ParameterDirection.Output;
        prams[25].Direction = ParameterDirection.Output;
        prams[26].Direction = ParameterDirection.Output;
        prams[27].Direction = ParameterDirection.Output;
        prams[28].Direction = ParameterDirection.Output;
        prams[29].Direction = ParameterDirection.Output;
        prams[30].Direction = ParameterDirection.Output;
        prams[31].Direction = ParameterDirection.Output;
        prams[32].Direction = ParameterDirection.Output;
        prams[33].Direction = ParameterDirection.Output;
        prams[34].Direction = ParameterDirection.Output;
        prams[35].Direction = ParameterDirection.Output;
        prams[36].Direction = ParameterDirection.Output;
        prams[37].Direction = ParameterDirection.Output;
        prams[38].Direction = ParameterDirection.Output;
        prams[39].Direction = ParameterDirection.Output;
        prams[40].Direction = ParameterDirection.Output;
        prams[41].Direction = ParameterDirection.Output;
        prams[42].Direction = ParameterDirection.Output;
        prams[43].Direction = ParameterDirection.Output;
        prams[44].Direction = ParameterDirection.Output;
        prams[45].Direction = ParameterDirection.Output;
        prams[46].Direction = ParameterDirection.Output;
        prams[47].Direction = ParameterDirection.Output;
        prams[48].Direction = ParameterDirection.Output;
        prams[49].Direction = ParameterDirection.Output;
        prams[50].Direction = ParameterDirection.Output;
        prams[51].Direction = ParameterDirection.Output;
        prams[52].Direction = ParameterDirection.Output;
        prams[53].Direction = ParameterDirection.Output;
        prams[54].Direction = ParameterDirection.Output;
        prams[55].Direction = ParameterDirection.Output;
        prams[56].Direction = ParameterDirection.Output;
        prams[57].Direction = ParameterDirection.Output;
        prams[58].Direction = ParameterDirection.Output;
        prams[59].Direction = ParameterDirection.Output;
        prams[60].Direction = ParameterDirection.Output;
        prams[61].Direction = ParameterDirection.Output;
        prams[62].Direction = ParameterDirection.Output;
        prams[63].Direction = ParameterDirection.Output;
        prams[64].Direction = ParameterDirection.Output;
        prams[65].Direction = ParameterDirection.Output;

        SqlCommand cmd = new SqlCommand(proName, con);

        cmd.CommandType = CommandType.StoredProcedure;//设值使用存储过程
        cmd.Parameters.AddRange(prams);
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            //接收 存储过程的输出参数
            sum = Convert.ToInt16(prams[0].Value);

            one_a = Convert.ToInt16(prams[1].Value);
            one_b = Convert.ToInt16(prams[2].Value);
            one_c = Convert.ToInt16(prams[3].Value);
            one_d = Convert.ToInt16(prams[4].Value);
            one_e = Convert.ToInt16(prams[5].Value);

            two_a = Convert.ToInt16(prams[6].Value);
            two_b = Convert.ToInt16(prams[7].Value);
            two_c = Convert.ToInt16(prams[8].Value);
            two_d = Convert.ToInt16(prams[9].Value);
            two_e = Convert.ToInt16(prams[10].Value);

            three_a = Convert.ToInt16(prams[11].Value);
            three_b = Convert.ToInt16(prams[12].Value);
            three_c = Convert.ToInt16(prams[13].Value);
            three_d = Convert.ToInt16(prams[14].Value);
            three_e = Convert.ToInt16(prams[15].Value);

            four_a = Convert.ToInt16(prams[16].Value);
            four_b = Convert.ToInt16(prams[17].Value);
            four_c = Convert.ToInt16(prams[18].Value);
            four_d = Convert.ToInt16(prams[19].Value);
            four_e = Convert.ToInt16(prams[20].Value);

            five_a = Convert.ToInt16(prams[21].Value);
            five_b = Convert.ToInt16(prams[22].Value);
            five_c = Convert.ToInt16(prams[23].Value);
            five_d = Convert.ToInt16(prams[24].Value);
            five_e = Convert.ToInt16(prams[25].Value);

            six_a = Convert.ToInt16(prams[26].Value);
            six_b = Convert.ToInt16(prams[27].Value);
            six_c = Convert.ToInt16(prams[28].Value);
            six_d = Convert.ToInt16(prams[29].Value);
            six_e = Convert.ToInt16(prams[30].Value);

            seven_a = Convert.ToInt16(prams[31].Value);
            seven_b = Convert.ToInt16(prams[32].Value);
            seven_c = Convert.ToInt16(prams[33].Value);
            seven_d = Convert.ToInt16(prams[34].Value);
            seven_e = Convert.ToInt16(prams[35].Value);

            eight_a = Convert.ToInt16(prams[36].Value);
            eight_b = Convert.ToInt16(prams[37].Value);
            eight_c = Convert.ToInt16(prams[38].Value);
            eight_d = Convert.ToInt16(prams[39].Value);
            eight_e = Convert.ToInt16(prams[40].Value);

            nine_a = Convert.ToInt16(prams[41].Value);
            nine_b = Convert.ToInt16(prams[42].Value);
            nine_c = Convert.ToInt16(prams[43].Value);
            nine_d = Convert.ToInt16(prams[44].Value);
            nine_e = Convert.ToInt16(prams[45].Value);

            ten_a = Convert.ToInt16(prams[46].Value);
            ten_b = Convert.ToInt16(prams[47].Value);
            ten_c = Convert.ToInt16(prams[48].Value);
            ten_d = Convert.ToInt16(prams[49].Value);
            ten_e = Convert.ToInt16(prams[50].Value);

            eleven_a = Convert.ToInt16(prams[51].Value);
            eleven_b = Convert.ToInt16(prams[52].Value);
            eleven_c = Convert.ToInt16(prams[53].Value);
            eleven_d = Convert.ToInt16(prams[54].Value);
            eleven_e = Convert.ToInt16(prams[55].Value);

            twelve_a = Convert.ToInt16(prams[56].Value);
            twelve_b = Convert.ToInt16(prams[57].Value);
            twelve_c = Convert.ToInt16(prams[58].Value);
            twelve_d = Convert.ToInt16(prams[59].Value);
            twelve_e = Convert.ToInt16(prams[60].Value);

            thirteen_a = Convert.ToInt16(prams[61].Value);
            thirteen_b = Convert.ToInt16(prams[62].Value);
            thirteen_c = Convert.ToInt16(prams[63].Value);
            thirteen_d = Convert.ToInt16(prams[64].Value);
            thirteen_e = Convert.ToInt16(prams[65].Value);
            
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
       

    }

    #endregion
}