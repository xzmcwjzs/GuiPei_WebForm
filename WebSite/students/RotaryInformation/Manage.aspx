<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="students_RotaryInformation_Manage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   
    <title>轮转信息</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/jqueryAutocomplete/jquery.autocomplete.js"></script>
    <link href="../../js/jqueryAutocomplete/jquery.autocomplete.css" rel="stylesheet" />
    <script type="text/javascript">
        var id="<%=id%>";
        $(function () {
            //$(function () {
            //    $.ajax({
            //        cache: false,
            //        type: "get",
            //        url: "ashx/Instructor.ashx",
            //        dataType: "text",
            //        data: {
            //            trainingbaseCode: $("#training_base_code").val(),
            //            professionalbaseCode: $("#professional_base_code").val(),
            //            type: "teachers"
            //        },
            //        success: function (data) {
            //            jsonArr = eval('(' + data + ')');
            //            $("#instructor").autocomplete(jsonArr, {
            //                autoFill: false,
            //                matchContains: true,
            //                width: 200,
            //                max: 10,
            //                matchSubset: true,
            //                matchCase: true,
            //                scroll: true,
            //                formatItem: function (row, i, max) {
            //                    return "[" + row.name + "]" + " " + row.real_name + " " + row.dept_name
            //                },
            //                formatMatch: function (row, i, max) {
            //                    return row.real_name;
            //                },
            //                formatResult: function (row) {
            //                    return row.real_name;
            //                }

            //            }).result(function (event, row, formatted) {
            //                $("#instructor_tag").val(row.name);
            //                });
            //        },
            //        error: function () {
            //            alert("系统繁忙，请联系管理员");
            //        }
            //    });

            //});
           
            if (id == "") {
                $.post("ashx/RotaryTime.ashx", { "name": $("#name").val(), "training_base_code": $("#training_base_code").val(), "professional_base_code": $("#professional_base_code").val() }, function (data) {
                    var dat = eval(data);
                    if (dat == "" || dat == null || dat.length == 0) {
                        return;
                    } else {
                        var register_date_now = $("#register_date").val();
                        var rotary_end_time_last = dat[0].rotary_end_time;
                        if (register_date_now <= rotary_end_time_last) {
                            var days = DateDiff(register_date_now, rotary_end_time_last);
                            if (parseInt(days) > 3) {
                                alert("距上一次轮转结束前三天方可进行登记");
                                window.close();
                            }
                        }
                     }
                });
            } else {
                return;
            }

            
        });
       
            
    </script>
   <%-- <script type="text/javascript">
        $(function () {
            $("#instructor").blur(function () {
                
                $.post("ashx/Instructor2.ashx", {"trainingbaseCode": $("#training_base_code").val(), "professionalbaseCode": $("#professional_base_code").val(), "type": "teachers", "real_name": $("#instructor").val() }, function (data) {
                    var dat = eval(data);
                    if (dat == "" || dat == null || dat.length == 0) {
                        return;
                    } else {
                        var name = dat[0].name;
                        $("#instructor_tag").val(name);
                        //alert($("#instructor_tag").val());
                    }
                });

            });
        });
    </script>--%>
</head>
<body style="background-color: #efebef;">
    <form id="form1" runat="server">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="4" class="detailHead">轮转信息</td>
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
                        <asp:DropDownList ID="rotary_dept_name" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rotary_dept_name_SelectedIndexChanged">
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
                    <td width="15%" class="detailTitle" style="height: 25px;">轮转时间<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;" colspan="3"><span class="detailContent" style="height: 25px">
                        从<asp:TextBox ID="rotary_begin_time" runat="server"  Width="150px" onclick="WdatePicker()"></asp:TextBox>
                        至<asp:TextBox ID="rotary_end_time" runat="server"  Width="150px" onclick="WdatePicker()"></asp:TextBox></span>
                    </td>
                    
                </tr>
                <tr>

                    <td width="15%" class="detailContent" style="height: 25px"></td>
                    <td width="85%" class="detailContent" style="height: 25px" colspan="5">
                        <table>
                            <tr>
                                
                                <td width="5%" class="detailContent" style="height: 25px" ></td>
                                
                                <td width="20%" class="detailTitle" style="height: 25px" >填写人<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px" ><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="writor" runat="server" Text=""></asp:TextBox>
                                </span></td>
                                <td width="20%" class="detailTitle" style="height: 25px" >登记日期<span style="color: #ff0000">*</span></td>
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
                            <a style="padding-left: 2em"></a>
                            <input type="button"  style="cursor: pointer; background-image: url(../images/2.jpg); border: none; height: 21px; width: 88px;" onclick="form1.reset();" />
                           
                         </div>
                    </td>
                </tr>
           </table>

        </div>
    </form>
    
</body>
</html>
