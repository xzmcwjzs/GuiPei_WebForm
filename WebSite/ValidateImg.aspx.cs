using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public partial class ValidateImg : System.Web.UI.Page
{

    //验证数字
    public string authcode = string.Empty;
    Random ran = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = getRandomValidate(4);
        Session["CheckCode"] = str;//这一部是Wie了验证码写入Session,进行验证，也可以使用cookie
        getImageValidate(str);
    }
    //得到随机字符串，长度自定义
    private string getRandomValidate(int len)
    {
        string[] source = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
        string code = "";
        //创建Random类的实例  
        Random rd = new Random();
        //获取验证码  
        for (int i = 0; i < len; i++)
        {
            code += source[rd.Next(0, source.Length)];

        }
        //返回产生的验证码  
        return code;  
    }
    //生成图像
    private void getImageValidate(string strValue)
    {
        //string str=oo00;前两个为字母o，后两个数为0
        //int width = Convert.ToInt32(strValue.Length * 14);
        Bitmap img = new Bitmap(60, 22);
        Graphics gfc = Graphics.FromImage(img);
        gfc.Clear(Color.White);
        drawLine(gfc, img);
        //写验证码，要定义Font
        Font font = new Font("arial", 14, FontStyle.Bold);
        //Font font = new Font("宋体",12,FontStyle.Bold|FontStyle.Italic);
        System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, img.Width, img.Height), Color.DarkBlue, Color.DarkRed,1.5f, false);
        gfc.DrawString(strValue, font, brush, 6,1);
        drawPoint(img);
        gfc.DrawRectangle(new Pen(Color.Black), 0, 0, img.Width - 1, img.Height - 1);
        //将图像添加到页面
        MemoryStream ms = new MemoryStream();
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        //更改HTTP
        Response.ClearContent();
        Response.ContentType = "image/gif";
        Response.BinaryWrite(ms.ToArray());
        //Dispose
        gfc.Dispose();
        img.Dispose();
        Response.End();


    }

    private void drawLine(Graphics gfc, Bitmap img)
    {
        //选择画10条线，也可以增加，也可以不要线，只要随机杂点就行
        for (int i = 0; i < 10; i++)
        {
            int x1 = ran.Next(img.Width);
            int y1 = ran.Next(img.Height);
            int x2 = ran.Next(img.Width);
            int y2 = ran.Next(img.Height);
            gfc.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);//注意画笔要淡，不然看不清
        }

    }

    //private void drawPoint(Bitmap img)
    //{

    //}

    private void drawPoint(Bitmap img)
    {
        int col = ran.Next();//在一次的图片中杂点颜色相同
        for (int i = 0; i < 100; i++)
        {
            int x = ran.Next(img.Width);
            int y = ran.Next(img.Height);
            img.SetPixel(x, y, Color.FromArgb(col));
        }
    }
}