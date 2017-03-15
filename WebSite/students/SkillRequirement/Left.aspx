<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="students_SkillRequire_Left"%>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <title>左侧页</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
</head>
<body style="background-color:#F1F3F5;">
    <form id="form1" runat="server" target="frmright" method="post" action="List.aspx">
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
                <td>技能名称：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="SkillName" name="SkillName" size="25" />                
                </td>
            </tr>
            <tr>
                <td>要求例数：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="RequiredNum" name="RequiredNum" size="25" />                
                </td>
            </tr>     
            <tr>
                <td>掌握程度：</td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="MasterDegree" name="MasterDegree" size="25" />                
                </td>
            </tr>           
            <tr>
                <td>
                    <div style="text-align:center;">     
                        <input type="submit" name="Submit1" id="Submit1" value="查询" style="width:50px;height:25px;" class="button" />
                        <input type="button" name="Submit2" value="重置"class="button" onClick="form1.reset();" style="width:50px;height:25px;"/>
                    </div>                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

