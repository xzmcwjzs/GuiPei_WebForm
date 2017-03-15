<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="managers_StudentsRotaryInformation_List" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学员轮转信息列表</title>
    <script src="../../js/global.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/PageList/PageList.js"></script>
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
    var TrainingBaseCode = "<%=TrainingBaseCode%>";
    var ProfessionalBaseCode = "";

    var StudentsRealName = "<%=StudentsRealName%>";
    var Sex = "<%=Sex%>";
    var MinZu = "<%=MinZu%>";
    var HighEducation = "<%=HighEducation%>";
    var HighSchool = "<%=HighSchool%>";
    var IdentityType = "<%=IdentityType%>";
    var SendUnit = "<%=SendUnit%>";
    var CollaborativeUnit = "<%=CollaborativeUnit%>";
    var TrainingTime = "<%=TrainingTime%>";
    var PlanTrainingTime = "<%=PlanTrainingTime%>";

    var DeptName = "<%=DeptName%>";
    var TeachersRealName = "<%=TeachersRealName%>";
    var RotaryBeginTime = "<%=RotaryBeginTime%>";
    var RotaryEndTime = "<%=RotaryEndTime%>";
    var OutdeptStatus = "<%=OutdeptStatus%>";

    var ProfessionalBaseName = "<%=ProfessionalBaseName%>";
    $(window).load(function () {

        loadPageList(1);
    });

    function loadPageList(pi) {
        $.post("../../ASHX/CommonList/StudentsRotaryList.ashx", {
            "pi": pi, "TrainingBaseCode": TrainingBaseCode, "ProfessionalBaseCode": ProfessionalBaseCode,
            "StudentsRealName": StudentsRealName, "Sex": Sex, "MinZu": MinZu, "HighEducation": HighEducation, "HighSchool": HighSchool,
            "IdentityType": IdentityType, "SendUnit": SendUnit, "CollaborativeUnit": CollaborativeUnit,
            "TrainingTime": TrainingTime, "PlanTrainingTime": PlanTrainingTime,
            "DeptName": DeptName, "TeachersRealName": TeachersRealName, "RotaryBeginTime": RotaryBeginTime,
            "RotaryEndTime": RotaryEndTime, "OutdeptStatus": OutdeptStatus,
            "ProfessionalBaseName": ProfessionalBaseName
        },
          function (data) {
              var jsonArr = eval("(" + data + ")");
              if (jsonArr.data == null) {
                  $("#tbList tr:gt(0)").remove();
              } else {
                  createRows(jsonArr.data, pi);
              }
              createPageBar($("#PageList"), pi, jsonArr.recordCount, jsonArr.pageCount);

          });
    }

    function createRows(jsonArr, pi) {
        var tbL = $("#tbList");
        $("#tbList tr:gt(0)").remove();
        for (i = 0; i < jsonArr.length; i++) {
            var trHTML = "<tr class='listTableContentRow'>";
            trHTML += "<td style='height:25px'>" + jsonArr[i].RealName + "</td>";
            trHTML += "<td>" + jsonArr[i].Sex + "</td>";
            trHTML += "<td>" + jsonArr[i].HighEducation + "</td>";
            trHTML += "<td>" + jsonArr[i].HighMajor + "</td>";
            trHTML += "<td>" + jsonArr[i].ProfessionalBaseName + "</td>";
            trHTML += "<td>" + jsonArr[i].DeptName + "</td>";
            trHTML += "<td>" + jsonArr[i].RotaryBeginTime + "</td>";
            trHTML += "<td>" + jsonArr[i].RotaryEndTime + "</td>";
            trHTML += "<td>" + jsonArr[i].TeachersRealName + "</td>";
            if (jsonArr[i].OutdeptStatus == "0") {
                trHTML += "<td style='color:red'>未出科</td>";
            } else if (jsonArr[i].OutdeptStatus == "1") {
                trHTML += "<td>已出科</td>";
            } else if (jsonArr[i].OutdeptStatus == "2") {
                trHTML += "<td style='color:red'>顺延一期</td>";
            }
            //trHTML += "<td><font color='red'>" + jsonArr[i].outdept_application + "</font></td>";

            //trHTML += "<td><a onclick=\"OpenTopWindow('View.aspx?id=" + jsonArr[i].GP_Students_Rotary_id + "',600,200);\" href='#'><img alt='查看详细资料' src='../../images/imgs/icon_show.gif'/></a></td>";
           // trHTML += "<td><a onclick=\"OutDeptExam('" + jsonArr[i].name + "','" + jsonArr[i].training_base_code + "','" + jsonArr[i].rotary_dept_code + "','" + jsonArr[i].rotary_begin_time + "','" + jsonArr[i].rotary_end_time + "','" + jsonArr[i].GP_Students_Rotary_id + "','" + pi + "','" + jsonArr[i].outdept_application + "');\" href='#'><img alt='出科考核' src='../../images/imgs/icon_add.gif'/></a></td>";
            trHTML += "</tr>";
            tbL.append(trHTML);


        }

        $("#tbList tr:gt(0)").mouseover(function () {
            $(this).removeClass("listTableContentRow");
            $(this).addClass("listTableContentRowMouseOver");
        });

        $("#tbList tr:gt(0)").mouseout(function () {
            $(this).removeClass("listTableContentRowMouseOver");
            $(this).addClass("listTableContentRow");
        });

    }


    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div id="couDiv">
        <table class="listTableHead" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="listTableHeadTR" style="height: 22px;" width="20%">
                    <img   height="16" src="../../images/imgs/Query.gif" width="16" style="vertical-align: middle" />学员轮转信息                    
                </td>
                
            </tr>
        </table>
        <table id="tbList" class="listTable" cellspacing="1" cellpadding="0" width="100%">
            <tr id="tr0" class="listTableTitleRow">
                
                <td>姓名</td>
                <td>性别</td> 
                <td>最高学历</td>
                <td>最高学历专业</td> 
                <td>专业基地</td> 
                <td>轮转科室</td>                                           
                <td>轮转开始时间</td> 
                <td>轮转结束时间</td>
                <td>指导医师</td>
                <td>出科状态</td>
               
                
            </tr>
            
      </table>
       <div id="PageList" style="text-align:center;vertical-align:middle; margin-top:10px;">
       
      </div>

    </div>
       <%--<asp:Literal runat="server" ID="wo"></asp:Literal>--%>
    </form>
   
</body>
    
</html>

