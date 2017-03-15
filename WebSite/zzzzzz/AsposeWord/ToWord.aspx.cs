using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aspose.Words;
using System.IO;
using BLL;
using System.Data.SqlClient;
using System.Data;
using Model;
using Aspose.Words.Tables;


public partial class zzzzzz_AsposeWord_ToWord : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    LoginModel loginModel = new LoginModel();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //loginModel = Session["loginModel"] as LoginModel;
        //string  name = loginModel.name.ToString();
        //string tbCode = loginModel.training_base_code.ToString();

        string tempPath = Server.MapPath("RotaryTemplete.docx");

        string outputPath = Server.MapPath("God.doc");

        Document doc = new Document(tempPath);
        DocumentBuilder builder = new DocumentBuilder(doc);
       
        StudentsRotaryBLL studentsRotaryBLL = new StudentsRotaryBLL();

        dt = studentsRotaryBLL.GetDtByNT("wangj","32017");

        //String[] fieldNames = new String[] { "TrainingBaseName", "StudentsRealName", "ProfessionalBaseName", "DeptName", "RotaryBeginTime", "RotaryEndTime","TeachersRealName" };

        //Object[] fieldValues = new Object[] { dt.Rows[0]["training_base_name"].ToString(), dt.Rows[0]["real_name"].ToString(), dt.Rows[0]["professional_base_name"].ToString(), dt.Rows[0]["rotary_dept_name"].ToString(), dt.Rows[0]["rotary_begin_time"].ToString(), dt.Rows[0]["rotary_end_time"].ToString(), dt.Rows[0]["instructor"] };
        int count = 0;
        //doc.MailMerge.Execute(fieldNames, fieldValues);
        //Bookmark mark1 = doc.Range.Bookmarks["training_base_name"];
        //Bookmark mark2 = doc.Range.Bookmarks["RealName"];
        //Bookmark mark3 = doc.Range.Bookmarks["ProfessionalBaseName"];
        //if (doc.Range.Bookmarks["training_base_name"] != null)
        //{
        //    Bookmark mark = doc.Range.Bookmarks["training_base_name"];
        //    mark.Text = dt.Rows[0]["training_base_name"].ToString(); ;
        //}  
        //mark1.Text = dt.Rows[0]["training_base_name"].ToString();
        //mark2.Text = "王杰";
        //mark3.Text = "医学院";
        
        //记录要显示多少列
        for (var i = 0; i < dt.Columns.Count; i++)
        {
            if (doc.Range.Bookmarks[dt.Columns[i].ColumnName.Trim()] != null)
            {
                Bookmark mark = doc.Range.Bookmarks[dt.Columns[i].ColumnName.Trim()];
                mark.Text = "";
                count++;
            }
        }
        System.Collections.Generic.List<string> listcolumn = new System.Collections.Generic.List<string>(count);
        for (var i = 0; i < count; i++)
        {
            builder.MoveToCell(0, 0, i, 0); //移动单元格
            if (builder.CurrentNode.NodeType == NodeType.BookmarkStart)
            {
                listcolumn.Add((builder.CurrentNode as BookmarkStart).Name);
            }
        }
        double width = builder.CellFormat.Width;//获取单元格宽度
        builder.MoveToBookmark("table");        //开始添加值
        for (var m = 0; m < dt.Rows.Count; m++)
        {
            for (var i = 0; i < listcolumn.Count; i++)
            {
                builder.InsertCell();            // 添加一个单元格                    
                builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                builder.CellFormat.Width = width;
                builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;//垂直居中对齐
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
                builder.Write(dt.Rows[m][listcolumn[i]].ToString());
            }
           builder.EndRow();
        }
        doc.Range.Bookmarks["table"].Text = "";    // 清掉标示  
        doc.Save("王杰"+".doc", SaveFormat.Doc, SaveType.OpenInWord, Page.Response);

        //doc.Save(outputPath);
        

    }
}