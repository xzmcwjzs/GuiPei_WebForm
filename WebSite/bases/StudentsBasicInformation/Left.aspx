<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="bases_StudentsBasicInformation_Left" %>

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
            $("#IdentityType").change(function () {
                if ($("#IdentityType").val() == "单位人") {
                    $("#SendUnit").removeAttr("disabled");
                } else {
                    $("#SendUnit").attr("disabled", "disabled");
                    $("#SendUnit").val();
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
                    <input type="text" id="StudentsRealname" name="StudentsRealname" size="25" />                
                </td>
            </tr>
            
            <tr>
                <td>性别：
                    <select id="Sex" name="Sex">
                        <option value="">==请选择==</option>
                        <option value="男">男</option>
                        <option value="女">女</option>
                    </select>
                </td>
            </tr>
           
            <tr>
                <td>民族：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="MinZu" name="MinZu" size="25" />                
                </td>
            </tr>
            <tr>
                <td>最高学历：
                    <select id="HighEducation" name="HighEducation">
                        <option value="">==请选择==</option>
                        <option value="专科">专科</option>
                        <option value="本科">本科</option>
                        <option value="硕士研究生">硕士研究生</option>
                        <option value="博士研究生">博士研究生</option>

                    </select>

                </td>
            </tr>
            <tr>
                <td>最高学历毕业院校：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="HighSchool" name="HighSchool" size="25" />                
                </td>
            </tr>
            <tr>
                <td>身份类型：
                    <select id="IdentityType" name="IdentityType">
                        <option value="">==请选择==</option>
                        <option value="单位人">单位人</option>
                        <option value="社会人">社会人</option>

                    </select>
                </td>
            </tr>
            
            <tr>
                <td>派出单位：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="SendUnit" name="SendUnit" size="25" disabled="disabled"/>                
                </td>
            </tr>
            <tr>
                <td>协同单位：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="CollaborativeUnit" name="CollaborativeUnit" size="25" />                
                </td>
            </tr>
            <tr>
                <td>参训时间：<span style="color: #ff0000">(例:2015年)</span></td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="TrainingTime" name="TrainingTime" size="25" />                
                </td>
            </tr>
            <tr>
                <td>计划参训时限：<span style="color: #ff0000">(例:2年)</span></td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="PlanTrainingTime" name="PlanTrainingTime" size="25" />                
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
