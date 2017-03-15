<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="teachers_StudentsBasicInformation_View" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学员基本信息</title>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script type="text/javascript">
        $(function () {
            if ($("#image_path").val() == "" || $("#image_path").val() == null) {
                $("#imgUpload").attr("src", "../../images/head1.jpg");
                
            } else {
                $("#imgUpload").attr("src", $("#image_path").val());
            }
           
        });
     </script>
</head>
<body style="background-color: #efebef;">
    <form id="form1" runat="server">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="6" class="detailHead">学员基本信息</td>
                </tr>
                 <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">姓名<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height:25px;">
                        <asp:Literal ID="real_name" runat="server"></asp:Literal>
                    </td>
                    <td width="60%" class="detailContent" colspan="4" rowspan="5">
                         <asp:Image ID="imgUpload" alt="图标" runat="server" width="120px" height="160px" />
                         <asp:HiddenField ID="image_path" runat="server" />
                        
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">性别<span style="color: #ff0000">*</span></td>
                    <td class="detailContent" width="23%" style="height: 25px;">
                        <asp:Literal ID="sex" runat="server"></asp:Literal>
                    </td>

                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px">居民身份证号<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="id_number" runat="server"></asp:Literal>
                    </td>

                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px">出生日期</td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="datebirth" runat="server"></asp:Literal>
                       
                    </td>
                </tr>
                 <tr>
                   <td width="10%" class="detailTitle" style="height: 25px">民族</td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="minzu"  runat="server"></asp:Literal>
                   </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px">手机号码<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="telephon" runat="server"></asp:Literal>
                       
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px">常用邮箱<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="mail" runat="server"></asp:Literal>
                   </td>
                     <td class="detailContent"></td>
                    <td class="detailContent"></td>
                </tr>
                
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px">本科毕业院校</td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="bk_school" runat="server"></asp:Literal>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px">本科专业</td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="bk_major" runat="server"></asp:Literal>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px">本科毕业时间</td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="graduation_time" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px">最高学历</td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="high_education" runat="server"></asp:Literal>
                   </td>
                    <td width="14%" class="detailTitle" style="height: 25px">最高学历毕业院校</td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="high_school" runat="server"></asp:Literal>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px">最高学历专业</td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="high_major" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td width="14%" class="detailTitle" style="height: 25px">获得最高学历时间</td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="high_education_time" runat="server"></asp:Literal>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px">身份类型</td>
                    <td width="23%" class="detailContent" style="height: 25px">
                         <asp:Literal ID="identity_type" runat="server"></asp:Literal>
                     </td>
                    <td width="10%" class="detailTitle" style="height: 25px">派出单位</td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="send_unit" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px">培训基地<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px" colspan="3">
                        <asp:Literal ID="training_base_province_name" runat="server"></asp:Literal>
                        <asp:Literal ID="training_base_name" runat="server"></asp:Literal>
                     </td>
                    <td width="10%" class="detailTitle" style="height: 25px">协同单位</td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="collaborative_unit" runat="server"></asp:Literal>
                    </td>
                    
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px">培训专业<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="professional_base_name" runat="server"></asp:Literal>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px">参训时间<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="training_time" runat="server"></asp:Literal>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px">计划参训时限<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="plan_training_time" runat="server"></asp:Literal>
                    </td>
                </tr>

               
                
           </table>

        </div>
    </form>
</body>

</html>

