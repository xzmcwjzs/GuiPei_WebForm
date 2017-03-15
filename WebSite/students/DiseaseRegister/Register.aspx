<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="students_DiseaseRegister_Register" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>病种登记</title>
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/global.js"></script>
     <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td width="20%" class="detailTitle" style="height: 25px;">病种名称：<span style="color: #ff0000">*</span></td>
                    <td colspan="3" width="70%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="disease_name" runat="server" Text="" Width="200px"></asp:TextBox>
                        <asp:HiddenField ID="students_name" runat="server" />
                        <asp:HiddenField ID="students_real_name" runat="server" />
                        <asp:HiddenField ID="training_base_code" runat="server" />
                        <asp:HiddenField ID="training_base_name" runat="server" />
                        <asp:HiddenField ID="professional_base_code" runat="server" />
                        <asp:HiddenField ID="professional_base_name" runat="server" />
                        <asp:HiddenField ID="dept_code" runat="server" />
                        <asp:HiddenField ID="dept_name" runat="server" />
                        <asp:HiddenField ID="TeacherId" runat="server" />
                        <asp:HiddenField ID="TeacherName" runat="server" />
                        <asp:HiddenField ID="required_num" runat="server" />
                        <asp:HiddenField ID="master_degree" runat="server" />
                        <asp:HiddenField ID="writor" runat="server" />
                        <asp:HiddenField ID="register_date" runat="server" />
                        </span>
                    </td>
                 </tr>
                 <tr>
                    <td width="20%" class="detailTitle" style="height: 25px;">病人姓名：<span style="color: #ff0000">*</span></td>
                    <td width="30%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="patient_name" runat="server" Text="" Width="150px"></asp:TextBox>
                        </span>
                    </td>
                     <td width="20%" class="detailTitle" style="height: 25px;">病历号：<span style="color: #ff0000">*</span></td>
                    <td width="30%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="case_num" runat="server" Text=""  Width="150px"></asp:TextBox>
                        
                        </span>
                    </td>
                 </tr>
                
                <tr>
                    <td width="20%" class="detailTitle" style="height: 25px;">主要诊断：<span style="color: #ff0000">*</span></td>
                    <td colspan="3" width="70%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="main_diagnosis" runat="server" Text="" TextMode="MultiLine" Width="350px" Height="80px"></asp:TextBox>
                        </span>
                    </td>
                 </tr>
                <tr>
                    <td width="20%" class="detailTitle" style="height: 25px;">次要诊断：</td>
                    <td colspan="3" width="70%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="secondary_diagnosis" runat="server" Text="" TextMode="MultiLine" Width="350px" Height="80px"></asp:TextBox>
                        </span>
                    </td>
                 </tr>
                <tr>
                    <td width="20%" class="detailTitle" style="height: 25px;">是否主管：<span style="color: #ff0000">*</span></td>
                    <td width="30%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:RadioButtonList ID="is_charge" runat="server" CellPadding="1" CellSpacing="1" RepeatDirection="Horizontal">
                            <asp:ListItem Text="是" Value="是" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="否" Value="否"></asp:ListItem>
                        </asp:RadioButtonList>
                       </span>
                    </td>
                    <td width="20%" class="detailTitle" style="height: 25px;">是否抢救：<span style="color: #ff0000">*</span></td>
                    <td width="30%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                       <asp:RadioButtonList ID="is_rescue" runat="server" CellPadding="1" CellSpacing="1" RepeatDirection="Horizontal">
                            <asp:ListItem Text="是" Value="是" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="否" Value="否"></asp:ListItem>
                        </asp:RadioButtonList>
                        </span>
                    </td>
                 </tr>
               
                <tr>
                    <td width="20%" class="detailTitle" style="height: 25px;">治疗措施：<span style="color: #ff0000">*</span></td>
                    <td colspan="3" width="70%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="cure_measure" runat="server" Text="" TextMode="MultiLine" Width="350px" Height="80px"></asp:TextBox>
                        </span>
                    </td>
                 </tr>
                <tr>
                    <td width="20%" class="detailTitle" style="height: 25px;">出诊日期：<span style="color: #ff0000">*</span></td>
                    <td  width="30%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="visit_date" runat="server" Text="" Width="150px" onclick="WdatePicker()"></asp:TextBox>
                        </span>
                    </td>
                    <td width="20%" class="detailTitle" style="height: 25px;">转归情况：</td>
                    <td  width="30%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="condition" runat="server" Text="" Width="150px" ></asp:TextBox>
                        </span>
                    </td>
                 </tr>
                <tr>
                    <td width="20%" class="detailTitle" style="height: 25px;">备注：</td>
                    <td colspan="3" width="70%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="comment" runat="server" Text="" TextMode="MultiLine" Width="350px" Height="80px"></asp:TextBox>
                        
                        </span>
                    </td>
                 </tr>
                <tr id="last">
                    <td colspan="8" style="height: 25px; border-left: 1px solid white; border-right: 1px solid white; border-bottom: 1px solid white">
                        <div style="text-align: center; margin-top: 8px;">
                            <asp:Button ID="save" runat="server" Text="" style="cursor: pointer; background-image: url(../images/1.jpg); border: none; height: 21px; width: 88px;" OnClick="save_Click" />
                            <%--<a style="padding-left: 2em"></a>
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

