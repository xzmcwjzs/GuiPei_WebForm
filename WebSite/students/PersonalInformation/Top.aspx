<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="students_PersonalInformation_Top" %>
<%@ Import Namespace="System.Data" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>头部</title>
    <link href="../../css/global.css" rel="stylesheet" />
    <style type="text/css">
	.tbmover{
		border: #336699 1px solid;
		padding-right: 2px; 
		padding-left: 2px; 
		background-color: #eef2f8;
		cursor: pointer;
	}
	.tbmout{
		padding-right: 3px; padding-left: 3px;
	}
	</style>
    <script src="../../js/global.js"></script>

     <script type="text/javascript">
         //function Alert(json) {
         //    if (json=="") {
         //        OpenTopWindow('PersonalInformation.aspx', 950, 400);
         //        //alert(json);
         //    } else {
         //        alert("您的信息已完善，请勿重复填写！");
         //        //alert(json);
         //    }
             
         //}
    </script>
</head>
<body>
    <table width="99%" border="0" cellpadding="0" cellspacing="0" class="toorbar2" style="margin: auto">
        <tr>
            <td style="width: 1%;">|</td>
           
            <td style="width: 10%;" class='tbmout' onmouseover="this.className='tbmover'" onmouseout="this.className='tbmout'" onclick="javascript:OpenTopWindow('PersonalInformation.aspx', 1000, 550);">
                <img src="../../images/imgs/icon_add.gif" alt="" height="16" align="absmiddle" /> 填写个人信息</td>
            
            

            <td style="width: 1%;">|</td>
            <td height="20">&nbsp;</td>
        </tr>
    </table>
</body>
</html>
