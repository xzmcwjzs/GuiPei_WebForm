using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Word=Microsoft.Office.Interop.Word;
using BLL;
using Model;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class zzzzzz_ToWord : System.Web.UI.Page
{
    protected string name = string.Empty;
    protected string tbCode = string.Empty;
   protected LoginModel loginModel = null;
   protected DataTable dt = null;
   private Word.Document doc;
   private Word.Application app;
   string _SaveDocPath = "";
   string filePath = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["loginModel"] == null)
        //{
        //    Response.Write("<script>alert('请重新登录');top.location.href='../../Default.aspx';window.close();</script>");
        //    return;

        //}
        //loginModel = (LoginModel)Session["loginModel"];
        name = "wangj";
        tbCode = "32017";
        //_SaveDocPath = HttpContext.Current.Server.MapPath(@"../RotaryTemplete/RotaryTemplete.docx");
      
    }
   

    protected void Button1_Click(object sender, EventArgs e)
    {
        StudentsRotaryBLL studentsRotaryBLL = new StudentsRotaryBLL();
        dt = new DataTable();

        try
        {
            string templatePath = HttpContext.Current.Server.MapPath(@"../RotaryTemplete/RotaryTemplete.docx");
            //生成的文档路径
            filePath = HttpContext.Current.Server.MapPath(@"../RotaryWord/");
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            if (!File.Exists(templatePath)) { Response.Write("<script>alert('error：服务器没有模版');</script>"); return; };
            DataTable dt_Stu = studentsRotaryBLL.GetDtByNT(name, tbCode);

            filePath = filePath + "个人轮转表-" + dt_Stu.Rows[0]["real_name"] + ".doc";
            //copy一份
            File.Copy(templatePath, filePath, true);

            object oMissing = System.Reflection.Missing.Value;
            app = new Word.Application();
            app.Visible = false;
            object fileName = filePath;
            doc = app.Documents.Open(ref fileName,
           ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
           ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
           ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            if (doc == null)
            {
                Response.Write("<script>alert('error：服务器没有打开Word');</script>"); 
                return; 
            }

            ////判断书签 //加入doc书签的方法
            //if (doc.Bookmarks.Exists("KJJBJNF"))
            //{
            //    doc.Bookmarks["KJJBJNF"].Range.Text = DateTime.Now.ToString("yyyyMMddHHmmss").ToString() + "标题";
            //}


            Word.Tables tabs1 = doc.Tables;
            if (tabs1 != null && tabs1.Count > 0)
            {
                Word.Table dt_Word = tabs1[1];

               
                doc.Bookmarks["TrainingBaseName"].Range.Text = dt_Stu.Rows[0]["training_base_name"].ToString();
                //默认从第2行开始，第1行为模板中的标头
                int rowIdex = 2;
                foreach (DataRow row in dt_Stu.Rows)
                {
                    object miss = System.Reflection.Missing.Value;
                    dt_Word.Rows.Add(miss);

                    //将从数据库中查询的数据，此处进行循环加载即可

                    
                    //1. 设置该单元格中字体的对齐方式
                    dt_Word.Cell(rowIdex, 1).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    //2.向单元格中添加数据
                    dt_Word.Cell(rowIdex, 1).Range.Text = row["real_name"].ToString();
                    dt_Word.Cell(rowIdex, 2).Range.Text = row["professional_base_name"].ToString();
                    dt_Word.Cell(rowIdex, 3).Range.Text = row["rotary_dept_name"].ToString();
                    dt_Word.Cell(rowIdex, 4).Range.Text = row["rotary_begin_time"].ToString();
                    dt_Word.Cell(rowIdex, 5).Range.Text = row["rotary_end_time"].ToString();
                    dt_Word.Cell(rowIdex, 6).Range.Text = row["instructor"].ToString();
                    // 3 .合并单元格Merge（行，列）
                    //dt_Word.Cell(rowIdex, 3).Merge(dt_Word.Cell(rowIdex, 4));

                    rowIdex++;
                }
            }
            doc.Save();
            QuitWord();
        }
        catch (Exception ex)
        {
            QuitWord();
            Response.Write("<script>alert('"+ex.Message+"');</script>"); 
        }

       

        //Word._Application appWord = new Word.ApplicationClass();
        //Word._Document docFile = null;
        //try
        //{
        //    appWord.Visible = false;
        //    object objTrue = true;
        //    object objFalse = false;
        //    object objTemplate = Server.MapPath(@"../RotaryTemplete/RotaryTemplete.docx");//模板路径
        //    object objDocType = Word.WdDocumentType.wdTypeDocument;
        //    docFile = appWord.Documents.Add(ref objTemplate, ref objFalse, ref objDocType, ref objTrue);
        //    //第一步生成word文档
        //    //定义书签变量
        //    object TrainingBaseName = "TrainingBaseName";
        //    object StudentsRealName = "StudentsRealName";
        //    object ProfessionalBaseName = "ProfessionalBaseName";
        //    object DeptName = "DeptName";
        //    object RotaryBeginTime = "RotaryBeginTime";
        //    object RotaryEndTime = "RotaryEndTime"; 
        //    object TeachersRealName = "TeachersRealName";

        //    //第二步 读取数据，填充数据集
        //    //SqlDataReader dr = XXXXX;//读取出来的数据集
        //    //第三步 给书签赋值
        //    //给书签赋值
        //     dt = studentsRotaryBLL.GetDtByNT(name, tbCode);
        //     if (dt == null)
        //     {
        //         Response.Write("<script>alert('暂无轮转信息');</script>");
        //         return;
        //     }
        //     else
        //     {
        //         foreach (DataRow row in dt.Rows)
        //         {
        //             docFile.Bookmarks.get_Item(ref TrainingBaseName).Range.Text = row["training_base_name"].ToString();
        //             docFile.Bookmarks.get_Item(ref StudentsRealName).Range.Text = row["real_name"].ToString();
        //             docFile.Bookmarks.get_Item(ref ProfessionalBaseName).Range.Text = row["professional_base_name"].ToString();
        //             docFile.Bookmarks.get_Item(ref DeptName).Range.Text = row["rotary_dept_name"].ToString();
        //             docFile.Bookmarks.get_Item(ref RotaryBeginTime).Range.Text = row["rotary_begin_time"].ToString();
        //             docFile.Bookmarks.get_Item(ref RotaryEndTime).Range.Text = row["rotary_end_time"].ToString();
        //             docFile.Bookmarks.get_Item(ref TeachersRealName).Range.Text = row["instructor"].ToString();
        //         }
        //     }
            

        //    //第四步 生成word
        //    object filename = Server.MapPath("../RotaryWord/") + "个人轮转表-"+dt.Rows[0]["real_name"]+".doc";
        //    object miss = System.Reflection.Missing.Value;
        //    docFile.SaveAs(ref filename, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
        //    object missingValue = Type.Missing;
        //    object doNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
        //    docFile.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
        //    appWord.Quit(ref miss, ref miss, ref miss);
        //    docFile = null;
        //    appWord = null;
        //}
        //catch (Exception ex)
        //{
        //    //捕捉异常，如果出现异常则清空实例，退出word,同时释放资源
        //    string aa = e.ToString();
        //    object miss = System.Reflection.Missing.Value;
        //    object missingValue = Type.Missing;
        //    object doNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
        //    docFile.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
        //    appWord.Quit(ref miss, ref miss, ref miss);
        //    docFile = null;
        //    appWord = null;
        //    throw ex;
        //}

    }
    private void QuitWord()
    {
        try
        {
            if (doc != null)
            {
                doc.Close();
                app.Quit();

                doc = null;
                app = null;
            }
        }
        catch
        { }
    }
}