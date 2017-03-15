<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="teachers_NianDuExam_List" %>

<%@ Import Namespace="Common" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Model" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学员日常考核</title>
    <script src="../../js/global.js"></script>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/PageList/PageList.js"></script>
    <script src="../../js/jquery-easyui-1.3.6/jquery.easyui.min.js"></script>
    <link href="../../js/jquery-easyui-1.3.6/themes/icon.css" rel="stylesheet" />
    <link href="../../js/jquery-easyui-1.3.6/themes/default/easyui.css" rel="stylesheet" />
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

    $(window).load(function () {

        //loadPageList(1);
        createPageBar($("#PageList"), 1, 1, 1);
    });

    //function loadPageList(pi) {

    //    $.post("ashx/List.ashx", {
    //        "pi": pi, "ManagersName": ManagersName, "TrainingBaseCode": TrainingBaseCode, "NewsTitle": NewsTitle,
    //        "RegisterDate": RegisterDate
    //    },
    //      function (data) {
    //          var jsonArr = eval("(" + data + ")");
    //          if (jsonArr.data == null) {
    //              $("#tbList tr:gt(0)").remove();
    //          } else {
    //              createRows(jsonArr.data, pi);
    //          }
    //          createPageBar($("#PageList"), pi, jsonArr.recordCount, jsonArr.pageCount);

    //      });
    //} 
    function createRows(jsonArr, pi) {
        var tbL = $("#tbList");
        $("#tbList tr:gt(0)").remove();
        for (i = 0; i < jsonArr.length; i++) {
            var object = "";
            var trHTML = "<tr class='listTableContentRow'>";
            trHTML += "<td style='height:25px'>" + jsonArr[i].NewsTitle + "</td>";
            if (jsonArr[i].FileName == "" || jsonArr[i].FileName == null) {
                trHTML += "<td>没有上传文件</td>";
            } else {
                trHTML += "<td style='color:red;'>" + jsonArr[i].FileName + "<a style='text-decoration:none;color:#002D96;font-size:10px;' href=\"ashx/Download.ashx?FileName=" + jsonArr[i].FileName + "&FilePath=" + jsonArr[i].FilePath + "\">下载</a></td>";
            }
            trHTML += "<td>" + jsonArr[i].Writor + "</td>";
            trHTML += "<td>" + jsonArr[i].RegisterDate + "</td>";
            trHTML += "<td><a onclick=\"OpenTopWindow('Manage.aspx?id=" + jsonArr[i].Id + "&tag=view',800,600);\" href='#'><img alt='查看详细资料' src='../../images/imgs/icon_show.gif'/></a></td>";
            //trHTML += "<td><a onclick=\"OpenTopWindow('Manage.aspx?id=" + jsonArr[i].Id + "&pi="+pi+"',800,480);\" href='#'><img alt='修改该记录' src='../../images/imgs/icon_edit.gif'/></a></td>";
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
<body style="text-align:center;">
    <form id="form1" runat="server">
    <div id="couDiv">
        
        <table id="tbList" class="listTable" cellspacing="1" cellpadding="0" width="100%">
            <tr id="tr0" class="listTableTitleRow">
                
                <td>姓名</td>
                <td>专业基地</td>
                <td>轮转科室</td> 
                <td>轮转开始时间</td> 
                <td>轮转结束时间</td>                                         
                <td>指导老师</td>
                <td>年度考核</td>
            </tr>
            <tr class='listTableContentRow'>
                <td>王杰</td>
                <td>内科</td>
                <td>内分泌科</td> 
                <td>2016-08-07</td> 
                <td>2016-09-05</td>                                         
                <td>胡小虎</td>
                <td><a onclick="OpenTopWindow('Manage.aspx',950,600);" href='#'><img alt='查看详细资料' src='../../images/imgs/icon_show.gif'/></a></td>
                </tr>
            
      </table>
       <div id="PageList" style="text-align:center;vertical-align:middle; margin-top:10px;">
       
      </div>
      
    </div> 
    </form>
   
</body>
</html>
