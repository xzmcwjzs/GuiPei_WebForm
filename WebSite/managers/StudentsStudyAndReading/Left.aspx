<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="managers_StudentsStudyAndReading_Left" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
                <td>学员姓名：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="StudentsRealName" name="StudentsRealName" size="25" />                
                </td>
            </tr>
            <tr>
                <td>专业基地：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="ProfessionalBaseName" name="ProfessionalBaseName" size="25" />                
                </td>
            </tr>
            <tr>
                <td>轮转科室：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="DeptName" name="DeptName" size="25" />                
                </td>
            </tr>
            <tr>
                <td>指导医师：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="TeachersRealName" name="TeachersRealName" size="25" />                
                </td>
            </tr>
             <tr>
                <td>活动形式：</td>
            </tr>
            <tr>
                <td>
                    <select id="ActivityForm" name="ActivityForm"  style="width:154px">
                        <option value="-1">==请选择==</option>
                        <option value="专业学习">专业学习</option>
                        <option value="英语学习">英语学习</option>
                        <option value="文献综述阅读">文献综述阅读</option>
                        <option value="文献综述撰写">文献综述撰写</option>
                        <option value="读书报告">读书报告</option>
                        <option value="病例报告">病例报告</option>
                        <option value="其他形式的学习和阅读">其他形式的学习和阅读</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>日期：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="ActivityDate" name="ActivityDate" size="25" onclick="WdatePicker({ maxDate: '%y-%M-%d' });" />               
                </td>
            </tr>
            <tr>
                <td>语种：</td>
            </tr>
            <tr>
                <td>
                    <select id="LanguageType" name="LanguageType" style="width: 154px">
                        <option value="-1">==请选择==</option>
                        <option value="中文">中文</option>
                        <option value="英文">英文</option>
                        <option value="其他">其他</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>上级医师：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="SuperiorDoctor" name="SuperiorDoctor" size="25" />                
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

