<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="students_DiseaseRegister_Manage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>病种登记</title>
    <script type="text/javascript" src="../../js/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="../../js/global.js"></script>
     <link href="../../css/global.css" rel="stylesheet" />
    
    <script type="text/javascript">
        
        $(function () {
        var students_name = $("#name").val();
        var students_real_name = $("#real_name").val();
        var training_base_code = $("#TrainingBaseCode").val();
        var training_base_name = $("#training_base_name").val();
        var professional_base_name = $("#professional_base_name").val();
        var professional_base_code = $("#ProfessionalBaseCode").val();
        
        var writor = $("#writor").val();
        var register_date = $("#register_date").val();

        $("#Teacher").change(function () {
            var dept_code = $("#RotaryDept").val();
            var dept_name = $("#RotaryDept option:selected").text();
            var TeacherId = $("#Teacher option:selected").val();
            var TeacherName = $("#Teacher option:selected").text();
                $("#disease tr:gt(0)").remove();
                if ($("#RotaryDept").val() != 0) {
                    var rotary_dept_code = $("#RotaryDept").val();
                    $.post("ashx/DiseaseRegister.ashx", { "rotary_dept_code": rotary_dept_code }, function (data) {
                        var jsonArr = eval("(" + data + ")");
                        if (jsonArr.data == null) {
                           
                        } else {
                            var k = 1;
                            for (i = 0; i < jsonArr.data.length; i++) {

                                var trHTML = "<tr class='listTableContentRow'>";
                                if (jsonArr.data[i].disease_code == null || jsonArr.data[i].disease_code == "") {

                                } else {
                                    trHTML += "<td align='center'>" + k + "</td>";
                                    trHTML += "<td align='center'>" + jsonArr.data[i].disease_name + "</td>";
                                    if (jsonArr.data[i].required_num == null || jsonArr.data[i].required_num == "") {
                                        trHTML += "<td align='center'>" + '无' + "</td>";
                                    } else {
                                        trHTML += "<td align='center'>" + jsonArr.data[i].required_num + "</td>";
                                    }
                                    trHTML += "<td align='center'>" + jsonArr.data[i].master_degree + "</td>";
                                    trHTML += "<td align='center'><font color='#0063ff'>" +
                                        "<a style='text-decoration:none;' " +
                                        "onclick=\"OpenTopWindow('Register.aspx?students_name=" + students_name + "" +
                                        "&students_real_name=" + students_real_name + "" +
                                        "&training_base_code=" + training_base_code + ""+
                                        "&training_base_name=" + training_base_name + "" +
                                        "&professional_base_code=" + professional_base_code + "" +
                                        "&professional_base_name=" + professional_base_name + "" +
                                        "&dept_code=" + dept_code + "" +
                                        "&dept_name=" + dept_name + "" +
                                        "&TeacherId=" + TeacherId + "" +
                                        "&TeacherName=" + TeacherName + "" +
                                        "&writor=" + writor + "" +
                                        "&register_date=" + register_date + "" +
                                        "&disease_name=" + jsonArr.data[i].disease_name + "" +
                                        "&required_num=" + jsonArr.data[i].required_num + "" +
                                        "&master_degree="+jsonArr.data[i].master_degree+"',500,550);\" " +
                                        "href='#'>登记</a></font></td>";
                                    k += 1;
                                }
                                trHTML += "</tr>";
                                $("#disease").append(trHTML);
                            }
                            $("#disease tr:gt(0)").mouseover(function () {
                                $(this).removeClass("listTableContentRow");
                                $(this).addClass("listTableContentRowMouseOver");
                            });

                            $("#disease tr:gt(0)").mouseout(function () {
                                $(this).removeClass("listTableContentRowMouseOver");
                                $(this).addClass("listTableContentRow");
                            });
                            //$("#disease").append("<tr><td colspan='5'align='left'><input type='button' value='新增病种登记' id='addDisease' name='addDisease' height='25'></td></tr>");
                        }
                        $("#disease").append("<tr><td colspan='5'align='left'><input onclick=\"OpenTopWindow('Register.aspx?students_name=" + students_name + "" +
                            "&students_real_name=" + students_real_name + "" +
                                        "&training_base_code=" + training_base_code + "" +
                                        "&training_base_name=" + training_base_name + "" +
                                        "&professional_base_code=" + professional_base_code + "" +
                                        "&professional_base_name=" + professional_base_name + "" +
                                        "&dept_code=" + dept_code + "" +
                                        "&dept_name=" + dept_name + "" +
                                        "&TeacherId=" + TeacherId + "" +
                                        "&TeacherName=" + TeacherName + "" +
                                        "&writor=" + writor + "" +
                                        "&register_date=" + register_date + "" +
                                        "&disease_name=" + "" + "" +
                                        "&required_num=" + "" + "" +
                                        "&master_degree=" + "" + "',500,550);\" " +
                            " type='button' value='新增病种登记' id='addDisease' name='addDisease' height='25'></td></tr>");

                    });
                    
                }
                
        });
        
        });

    </script>
</head>
<body>
     <form id="form1" runat="server">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse; text-align: center;width: 100%;margin:0 auto" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="8" class="detailHead">病种登记</td>
                </tr>
                <tr>
                    <td width="3%" class="detailTitle" style="height: 25px;">姓名<span style="color: #ff0000">*</span></td>
                    <td width="6%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="real_name" runat="server" Text="" ReadOnly="true" Width="150px"></asp:TextBox>
                        <asp:HiddenField ID="name" runat="server" />
                        </span>
                    </td>

                    <td width="12%" class="detailTitle" style="height: 25px;">培训基地<span style="color: #ff0000">*</span></td>
                    <td width="15%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="training_base_name" runat="server" Text="" ReadOnly="true" Width="150px"></asp:TextBox></span>
                        <asp:HiddenField ID="TrainingBaseCode" runat="server" />
                    </td>
                    <td width="12%" class="detailTitle" style="height: 25px;">专业基地<span style="color: #ff0000">*</span></td>
                    <td width="15%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="professional_base_name" runat="server" Text="" ReadOnly="true" Width="150px"></asp:TextBox></span>
                        <asp:HiddenField ID="ProfessionalBaseCode" runat="server" />
                    </td>
                    
                </tr>
                <tr>
                    <td colspan="6" style="width: 100%">
                        <table style="width: 100%;margin:0 auto">
                            <tr>
                                <td width="25%" class="detailTitle" style="height: 25px;">轮转科室<span style="color: #ff0000">*</span></td>
                                <td width="25%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <asp:DropDownList ID="RotaryDept" runat="server" OnSelectedIndexChanged="RotaryDept_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Value="0">==请选择==</asp:ListItem>
                                    </asp:DropDownList>
                                </span>
                                </td>
                                <td width="25%" class="detailTitle" style="height: 25px;">指导医师<span style="color: #ff0000">*</span></td>
                                <td width="25%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">

                                    <asp:DropDownList ID="Teacher" runat="server">
                                        <asp:ListItem Value="0">==请选择==</asp:ListItem>
                                    </asp:DropDownList>
                                </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>

                    <td colspan="6">
                        <table width="100%" class="listTable" id="disease" style="border: 1px;border-style: solid">
                            <tr class="listTableTitleRow">
                                <td width="10%" style="height: 25px;" align="center">序号</td>
                                <td width="60%" style="height: 25px;" align="center">病种名称</td>
                                <td width="10%"  style="height: 25px;"align="center">要求例数</td>
                                <td width="10%"  style="height: 25px;" align="center">掌握程度</td>
                                <td width="10%"  style="height: 25px;" align="center">登记</td>
                            </tr>
                            <tr>
                                <td colspan="5" align="center" bgcolor="#f1f3f5">请选择轮转科室进行病种登记</td>
                            </tr>
                            

                        </table>

                    </td>
                </tr>
               
                <tr>
                     
                    <td width="100%" class="detailContent" style="height: 25px;" colspan="7">
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
                <%--<tr id="last">
                    <td colspan="8" style="height: 25px; border-left: 1px solid white; border-right: 1px solid white; border-bottom: 1px solid white">
                        <div style="text-align: center; margin-top: 8px;">
                            <asp:Button ID="save" runat="server" Text="" style="cursor: pointer; background-image: url(../images/1.jpg); border: none; height: 21px; width: 88px;" />
                            <a style="padding-left: 2em"></a>
                            <input type="button"  style="cursor: pointer; background-image: url(../images/2.jpg); border: none; height: 21px; width: 88px;" onclick="form1.reset();" />
                           
                         </div>
                    </td>
                </tr>--%>
           </table>

        </div>
    </form>
    
</body>
</html>
