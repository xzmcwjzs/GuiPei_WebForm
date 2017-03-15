<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrameMain.aspx.cs" Inherits="teachers_FrameMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <link href="../css/global.css" rel="stylesheet" />
    <title>无标题页</title>
    <script src="../js/global.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable" id="yujing">
                <tr>
                    <%--<td height="24" style="font-size: 18px;">住院医师规范化培训大纲-<a href="#" onclick="OpenTopWindow('Alert.aspx','600','600');">点击查看</a>
                   <a style="padding-left:20em"></a>住院医师规范化培训考核实施办法-<a href="#" onclick="OpenTopWindow('Alert1.aspx','600','600');">点击查看</a></td>--%>
                    <td style="font-size: 18px;width:50%;" class="auto-style1">住院医师规范化培训考核实施办法-<a href="../index/download/住院医师规范化培训考核实施办法.pdf" target="_blank">点击下载</a></td>
                   <td style="font-size: 18px;width:50%;" class="auto-style1">住院医师规范化培训招收实施办法-<a href="../index/download/住院医师规范化培训招收实施办法.pdf" target="_blank">点击下载</a></td>
                     </tr>
               
            </table>

            <br />
            <table id="guoqi" width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" style="font-size: 18px;width:50%;">住院医师规范化培训内容与标准-<a href="../index/download/住院医师规范化培训内容与标准.PDF" target="_blank">点击下载</a></td>
                       <td height="24" style="font-size: 18px;width:50%;">住院医师规范化培训基地认定标准（试行）-<a href="../index/download/住院医师规范化培训基地认定标准（试行）.pdf" target="_blank">点击下载</a>
                    </td>
                </tr>
                
            </table>

            <br />
            <table id="Table1" width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" style="font-size: 18px;width:50%;">住院医师规范化培训管理办法（试行）-<a href="../index/download/住院医师规范化培训管理办法（试行）.pdf" target="_blank">点击下载</a></td>
                       <td height="24" style="font-size: 18px;width:50%;">住院医师规范化培训制度的指导意见-<a href="../index/download/国家卫生计生委等7部门关于建立住院医师规范化培训制度的指导意见（国卫科教发〔2013〕56号）.pdf" target="_blank">点击下载</a></td>
                </tr>
            </table>
            <br />

            <iframe frameborder="0" width="100%" height="600" src=""></iframe>
        </div>
    </form>
</body>
</html>