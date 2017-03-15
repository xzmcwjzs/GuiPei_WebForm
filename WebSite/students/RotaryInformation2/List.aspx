<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="students_RotaryInformation2_List" %>

<%@ Import Namespace="Common" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Model" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>轮转信息</title>
    <script src="../../js/jquery-1.7.2.js"></script> 
    <script src="../../js/PageList/PageList.js"></script>
    <script src="../../js/global.js"></script>
    <link href="../../css/global.css" rel="stylesheet" /> 
   
    <style type="text/css">
    .button
    {
	    width:200px; height:20px; border: #002D96 1px solid; padding: 2px; filter: progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr=#FFFFFF, EndColorStr=#9DBCEA); cursor: pointer; color: black;
    }
    .tbmover{
		border: #336699 1px solid;
		padding-right: 2px; 
		padding-left: 2px; 
		cursor: pointer;
	}
	.tbmout{
		padding-right: 3px; padding-left: 3px;
		
	}
    </style> 
    <script type="text/javascript">
        var Name = "<%:Name%>";
        var RealName = "<%:RealName%>";
        var TrainingBaseCode = "<%:TrainingBaseCode%>";
        var TrainingBaseName = "<%:TrainingBaseName%>";
        var NowDate;
        var nowDate;
       
        $(function() {
            $("#Name").val(Name);
            $("#RealName").val(RealName);
            $("#TrainingBaseCode").val(TrainingBaseCode);
            $("#TrainingBaseName").val(TrainingBaseName);
            NowDate = new Date();
            nowDate = new Date(NowDate.getFullYear() + "/" + (NowDate.getMonth() + 1) + "/" + NowDate.getDate());

            loadRotaryInfo(Name, TrainingBaseCode);
            if ($("#tbList tr:gt(0)").length > 0) {
                $("#GenerateRotaryInformation").css("display", "none");
            }
        });

        function generateRotaryInformation() {
            var ProfessionalBaseCode, TrainingTime;
            var k="" ;
            
            $.ajax({
                cache: false,
                async: false,
                type: "post",
                url: "ashx/GetPersonalInfo.ashx",
                dataType: "text",
                data: {Name:Name,TrainingBaseCode:TrainingBaseCode},
                success: function (data) {
                    if (data == "") {
                        alert("请完善个人信息");
                        return;
                    } else {
                        var jsonArr = eval("(" + data + ")");

                        ProfessionalBaseCode = jsonArr[0].ProfessionalBaseCode;
                        TrainingTime = jsonArr[0].TrainingTime;

                    }
                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }
            });

            $.ajax({
                cache: false,
                async: false,
                type: "post",
                url: "ashx/GetRotaryInfo.ashx",
                dataType: "text",
                data: {TrainingBaseCode: TrainingBaseCode,ProfessionalBaseCode:ProfessionalBaseCode,TrainingTime:TrainingTime },
                success: function (data) {
                    if (data == "") {
                        alert("管理员尚未进行轮转排班");
                        return;
                    } else {
                        var jsonArr = eval("(" + data + ")");
                        for (var i = 0; i < jsonArr.length; i++) {
                            var arr = new Array();
                            var nameList = jsonArr[i].Tag1;
                            arr = nameList.split("}");
                            for (var j = 0; j < arr.length; j++) {
                                if (arr[j] == Name) {
                                    k = i;
                                }
                            }
                        }
                        if (k == "") {
                            alert("管理员尚未进行学员分配");
                            return;
                        } else {
                            $.ajax({
                                cache: false,
                                async: false,
                                type: "post",
                                url: "ashx/InsertRotary.ashx",
                                dataType: "text",
                                data: {
                                    name: Name, realName: RealName, trainingBaseCode: jsonArr[k].TrainingBaseCode, trainingBaseName: jsonArr[k].TrainingBaseName,
                                    professionalBaseCode: jsonArr[k].ProfessionalBaseCode, professionalBaseName: jsonArr[k].ProfessionalBaseName, deptCodeList: jsonArr[k].DeptCodeList,
                                    deptNameList: jsonArr[k].DeptNameList, beginTimeList: jsonArr[k].BeginTimeList, endTimeList: jsonArr[k].EndTimeList, daysList: jsonArr[k].DaysList,
                                    trainingTime:jsonArr[k].TrainingTime,outdeptStatus:"0",outdeptApplication:"0",questionnaireStatus:"0",length:jsonArr.length
                                },
                                success: function (data) {
                                    alert(data);
                                    loadRotaryInfo(Name,TrainingBaseCode);
                                },
                                error: function () {
                                    alert("系统繁忙，请联系管理员");
                                }
                            });

                        }
                        
                    }
                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }
            });
        }

        function loadRotaryInfo(Name, TrainingBaseCode) {
            $.ajax({
                cache: false,
                async: false,
                type: "get",
                url: "ashx/GetRotaryInfo2.ashx",
                dataType: "text",
                data: { Name: Name, TrainingBaseCode: TrainingBaseCode },
                success: function (data) {
                    if (data == "") {
                        return;
                    } else {
                        var tbL = $("#tbList");
                        var jsonArr=eval("("+data+")");
                        $("#tbList tr:gt(0)").remove();
                       
                        for (i = 0; i < jsonArr.length; i++) {
                            var trHTML = "<tr class='listTableContentRow'>";
                            trHTML += "<td style='height:25px'>" + jsonArr[i].ProfessionalBaseName + "</td>";
                            trHTML += "<td style='width:20%'>" + jsonArr[i].DeptName + "</td>";
                            trHTML += "<td>" + jsonArr[i].RotaryBeginTime + "</td>";
                            trHTML += "<td>" + jsonArr[i].RotaryEndTime + "</td>";
                            trHTML += "<td>" + jsonArr[i].TeachersRealName + "</td>";
                            if (nowDate >= new Date(jsonArr[i].RotaryBeginTime.replace(/-/g, "/")) && nowDate <= new Date(jsonArr[i].RotaryEndTime.replace(/-/g, "/"))) {
                                trHTML += "<td style='color:red'>正在轮转</td>";
                                if (jsonArr[i].OutdeptStatus == "0") {
                                    trHTML += "<td style='color:red'>未出科</td>";
                                } else if (jsonArr[i].OutdeptStatus == "1") {
                                    trHTML += "<td>已出科</td>";
                                } else if (jsonArr[i].OutdeptStatus == "2") {
                                    trHTML += "<td style='color:red'>顺延一期</td>";
                                }
                                if (jsonArr[i].OutdeptApplication == "0") {
                                    trHTML += "<td><a style='color:red;text-decoration:none' onclick=\"application('" + jsonArr[i].Id + "');\" href='#'><img src='../../images/imgs/icon_edit.gif'/>申请出科考核</a></td>";
                                } else if (jsonArr[i].OutdeptApplication == "1") {
                                    trHTML += "<td style='color:green'>已申请出科考核</td>";
                                }
                                if (jsonArr[i].QuestionnaireStatus == "0") {
                                    trHTML += "<td><a style='color:red;text-decoration:none' onclick=\"OpenTopWindow('Questionnaire.aspx?id=" + jsonArr[i].Id + "',900,650);\" href='#'><img src='../../images/imgs/icon_add.gif'/>填写问卷</a></td>";
                                } else if (jsonArr[i].QuestionnaireStatus == "1") {
                                    trHTML += "<td style='color:green'>已填写</td>";
                                }

                            } else if (nowDate < new Date(jsonArr[i].RotaryBeginTime.replace(/-/g, "/"))) {
                                trHTML += "<td>未轮转</td>";
                                if (jsonArr[i].OutdeptStatus == "0") {
                                    trHTML += "<td style='color:red'>未出科</td>";
                                } else if (jsonArr[i].OutdeptStatus == "1") {
                                    trHTML += "<td>已出科</td>";
                                } else if (jsonArr[i].OutdeptStatus == "2") {
                                    trHTML += "<td style='color:red'>顺延一期</td>";
                                }
                               trHTML += "<td>不能申请出科考核</td>";
                               trHTML += "<td>不能填写问卷</td>";
                                
                            } else if (nowDate > new Date(jsonArr[i].RotaryEndTime.replace(/-/g, "/"))) {
                                trHTML += "<td style='color:green'>已轮转</td>";
                                if (jsonArr[i].OutdeptStatus == "0") {
                                    trHTML += "<td style='color:red'>未出科</td>";
                                } else if (jsonArr[i].OutdeptStatus == "1") {
                                    trHTML += "<td>已出科</td>";
                                } else if (jsonArr[i].OutdeptStatus == "2") {
                                    trHTML += "<td style='color:red'>顺延一期</td>";
                                }

                                if (jsonArr[i].OutdeptApplication == "0") {
                                    trHTML += "<td><a style='color:red;text-decoration:none' onclick=\"application('" + jsonArr[i].Id + "');\" href='#'><img src='../../images/imgs/icon_edit.gif'/>申请出科考核</a></td>";
                                } else if (jsonArr[i].OutdeptApplication == "1") {
                                    trHTML += "<td style='color:green'>已申请出科考核</td>";
                                }
                                if (jsonArr[i].QuestionnaireStatus == "0") {
                                    trHTML += "<td><a style='color:red;text-decoration:none' onclick=\"OpenTopWindow('Questionnaire.aspx?Id=" + jsonArr[i].Id + "',900,650);\" href='#'><img src='../../images/imgs/icon_add.gif'/>填写问卷</a></td>";
                                } else if (jsonArr[i].QuestionnaireStatus == "1") {
                                    trHTML += "<td style='color:green'>已填写</td>";
                                }
                            }
                            trHTML += "</tr>";
                            tbL.append(trHTML);
                        }
                        $("#GenerateRotaryInformation").css("display", "none");
                        $("#tbList tr:gt(0)").mouseover(function () {
                            $(this).removeClass("listTableContentRow");
                            $(this).addClass("listTableContentRowMouseOver");
                        });

                        $("#tbList tr:gt(0)").mouseout(function () {
                            $(this).removeClass("listTableContentRowMouseOver");
                            $(this).addClass("listTableContentRow");
                        });
                    }
                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }
            });
        }

        function ToWord() {
            $.ajax({
                cache: false,
                type: "post",
                url: "ashx/AsposeWord.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                data:{Name:$("#Name").val(),RealName:$("#RealName").val(),TrainingBaseCode:$("#TrainingBaseCode").val(),TrainingBaseName:$("#TrainingBaseName").val()},
                success: function (data) {
                    var filename = data;
                    window.location.href = "/RotaryWord/" + filename;
                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }

            });
        }

        function application(id) {

            $.post("ashx/OutDeptApplication.ashx", { "Id": id }, function (data) {
                alert(data);
                loadRotaryInfo(Name, TrainingBaseCode)
            });
        }
    </script>  
</head>
<body style="text-align:center;">
    <form id="form1" runat="server">
     
    <div id="generateList" style="margin:0 auto;text-align:center;">
        <table style="margin: 0 auto">
            <tr>
                <td class='tbmout' onmouseover="this.className='tbmover'" onmouseout="this.className='tbmout'" onclick="ToWord();">
                    <img src="../../images/imgs/export1.png" alt="" height="16" align="absmiddle" />导出轮转信息</td>
                
                <td class="detailTitle" style="height: 25px;">姓名</td>
                <td class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                    <input type="text" id="RealName" name="RealName" readonly="readonly"/></span>
                    <input type="hidden" id="Name" name="Name" />
                </td>
                <td class="detailTitle" style="height: 25px;">培训基地</td>
                <td class="detailContent" style="height: 25px;"><span class="detailContent" style="height: 25px">
                    <input type="text" id="TrainingBaseName" name="TrainingBaseName" readonly="readonly"/></span>
                    <input type="hidden" id="TrainingBaseCode" name="TrainingBaseCode" />
                </td>
                 <td  style="height: 25px;"><span style="height: 25px">
                    <input type="button" style="display:block;" id="GenerateRotaryInformation" name="GenerateRotaryInformation"value="生成轮转信息" onclick="generateRotaryInformation()"/></span>
                </td>
            </tr>
        </table>
    </div>

    <div id="listDiv">
        <table id="tbList" class="listTable" cellspacing="1" cellpadding="0" width="100%">
            <tr id="tr0" class="listTableTitleRow">
                
                <td>专业基地</td> 
                <td>轮转科室</td>                                           
                <td>轮转开始时间</td> 
                <td>轮转结束时间</td>
                <td>指导医师</td>
                <td>状态</td>
                <td>出科情况</td>
                <td>申请</td>
                <td>问卷</td>
                
            </tr>
            
      </table>
       <%--<div id="PageList" style="text-align:center;vertical-align:middle; margin-top:10px;"></div>--%>

    </div>
      
    </form>
   
</body>
    
</html>
