<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="students_PersonalInformation_View" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>个人信息资料</title>
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
                    <td height="24" align="center" colspan="6" class="detailHead">个人基本信息</td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">姓名<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height:25px;">
                        <asp:Literal ID="real_name" runat="server"></asp:Literal>
                    </td>
                    <td width="60%" class="detailContent" style="height: 50px" colspan="4" rowspan="5">
                        <div style="float:left;width:30%;height:125px;margin-left:70px;margin-top:5px;">
                            <%--<img src="../../images/head1.jpg" alt="图标" id="imgUpload" width="120px" height="160px"/>--%>
                            <asp:Image ID="imgUpload" alt="图标" runat="server" width="120px" height="160px" />
                            <asp:HiddenField ID="image_path" runat="server" />
                            
                        </div>
                        
                        
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
                    <td class="detailTitle" style="height: 25px;" width="10%">年龄</td>
                    <td class="detailContent" style="height: 25px" width="23%">
                        <asp:Label ID="age" runat="server"  Width="160px"></asp:Label>
                     </td>
                </tr>
                   <tr>
                     <td class="detailTitle" style="height: 25px;" width="10%"><span class="detailTitle" style="height: 25px;">常住地址<span style="color: #ff0000">*</span></span></td>
                    <td colspan="5" class="detailContent" style="height: 25px" >
                       
                        <asp:Literal ID="province" runat="server"></asp:Literal>
                        <asp:Literal ID="city" runat="server"></asp:Literal>
                        <asp:Literal ID="area" runat="server"></asp:Literal>
                        <asp:Literal ID="detail_address" runat="server"></asp:Literal>
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
                    <td width="10%" class="detailTitle" style="height: 25px">民族</td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="minzu" runat="server"></asp:Literal>
                   </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px">紧急联系人</td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="urgent" runat="server"></asp:Literal>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px">紧急联系人手机</td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="urgent_telephon" runat="server"></asp:Literal>
                    </td>
                   
                    <td width="10%" class="detailTitle" style="height: 25px"></td>
                    <td width="23%" class="detailContent" style="height: 25px"><span class="detailContent" style="height: 25px">
                    </span></td>
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
                    <td width="10%" class="detailTitle" style="height: 25px">计划参训年限<span style="color: #ff0000">*</span></td>
                    <td width="23%" class="detailContent" style="height: 25px">
                        <asp:Literal ID="plan_training_time" runat="server"></asp:Literal>
                    </td>
                </tr>

                <tr>

                    <td width="10%" class="detailTitle" style="height: 25px"></td>
                    <td width="23%" class="detailContent" style="height: 25px" colspan="5">
                        <table>
                            <tr>
                                
                                <td width="40%" class="detailContent" style="height: 25px" ></td>
                                
                                <td width="10%" class="detailTitle" style="height: 25px" >填写人<span style="color: #ff0000">*</span></td>
                                <td width="23%" class="detailContent" style="height: 25px" >
                                    <asp:Literal ID="writor" runat="server"></asp:Literal>
                                </td>
                                <td width="10%" class="detailTitle" style="height: 25px" >登记日期<span style="color: #ff0000">*</span></td>
                                <td width="23%" class="detailContent" style="height: 25px" >
                                    <asp:Literal ID="register_date" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                
           </table>

        </div>
    </form>
</body>

</html>
