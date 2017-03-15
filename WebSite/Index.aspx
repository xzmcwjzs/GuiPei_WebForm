<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登录首页</title>
    <script type="text/javascript" src="js/jquery-1.7.2.js"></script>
    <style type="text/css">
        body {
            text-align: center;
            margin: 0 auto;
        }

        .main {
            width: 990px;
            height: 630px;
            background-color: #4f92c5;
            margin: 0 auto;
            padding: 0;
        }

        .top {
            width: 900px;
            height: 100px;
            margin-top: 25px;
            margin-left: 30px;
            float: left;
            background-color: #4f92c5;
        }

        .top_left {
            width: 100px;
            height: 100px;
            float: left;
            background-color: #4f92c5;
        }

        .top_right {
            width: 600px;
            height: 100px;
            float: left;
            margin-left: 20px;
            margin-top: 30px;
            background-color: #4f92c5;
            font-size: 32pt;
            text-align: left;
            font-family: "黑体";
            color: white;
        }

        .center {
            width: 900px;
            height: 300px;
            margin-top: 40px;
            margin-left: 30px;
            float: left;
            background-color: #4f92c5;
        }

        .center_left {
            width: 440px;
            height: 273px;
            margin-left: 35px;
            float: left;
            background-color: #4f92c5;
            border-right-style: solid;
            border-right-width: thin;
            border-right-color: #4f92c5;
        }

        .center_right {
            background-color: white;
            width: 400px;
            height: 273px;
            float: left;
        }

        .STYLE66 {
            font-size: 14pt;
            line-height: 20px;
            color: #000000;
        }

        .bottom {
            width: 990px;
            height: 100px;
            float: left;
            background-color: #4f92c5;
            text-align: center;
            margin-top: 80px;
        }

        .STYLE40 {
            font-size: 15px;
            color: #000000;
            font-family: "宋体";
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div class="top">
                <div class="top_left">
                    <img alt="" src="index/images/tubiao3.png" style="width: 100px; height: 100px;" />

                </div>
                <div class="top_right">
                    <asp:Literal ID="title" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="center">
                <div class="center_left">
                    <img alt="" src="index/images/main.jpg" style="width: 440px; height: 273px;" />

                </div>
                <div class="center_right">
                    <span style="font-size: 20pt; font-family: 黑体; padding-top: 10px; color: #808080; line-height: 40px; margin-right: 190px;">系统登录</span>
                    <hr style="width: 350px; color: #bbb;" size="1" />
                    <br />
                    <br />
                    <span class="STYLE66">角色:</span>
                    <asp:DropDownList ID="role" runat="server" Width="150px" Height="20px">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="login" runat="server" Text="登录" Width="80px" OnClick="login_Click" />
                </div>
            </div>
            <div class="bottom">
                <span class="STYLE40">电话：0513-85051890<a href="mailto:nthealth@126.com" style="color: #000000; text-decoration: none;">邮箱：chinancd@163.com </a></span>
                <br />
                <span class="STYLE40">Copyright &copy; 2015-2017  www.chinaehr.org </span><span class="STYLE40"><a href="http://icp.valu.cn/beianxinxi/28552c0a-5976-4e41-92c4-3a8f38460f02.html" target="_blank" style="color: #000000; text-decoration: none;">苏ICP备11018114号</a></span>

            </div>

        </div>
    </form>
</body>
</html>
