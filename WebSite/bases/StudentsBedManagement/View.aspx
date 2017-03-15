<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="bases_StudentsBedManagement_View" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>床位管理</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/jquery-1.7.2.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
</head>

<body style="background-color: #efebef;">
    <form id="form1" runat="server">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="4" class="detailHead">床位信息</td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">姓名<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="students_real_name" runat="server" Text="" ReadOnly="true" Width="150px"></asp:TextBox>
                        <asp:HiddenField ID="students_name" runat="server" />
                        </span>
                    </td>
                    <td width="15%" class="detailTitle" style="height: 25px;"></td>
                    <td width="35%" class="detailContent" style="height:25px;"></td>
                </tr>

                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">培训基地<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="training_base_name" runat="server" Text="" ReadOnly="true" Width="150px"></asp:TextBox></span>
                        <asp:HiddenField ID="training_base_code" runat="server" />
                    </td>
                     <td width="15%" class="detailTitle" style="height: 25px;">专业基地<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="professional_base_name" runat="server" Text="" ReadOnly="true" Width="150px"></asp:TextBox></span>
                        <asp:HiddenField ID="professional_base_code" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">轮转科室<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:DropDownList ID="rotary_dept" runat="server">
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
                   <td width="15%" class="detailTitle" style="height: 25px;">病人姓名<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="patient_name" runat="server" Text="" Width="150px"></asp:TextBox></span>
                    </td>
                     <td width="15%" class="detailTitle" style="height: 25px;">病人编号</td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="patient_id" runat="server" Text="" Width="150px"></asp:TextBox></span>
                    </td>
                </tr>
                <tr>
                   <td width="15%" class="detailTitle" style="height: 25px;">床位编号<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="bed_id" runat="server" Text="" Width="150px"></asp:TextBox></span>
                    </td>
                     <td width="15%" class="detailTitle" style="height: 25px;">床位卡号</td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="bed_card" runat="server" Text="" Width="150px"></asp:TextBox></span>
                    </td>
                </tr>
                <tr>
                   <td width="15%" class="detailTitle" style="height: 25px;">价格</td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="bed_price" runat="server" Text="" Width="150px"></asp:TextBox></span>
                    </td>
                     <td width="15%" class="detailTitle" style="height: 25px;">状态<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="bed_status" runat="server" Text="" Width="150px"></asp:TextBox></span>
                    </td>
                </tr>
               <tr>
                   <td width="15%" class="detailTitle" style="height: 25px;">房间号<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="room_id" runat="server" Text="" Width="150px"></asp:TextBox></span>
                    </td>
                     <td width="15%" class="detailTitle" style="height: 25px;">所在楼<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="building_id" runat="server" Text="" Width="150px"></asp:TextBox></span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">备注</td>
                    <td width="35%" class="detailContent" style="height:25px;" colspan="3">
                        <asp:TextBox ID="comment" TextMode="MultiLine" Width="90%" Height="100px" runat="server"></asp:TextBox></td>
                    
                </tr>
                <tr> 
                    <td width="100%" class="detailContent" style="height: 25px" colspan="5">
                        <table align="right">
                            <tr>
                                <td width="20%" class="detailTitle" style="height: 25px" >填写人<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px" ><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="writor" runat="server" Text="" ReadOnly="true"></asp:TextBox>
                                </span></td>
                                <td width="30%" class="detailTitle" style="height: 25px" >登记日期<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px" ><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="register_date" runat="server" Text="" ReadOnly="true"></asp:TextBox>
                                </span></td>
                            </tr>
                        </table>
                    </td>
                </tr>
               
           </table>

        </div>
    </form>
    
</body>
</html>



