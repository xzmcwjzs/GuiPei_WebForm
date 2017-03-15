<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="teachers_AppointInformation_Left" %>
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
                <td>预约时间：</td>
            </tr>
            <tr>
                <td>从
                    <input type="text" id="appoint_begin_time" name="appoint_begin_time"  onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm', position: { left: -25, top: 0 } })" size="21" />                
                </td>
            </tr>
            <tr>
                <td>到
                  <input type="text" id="appoint_end_time" name="appoint_end_time"  onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm', position: { left: -25, top: 0 } })"  size="21"/>
                </td>
            </tr>
            <tr>
                <td>审核结果：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="is_pass" name="is_pass" size="25" />                
                </td>
            </tr>  
                    
            <tr>
                <td>
                    <div style="text-align:center;">     
                        <asp:Button ID="Button1" runat="server" Text="查询" CssClass="button" PostBackUrl="~/teachers/AppointInformation/List.aspx" Height="25px" Width="50px" />
                        <input type="button" name="Submit2" value="重置"class="button" onClick="form1.reset();" style="width:50px;height:25px;"/>
                    </div>                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
