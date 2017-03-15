<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="teachers_StudentsBasicInformation_Left" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <title>左侧页</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#identity_type").change(function () {
                if ($("#identity_type").val() == "单位人") {
                    $("#send_unit").removeAttr("disabled");
                } else {
                    $("#send_unit").attr("disabled", "disabled");
                    $("#send_unit").val();
                }

            });
        });
    </script>
</head>
<body style="background-color:#F1F3F5;">
    <form id="form1" runat="server" target="frmright" method="post">
    <div>
        <table cellpadding="1" cellspacing="1" class="qryTable">
           <tr>
                <td>学员姓名：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="name" name="name" size="25" />                
                </td>
            </tr>
            
            <tr>
                <td>性别：<asp:DropDownList ID="sex" runat="server" Height="16px" >
                    <asp:ListItem Value="" Text="==请选择==" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="女" Text="女"></asp:ListItem>
                        <asp:ListItem Value="男" Text="男"></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
           
            <tr>
                <td>民族：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="minzu" name="minzu" size="25" />                
                </td>
            </tr>
            <tr>
                <td>最高学历：<asp:DropDownList ID="high_education" runat="server" Height="16px" >
                        <asp:ListItem Value="" Text="==请选择==" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="专科" Text="专科"></asp:ListItem>
                        <asp:ListItem Value="本科" Text="本科"></asp:ListItem>
                        <asp:ListItem Value="硕士研究生" Text="硕士研究生"></asp:ListItem>
                        <asp:ListItem Value="博士研究生" Text="博士研究生"></asp:ListItem>
                    </asp:DropDownList>    </td>
            </tr>
            <tr>
                <td>最高学历毕业院校：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="high_school" name="high_school" size="25" />                
                </td>
            </tr>
            <tr>
                <td>身份类型：<asp:DropDownList ID="identity_type" runat="server">
                        <asp:ListItem Value="" Text="==请选择==" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="单位人" Text="单位人" ></asp:ListItem>
                        <asp:ListItem Value="社会人" Text="社会人"></asp:ListItem>
                    </asp:DropDownList> </td>
            </tr>
            
            <tr>
                <td>派出单位：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="send_unit" name="send_unit" size="25" disabled="disabled"/>                
                </td>
            </tr>
            <tr>
                <td>协同单位：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="collaborative_unit" name="collaborative_unit" size="25" />                
                </td>
            </tr>
            <tr>
                <td>参训时间：<span style="color: #ff0000">(例:2015年)</span></td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="training_time" name="training_time" size="25" />                
                </td>
            </tr>
            <tr>
                <td>计划参训时限：<span style="color: #ff0000">(例:2年)</span></td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="plan_training_time" name="plan_training_time" size="25" />                
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