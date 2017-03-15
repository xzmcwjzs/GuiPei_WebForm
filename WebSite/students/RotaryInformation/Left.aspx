<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="students_RotaryInformation_Left" %>

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
                <td>轮转科室：</td>
            </tr>
            <tr>
                <td>
                    <%--<asp:DropDownList ID="rotary_dept" runat="server" Height="16px" Width="154px">

                    </asp:DropDownList>  --%>  
                  <input type="text" id="rotary_dept" name="rotary_dept" size="25" />      
                </td>
            </tr>
            
            <tr>
                <td>指导医师：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="instructor" name="instructor" size="25" />                
                </td>
            </tr>
            <tr>
                <td>轮转时间：</td>
            </tr>
            <tr>
                <td>从
                    <input type="text" id="rotary_begin_time" name="rotary_begin_time"  onclick="WdatePicker({position:{left:-25,top:0}})"  size="21" />                
                </td>
            </tr>
            <tr>
                <td>到
                  <input type="text" id="rotary_end_time" name="rotary_end_time"  onclick="WdatePicker({position:{left:-25,top:0}})"  size="21"/>
                </td>
            </tr>         
            <tr>
                <td>
                    <div style="text-align:center;">     
                        <asp:Button ID="Button1" runat="server" Text="查询" CssClass="button" PostBackUrl="~/students/RotaryInformation/List.aspx" Height="25px" Width="50px" />
                        <input type="button" name="Submit2" value="重置"class="button" onClick="form1.reset();" style="width:50px;height:25px;"/>
                    </div>                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
