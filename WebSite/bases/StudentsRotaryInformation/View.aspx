<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="bases_StudentsRotaryInformation_View" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学员轮转信息</title>
     <link href="../../css/global.css" rel="stylesheet" />
</head>
<body style="background-color: #efebef;">
    <form id="form1" runat="server">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="6" class="detailHead">学员轮转信息</td>
                </tr>
                 <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">姓名<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        
                        <asp:Literal ID="real_name" runat="server"></asp:Literal>
                        
                    </td>
                     <td width="15%" class="detailTitle" style="height: 25px;"></td>
                    <td width="35%" class="detailContent" style="height:25px;"></td>
                </tr>

                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">培训基地<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                       
                        <asp:Literal ID="training_base_name" runat="server"></asp:Literal>
                       
                    </td>
                     <td width="15%" class="detailTitle" style="height: 25px;">专业基地<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <asp:Literal ID="professional_base_name" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">轮转科室<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                        <asp:Literal ID="rotary_dept_name" runat="server"></asp:Literal>
                    </td>
                     <td width="15%" class="detailTitle" style="height: 25px;">指导医师<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;">
                         
                         <asp:Literal ID="instructor" runat="server"></asp:Literal>
                         
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">轮转时间<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;" colspan="3">
                        从<asp:Literal ID="rotary_begin_time" runat="server"></asp:Literal>
                        至<asp:Literal ID="rotary_end_time" runat="server"></asp:Literal>
                       
                    </td>
                    
                </tr>
                <tr>

                    <td width="15%" class="detailTitle" style="height: 25px"></td>
                    <td width="85%" class="detailContent" style="height: 25px" colspan="5">
                        <table>
                            <tr>
                                
                                <td width="15%" class="detailContent" style="height: 25px" ></td>
                                
                                <td width="15%" class="detailTitle" style="height: 25px" >填写人<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px" >
                                    <asp:Literal ID="writor" runat="server"></asp:Literal>
                             </td>
                                <td width="15%" class="detailTitle" style="height: 25px" >登记日期<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px" >
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
