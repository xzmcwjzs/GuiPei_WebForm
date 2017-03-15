<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="bases_AppointInformation_List" %>
<%@ Import Namespace="Common" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Model" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学员基本信息列表</title>
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
    var BasesName = "<%=BasesName%>";
    var TrainingBaseCode = "<%=TrainingBaseCode%>";
    var ProfessionalBaseCode = "<%=ProfessionalBaseCode%>";


    var AppointBeginTime = "<%=AppointBeginTime%>";
    var AppointEndTime = "<%=AppointEndTime%>";
    var IsPass = "<%=IsPass%>";

    $(window).load(function () {

        loadPageList(1);
    });

    function loadPageList(pi) {

        $.post("ashx/List.ashx", {
            "pi": pi, "BasesName": BasesName, "TrainingBaseCode": TrainingBaseCode, "ProfessionalBaseCode": ProfessionalBaseCode,
            "AppointBeginTime": AppointBeginTime, "AppointEndTime": AppointEndTime, "IsPass": IsPass
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

    function createRows(jsonArr,pi) {
        var tbL = $("#tbList");
        $("#tbList tr:gt(0)").remove();
        for (i = 0; i < jsonArr.length; i++) {
            
            var trHTML = "<tr class='listTableContentRow'>";
            trHTML += "<td style='height:25px'>" + jsonArr[i].teachers_real_name + "</td>";
            trHTML += "<td>" + jsonArr[i].professional_base_name + "</td>";
            trHTML += "<td>" + jsonArr[i].appoint_begin_time + "</td>";
            trHTML += "<td>" + jsonArr[i].appoint_end_time + "</td>";
            trHTML += "<td>" + jsonArr[i].total_num + "</td>";
            if (jsonArr[i].FileName == "" || jsonArr[i].FileName == null) {
                trHTML += "<td>没有上传文件</td>";
            } else {
                trHTML += "<td style='color:red;'>" + jsonArr[i].IsReceive + "</td>";
            }
            
            trHTML += "<td><font color='red'>" + jsonArr[i].is_pass + "</font></td>";
            trHTML += "<td><a onclick=\"OpenTopWindow('Manage.aspx?id=" + jsonArr[i].id + "&tag=view',770,330);\" href='#'><img alt='查看详细资料' src='../../images/imgs/icon_show.gif'/></a></td>";
            //trHTML += "<td><a onclick=\"OpenTopWindow('Manage.aspx?id=" + jsonArr[i].id + "&pi="+pi+"',770,340);\" href='#'><img alt='修改该记录' src='../../images/imgs/icon_edit.gif'/></a></td>";
            trHTML += "<td><a onclick=\"check('" + jsonArr[i].is_pass + "','" + jsonArr[i].id + "','" + pi + "');\" href='#'><img alt='修改该记录' src='../../images/imgs/icon_edit.gif'/></a></td>";
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
    function check(is_pass, id, pi) {
        if (is_pass == "已通过") {
            alert("审核已通过，无法进行修改");
            return;
        } else {
            OpenTopWindow("Manage.aspx?id=" + id + "&pi=" + pi + "&tag=manage", 770, 340);
        }
    }

    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div id="couDiv">
        <table class="listTableHead" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="listTableHeadTR" style="height: 22px;" width="20%">
                    <img   height="16" src="../../images/imgs/Query.gif" width="16" style="vertical-align: middle" />专业基地预约信息                    
                </td>
                
            </tr>
        </table>
        <table id="tbList" class="listTable" cellspacing="1" cellpadding="0" width="100%">
            <tr id="tr0" class="listTableTitleRow">
                
                <td>基地负责人</td>
                <td>专业基地</td>  
                <td>预约开始时间</td> 
                <td>预约结束时间</td>                                           
                <td>培训总人数</td> 
                <td>附件状态</td>
                <td>审核</td>
                <td>查看</td>
                <td>修改</td>
            </tr>
            
      </table>
       <div id="PageList" style="text-align:center;vertical-align:middle; margin-top:10px;">
       
      </div>

    </div>
      <%--<asp:Literal ID="xianshi" runat="server"></asp:Literal>--%>
    </form>
   
</body>
    
</html>


