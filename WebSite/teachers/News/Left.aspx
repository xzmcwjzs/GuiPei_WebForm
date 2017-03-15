<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="students_News_Left" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <title>左侧页</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
</head>
<body style="background-color:#F1F3F5;">
    <form id="form1" runat="server" target="frmright" method="post">
    <div>
        <table cellpadding="1" cellspacing="1" class="qryTable">
           
            <tr>
                <td>标题：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="NewsTitle" name="NewsTitle"   size="25" />                
                </td>
            </tr>
            
            <tr>
                <td>发布日期：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="RegisterDate" name="RegisterDate" onclick="WdatePicker({ maxDate: '%y-%M-%d'});" size="25" />                
                </td>
            </tr>  
                    
            <tr>
                <td>
                    <div style="text-align:center;">     
                        <asp:Button ID="Button1" runat="server" Text="查询" CssClass="button" PostBackUrl="List.aspx" Height="25px" Width="50px" />
                        <input type="button" name="Submit2" value="重置"class="button" onClick="form1.reset();" style="width:50px;height:25px;"/>
                    </div>                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

