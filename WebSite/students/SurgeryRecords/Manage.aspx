  <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="students_SurgeryRecords_Manage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>手术记录</title>
    <script src="../../js/global.js"></script>
    <script src="../../js/jquery-1.7.2.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../../js/jqueryAutocomplete/jquery.autocomplete.css" rel="stylesheet" />
    <script src="../../js/jqueryAutocomplete/jquery.autocomplete.js"></script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                cache: false,
                type: "get",
                url: "ashx/SurgeryName.ashx",
                dataType: "text",
                success: function (data) {
                    jsonArr = eval('(' + data + ')');
                    $("#SurgeryName").autocomplete(jsonArr, {
                        autoFill: false,
                        matchContains: true,
                        width: 200,
                        max: 10,
                        matchSubset: true,
                        matchCase: true,
                        scroll: true,
                        formatItem: function (row, i, max) {
                            return row.SurgeryName;
                        },
                        formatMatch: function (row, i, max) {
                            return row.SurgeryName;
                        },
                        formatResult: function (row) {
                            return row.SurgeryName;
                        }

                    });

                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }
            });

        });
     
        $(function () {
            
            $("#SurgeryIsStop").click(function () {
                
                if ($("input[name='SurgeryIsStop']:checked").val() == "是") {
                    $("#StopReason").removeAttr("disabled");
                    return;
                } else {
                    $("#StopReason").attr("disabled", true);
                    $("#StopReason").val("");
                }
                
            });
        });
    </script>
</head>

<body style="background-color: #efebef;">
    <form id="form1" runat="server">
        <div align="center">
            <table width="100%" border="0" style="border-collapse: collapse;margin:0 auto" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="4" class="detailHead">手术记录</td>
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
                     <td colspan="4" class="detailContent" style="height:25px;text-align:center">
                        <table style="margin:0 auto;height:25px" align="center">
                            <tr>
                                <td width="15%" class="detailTitle" style="height: 25px;">手术名称<span style="color: #ff0000">*</span></td>
                                <td width="15%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="SurgeryName" runat="server" Text="" Width="100px"></asp:TextBox></span>
                                </td>
                                <td width="15%" class="detailTitle" style="height: 25px;">术中职务<span style="color: #ff0000">*</span></td>
                                <td width="15%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="IntraoperativePosition" runat="server" Text="" Width="100px"></asp:TextBox></span>
                                </td>
                                <td width="15%" class="detailTitle" style="height: 25px;">手术间号</td>
                                <td width="15%" class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="RoomId" runat="server" Text="" Width="100px"></asp:TextBox></span>
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">主要诊断<span style="color: #ff0000">*</span></td>
                    <td width="70%" class="detailContent" style="height:25px;" colspan="3">
                        <asp:TextBox ID="MainDiagnosis" TextMode="MultiLine" Width="90%" Height="100px" runat="server"></asp:TextBox></td>
                    
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">次要诊断</td>
                    <td width="70%" class="detailContent" style="height:25px;" colspan="3">
                        <asp:TextBox ID="SecondaryDiagnosis" TextMode="MultiLine" Width="90%" Height="100px" runat="server"></asp:TextBox></td>
                    
                </tr>
                <tr>
                    <td colspan="4" class="detailContent" style="height:25px;text-align:center">
                        <table style="margin:0 auto;height:25px" align="center">
                            <tr>
                                <td class="detailTitle" style="height: 25px;width:100px">急诊<span style="color: #ff0000">*</span></td>
                                <td class="detailContent" style="height: 25px;width:100px">
                                <asp:RadioButtonList ID="Emergency" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="是" Value="是" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="否" Value="否"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td class="detailTitle" style="height: 25px;width:100px">手术日期<span style="color: #ff0000">*</span></td>
                                <td  class="detailContent" style="height: 25px;width:100px"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="SurgeryDate" runat="server" Text="" Width="100px" onclick="WdatePicker()"></asp:TextBox></span>
                                </td>
                                <td  class="detailTitle" style="height: 25px;width:100px">手术规模</td>
                                <td  class="detailContent" style="height: 25px;width:100px"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="SurgeryScale" runat="server" Text="" Width="100px"></asp:TextBox></span>
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>
                <tr>
                   <td colspan="4" class="detailContent" style="height:25px;text-align:center">
                        <table style="margin:0 auto;height:25px" align="center">
                            <tr>
                                <td class="detailTitle" style="height: 25px;width:100px">主刀医师<span style="color: #ff0000">*</span></td>
                                <td class="detailContent" style="height: 25px;width:100px"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="DoctorInCharge" runat="server" Text="" Width="100px"></asp:TextBox></span>
                                </td>
                                <td  class="detailTitle" style="height: 25px;width:100px">助理医师</td>
                                <td class="detailContent" style="height: 25px;width:100px"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="Assistant" runat="server" Text="" Width="100px"></asp:TextBox></span>
                                </td>
                                <td class="detailTitle" style="height: 25px;width:100px">护士</td>
                                <td  class="detailContent" style="height: 25px;width:100px"><span class="detailContent" style="height: 25px">
                                    <asp:TextBox ID="Nurse" runat="server" Text="" Width="100px"></asp:TextBox></span>
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">麻醉方式</td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="AnesthesiaMethod" runat="server" Text="" Width="150px"></asp:TextBox></span>
                    </td>
                     <td width="15%" class="detailTitle" style="height: 25px;">麻醉师</td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="Anesthetist" runat="server" Text="" Width="150px"></asp:TextBox></span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">手术停台<span style="color: #ff0000">*</span></td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:RadioButtonList ID="SurgeryIsStop" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="是" Value="是"></asp:ListItem>
                            <asp:ListItem Text="否" Value="否" Selected="True"></asp:ListItem>
                        </asp:RadioButtonList></span>
                    </td>
                     <td width="15%" class="detailTitle" style="height: 25px;">停台原因</td>
                    <td width="35%" class="detailContent" style="height:25px;"><span class="detailContent" style="height: 25px">
                        <asp:TextBox ID="StopReason" runat="server" Text=""  Width="150px" Enabled="false"></asp:TextBox></span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 25px;">备注</td>
                    <td width="70%" class="detailContent" style="height:25px;" colspan="3">
                        <asp:TextBox ID="Comment" TextMode="MultiLine" Width="90%" Height="100px" runat="server"></asp:TextBox></td>
                    
                </tr>
                <tr>
                    <td width="100%" class="detailContent" style="height: 25px" colspan="5">
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
