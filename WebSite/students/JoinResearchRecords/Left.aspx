<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="students_JoinResearchRecords_Left" %>

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
                <td>轮转科室：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="DeptName" name="DeptName" size="25" />                
                </td>
            </tr>
             <tr>
                <td>课题题目：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="ResearchTitle" name="ResearchTitle" size="25" /> 
                </td>
            </tr>
            <tr>
                <td>课题负责人：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="ResearchManager" name="ResearchManager" size="25" />  
                </td>
            </tr>
            <tr>
                <td>参与角色：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="JoinRole" name="JoinRole" size="25" />  
                </td>
            </tr>
            <tr>
                <td>日期：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="ResearchDate" name="ResearchDate" size="25" onclick="WdatePicker({ maxDate: '%y-%M-%d' });" />               
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

