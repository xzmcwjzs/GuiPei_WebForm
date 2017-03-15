﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="bases_StudentsRescuePatientRecords_View" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>抢救病人记录</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/jquery-1.7.2.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
</head>

<body style="background-color: #efebef;">
    <form id="form1" runat="server">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="4" class="detailHead">抢救病人记录</td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">姓名<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;" colspan="3"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="StudentsRealName" runat="server" Text="" ReadOnly="true" Width="150px"></asp:TextBox>
                        <asp:HiddenField ID="StudentsName" runat="server" />
                        </span>
                    </td>
                    
                </tr>

                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">培训基地<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="TrainingBaseName" runat="server" Text="" ReadOnly="true" Width="150px"></asp:TextBox></span>
                        <asp:HiddenField ID="TrainingBaseCode" runat="server" />
                    </td>
                     <td width="15%" class="detailTitle" style="height: 25px;">专业基地<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="ProfessionalBaseName" runat="server" Text="" ReadOnly="true" Width="150px"></asp:TextBox></span>
                        <asp:HiddenField ID="ProfessionalBaseCode" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">轮转科室<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:DropDownList ID="RotaryDept" runat="server" AutoPostBack="True" >
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
                        <asp:TextBox ID="PatientName" runat="server" Text="" Width="150px"></asp:TextBox></span>
                    </td>
                     <td width="15%" class="detailTitle" style="height: 25px;">病历号<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="CaseId" runat="server" Text="" Width="150px"></asp:TextBox></span>
                    </td>
                </tr>
                <tr>
                     <td width="15%" class="detailTitle" style="height: 25px;">疾病名称<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="DiseaseName" runat="server" Text="" Width="150px"></asp:TextBox></span>
                    </td>
                     <td width="15%" class="detailTitle" style="height: 25px;">转归情况<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="Condition" runat="server" Text="" Width="150px"></asp:TextBox></span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">治疗措施<span style="color: #ff0000">*</span></td>
                    <td width="70%" class="detailContent" style="height:25px;" colspan="3">
                        <asp:TextBox ID="RescueMeasure" TextMode="MultiLine" Width="90%" Height="100px" runat="server"></asp:TextBox></td>
                    
                </tr>

                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">备注</td>
                    <td width="70%" class="detailContent" style="height:25px;" colspan="3">
                        <asp:TextBox ID="Comment" TextMode="MultiLine" Width="90%" Height="100px" runat="server"></asp:TextBox></td>
                    
                </tr>
                <tr> 
                    <td width="100%" class="detailContent" style="height: 25px" colspan="6">
                        <table align="right">
                            <tr>
                                 
                                <td width="20%" class="detailTitle" style="height: 25px" >填写人<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px" ><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="Writor" runat="server" Text=""></asp:TextBox>
                                </span></td>
                                <td width="30%" class="detailTitle" style="height: 25px" >登记日期<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px" ><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="RegisterDate" runat="server" Text="" ></asp:TextBox>
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

