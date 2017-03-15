<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="managers_LoginCheck_Left" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>左侧页</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
</head>
<body style="background-color:#F1F3F5;">
    <form id="form1" runat="server"  method="post" target="frmright">
    <div>
        <table cellpadding="1" cellspacing="1" class="qryTable">
          
            <tr>
                <td>真实姓名：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="RealName" name="RealName" size="25" />                
                </td>
            </tr>
             <tr>
                <td>角色：</td>
            </tr>
            <tr>
                <td>
                    <select id="Type" name="Type" style="width: 150px;">
                        <option value="">==请选择==</option>
                        <option value="students">学员</option>
                        <option value="teachers">指导医师</option>
                        <option value="bases">专业基地负责人</option>
                    </select>
                </td>
            </tr>
            
            <tr>
                <td>注册年份：<span style="color: #ff0000">(例:2015)</span></td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="RegisterDate" name="RegisterDate" size="25"/>               
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

