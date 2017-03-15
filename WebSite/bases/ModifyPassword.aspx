<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyPassword.aspx.cs" Inherits="bases_ModifyPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>修改登录密码</title>
    <script src="../js/global.js"></script>
    <link href="../css/global.css" rel="stylesheet" />
</head>
<body style="background-color:#efebef;">
    <form id="form1" runat="server">
        <div style="text-align: center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="2" class="detailHead">登录密码修改</td>
                </tr>
                <tr>
                    <td class="detailTitle" style="width: 50%;">请输入新密码</td>
                    <td class="detailContent">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="25">
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

