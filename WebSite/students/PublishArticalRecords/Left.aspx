<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="students_PublishArticalRecords_Left" %>

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
                <td>题目：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="ArticalTitle" name="ArticalTitle" size="25" /> 
                </td>
            </tr>
            <tr>
                <td>类别：</td>
            </tr>
            <tr>
                <td>
                    <select id="ArticalCategory" name="ArticalCategory" style="width: 150px;">
                        <option value="">==请选择==</option>
                        <option value="译文">译文</option>
                        <option value="个案报道">个案报道</option>
                        <option value="综述">综述</option>
                        <option value="论文">论文</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>第几作者：</td>
            </tr>
            <tr>
                <td>
                    <select id="Author" name="Author" style="width:150px;">
                                <option value="">==请选择==</option>
                                <option value="第一作者">第一作者</option>
                                <option value="第二/三作者">第二/三作者</option>
                                <option value="通讯作者">通讯作者</option>
                            </select>               
                </td>
            </tr>
            <tr>
                <td>日期：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="PublishDate" name="PublishDate" size="25" onclick="WdatePicker({ maxDate: '%y-%M-%d' });" />               
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

