<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="bases_AppointInformation_List" %>
<%@ Import Namespace="Common" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Model" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>预约信息</title>
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
    var RealName = "<%=RealName%>";
    var ProfessionalBaseName = "<%=ProfessionalBaseName%>";
    var DeptName = "<%=DeptName%>";

    var AppointBeginTime = "<%=AppointBeginTime%>";
    var AppointEndTime = "<%=AppointEndTime%>";
    var IsPass = "<%=IsPass%>";

    $(window).load(function () {

        loadPageList(1);
    });

    function loadPageList(pi) {

        $.post("ashx/List.ashx", {
            "pi": pi, "TrainingBaseCode": TrainingBaseCode, "RealName": RealName,"ProfessionalBaseName":ProfessionalBaseName,"DeptName":DeptName,
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
            var jbjn = parseFloat(jsonArr[i].blsx) + parseFloat(jsonArr[i].clbrnl) + parseFloat(jsonArr[i].sjcznl) + parseFloat(jsonArr[i].czjn) + parseFloat(jsonArr[i].zdsp);
            var trHTML = "<tr class='listTableContentRow'>";
            trHTML += "<td style='height:25px'>" + jsonArr[i].teachers_real_name + "</td>";
            trHTML += "<td>" + jsonArr[i].professional_base_name + "</td>";
            trHTML += "<td>" + jsonArr[i].appoint_begin_time + "</td>";
            trHTML += "<td>" + jsonArr[i].appoint_end_time + "</td>";
            trHTML += "<td>" + jsonArr[i].total_num + "</td>";
            if (jsonArr[i].FileName == "" || jsonArr[i].FileName == null) {
                trHTML += "<td>没有上传文件</td>";
            } else {
                trHTML += "<td style='color:red;'>" + jsonArr[i].FileName + "(" + jsonArr[i].IsReceive + ")<a style='text-decoration:none;color:#002D96;font-size:10px;' onclick=\"IsReceive('" + jsonArr[i].IsReceive + "','" + jsonArr[i].id + "','" + pi + "');\" href=\"ashx/Download.ashx?FileName="+jsonArr[i].FileName+"&FilePath="+jsonArr[i].FilePath+"\">下载</a></td>";
            }
            trHTML += "<td><a style='text-decoration:none;color:red;' onclick=\"handle('" + jsonArr[i].is_pass + "','" + jsonArr[i].id + "','" + pi + "');\" href='#'>" + jsonArr[i].is_pass + "</a></td>";
            
            trHTML += "<td><a onclick=\"OpenTopWindow('Manage.aspx?id=" + jsonArr[i].id + "&tag=view',770,300);\" href='#'><img alt='查看详细资料' src='../../images/imgs/icon_show.gif'/></a></td>";
            //trHTML += "<td><a onclick=\"check('" + jsonArr[i].is_pass + "','" + jsonArr[i].id + "','" + pi + "');\" href='#'><img alt='修改该记录' src='../../images/imgs/icon_edit.gif'/></a></td>";
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
    function IsReceive(check, id, pi) {
        $.ajax({
            cache: false,
            type: "post",
            url: "ashx/IsReceive.ashx",
            dataType: "text",//如果是json的话，不用eval()在解析
            data: { id: id, check: check },
            success: function (data) {
                if (data == "checkSuccess") {
                    loadPageList(pi);
                    return;
                }
            },
            error: function () {
                alert("系统繁忙，请联系管理员");
            }

        });
    }
    function handle(check, id, pi) {
        $.ajax({
            cache: false,
            type: "post",
            url: "ashx/Handle.ashx",
            dataType: "text",//如果是json的话，不用eval()在解析
            data: { id: id, check: check },
            success: function (data) {
                if (data == "checkSuccess") {
                    loadPageList(pi);
                    return;
                } else {
                    alert("审核操作失败");
                }

            },
            error: function () {
                alert("系统繁忙，请联系管理员");
            }

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
                    <img   height="16" src="../../images/imgs/Query.gif" width="16" style="vertical-align: middle" />预约信息查询结果                   
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
                <td>附件</td>
                <td>审核</td>
                <td>查看</td>
            </tr>
            
      </table>
       <div id="PageList" style="text-align:center;vertical-align:middle; margin-top:10px;">
       
      </div>

    </div>
      <%--<asp:Literal ID="xianshi" runat="server"></asp:Literal>--%>
    </form>
   
</body>
    
</html>


