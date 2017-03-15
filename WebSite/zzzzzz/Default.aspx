<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="zzzzzz_Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../FusionCharts/FusionCharts.js"></script>
    <script src="../js/jquery-1.7.2.js"></script>
    <%--<script type="text/javascript">
        $(function () {
         
            //var dataXml = "<chart caption='Indian Premier League Points' xAxisName='满意度'"+
            //"yAxisName='比例'showValues='0' formatNumberScale='0' showBorder='0'>"+
            //"<set label='Mumbai Indians' value='16' />"+
            //"<set label='Chennai Super Kings' value='14' />"+
            //"<set label='Kolkata Riders' value='12' /></chart>";

            var dataJson = "{'chart':{'caption':'Monthly','xaxisname':'Month','yaxisname':'Revenue'},'data': [{'label': 'Jan','value': '420000'},{'label':'feburay','value':'220000'}],'trendlines':[{'line':[{'startvalue':'700000','istrendzone':'1','valueonright':'1','color':'000000'}]}]}";
            
            var json = eval("("+dataJson+")");
            //var json = JSON.parse(dataJson);
            var chart = new FusionCharts("../FusionCharts/Column3D.swf", "myChart", "1000", "600");
            //chart.setXMLUrl("XMLFile.xml");
            //chart.setXMLData(dataXml);
            //chart.setJSONUrl("Data.json");
            chart.setJSONData(json);
            chart.render("chartdiv");

        });
        
    </script>--%>

</head>
<body>
    <form id="form1" runat="server">
    <div id="chartdiv" style="text-align:center">
        <%--<asp:Literal ID="Literal1" runat="server"></asp:Literal>--%>
    </div>
       <script type="text/javascript">

 //var dataJson = "{'chart':{'caption':'Monthly','xaxisname':'Month','yaxisname':'Revenue'},'data': [{'label': 'Jan','value': '420000'},{'label':'feburay','value':'220000'}],'trendlines':[{'line':[{'startvalue':'700000','istrendzone':'1','valueonright':'1','color':'000000'}]}]}";
           //var dataJson = "{'chart':{'caption':'My Json Example','xaxisname':'Month','yaxisname':'Revenue',"+
           //    "'showvalues':'1','numberSuffix':'%25','labelDisplay':'Rotate','slantLabels':'1'}," +
           //"'categories':[{'category':[{'label':'one'},{'label':'two'}]}],'dataset':[{'seriesname':'2006','data':[{'value':'27'},"+
           //"{'value':'29'}]},{'seriesname':'2007','data':[{'value':'21','tooltext':'2007{br}34人,21%'},{'value':'19'}]}]}";

           var dataJson = "{'chart':{'caption': '满意度调查反馈图','subCaption': 'By Students','xaxisname':'调查项目','yaxisname':'比例(人数)','showvalues':'1','numberSuffix':'%25','labelDisplay':'Rotate','slantLabels':'1'},'categories':[{'category': [{'label':'敬业精神'},{'label':'工作作风'},{'label':'理论水平'},{'label':'疑难病症处理'},{'label':'临床操作技能'},{'label':'交流能力'},{'label':'学科进展了解'},{'label':'纠纷防范意识'},{'label':'科研能力'},{'label':'外语运用水平'},{'label':'带教经验'},{'label':'表达能力'},{'label':'放手能力'}]}],'dataset':[{'seriesname':'A.非常满意','data':[{'value':'64'},{'value':'55'},{'value':'9'},{'value':'9'},{'value':'9'},{'value':'9'},{'value':'9'},{'value':'45'},{'value':'0'},{'value':'18'},{'value':'9'},{'value':'9'},{'value':'9'}]},{'seriesname':'B.比较满意','data':[{'value':'9'},{'value':'18'},{'value':'55'},{'value':'45'},{'value':'18'},{'value':'9'},{'value':'18'},{'value':'18'},{'value':'64'},{'value':'9'},{'value':'9'},{'value':'64'},{'value':'9'}]}]}";
               var json = eval("(" + dataJson + ")");
               
               var chart = new FusionCharts("../FusionCharts/ScrollColumn2D.swf", "myChart", "1000", "800");
               
               chart.setJSONData(json);
               chart.render("chartdiv");


    </script>

    </form>
</body>
</html>
