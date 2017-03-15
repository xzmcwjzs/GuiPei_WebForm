<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码

    }
    /// <summary>
    /// url重写
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        string url = Request.AppRelativeCurrentExecutionFilePath;//~/BookDetail_4976.aspx
        Match match = Regex.Match(url, @"~/Frame_([a-z]+).aspx");
        if (match.Success)
        {
            Context.RewritePath("/Frame.aspx?role=" + match.Groups[1].Value);
        }

        //Match match = Regex.Match(url, @"~/BookDetail_(\d+).aspx");
        //if (match.Success)
        //{
        //    Context.RewritePath("/BookDetail.aspx?id=" + match.Groups[1].Value);
        //}
   }
   
   
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer
        // 或 SQLServer，则不引发该事件。

    }
       
</script>
