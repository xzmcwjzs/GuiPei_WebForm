<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="students_BedManagement_Left" %>

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
                    <input type="text" id="dept_name" name="dept_name" size="25" />                
                </td>
            </tr>
             <tr>
                <td>病人姓名：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="patient_name" name="patient_name" size="25" />                
                </td>
            </tr>
            <tr>
                <td>床位编号：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="bed_id" name="bed_id" size="25" />                
                </td>
            </tr>
            <tr>
                <td>床位状态：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="bed_status" name="bed_status" size="25" />                
                </td>
            </tr>
            <tr>
                <td>房间号：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="room_id" name="room_id" size="25" />                
                </td>
            </tr>
            <tr>
                <td>所在楼：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="building_id" name="building_id" size="25" />                
                </td>
            </tr>                  
            <tr>
                <td>
                    <div style="text-align:center;">     
                        <asp:Button ID="Button1" runat="server" Text="查询" CssClass="button" PostBackUrl="~/students/BedManagement/List.aspx" Height="25px" Width="50px" />
                        <input type="button" name="Submit2" value="重置"class="button" onClick="form1.reset();" style="width:50px;height:25px;"/>
                    </div>                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
