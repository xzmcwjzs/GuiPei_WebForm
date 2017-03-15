<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="bases_AppointInformation_View" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>预约信息填写</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/jqueryAutocomplete/jquery.autocomplete.js"></script>
    <link href="../../js/jqueryAutocomplete/jquery.autocomplete.css" rel="stylesheet" />
    <script type="text/javascript">

        $(function () {
            $("#each_class_num").focus(function () {
                var reg = /^\+?[1-9]\d*$/;

                var totalnum = $("#total_num").val();
                var classnum = $("#class_num").val();
                if (classnum == "0" || !reg.test(totalnum) || !reg.test(classnum) || parseInt(classnum) > parseInt(totalnum)) {
                    alert("输入的数值不合法");
                    return;
                } else {
                    $("#each_class_num").val(Math.round(parseInt(totalnum) / parseInt(classnum)));
                }

            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="7" class="detailHead">预约信息表
                    </td>
                </tr>

                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">指导医师：<span style="color: #ff0000">*</span></td>
                    <td width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="teachers_real_name" runat="server" Width="100px"></asp:TextBox>
                        <asp:HiddenField ID="teachers_name" runat="server" />
                        <asp:HiddenField ID="training_base_code" runat="server" />
                        <asp:HiddenField ID="training_base_name" runat="server" />
                        <asp:HiddenField ID="professional_base_code" runat="server" />
                        <asp:HiddenField ID="professional_base_name" runat="server" />
                    </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px;">所在科室：<span style="color: #ff0000">*</span></td>
                    <td width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="dept_name" runat="server" Width="100px"></asp:TextBox>
                        <asp:HiddenField ID="dept_code" runat="server" />
                    </span>
                    </td>
                    <td width="10%" class="detailContent" style="height: 25px;"></td>
                    <td width="20%" class="detailContent" style="height: 25px;"></td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">预约时间：<span style="color: #ff0000">*</span></td>
                    <td colspan="5" width="20%" class="detailContent" style="height: 25px;">
                        从<asp:TextBox ID="appoint_begin_time" runat="server" Width="180px" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                    到<asp:TextBox ID="appoint_end_time" runat="server" Width="180px" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                   
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">培训总人数：<span style="color: #ff0000">*</span></td>
                    <td width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="total_num" runat="server" Width="100px"></asp:TextBox>

                    </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px;">组数：</td>
                    <td width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="class_num" runat="server" Width="100px"></asp:TextBox>组
                    </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 25px;">每组人数：</td>
                    <td width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="each_class_num" runat="server" Width="100px" onfocus="this.blur()"></asp:TextBox>
                    </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">培训内容：<span style="color: #ff0000">*</span></td>
                    <td colspan="5" width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="training_content" runat="server" Width="95%" TextMode="MultiLine" Height="80px"></asp:TextBox>
                    </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 25px;">备注：</td>
                    <td colspan="5" width="20%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="comment" runat="server" Width="95%" TextMode="MultiLine" Height="80px"></asp:TextBox>
                    </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" class="detailContent" style="text-align: right">
                        <table align="right">
                            <tr> 
                                <td width="70px" class="detailTitle" style="height: 25px;">登记日期：<span style="color: #ff0000">*</span></td>
                                <td width="100px" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="register_date" runat="server" Width="100px"></asp:TextBox>
                                </span>
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

