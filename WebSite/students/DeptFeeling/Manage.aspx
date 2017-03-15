<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="students_DeptFeeling_Manager"  %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>入科感想</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/jquery-1.7.2.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
  
</head>

<body style="background-color: #efebef;">
    <form id="form1" runat="server">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="4" class="detailHead">入科感想</td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">姓名<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="real_name" runat="server" Text="" ReadOnly="true" Width="150px"></asp:TextBox>
                        <asp:HiddenField ID="name" runat="server" />
                        </span>
                    </td>
                    <td width="15%" class="detailTitle" style="height: 25px;"></td>
                    <td width="35%" class="detailContent" style="height:25px;"></td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">培训基地<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="training_base_name" runat="server" Text="" ReadOnly="true" Width="150px"></asp:TextBox></span>
                        <asp:HiddenField ID="TrainingBaseCode" runat="server" />
                        
                    </td>
                     <td width="15%" class="detailTitle" style="height: 25px;">专业基地<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="professional_base_name" runat="server" Text="" ReadOnly="true" Width="150px"></asp:TextBox></span>
                        <asp:HiddenField ID="ProfessionalBaseCode" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">轮转科室<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:DropDownList ID="RotaryDept" runat="server" OnSelectedIndexChanged="RotaryDept_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="0">==请选择==</asp:ListItem>
                         </asp:DropDownList>
                        </span>
                    </td>
                     <td width="15%" class="detailTitle" style="height: 25px;">指导医师<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        
                        <asp:DropDownList ID="Teacher" runat="server">
                            <asp:ListItem Value="0">==请选择==</asp:ListItem>
                         </asp:DropDownList>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">入科感想<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;" colspan="3">
                        <asp:TextBox ID="dept_felling" TextMode="MultiLine" Width="90%" Height="100px" runat="server"></asp:TextBox></td>
                    
                </tr>
                <tr>

                    <td width="100%" class="detailContent" style="height: 25px;" colspan="5">
                        <table align="right">
                            <tr>
                                
                                <td width="20%" class="detailTitle" style="height: 25px" >填写人<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px" ><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="writor" runat="server" Text=""></asp:TextBox>
                                </span></td>
                                <td width="30%" class="detailTitle" style="height: 25px" >登记日期<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px" ><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="register_date" runat="server" Text="" ReadOnly="true"></asp:TextBox>
                                </span></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="last">
                    <td colspan="6" style="height: 25px; border-left: 1px solid white; border-right: 1px solid white; border-bottom: 1px solid white">
                        <div style="text-align: center; margin-top: 8px;">
                            <asp:Button ID="save" runat="server" Text="" style="cursor: pointer; background-image: url(../images/1.jpg); border: none; height: 21px; width: 88px;" OnClick="save_Click"/>
                           <%-- <a style="padding-left: 2em"></a>
                            <input type="button"  style="cursor: pointer; background-image: url(../images/2.jpg); border: none; height: 21px; width: 88px;" onclick="form1.reset();" />
                           --%>
                         </div>
                    </td>
                </tr>
           </table>

        </div>
    </form>
    
</body>
</html>
