<%@ WebHandler Language="C#" Class="ToWord"%>

using System;
using System.Web;
using Model;
using System.Web.Script.Serialization;
using BLL;
using System.Web.SessionState;
using Common;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public class ToWord : IHttpHandler,IRequiresSessionState {
    LoginModel loginModel = new LoginModel();
    StudentsRotaryBLL studentsRotaryBLL = new StudentsRotaryBLL();
    protected string name = string.Empty;
    protected string tbCode = string.Empty;
    private Word.Document doc;
    private Word.Application app;
    string filePath = string.Empty;
    string filename = string.Empty;
    DataTable dt_Rot = new DataTable();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (context.Session["loginModel"] == null)
        {
            context.Response.Write("error");
            return;
        }
        loginModel = context.Session["loginModel"] as LoginModel;
        name = loginModel.name.ToString();
        tbCode = loginModel.training_base_code.ToString();
        try
        {
            string templatePath = HttpContext.Current.Server.MapPath(@"/RotaryTemplete/RotaryTemplete.docx");
            //生成的文档路径
            filePath = HttpContext.Current.Server.MapPath(@"/RotaryWord/");
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            if (!File.Exists(templatePath)) { context.Response.Write("服务器没有模版"); return; };
            dt_Rot = studentsRotaryBLL.GetDtByNT(name, tbCode);
            filename = "个人轮转表-" + dt_Rot.Rows[0]["real_name"] + ".doc";
            
            filePath = filename;
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
                context.Response.Write("服务器没有打开Word");
                return;
            }
            
            Word.Tables tabs1 = doc.Tables;
            if (tabs1 != null && tabs1.Count > 0)
            {
                Word.Table dt_Word = tabs1[1];


                doc.Bookmarks["TrainingBaseName"].Range.Text = dt_Rot.Rows[0]["training_base_name"].ToString();
                //默认从第2行开始，第1行为模板中的标头
                int rowIdex = 2;
                foreach (DataRow row in dt_Rot.Rows)
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
            //filename = HttpUtility.UrlEncode(filename);
            //context.Response.AddHeader("Content-Disposition", "attachment;filename" + filename);
            //context.Response.WriteFile(filePath);
            QuitWord();
            context.Response.Write(filename);
           
        }
        catch (Exception ex)
        {
            QuitWord();
            context.Response.Write(ex.Message);
        }

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
    public bool IsReusable {
        get {
            return false;
        }
    }

}