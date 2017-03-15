<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="students_PersonalInformation_List" %>

<%@ Import Namespace="Common" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="Model" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="head1">
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
        var name = "<%=students_name%>";
        var session="<%=Session["loginModel"]%>";
        $(window).load(function () {
            
            loadPageList(1);
        });
        

        function loadPageList(pi) {
            //var pageListDiv = $("#PageList");
            $.post("List.ashx?do=l", { "pi": pi, "name": name }, function (data) {
                var jsonArr = eval("(" + data + ")");
                if (jsonArr.data == null) {
                    $("#tbList tr:gt(0)").remove();
                } else {
                    createRows(jsonArr.data, pi);
                }
                createPageBar($("#PageList"), pi, jsonArr.rowCount, jsonArr.pageCount);
                
            });
        }
        
        function createRows(jsonArr,pi) {
            var tbL = $("#tbList");
            $("#tbList tr:gt(0)").remove();
            for (i = 0; i < jsonArr.length; i++) {
                var trHTML = "<tr class='listTableContentRow'>";
                trHTML += "<td>" + jsonArr[i].real_name + "</td>";
                trHTML += "<td>" + jsonArr[i].sex + "</td>";
                trHTML += "<td>" + jsonArr[i].age + "</td>";
                trHTML += "<td>" + jsonArr[i].id_number + "</td>";
                trHTML += "<td>" + jsonArr[i].telephon + "</td>";
                trHTML += "<td>" + jsonArr[i].mail + "</td>";
                trHTML += "<td>" + jsonArr[i].training_base_name + "</td>";
                trHTML += "<td>" + jsonArr[i].professional_base_name+ "</td>";
                trHTML += "<td>" + jsonArr[i].plan_training_time + "</td>";
                trHTML += "<td><a onclick=\"OpenTopWindow('View.aspx?id=" + jsonArr[i].id + "',1000,500);\" href='#'><img alt='查看详细资料' src='../../images/imgs/icon_show.gif'/></a></td>";
                trHTML += "<td><a onclick=\"OpenTopWindow('PersonalInformation.aspx?id=" + jsonArr[i].id + "&pi=" + pi + "',1000,550);\" href='#'><img alt='修改该记录' src='../../images/imgs/icon_edit.gif'/></a></td>";
                
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
                    <img alt="" height="16" src="../../images/imgs/Query.gif" width="16" style="vertical-align: middle" />个人基本信息                    
                </td>
                
            </tr>
        </table>
        <table id="tbList" class="listTable" cellspacing="1" cellpadding="0" width="100%">
            <tr id="tr0" class="listTableTitleRow">
                
                <td>姓名</td>
                <td>性别</td>  
                <td>年龄</td> 
                <td>身份证号码</td>                                           
                <td>常用手机号码</td> 
                <td>常用电子邮箱</td>
                <td>培训基地</td>
                <td>培训专业</td>
                <td>计划参训时限</td>
                <td>查看</td>
                <td>修改</td>
                
            </tr>
            
      </table>
       <div id="PageList" style="text-align:center;vertical-align:middle; margin-top:10px;">
       
      </div>

    </div>
    </form>
   
</body>
    
</html>
