<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyPassword.aspx.cs" Inherits="ModifyPassword_ModifyPassword" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>修改登录密码</title>
    <script src="../js/global.js"></script>
    <link href="../css/global.css" rel="stylesheet" />
    <script src="../js/jquery-1.7.2.js"></script>

    <script type="text/javascript">

        function checkPassword() {
            var psw1 = $("#txtPassword").val();
            var length1 = $("#txtPassword").val().length;

            var psw2 = $("#txtPassword2").val();
            var length2 = $("#txtPassword2").val().length;
            
                if (length1 == length2) {
                    if (psw1 == psw2) {
                        $("#Tip").text("两次输入密码一致");
                    } else {
                        $("#Tip").text("密码输入不一致，请重新输入");
                        $("#txtPassword").val(""); $("#txtPassword2").val("");
                        $("#txtPassword").focus();
                    }
                }

            }

    </script>
</head>
<body style="background-color:#efebef;">
    <form id="form1" runat="server">
        <div style="text-align: center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="3" class="detailHead">登录密码修改</td>
                </tr>

                <tr>
                    <td class="detailTitle" style="width: 30%;">输入新密码</td>
                    <td class="detailContent">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150" Height="20"></asp:TextBox>
                    </td>
                    <td style="color:#ff0000">(密码长度不得小于六位)</td>
                </tr>
                <tr>
                    <td class="detailTitle" style="width: 30%;">确认新密码</td>
                    <td class="detailContent">
                        <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password" Width="150" Height="20" onkeyup="checkPassword();"></asp:TextBox>
                    </td>
                    <td style="color:#ff0000"><label id="Tip"></label></td>
                </tr>
                <tr>
                    <td colspan="3" height="25">
                        <div align="center">

                            <asp:Button ID="Button1" runat="server" CssClass="button" Text=" 提交 " OnClick="Button1_Click" />
                            <input type="button" name="Submit2" value="重置" class="button" onclick="form1.reset();" />

                        </div>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>

