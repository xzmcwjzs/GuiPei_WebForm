<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="Statics_Students_ChuKeExam_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="
    text/html; charset=utf-8" />
    <title>考核成绩统计图</title>
    <script src="../../../js/jquery-1.7.2.js"></script>
    <script src="../../../js/bootstrap-2.3.3/js/bootstrap.min.js"></script> 
    <link href="../../../js/bootstrap-2.3.3/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body style="text-align:center;">

    <div style="margin:0 auto;padding-top:10px; height: 220px;width:60%">
            <table class="table table-bordered">
                <caption><b style="font:800 18px '宋体'">考核成绩统计</b></caption>
                <thead>
                    <tr>
                        <th>医德医风</th>
                        <th>职业素养</th>
                        <th>出勤情况</th>
                        <th>理论成绩</th>
                        <th>临床实践</th>
                    </tr>
                </thead>
                <tbody>
                   <tr>
                        <td>7</td>
                        <td>81</td>
                        <td>89</td>
                       <td>83</td>
                        <td>76</td> 
                    </tr>   
                            
                </tbody>
            </table>
        </div>
    <div id="main" style="width: 60%; height: 400px;margin:0 auto;padding-top: 10px"></div>

    <script src="../../../echarts-2.2.7/build/dist/echarts.js"></script>
    <script type="text/javascript">
        
        var myChart;

        $(function () {
            pieChart();
        })
        function pieChart() {
            require.config({
                paths: {
                    'echarts': '../../../echarts-2.2.7/build/dist'
                }
            });

            require(
             [
                 'echarts',
                 'echarts/chart/pie'   // 按需加载所需图表，如需动态类型切换功能，别忘了同时加载相应图表
             ],
             function (ec) {
                 myChart = ec.init(document.getElementById('main'), 'macarons');
                 myChart.showLoading({ text: '数据读取中...' });

                 myChart.hideLoading();//隐藏loading

                 option = {
                     title: {
                         text: '考核成绩扇形统计',
                         //subtext: '纯属虚构',
                         x: 'center'
                     },
                     tooltip: {
                         trigger: 'item',
                         formatter: "{a} <br/>{b} : {c} ({d}%)"
                     },
                     legend: {
                         orient: 'vertical',
                         x: 'left',
                         data: ['医德医风', '职业素养', '出勤情况', '理论成绩', '临床实践']
                     },
                     series: [
                         {
                             name: '考核成绩',
                             type: 'pie',
                             radius: '55%',
                             center: ['50%', '60%'],
                             data: [
                { value: 75, name: '医德医风' },
                { value: 81, name: '职业素养' },
                { value: 89, name: '出勤情况' },
                { value: 83, name: '理论成绩' },
                { value: 76, name: '临床实践' }
                             ],
                             itemStyle: {
                                 emphasis: {
                                     shadowBlur: 10,
                                     shadowOffsetX: 0,
                                     shadowColor: 'rgba(0, 0, 0, 0.5)'
                                 }
                             }
                         }
                     ]
                 };

                 myChart.setOption(option);
                 myChart.hideLoading();
                 //getPieData();
             }
         );

        }

        function getPieData() {
            var options = myChart.getOption();
            var strHtmlD = "", strHtmlR = "", strHtmlB = "";
            $.ajax({
                cache: false,
                type: "get",
                url: "ashx/Load.ashx",
                dataType: "text",
                data: { Name: Name, TrainingBaseCode: TrainingBaseCode },
                success: function (data) {
                    var jsonArr = eval("(" + data + ")");
                    var total = 0;
                    $.each(jsonArr, function (i, val) {
                        label[i] = val['ProfessionalBaseName'];
                        value[i] = { 'name': val['ProfessionalBaseName'], 'value': val['CountPB'] };
                        total += val['CountPB'];
                    });
                    for (var j = 0; j < label.length; j++) {
                        strHtmlD += "<th>" + label[j] + "</th>";
                        strHtmlR += "<td>" + value[j].value + "</td>";
                        strHtmlB += "<td>" + (value[j].value * 100 / total).toFixed(2) + "%</td>";
                    }
                    $("#StaticsD").after(strHtmlD);
                    $("#StaticsR").after(strHtmlR);
                    $("#StaticsB").after(strHtmlB);

                    options.legend.data = label;
                    options.series[0].data = value;

                    myChart.hideLoading();
                    myChart.setOption(options);



                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }
            });
        }

    </script>

</body>
</html>
