<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="bases_StudentsBigMedicalRecords_Manage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>大病历</title>
    <link href="../../css/global.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.js"></script>
    <script src="../../js/global.js"></script>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script src="../../js/InitialStudents/InitialInformation.js"></script>
    <script type="text/javascript">
        var id = "<%=id%>";
        var pi = "<%=pi%>";
        var tag = "<%=tag%>";
        $(function () {
            //Initial();
            loadProvinceCityArea("#BirthProvince", "#BirthCity", "#BirthArea", "#BirthProvinceName", "#BirthCityName", "#BirthAreaName");
            loadProvinceCityArea("#NowProvince", "#NowCity", "#NowArea", "#NowProvinceName", "#NowCityName", "#NowAreaName");
            loadProvinceCityArea("#GRShi_BirthProvince", "#GRShi_BirthCity", "#GRShi_BirthArea", "#GRShi_BirthProvinceName", "#GRShi_BirthCityName", "#GRShi_BirthAreaName");
            $("#XZZhenDuan").removeAttr("disabled");
            $("#Reviewer").removeAttr("disabled");
            var nowDate = new Date();
            var str = "" + nowDate.getFullYear() + "-";
            str += (nowDate.getMonth() + 1) + "-";
            str += nowDate.getDate() + "-";
            
            $("#ReviewerDate").removeAttr("disabled").val(str);
            if (id != "") {
                if (tag == "view") {
                    $("#last").remove();
                }
                loadAllData(id);
            }

            $("#SaveAndUpdate").click(function () {
                if (id != "") {
                    update();
                } else {
                    alert("服务器繁忙，请联系管理员")
                    return;
                }
            });

        });
       
        function update() {
            //var forms = $("#form1").serializeArray();
            var XZZhenDuan = $("#XZZhenDuan").val();
            var Reviewer = $("#Reviewer").val();
            var ReviewerDate = $("#ReviewerDate").val();
            if ($("#RotaryDept").val() == "-1") { alert("轮转科室不能为空"); return; }
            if ($("#Teacher").val() == "-1") { alert("指导医师不能为空"); return; }
            $.ajax({
                cache: false,
                type: "post",
                url: "ashx/Update.ashx",
                dataType: "text",//如果是json的话，不用eval()在解析
                data: {id:id,XZZhenDuan:XZZhenDuan,Reviewer:Reviewer,ReviewerDate:ReviewerDate},
                success: function (data) {
                    if (data == "updateSuccess") {
                        alert("大病历信息修正成功");
                        self.opener.window.loadPageList(pi);
                        window.close();
                    } else {
                        alert("大病历信息修正失败");
                    }

                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }

            });
        }
        function loadAllData(id) {
            $.ajax({
                cache: false,
                type: "get",
                url: "../../students/BigMedicalRecords/ashx/loadAllData.ashx",
                dataType: "text",
                data: { id: id },
                success: function (data) {
                    var jsonArr = eval("(" + data + ")");
                    var json = jsonArr.data[0];
                    if (json == null) { return; } else {
                        //loadTeacher(json.DeptCode, json.TeacherId);
                        loadUpdateCA(json.BirthProvinceCode, "#BirthCity", json.BirthCityCode, "#BirthArea", json.BirthAreaCode)
                        loadUpdateCA(json.NowProvinceCode, "#NowCity", json.NowCityCode, "#NowArea", json.NowAreaCode)
                        loadUpdateCA(json.GRShi_BirthProvinceCode, "#GRShi_BirthCity", json.GRShi_BirthCityCode, "#GRShi_BirthArea", json.GRShi_BirthAreaCode)
                        $("#RotaryDept option:selected").text(json.DeptName);
                        $("#Teacher option:selected").text(json.TeacherName);

                        $("#Id").val(json.Id);
                        $("#StudentsRealName").val(json.StudentsRealName);
                        $("#StudentsName").val(json.StudentsName);
                        $("#TrainingBaseCode").val(json.TrainingBaseCode);
                        $("#TrainingBaseName").val(json.TrainingBaseName);
                        $("#ProfessionalBaseCode").val(json.ProfessionalBaseCode);
                        $("#ProfessionalBaseName").val(json.ProfessionalBaseName);
                        $("#RotaryDept").val(json.DeptCode);
                        $("#DeptName").val(json.DeptName);
                        $("#RegisterDate").val(json.RegisterDate);
                        $("#Writor").val(json.Writor);
                        $("#Teacher").val(json.TeacherId);
                        $("#TeacherName").val(json.TeacherName);

                        $("#PatientNo").val(json.PatientNo);
                        $("#InhospitalNo").val(json.InhospitalNo);
                        $("#PatientName").val(json.PatientName);
                        $(":radio[name='sex'][value='" + json.sex + "']").attr('checked', true);
                        $("#Age").val(json.Age);
                        $("#Job").val(json.Job);
                        $("#Nation").val(json.Nation);
                        $("#Marriage").val(json.Marriage);
                        $("#BirthProvince").val(json.BirthProvinceCode);
                        $("#BirthProvinceName").val(json.BirthProvinceName);
                        //$("#BirthCity").val(json.BirthCityCode);
                        $("#BirthCityName").val(json.BirthCityName);
                        //$("#BirthArea").val(json.BirthAreaCode);

                        $("#BirthAreaName").val(json.BirthAreaName);
                        $("#BirthDetailAddress").val(json.BirthDetailAddress);
                        $("#Company").val(json.Company);
                        $("#NowProvince").val(json.NowProvinceCode);
                        $("#NowProvinceName").val(json.NowProvinceName);
                        //$("#NowCity").val(json.NowCityCode);
                        $("#NowCityName").val(json.NowCityName);
                        //$("#NowArea").val(json.NowAreaCode);

                        $("#NowAreaName").val(json.NowAreaName);
                        $("#NowDetailAddress").val(json.NowDetailAddress);
                        $("#Phone").val(json.Phone);
                        $("#InhospitalDate").val(json.InhospitalDate);
                        $("#RecordDate").val(json.RecordDate);
                        $("#MedicalHistorySpeaker").val(json.MedicalHistorySpeaker);
                        $("#ReliableDegree").val(json.ReliableDegree);
                        $("#ZSu").val(json.ZSu);
                        $("#XBShi").val(json.XBShi);
                        $(":radio[name='JWShi_PSJKZhuangKuang'][value='" + json.JWShi_PSJKZhuangKuang + "']").attr('checked', true);
                        $("#JWShi_CHJBHCRBingShi").val(json.JWShi_CHJBHCRBingShi);
                        $("#JWShi_YFJZhongShi").val(json.JWShi_YFJZhongShi);
                        $(":radio[name='JWShi_GMinShi'][value='" + json.JWShi_GMinShi + "']").attr('checked', true);
                        $("#JWShi_GMinYuan").val(json.JWShi_GMinYuan);
                        $("#JWShi_LCBiaoXian").val(json.JWShi_LCBiaoXian);
                        $("#JWShi_WShangShi").val(json.JWShi_WShangShi);
                        $("#JWShi_SShuShi").val(json.JWShi_SShuShi);
                        $(":checkbox[name='XTHGu_KeSou'][value='" + json.XTHGu_KeSou + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_KeTan'][value='" + json.XTHGu_KeTan + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_KaXie'][value='" + json.XTHGu_KaXie + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_ChuanXi'][value='" + json.XTHGu_ChuanXi + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_XiongTong'][value='" + json.XTHGu_XiongTong + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_HXKunNan'][value='" + json.XTHGu_HXKunNan + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_XinJi'][value='" + json.XTHGu_XinJi + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_HDHQiCu'][value='" + json.XTHGu_HDHQiCu + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_XZShuiZhong'][value='" + json.XTHGu_XZShuiZhong + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_XQQuTong'][value='" + json.XTHGu_XQQuTong + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_XYZengGao'][value='" + json.XTHGu_XYZengGao + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_YunJue'][value='" + json.XTHGu_YunJue + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_SYJianTui'][value='" + json.XTHGu_SYJianTui + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_FanSuan'][value='" + json.XTHGu_FanSuan + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_AiQi'][value='" + json.XTHGu_AiQi + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_EXin'][value='" + json.XTHGu_EXin + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_OuTu'][value='" + json.XTHGu_OuTu + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_FuZhang'][value='" + json.XTHGu_FuZhang + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_FuTong'][value='" + json.XTHGu_FuTong + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_BianMi'][value='" + json.XTHGu_BianMi + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_FuXie'][value='" + json.XTHGu_FuXie + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_OuXue'][value='" + json.XTHGu_OuXue + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_HeiBian'][value='" + json.XTHGu_HeiBian + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_BianXue'][value='" + json.XTHGu_BianXue + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_HuangDan'][value='" + json.XTHGu_HuangDan + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_YaoTong'][value='" + json.XTHGu_YaoTong + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_NiaoPin'][value='" + json.XTHGu_NiaoPin + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_NiaoJi'][value='" + json.XTHGu_NiaoJi + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_NiaoTong'][value='" + json.XTHGu_NiaoTong + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_PNKunNan'][value='" + json.XTHGu_PNKunNan + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_XueNiao'][value='" + json.XTHGu_XueNiao + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_NLYiChang'][value='" + json.XTHGu_NLYiChang + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_YNZengDuo'][value='" + json.XTHGu_YNZengDuo + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_ShuiZhong'][value='" + json.XTHGu_ShuiZhong + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_YBSaoYang'][value='" + json.XTHGu_YBSaoYang + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_YBKuiLan'][value='" + json.XTHGu_YBKuiLan + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_FaLi'][value='" + json.XTHGu_FaLi + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_TouYun'][value='" + json.XTHGu_TouYun + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_YanHua'][value='" + json.XTHGu_YanHua + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_YYChuXue'][value='" + json.XTHGu_YYChuXue + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_BChuXue'][value='" + json.XTHGu_BChuXue + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_PXChuXue'][value='" + json.XTHGu_PXChuXue + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_GuTong'][value='" + json.XTHGu_GuTong + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_SYKangJin'][value='" + json.XTHGu_SYKangJin + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_PaRe'][value='" + json.XTHGu_PaRe + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_DuoHan'][value='" + json.XTHGu_DuoHan + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_WeiHan'][value='" + json.XTHGu_WeiHan + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_DuoYin'][value='" + json.XTHGu_DuoYin + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_DuoNiao'][value='" + json.XTHGu_DuoNiao + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_SSZhenChan'][value='" + json.XTHGu_SSZhenChan + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_XGGaiBian'][value='" + json.XTHGu_XGGaiBian + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_XZFeiPang'][value='" + json.XTHGu_XZFeiPang + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_MXXiaoShou'][value='" + json.XTHGu_MXXiaoShou + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_MFZengDuov'][value='" + json.XTHGu_MFZengDuov + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_MFTuoLuo'][value='" + json.XTHGu_MFTuoLuo + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_SSChenZhuo'][value='" + json.XTHGu_SSChenZhuo + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_XGNGaiBian'][value='" + json.XTHGu_XGNGaiBian + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_BiJing'][value='" + json.XTHGu_BiJing + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_GJieTong'][value='" + json.XTHGu_GJieTong + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_GJHongZhong'][value='" + json.XTHGu_GJHongZhong + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_GJBianXing'][value='" + json.XTHGu_GJBianXing + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_JRouTong'][value='" + json.XTHGu_JRouTong + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_JRWeiSuo'][value='" + json.XTHGu_JRWeiSuo + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_TouTong'][value='" + json.XTHGu_TouTong + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_XuanYun'][value='" + json.XTHGu_XuanYun + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_YunJue1'][value='" + json.XTHGu_YunJue1 + "']").attr('checked', true);
                        $(":checkbox[name='JXTHGu_JYLJianTui'][value='" + json.JXTHGu_JYLJianTui + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_SLZhangAi'][value='" + json.XTHGu_SLZhangAi + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_ShiMian'][value='" + json.XTHGu_ShiMian + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_YSZhangAi'][value='" + json.XTHGu_YSZhangAi + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_ChanDong'][value='" + json.XTHGu_ChanDong + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_ChouChu'][value='" + json.XTHGu_ChouChu + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_TanHuan'][value='" + json.XTHGu_TanHuan + "']").attr('checked', true);
                        $(":checkbox[name='XTHGu_GJYiChang'][value='" + json.XTHGu_GJYiChang + "']").attr('checked', true);

                        $("#GRShi_BirthProvince").val(json.GRShi_BirthProvinceCode);
                        $("#GRShi_BirthProvinceName").val(json.GRShi_BirthProvinceName);
                        //$("#GRShi_BirthCity").val(json.GRShi_BirthCityCode);
                        $("#GRShi_BirthCityName").val(json.GRShi_BirthCityName);
                        //$("#GRShi_BirthArea").val(json.GRShi_BirthAreaCode);

                        $("#GRShi_BirthAreaName").val(json.GRShi_BirthAreaName);
                        $("#GRShi_BirthDetailAddress").val(json.GRShi_BirthDetailAddress);
                        $("#GRShi_CSHZGongZuo").val(json.GRShi_CSHZGongZuo);
                        $("#GRShi_DFBDQJZQingKuang").val(json.GRShi_DFBDQJZQingKuang);
                        $("#GRShi_YYouShi").val(json.GRShi_YYouShi);
                        $(":radio[name='GRShi_ShiYan'][value='" + json.GRShi_ShiYan + "']").attr('checked', true);
                        $("#GRShi_SYanNian").val(json.GRShi_SYanNian);
                        $("#GRShi_SYanZhi").val(json.GRShi_SYanZhi);
                        $(":radio[name='GRShi_JieYan'][value='" + json.GRShi_JieYan + "']").attr('checked', true);
                        $("#GRShi_JYanNian").val(json.GRShi_JYanNian);
                        $(":radio[name='GRShi_ShiJiu'][value='" + json.GRShi_ShiJiu + "']").attr('checked', true);
                        $("#GRShi_SJiuNian").val(json.GRShi_SJiuNian);
                        $("#GRShi_SJiuLiang").val(json.GRShi_SJiuLiang);
                        $("#GRShi_SJQiTa").val(json.GRShi_SJQiTa);
                        $("#HYShi_JHNianLing").val(json.HYShi_JHNianLing);
                        $("#HYShi_POQingKuang").val(json.HYShi_POQingKuang);
                        $("#YJSHSYShi_CChaoSui").val(json.YJSHSYShi_CChaoSui);
                        $("#YJSHSYShi_CChaoTian").val(json.YJSHSYShi_CChaoTian);
                        $("#YJSHSYShi_MCYJRiQi").val(json.YJSHSYShi_MCYJRiQi);
                        $("#YJSHSYShi_JJNianLing").val(json.YJSHSYShi_JJNianLing);
                        $("#YJSHSYShi_ZhouQi").val(json.YJSHSYShi_ZhouQi);
                        $(":radio[name='YJSHSYShi_JingLiang'][value='" + json.YJSHSYShi_JingLiang + "']").attr('checked', true);
                        $(":radio[name='YJSHSYShi_TongJing'][value='" + json.YJSHSYShi_TongJing + "']").attr('checked', true);
                        $(":radio[name='YJSHSYShi_JingQi'][value='" + json.YJSHSYShi_JingQi + "']").attr('checked', true);
                        $("#YJSHSYShi_RenShen").val(json.YJSHSYShi_RenShen);
                        $("#YJSHSYShi_ShunChan").val(json.YJSHSYShi_ShunChan);
                        $("#YJSHSYShi_LiuChan").val(json.YJSHSYShi_LiuChan);
                        $("#YJSHSYShi_ZaoChan").val(json.YJSHSYShi_ZaoChan);
                        $("#YJSHSYShi_SiChan").val(json.YJSHSYShi_SiChan);
                        $(":radio[name='YJSHSYShi_NCJBingQing'][value='" + json.YJSHSYShi_NCJBingQing + "']").attr('checked', true);
                        $("#YJSHSYShi_Zi").val(json.YJSHSYShi_Zi);
                        $("#YJSHSYShi_Nv").val(json.YJSHSYShi_Nv);
                        $(":radio[name='JZShi_Fu'][value='" + json.JZShi_Fu + "']").attr('checked', true);
                        $("#JZShi_FSiYin").val(json.JZShi_FSiYin);
                        $(":radio[name='JZShi_Mu'][value='" + json.JZShi_Mu + "']").attr('checked', true);
                        $("#JZShi_MSiYin").val(json.JZShi_MSiYin);
                        $("#JZShi_XDJieMei").val(json.JZShi_XDJieMei);
                        $("#JZShi_ZNJQiTa").val(json.JZShi_ZNJQiTa);
                        $("#SMTZheng_TiWen").val(json.SMTZheng_TiWen);
                        $("#SMTZheng_MaiBo").val(json.SMTZheng_MaiBo);
                        $("#SMTZheng_HuXi").val(json.SMTZheng_HuXi);
                        $("#SMTZheng_XueYa1").val(json.SMTZheng_XueYa1);
                        $("#SMTZheng_XueYa2").val(json.SMTZheng_XueYa2);
                        $("#SMTZheng_TiZhong").val(json.SMTZheng_TiZhong);
                        $(":radio[name='YBZKuang_FaYu'][value='" + json.YBZKuang_FaYu + "']").attr('checked', true);
                        $(":radio[name='YBZKuang_YingYang'][value='" + json.YBZKuang_YingYang + "']").attr('checked', true);
                        $(":radio[name='YBZKuang_MianRong'][value='" + json.YBZKuang_MianRong + "']").attr('checked', true);
                        $("#YBZKuang_QiTa").val(json.YBZKuang_QiTa);
                        $(":radio[name='YBZKuang_BiaoQing'][value='" + json.YBZKuang_BiaoQing + "']").attr('checked', true);
                        $(":radio[name='YBZKuang_TiWei'][value='" + json.YBZKuang_TiWei + "']").attr('checked', true);
                        $("#YBZKuang_TWForQP").val(json.YBZKuang_TWForQP);
                        $(":radio[name='YBZKuang_BuTai'][value='" + json.YBZKuang_BuTai + "']").attr('checked', true);
                        $("#YBZKuang_BTForBZC").val(json.YBZKuang_BTForBZC);
                        $(":radio[name='YBZKuang_ShenZhi'][value='" + json.YBZKuang_ShenZhi + "']").attr('checked', true);
                        $(":radio[name='YBZKuang_PHJianCha'][value='" + json.YBZKuang_PHJianCha + "']").attr('checked', true);
                        $(":radio[name='PFNMo_SeZe'][value='" + json.PFNMo_SeZe + "']").attr('checked', true);
                        $(":radio[name='PFNMo_PiZhen'][value='" + json.PFNMo_PiZhen + "']").attr('checked', true);
                        $("#PFNMo_PZLXJFenBu").val(json.PFNMo_PZLXJFenBu);
                        $(":radio[name='PFNMo_PXChuXue'][value='" + json.PFNMo_PXChuXue + "']").attr('checked', true);
                        $("#PFNMo_PXCXLXJFenBu").val(json.PFNMo_PXCXLXJFenBu);
                        $(":radio[name='PFNMo_MFFenBu'][value='" + json.PFNMo_MFFenBu + "']").attr('checked', true);
                        $("#PFNMo_MFFBBuWei").val(json.PFNMo_MFFBBuWei);
                        $(":radio[name='PFNMo_WDYShiDu'][value='" + json.PFNMo_WDYShiDu + "']").attr('checked', true);
                        $(":radio[name='PFNMo_TanXing'][value='" + json.PFNMo_TanXing + "']").attr('checked', true);
                        $(":radio[name='PFNMo_GanZhang'][value='" + json.PFNMo_GanZhang + "']").attr('checked', true);
                        $(":radio[name='PFNMo_ShuiZhong'][value='" + json.PFNMo_ShuiZhong + "']").attr('checked', true);
                        $("#PFNMo_BWJChengDu").val(json.PFNMo_BWJChengDu);
                        $(":radio[name='PFNMo_ZZhuZhi'][value='" + json.PFNMo_ZZhuZhi + "']").attr('checked', true);
                        $("#PFNMo_ZZZBuWei").val(json.PFNMo_ZZZBuWei);
                        $("#PFNMo_ZZZShuMu").val(json.PFNMo_ZZZShuMu);
                        $("#PFNMo_QiTa").val(json.PFNMo_QiTa);
                        $(":radio[name='LBJie_QSQBLBaJie'][value='" + json.LBJie_QSQBLBaJie + "']").attr('checked', true);
                        $("#LBJie_QSQBLBJBWJTeZheng").val(json.LBJie_QSQBLBJBWJTeZheng);
                        $(":radio[name='TBu_TLDaXiao'][value='" + json.TBu_TLDaXiao + "']").attr('checked', true);
                        $(":radio[name='TBu_TLJiXing'][value='" + json.TBu_TLJiXing + "']").attr('checked', true);
                        $("#TBu_TLJXForYou").val(json.TBu_TLJXForYou);
                        $("#TBu_TLQTYCYaTong").val(json.TBu_TLQTYCYaTong);
                        $("#TBu_TLQTYCBaoKuai").val(json.TBu_TLQTYCBaoKuai);
                        $("#TBu_TLQTYCAoXian").val(json.TBu_TLQTYCAoXian);
                        $("#TBu_TLQTYCBuWei").val(json.TBu_TLQTYCBuWei);
                        $(":radio[name='TBu_YMMXiShu'][value='" + json.TBu_YMMXiShu + "']").attr('checked', true);
                        $(":radio[name='TBu_YMMTuoLuo'][value='" + json.TBu_YMMTuoLuo + "']").attr('checked', true);
                        $(":radio[name='TBu_YDaoJie'][value='" + json.TBu_YDaoJie + "']").attr('checked', true);
                        $(":radio[name='TBu_YYanJian'][value='" + json.TBu_YYanJian + "']").attr('checked', true);
                        $(":radio[name='TBu_YJieMo'][value='" + json.TBu_YJieMo + "']").attr('checked', true);
                        $(":radio[name='TBu_YJiaoMo'][value='" + json.TBu_YJiaoMo + "']").attr('checked', true);
                        $("#TBu_YJiaoMForYiChang").val(json.TBu_YJiaoMForYiChang);
                        $(":radio[name='TBu_YGongMo'][value='" + json.TBu_YGongMo + "']").attr('checked', true);
                        $(":radio[name='TBu_YYanQiu'][value='" + json.TBu_YYanQiu + "']").attr('checked', true);
                        $("#TBu_YYQForAll").val(json.TBu_YYQForAll);
                        $(":radio[name='TBu_YTongKong'][value='" + json.TBu_YTongKong + "']").attr('checked', true);
                        $("#TBu_TKForBuDengZ").val(json.TBu_TKForBuDengZ);
                        $("#TBu_TKForBuDengY").val(json.TBu_TKForBuDengY);
                        $(":radio[name='TBu_YTKDGFanShe'][value='" + json.TBu_YTKDGFanShe + "']").attr('checked', true);
                        $("#TBu_YTKDGFSForAll").val(json.TBu_YTKDGFSForAll);
                        $(":radio[name='TBu_YTKJShiLi'][value='" + json.TBu_YTKJShiLi + "']").attr('checked', true);
                        $("#TBu_TKJSLForAllZ").val(json.TBu_TKJSLForAllZ);
                        $("#TBu_TKJSLForAllY").val(json.TBu_TKJSLForAllY);
                        $("#TBu_TKJSLQiTa").val(json.TBu_TKJSLQiTa);
                        $(":radio[name='TBu_EErKuo'][value='" + json.TBu_EErKuo + "']").attr('checked', true);
                        $("#TBu_EEKQiTa").val(json.TBu_EEKQiTa);
                        $("#TBu_EErKForAll").val(json.TBu_EErKForAll);
                        $(":radio[name='TBu_EWEDFMiWu'][value='" + json.TBu_EWEDFMiWu + "']").attr('checked', true);
                        $("#TBu_EWEDFMWForY").val(json.TBu_EWEDFMWForY);
                        $("#TBu_EWEDFMWXingZhi").val(json.TBu_EWEDFMWXingZhi);
                        $(":radio[name='TBu_ERTYaTong'][value='" + json.TBu_ERTYaTong + "']").attr('checked', true);
                        $("#TBu_ERTYTForY").val(json.TBu_ERTYTForY);
                        $(":radio[name='TBu_TLCSZhangAi'][value='" + json.TBu_TLCSZhangAi + "']").attr('checked', true);
                        $("#TBu_TLCSZAForY").val(json.TBu_TLCSZAForY);
                        $(":radio[name='TBu_BWaiXing'][value='" + json.TBu_BWaiXing + "']").attr('checked', true);
                        $("#TBu_BForYC").val(json.TBu_BForYC);
                        $(":radio[name='TBu_BBDYaTong'][value='" + json.TBu_BBDYaTong + "']").attr('checked', true);
                        $("#TBu_BForBDYT").val(json.TBu_BForBDYT);
                        $(":checkbox[name='TBu_BQTYCBYShanDong'][value='" + json.TBu_BQTYCBYShanDong + "']").attr('checked', true);
                        $(":checkbox[name='TBu_BQTYCFMiWu'][value='" + json.TBu_BQTYCFMiWu + "']").attr('checked', true);
                        $(":checkbox[name='TBu_BQTYCChuXue'][value='" + json.TBu_BQTYCChuXue + "']").attr('checked', true);
                        $(":checkbox[name='TBu_BQTYCZuSe'][value='" + json.TBu_BQTYCZuSe + "']").attr('checked', true);
                        $(":checkbox[name='TBu_BQTYCBZGPianQu'][value='" + json.TBu_BQTYCBZGPianQu + "']").attr('checked', true);
                        $(":checkbox[name='TBu_BQTYCBZGChuanKong'][value='" + json.TBu_BQTYCBZGChuanKong + "']").attr('checked', true);
                        $(":radio[name='TBu_KQKouChun'][value='" + json.TBu_KQKouChun + "']").attr('checked', true);
                        $(":radio[name='TBu_KQNianMo'][value='" + json.TBu_KQNianMo + "']").attr('checked', true);
                        $("#TBu_KQNMForYC").val(json.TBu_KQNMForYC);
                        $(":radio[name='TBu_KQSXDGKaiKou'][value='" + json.TBu_KQSXDGKaiKou + "']").attr('checked', true);
                        $("#TBu_KQSXDGKKForYC").val(json.TBu_KQSXDGKKForYC);
                        $(":radio[name='TBu_KQShe'][value='" + json.TBu_KQShe + "']").attr('checked', true);
                        $("#TBu_KQSForYC").val(json.TBu_KQSForYC);
                        $(":radio[name='TBu_KQChiYin'][value='" + json.TBu_KQChiYin + "']").attr('checked', true);
                        $(":radio[name='TBu_KQChiLie'][value='" + json.TBu_KQChiLie + "']").attr('checked', true);
                        $(":radio[name='TBu_KQBTaoTi'][value='" + json.TBu_KQBTaoTi + "']").attr('checked', true);
                        $("#TBu_KQBTTForZD").val(json.TBu_KQBTTForZD);
                        $(":radio[name='TBu_KQYan'][value='" + json.TBu_KQYan + "']").attr('checked', true);
                        $(":radio[name='TBu_KQShengYin'][value='" + json.TBu_KQShengYin + "']").attr('checked', true);
                        $(":radio[name='JBu_DKangGan'][value='" + json.JBu_DKangGan + "']").attr('checked', true);
                        $(":radio[name='JBu_QiGuan'][value='" + json.JBu_QiGuan + "']").attr('checked', true);
                        $("#JBu_QGForPY").val(json.JBu_QGForPY);
                        $(":radio[name='JBu_JJingMai'][value='" + json.JBu_JJingMai + "']").attr('checked', true);
                        $(":radio[name='JBu_JDMBoDoong'][value='" + json.JBu_JDMBoDoong + "']").attr('checked', true);
                        $("#JBu_JDMBDForAll").val(json.JBu_JDMBDForAll);
                        $(":radio[name='JBu_GJJMHLiuZheng'][value='" + json.JBu_GJJMHLiuZheng + "']").attr('checked', true);
                        $(":radio[name='JBu_JZhuangXian'][value='" + json.JBu_JZhuangXian + "']").attr('checked', true);
                        $("#JBu_JZXForZDZ").val(json.JBu_JZXForZDZ);
                        $("#JBu_JZXForZDY").val(json.JBu_JZXForZDY);
                        $(":checkbox[name='JBu_JZXZhiRuan'][value='" + json.JBu_JZXZhiRuan + "']").attr('checked', true);
                        $(":checkbox[name='JBu_JZXZhiYing'][value='" + json.JBu_JZXZhiYing + "']").attr('checked', true);
                        $(":checkbox[name='JBu_JZXYaTong'][value='" + json.JBu_JZXYaTong + "']").attr('checked', true);
                        $(":checkbox[name='JBu_JZXZhenChan'][value='" + json.JBu_JZXZhenChan + "']").attr('checked', true);
                        $(":checkbox[name='JBu_JZXXGZaYin'][value='" + json.JBu_JZXXGZaYin + "']").attr('checked', true);
                        $(":radio[name='XBu_XiongKuo'][value='" + json.XBu_XiongKuo + "']").attr('checked', true);
                        $(":radio[name='XBu_RuFang'][value='" + json.XBu_RuFang + "']").attr('checked', true);
                        $("#XBu_RFForYC").val(json.XBu_RFForYC);
                        $(":radio[name='Fei_SZHXYunDong'][value='" + json.Fei_SZHXYunDong + "']").attr('checked', true);
                        $("#Fei_SZHXYDForYC").val(json.Fei_SZHXYDForYC);
                        $(":radio[name='Fei_SZLJianXi'][value='" + json.Fei_SZLJianXi + "']").attr('checked', true);
                        $("#Fei_SZLJXBWForAll").val(json.Fei_SZLJXBWForAll);
                        $(":radio[name='Fei_CZYuChan'][value='" + json.Fei_CZYuChan + "']").attr('checked', true);
                        $("#Fei_CZYCForYC").val(json.Fei_CZYCForYC);
                        $(":radio[name='Fei_CZXMMCaGan'][value='" + json.Fei_CZXMMCaGan + "']").attr('checked', true);
                        $("#Fei_CZXMMCGForY").val(json.Fei_CZXMMCGForY);
                        $(":radio[name='Fei_CZPXNFaGan'][value='" + json.Fei_CZPXNFaGan + "']").attr('checked', true);
                        $("#Fei_CZPXNFGForY").val(json.Fei_CZPXNFGForY);
                        $(":radio[name='Fei_KouZhen'][value='" + json.Fei_KouZhen + "']").attr('checked', true);
                        $("#Fei_KZForAll").val(json.Fei_KZForAll);
                        $("#Fei_FXJJJiaXianY").val(json.Fei_FXJJJiaXianY);
                        $("#Fei_FXJJJiaXianZ").val(json.Fei_FXJJJiaXianZ);
                        $("#Fei_FXJSGZhongXianY").val(json.Fei_FXJSGZhongXianY);
                        $("#Fei_FXJSGZhongXianZ").val(json.Fei_FXJSGZhongXianZ);
                        $("#Fei_FXJYZhongXianY").val(json.Fei_FXJYZhongXianY);
                        $("#Fei_FXJYZhongXianZ").val(json.Fei_FXJYZhongXianZ);
                        $("#Fei_FXJYDongDuY").val(json.Fei_FXJYDongDuY);
                        $("#Fei_FXJYDongDuZ").val(json.Fei_FXJYDongDuZ);
                        $(":radio[name='Fei_TZHuXi'][value='" + json.Fei_TZHuXi + "']").attr('checked', true);
                        $(":radio[name='Fei_TZHXiYin'][value='" + json.Fei_TZHXiYin + "']").attr('checked', true);
                        $("#Fei_TZHXYForYC").val(json.Fei_TZHXYForYC);
                        $(":radio[name='Fei_TZLuoYing'][value='" + json.Fei_TZLuoYing + "']").attr('checked', true);
                        $("#Fei_TZLYForY").val(json.Fei_TZLYForY);
                        $(":radio[name='Fei_TZYYChuanDao'][value='" + json.Fei_TZYYChuanDao + "']").attr('checked', true);
                        $("#Fei_TZYYCDForYC").val(json.Fei_TZYYCDForYC);
                        $(":radio[name='Fei_TZXMMCaYin'][value='" + json.Fei_TZXMMCaYin + "']").attr('checked', true);
                        $("#Fei_XMMCYForY").val(json.Fei_XMMCYForY);
                        $(":radio[name='Xin_SZXQQLongQi'][value='" + json.Xin_SZXQQLongQi + "']").attr('checked', true);
                        $(":radio[name='Xin_SZXJBDWeiZhi'][value='" + json.Xin_SZXJBDWeiZhi + "']").attr('checked', true);
                        $("#Xin_SZXJBOWZForYW").val(json.Xin_SZXJBOWZForYW);
                        $(":radio[name='Xin_SZXJBoDong'][value='" + json.Xin_SZXJBoDong + "']").attr('checked', true);
                        $(":radio[name='Xin_SZXQQYCBoDong'][value='" + json.Xin_SZXQQYCBoDong + "']").attr('checked', true);
                        $("#Xin_SZXQQYCBDForY").val(json.Xin_SZXQQYCBDForY);
                        $(":radio[name='Xin_CZXJBoDong'][value='" + json.Xin_CZXJBoDong + "']").attr('checked', true);
                        $(":radio[name='Xin_CZZhenChan'][value='" + json.Xin_CZZhenChan + "']").attr('checked', true);
                        $("#Xin_ZCForY").val(json.Xin_ZCForY);
                        $(":radio[name='Xin_CZXBMCaGan'][value='" + json.Xin_CZXBMCaGan + "']").attr('checked', true);
                        $(":radio[name='Xin_KZXDZYinJie'][value='" + json.Xin_KZXDZYinJie + "']").attr('checked', true);
                        $("#Xin_KZYEr").val(json.Xin_KZYEr);
                        $("#Xin_KZZEr").val(json.Xin_KZZEr);
                        $("#Xin_KZYSan").val(json.Xin_KZYSan);
                        $("#Xin_KZZSan").val(json.Xin_KZZSan);
                        $("#Xin_KZYSi").val(json.Xin_KZYSi);
                        $("#Xin_KZZSi").val(json.Xin_KZZSi);
                        $("#Xin_KZYWu").val(json.Xin_KZYWu);
                        $("#Xin_KZZWu").val(json.Xin_KZZWu);
                        $("#Xin_KZZXian").val(json.Xin_KZZXian);
                        $("#Xin_TZXinLvC").val(json.Xin_TZXinLvC);
                        $(":radio[name='Xin_TZXinLv'][value='" + json.Xin_TZXinLv + "']").attr('checked', true);
                        $("#Xin_TZXinYin").val(json.Xin_TZXinYin);
                        $(":checkbox[name='Xin_ZWXGWYCXGuanZheng'][value='" + json.Xin_ZWXGWYCXGuanZheng + "']").attr('checked', true);
                        $(":checkbox[name='Xin_ZWXGQJiYin'][value='" + json.Xin_ZWXGQJiYin + "']").attr('checked', true);
                        $(":checkbox[name='Xin_ZWXGDDSChongYin'][value='" + json.Xin_ZWXGDDSChongYin + "']").attr('checked', true);
                        $(":checkbox[name='Xin_ZWXGSChongMai'][value='" + json.Xin_ZWXGSChongMai + "']").attr('checked', true);
                        $(":checkbox[name='Xin_ZWXGMXXGBoDong'][value='" + json.Xin_ZWXGMXXGBoDong + "']").attr('checked', true);
                        $(":checkbox[name='Xin_ZWXGMBDuanChu'][value='" + json.Xin_ZWXGMBDuanChu + "']").attr('checked', true);
                        $(":checkbox[name='Xin_ZWXGQiMai'][value='" + json.Xin_ZWXGQiMai + "']").attr('checked', true);
                        $(":checkbox[name='Xin_ZWXGJTiMai'][value='" + json.Xin_ZWXGJTiMai + "']").attr('checked', true);
                        $("#Xin_ZWXGQiTa").val(json.Xin_ZWXGQiTa);
                        $("#FBu_ShiZhen").val(json.FBu_ShiZhen);
                        $("#FBu_CZRouRuan").val(json.FBu_CZRouRuan);
                        $(":radio[name='FBu_CZFJJinZhang'][value='" + json.FBu_CZFJJinZhang + "']").attr('checked', true);
                        $("#FBu_CZFJJZForYou").val(json.FBu_CZFJJZForYou);
                        $(":radio[name='FBu_CZYaTong'][value='" + json.FBu_CZYaTong + "']").attr('checked', true);
                        $("#FBu_CZYTForYou").val(json.FBu_CZYTForYou);
                        $(":radio[name='FBu_CZFTiaoTong'][value='" + json.FBu_CZFTiaoTong + "']").attr('checked', true);
                        $("#FBu_CZFTTForYou").val(json.FBu_CZFTTForYou);
                        $(":radio[name='FBu_CZYBZhenChan'][value='" + json.FBu_CZYBZhenChan + "']").attr('checked', true);
                        $(":radio[name='FBu_CZZShuiSheng'][value='" + json.FBu_CZZShuiSheng + "']").attr('checked', true);
                        $(":radio[name='FBu_CZFBBaoKuai'][value='" + json.FBu_CZFBBaoKuai + "']").attr('checked', true);
                        $("#FBu_CZFBBKForYou").val(json.FBu_CZFBBKForYou);
                        $("#FBu_CZFBBKTZMiaoShu").val(json.FBu_CZFBBKTZMiaoShu);
                        $("#FBu_CZGan").val(json.FBu_CZGan);
                        $("#FBu_CZDanNang").val(json.FBu_CZDanNang);
                        $("#FBu_CZPi").val(json.FBu_CZPi);
                        $("#FBu_CZShen").val(json.FBu_CZShen);
                        $(":radio[name='FBu_KZGZYinJie'][value='" + json.FBu_KZGZYinJie + "']").attr('checked', true);
                        $("#FBu_KZSGZhongXian").val(json.FBu_KZSGZhongXian);
                        $(":radio[name='FBu_KZYDXZhuoYin'][value='" + json.FBu_KZYDXZhuoYin + "']").attr('checked', true);
                        $(":radio[name='FBu_KZSQKouTong'][value='" + json.FBu_KZSQKouTong + "']").attr('checked', true);
                        $("#FBu_KZQiTa").val(json.FBu_KZQiTa);
                        $(":radio[name='FBu_TZCMinYin'][value='" + json.FBu_TZCMinYin + "']").attr('checked', true);
                        $(":radio[name='FBu_TZXGZaYin'][value='" + json.FBu_TZXGZaYin + "']").attr('checked', true);
                        $("#FBu_TZXGZYForY").val(json.FBu_TZXGZYForY);
                        $(":radio[name='FBu_TZQGShuiSheng'][value='" + json.FBu_TZQGShuiSheng + "']").attr('checked', true);
                        $(":radio[name='GMZChang'][value='" + json.GMZChang + "']").attr('checked', true);
                        $("#GMZChangForY").val(json.GMZChangForY);
                        $(":radio[name='SZQi'][value='" + json.SZQi + "']").attr('checked', true);
                        $("#SZQiForY").val(json.SZQiForY);
                        $(":radio[name='GGJRou_JiZhu'][value='" + json.GGJRou_JiZhu + "']").attr('checked', true);
                        $("#GGJRou_JZForJX").val(json.GGJRou_JZForJX);
                        $("#GGJRou_QiTa").val(json.GGJRou_QiTa);
                        $(":radio[name='GGJRou_SiZhi'][value='" + json.GGJRou_SiZhi + "']").attr('checked', true);
                        $("#SJXiTong").val(json.SJXiTong);
                        $("#ZKQingKuang").val(json.ZKQingKuang);
                        $("#SYSJQXJianCha").val(json.SYSJQXJianCha);
                        $("#BLZhaiYao").val(json.BLZhaiYao);
                        $("#CBZhenDuan").val(json.CBZhenDuan);
                        $("#RYZhenDuan").val(json.RYZhenDuan);
                        $("#XZZhenDuan").val(json.XZZhenDuan);
                        $("#Reviewer").val(json.Reviewer);
                        $("#ReviewerDate").val(json.ReviewerDate);

                    }
                },
                error: function () {
                    alert("系统繁忙，请联系管理员");
                }
            });
        }
    </script>
</head>
<body style="background-color: #efebef;">
    <form id="form1">
        <div align="center">
            <input  type="hidden" id="Id"name="Id" />
            <table width="100%" border="0" style="border-collapse: collapse" cellpadding="0" cellspacing="1" class="detailTable">
                <tr>
                    <td height="24" align="center" colspan="10" class="detailHead">大病历</td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">姓名<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;">
                        <span class="detailContent" style="height: 15px">
                            <input type="text" id="StudentsRealName" name="StudentsRealName" readonly="readonly" style="width: 100px;"/>
                            <input type="hidden" id="StudentsName" name="StudentsName"/>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">培训基地<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;">
                        <span class="detailContent" style="height: 15px">
                            <input type="text" id="TrainingBaseName" name="TrainingBaseName" readonly="readonly" style="width: 120px;" />
                            <input type="hidden" id="TrainingBaseCode" name="TrainingBaseCode" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">专业基地<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;">
                        <span class="detailContent" style="height: 15px">
                            <input type="text" id="ProfessionalBaseName" name="ProfessionalBaseName" readonly="readonly" style="width: 100px;" />
                            <input type="hidden" id="ProfessionalBaseCode" name="ProfessionalBaseCode" />
                        </span>
                    </td>
                    <td width="11%" class="detailTitle" style="height: 15px;">轮转科室<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;">
                        <span class="detailContent" style="height: 15px">
                            <select id="RotaryDept" name="RotaryDept" style="width:150px">
                               <option value="" >==请选择==</option>
                            </select><input type="hidden" id="DeptName" name="DeptName" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">指导医师<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;">
                        <span class="detailContent" style="height: 15px">
                            <select id="Teacher" name="Teacher" style="width:100px">
                                <option value="">==请选择==</option>
                            </select><input type="hidden" id="TeacherName" name="TeacherName" />
                        </span>
                    </td>
                </tr>
                <tr><td height="1" colspan="10"><hr style="width:100%;color:#000;" size="1" /></td></tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">门诊号<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;" >
                        <span class="detailContent" style="height: 15px">
                            <input type="text" name="PatientNo" id="PatientNo" style="width:100px" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">住院号<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;" >
                        <span class="detailContent" style="height: 15px">
                            <input type="text" name="InhospitalNo" id="InhospitalNo" style="width:100px" />
                        </span>
                    </td>
                    <td class="detailContent" style="height:15px;" colspan="6"></td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">患者姓名<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;" >
                        <span class="detailContent" style="height: 15px">
                            <input type="text" name="PatientName" id="PatientName" style="width:100px" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">性别<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="Man" name="sex" value="男"/>男</label>
                            <label><input type="radio" id="Woman" name="sex" value="女" />女</label>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">年龄<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;" >
                        <span class="detailContent" style="height: 15px">
                            <input type="text" name="Age" id="Age" style="width:100px" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">职业<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;" >
                        <span class="detailContent" style="height: 15px">
                            <input type="text" name="Job" id="Job" style="width:100px" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">民族<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;" >
                        <span class="detailContent" style="height: 15px">
                            <select id="Nation" name="Nation" style="width:100px">
                                <option value="">==请选择==</option>
                                <option value="汉族">汉族</option>
                                <option value="蒙古族">蒙古族</option>
                                <option value="彝族">彝族</option>
                                <option value="侗族">侗族</option>
                                <option value="哈萨克族">哈萨克族</option>
                                <option value="畲族">畲族</option>
                                <option value="纳西族">纳西族</option>
                                <option value="仫佬族">仫佬族</option>
                                <option value="仡佬族">仡佬族</option>
                                <option value="怒族">怒族</option>
                                <option value="保安族">保安族</option>
                                <option value="鄂伦春族">鄂伦春族</option>
                                <option value="回族">回族</option>
                                <option value="壮族">壮族</option>
                                <option value="瑶族">瑶族</option>
                                <option value="傣族">傣族</option>
                                <option value="高山族">高山族</option>
                                <option value="景颇族">景颇族</option>
                                <option value="羌族">羌族</option>
                                <option value="锡伯族">锡伯族</option>
                                <option value="乌孜别克族">乌孜别克族</option>
                                <option value="裕固族">裕固族</option>
                                <option value="赫哲族">赫哲族</option>
                                <option value="藏族">藏族</option>
                                <option value="布依族">布依族</option>
                                <option value="白族">白族</option>
                                <option value="黎族">黎族</option>
                                <option value="拉祜族">拉祜族</option>
                                <option value="柯尔克孜族">柯尔克孜族</option>
                                <option value="布朗族">布朗族</option>
                                <option value="阿昌族">阿昌族</option>
                                <option value="俄罗斯族">俄罗斯族</option>
                                <option value="京族">京族</option>
                                <option value="门巴族">门巴族</option>
                                <option value="维吾尔族">维吾尔族</option>
                                <option value="朝鲜族">朝鲜族</option>
                                <option value="土家族">土家族</option>
                                <option value="傈僳族">傈僳族</option>
                                <option value="水族">水族</option>
                                <option value="土族">土族</option>
                                <option value="撒拉族">撒拉族</option>
                                <option value="普米族">普米族</option>
                                <option value="鄂温克族">鄂温克族</option>
                                <option value="塔塔尔族">塔塔尔族</option>
                                <option value="珞巴族">珞巴族</option>
                                <option value="苗族">苗族</option>
                                <option value="满族">满族</option>
                                <option value="哈尼族">哈尼族</option>
                                <option value="佤族">佤族</option>
                                <option value="东乡族">东乡族</option>
                                <option value="达斡尔族">达斡尔族</option>
                                <option value="毛南族">毛南族</option>
                                <option value="塔吉克族">塔吉克族</option>
                                <option value="德昂族">德昂族</option>
                                <option value="独龙族">独龙族</option>
                                <option value="基诺族">基诺族</option>
                            </select>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">婚姻<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;"colspan="2" >
                        <span class="detailContent" style="height: 15px">
                           <select id="Marriage" name="Marriage" style="width:100px"">
                               <option value="">==请选择==</option>
                               <option value="未婚">未婚</option>
                               <option value="已婚">已婚</option>
                               <option value="离婚">离婚</option>
                               <option value="再婚">再婚</option>
                               <option value="丧偶">丧偶</option>
                               <option value="独居">独居</option>
                               <option value="未明婚姻">未明婚姻</option>
                           </select>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">出生地<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="6">
                        <span class="detailContent" style="height: 15px">
                           <select id="BirthProvince" name="BirthProvince" style="width:100px;">
                               <option value="">==请选择==</option>
                           </select><input type="hidden" id="BirthProvinceName"name="BirthProvinceName" />
                            <select id="BirthCity" name="BirthCity" style="width:100px;">
                               <option value="">==请选择==</option>
                           </select><input type="hidden" id="BirthCityName"name="BirthCityName" />
                            <select id="BirthArea" name="BirthArea" style="width:100px;">
                               <option value="">==请选择==</option>
                           </select><input type="hidden" id="BirthAreaName"name="BirthAreaName" />
                            <input type="text" id="BirthDetailAddress" name="BirthDetailAddress" style="width:300px" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">工作单位<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="2">
                        <span class="detailContent" style="height: 15px">
                           <input type="text" name="Company" id="Company" style="width:200px;" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">现住址<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="6">
                        <span class="detailContent" style="height: 15px">
                           <select id="NowProvince" name="NowProvince" style="width:100px;">
                               <option value="">==请选择==</option>
                           </select><input type="hidden" id="NowProvinceName" name="NowProvinceName" />
                            <select id="NowCity" name="NowCity" style="width:100px;">
                               <option value="">==请选择==</option>
                           </select><input type="hidden" id="NowCityName" name="NowCityName" />
                            <select id="NowArea" name="NowArea" style="width:100px;">
                               <option value="">==请选择==</option>
                           </select><input type="hidden" id="NowAreaName" name="NowAreaName" />
                            <input type="text" id="NowDetailAddress" name="NowDetailAddress" style="width:300px" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">电话<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;">
                        <span class="detailContent" style="height: 15px">
                           <input type="text" name="Phone" id="Phone" style="width:100px;" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">入院日期<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;">
                        <span class="detailContent" style="height: 15px">
                           <input type="text" name="InhospitalDate" id="InhospitalDate" style="width:100px;" onclick="WdatePicker({ maxDate: '%y-%M-%d' });"/>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">记录日期<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;">
                        <span class="detailContent" style="height: 15px">
                           <input type="text" name="RecordDate" id="RecordDate" style="width:100px;" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH时', maxDate: '%y-%M-%d' });"/>
                        </span>
                    </td>
                    <td width="13%" class="detailTitle" style="height: 15px;">病史叙述者<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;">
                        <span class="detailContent" style="height: 15px">
                           <input type="text" name="MedicalHistorySpeaker" id="MedicalHistorySpeaker" style="width:100px;" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">可靠程度<span style="color: #ff0000">*</span></td>
                    <td width="10%" class="detailContent" style="height:15px;">
                        <span class="detailContent" style="height: 15px">
                           <select id="ReliableDegree" name="ReliableDegree" style="width:100px">
                               <option value="">==不清楚==</option>
                               <option value="非常可靠">非常可靠</option>
                               <option value="较可靠">较可靠</option>
                               <option value="可靠">可靠</option>
                               <option value="不可靠">不可靠</option>
                           </select>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td  style="height: 25px;text-align:center;font-weight:bold;" class="detailContent" colspan="10">病史</td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight:bold;">主诉</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="9">
                        <span class="detailContent" style="height: 15px">
                           <textarea id="ZSu" name="ZSu" rows="" cols="" style="width:100%;height:70px;"></textarea>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight:bold;">现病史</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="9">
                        <span class="detailContent" style="height: 15px">
                           <textarea id="XBShi" name="XBShi"rows="" cols=""  style="width:100%;height:70px;"></textarea>
                        </span>
                    </td>
                </tr>
                <%--<tr><td height="0" colspan="10"><hr style="width:100%;color:#000;" size="1" /></td></tr>--%>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight:bold;" rowspan="6">既往史</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">平素健康状况</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="8">
                        <span class="detailContent" style="height: 15px">
                           <label><input type="radio" id="JWShi_LiangHao" name="JWShi_PSJKZhuangKuang" value="良好"/>良好</label>
                            <label><input type="radio" id="JWShi_YiBan" name="JWShi_PSJKZhuangKuang"value="一般" />一般</label>
                            <label><input type="radio" id="JWShi_JiaoCha" name="JWShi_PSJKZhuangKuang" value="较差"/>较差</label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="detailTitle" style="height: 15px;">曾患疾病和传染病史</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="8">
                        <span class="detailContent" style="height: 15px">
                           <textarea id="JWShi_CHJBHCRBingShi" name="JWShi_CHJBHCRBingShi"rows="" cols=""  style="width:100%;height:70px;"></textarea>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">预防接种史</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="8">
                        <span class="detailContent" style="height: 15px">
                           <textarea id="JWShi_YFJZhongShi" name="JWShi_YFJZhongShi"rows="" cols=""  style="width:100%;height:70px;"></textarea>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">过敏史</td>
                    <td width="10%" class="detailContent" style="height:15px;">
                        <span class="detailContent" style="height: 15px">
                           <label><input type="radio" id="JWShi_Wu" name="JWShi_GMinShi" value="无" onclick="$('#JWShi_GMinYuan').attr('disabled', true); $('#JWShi_LCBiaoXian').attr('disabled', true);"/>无</label>
                            <label><input type="radio" id="JWShi_You" name="JWShi_GMinShi" value="有" onclick="$('#JWShi_GMinYuan').attr('disabled', false); $('#JWShi_LCBiaoXian').attr('disabled', false);"/>有</label>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">过敏原</td>
                    <td width="10%" class="detailContent" style="height:15px;">
                        <span class="detailContent" style="height: 15px">
                           <input type="text" id="JWShi_GMinYuan" name="JWShi_GMinYuan" style="width:100px;" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">临床表现</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="4">
                        <span class="detailContent" style="height: 15px">
                           <textarea id="JWShi_LCBiaoXian" name="JWShi_LCBiaoXian"rows="" cols=""  style="width:100%;height:200%;"></textarea>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">外伤史</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="8">
                        <span class="detailContent" style="height: 15px">
                           <textarea id="JWShi_WShangShi" name="JWShi_WShangShi"rows="" cols=""  style="width:100%;height:70px;"></textarea>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">手术史</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="8">
                        <span class="detailContent" style="height: 15px">
                           <textarea id="JWShi_SShuShi" name="JWShi_SShuShi"rows="" cols=""  style="width:100%;height:70px;"></textarea>
                        </span>
                    </td>
                </tr>
                <%--<tr><td height="0" colspan="10"><hr style="width:100%;color:#000;" size="1" /></td></tr>--%>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight:bold;border-top-color:black;border:1px;" rowspan="8">系统回顾</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">呼吸系统</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="8">
                        <span class="detailContent" style="height: 15px">
                            <label><input id="XTHGu_KeSou" name="XTHGu_KeSou" type="checkbox" value="咳嗽" style="width:20px;"/>咳嗽</label>
                            <label><input id="XTHGu_KeTan" name="XTHGu_KeTan" type="checkbox" value="咳痰" style="width:20px;"/>咳痰</label>
                           <label> <input id="XTHGu_KaXie" name="XTHGu_KaXie" type="checkbox" value="咯血" style="width:20px;"/>咯血</label>
                            <label><input id="XTHGu_ChuanXi" name="XTHGu_ChuanXi" type="checkbox" value="喘息" style="width:20px;"/>喘息</label>
                            <label><input id="XTHGu_XiongTong" name="XTHGu_XiongTong" type="checkbox" value="胸痛" style="width:20px;"/>胸痛</label>
                            <label><input id="XTHGu_HXKunNan" name="XTHGu_HXKunNan" type="checkbox" value="呼吸困难" style="width:20px;"/>呼吸困难</label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">循环系统</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="8">
                        <span class="detailContent" style="height: 15px">
                           <label> <input id="XTHGu_XinJi" name="XTHGu_XinJi" type="checkbox" value="心悸" style="width:20px;"/>心悸</label>
                           <label> <input id="XTHGu_HDHQiCu" name="XTHGu_HDHQiCu" type="checkbox" value="活动后气促" style="width:20px;"/>活动后气促</label>
                           <label> <input id="XTHGu_XZShuiZhong" name="XTHGu_XZShuiZhong" type="checkbox" value="下肢水肿" style="width:20px;"/>下肢水肿</label>
                            <label><input id="XTHGu_XQQuTong" name="XTHGu_XQQuTong" type="checkbox" value="心前区痛" style="width:20px;"/>心前区痛</label>
                           <label> <input id="XTHGu_XYZengGao" name="XTHGu_XYZengGao" type="checkbox" value="血压增高" style="width:20px;"/>血压增高</label>
                           <label> <input id="XTHGu_YunJue" name="XTHGu_YunJue" type="checkbox" value="晕厥" style="width:20px;"/>晕厥</label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">消化系统</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="8">
                        <span class="detailContent" style="height: 15px">
                           <label> <input id="XTHGu_SYJianTui" name="XTHGu_SYJianTui" type="checkbox" value="食欲减退" style="width:20px;"/>食欲减退</label>
                            <label><input id="XTHGu_FanSuan" name="XTHGu_FanSuan" type="checkbox" value="反酸" style="width:20px;"/>反酸</label>
                            <label><input id="XTHGu_AiQi" name="XTHGu_AiQi" type="checkbox" value="嗳气" style="width:20px;"/>嗳气</label>
                            <label><input id="XTHGu_EXin" name="XTHGu_EXin" type="checkbox" value="恶心" style="width:20px;"/>恶心</label>
                            <label><input id="XTHGu_OuTu" name="XTHGu_OuTu" type="checkbox" value="呕吐" style="width:20px;"/>呕吐</label>
                            <label><input id="XTHGu_FuZhang" name="XTHGu_FuZhang" type="checkbox" value="腹胀" style="width:20px;"/>腹胀</label>
                            <label><input id="XTHGu_FuTong" name="XTHGu_FuTong" type="checkbox" value="腹痛" style="width:20px;"/>腹痛</label>
                           <label> <input id="XTHGu_BianMi" name="XTHGu_BianMi" type="checkbox" value="便秘" style="width:20px;"/>便秘</label>
                           <label> <input id="XTHGu_FuXie" name="XTHGu_FuXie" type="checkbox" value="腹泻" style="width:20px;"/>腹泻</label>
                           <label> <input id="XTHGu_OuXue" name="XTHGu_OuXue" type="checkbox" value="呕血" style="width:20px;"/>呕血</label>
                           <label> <input id="XTHGu_HeiBian" name="XTHGu_HeiBian" type="checkbox" value="黑便" style="width:20px;"/>黑便</label>
                            <label><input id="XTHGu_BianXue" name="XTHGu_BianXue" type="checkbox" value="便血" style="width:20px;"/>便血</label>
                           <label> <input id="XTHGu_HuangDan" name="XTHGu_HuangDan" type="checkbox" value="黄疸" style="width:20px;"/>黄疸</label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">泌尿生殖系统</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="8">
                        <span class="detailContent" style="height: 15px">
                           <label> <input id="XTHGu_YaoTong" name="XTHGu_YaoTong" type="checkbox" value="腰痛" style="width:20px;"/>腰痛</label>
                            <label><input id="XTHGu_NiaoPin" name="XTHGu_NiaoPin" type="checkbox" value="尿频" style="width:20px;"/>尿频</label>
                            <label><input id="XTHGu_NiaoJi" name="XTHGu_NiaoJi" type="checkbox" value="尿急" style="width:20px;"/>尿急</label>
                            <label><input id="XTHGu_NiaoTong" name="XTHGu_NiaoTong" type="checkbox" value="尿痛" style="width:20px;"/>尿痛</label>
                            <label><input id="XTHGu_PNKunNan" name="XTHGu_PNKunNan" type="checkbox" value="排尿困难" style="width:20px;"/>排尿困难</label>
                            <label><input id="XTHGu_XueNiao" name="XTHGu_XueNiao" type="checkbox" value="血尿" style="width:20px;"/>血尿</label>
                            <label><input id="XTHGu_NLYiChang" name="XTHGu_NLYiChang" type="checkbox" value="尿量异常" style="width:20px;"/>尿量异常</label>
                            <label><input id="XTHGu_YNZengDuo" name="XTHGu_YNZengDuo" type="checkbox" value="夜尿增多" style="width:20px;"/>夜尿增多</label>
                            <label><input id="XTHGu_ShuiZhong" name="XTHGu_ShuiZhong" type="checkbox" value="水肿" style="width:20px;"/>水肿</label>
                            <label><input id="XTHGu_YBSaoYang" name="XTHGu_YBSaoYang" type="checkbox" value="阴部瘙痒" style="width:20px;"/>阴部瘙痒</label>
                            <label><input id="XTHGu_YBKuiLan" name="XTHGu_YBKuiLan" type="checkbox" value="阴部溃烂" style="width:20px;"/>阴部溃烂</label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">造血系统</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="8">
                        <span class="detailContent" style="height: 15px">
                           <label> <input id="XTHGu_FaLi" name="XTHGu_FaLi" type="checkbox" value="乏力" style="width:20px;"/>乏力</label>
                            <label><input id="XTHGu_TouYun" name="XTHGu_TouYun" type="checkbox" value="头晕" style="width:20px;"/>头晕</label>
                            <label><input id="XTHGu_YanHua" name="XTHGu_YanHua" type="checkbox" value="眼花" style="width:20px;"/>眼花</label>
                            <label><input id="XTHGu_YYChuXue" name="XTHGu_YYChuXue" type="checkbox" value="牙龈出血" style="width:20px;"/>牙龈出血</label>
                            <label><input id="XTHGu_BChuXue" name="XTHGu_BChuXue" type="checkbox" value="鼻出血" style="width:20px;"/>鼻出血</label>
                            <label><input id="XTHGu_PXChuXue" name="XTHGu_PXChuXue" type="checkbox" value="皮下出血" style="width:20px;"/>皮下出血</label>
                            <label><input id="XTHGu_GuTong" name="XTHGu_GuTong" type="checkbox" value="骨痛" style="width:20px;"/>骨痛</label>
                        </span>
                    </td>
                </tr>
                 <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">内分泌与代谢系统</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="8">
                        <span class="detailContent" style="height: 15px">
                            <label><input id="XTHGu_SYKangJin" name="XTHGu_SYKangJin" type="checkbox" value="食欲亢进" style="width:20px;"/>食欲亢进</label>
                            <label><input id="XTHGu_PaRe" name="XTHGu_PaRe" type="checkbox" value="怕热" style="width:20px;"/>怕热</label>
                           <label> <input id="XTHGu_DuoHan" name="XTHGu_DuoHan" type="checkbox" value="多汗" style="width:20px;"/>多汗</label>
                           <label> <input id="XTHGu_WeiHan" name="XTHGu_WeiHan" type="checkbox" value="畏寒" style="width:20px;"/>畏寒</label>
                            <label><input id="XTHGu_DuoYin" name="XTHGu_DuoYin" type="checkbox" value="多饮" style="width:20px;"/>多饮</label>
                            <label><input id="XTHGu_DuoNiao" name="XTHGu_DuoNiao" type="checkbox" value="多尿" style="width:20px;"/>多尿</label>
                            <label><input id="XTHGu_SSZhenChan" name="XTHGu_SSZhenChan" type="checkbox" value="双手震颤" style="width:20px;"/>双手震颤</label>
                            <label><input id="XTHGu_XGGaiBian" name="XTHGu_XGGaiBian" type="checkbox" value="性格改变" style="width:20px;"/>性格改变</label>
                            <label><input id="XTHGu_XZFeiPang" name="XTHGu_XZFeiPang" type="checkbox" value="显著肥胖" style="width:20px;"/>显著肥胖</label>
                            <label><input id="XTHGu_MXXiaoShou" name="XTHGu_MXXiaoShou" type="checkbox" value="明显消瘦" style="width:20px;"/>明显消瘦</label>
                            <label> <input id="XTHGu_MFZengDuo" name="XTHGu_MFZengDuo" type="checkbox" value="毛发增多" style="width:20px;"/>毛发增多</label>
                             <label><input id="XTHGu_MFTuoLuo" name="XTHGu_MFTuoLuo" type="checkbox" value="毛发脱落" style="width:20px;"/>毛发脱落</label>
                             <label><input id="XTHGu_SSChenZhuo" name="XTHGu_SSChenZhuo" type="checkbox" value="色素沉着" style="width:20px;"/>色素沉着</label>
                             <label><input id="XTHGu_XGNGaiBian" name="XTHGu_XGNGaiBian" type="checkbox" value="性功能改变" style="width:20px;"/>性功能改变</label>
                             <label><input id="XTHGu_BiJing" name="XTHGu_BiJing" type="checkbox" value="闭经" style="width:20px;"/>闭经</label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">肌肉骨骼系统</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="8">
                        <span class="detailContent" style="height: 15px">
                            <label><input id="XTHGu_GJieTong" name="XTHGu_GJieTong" type="checkbox" value="关节痛" style="width:20px;"/>关节痛</label>
                            <label><input id="XTHGu_GJHongZhong" name="XTHGu_GJHongZhong" type="checkbox" value="关节红肿" style="width:20px;"/>关节红肿</label>
                            <label><input id="XTHGu_GJBianXing" name="XTHGu_GJBianXing" type="checkbox" value="关节变形" style="width:20px;"/>关节变形</label>
                            <label><input id="XTHGu_JRouTong" name="XTHGu_JRouTong" type="checkbox" value="肌肉痛" style="width:20px;"/>肌肉痛</label>
                            <label><input id="XTHGu_JRWeiSuo" name="XTHGu_JRWeiSuo" type="checkbox" value="肌肉萎缩" style="width:20px;"/>肌肉萎缩</label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">神经系统</td>
                    <td width="10%" class="detailContent" style="height:15px;" colspan="8">
                        <span class="detailContent" style="height: 15px">
                            <label><input id="XTHGu_TouTong" name="XTHGu_TouTong" type="checkbox" value="头痛" style="width:20px;"/>头痛</label>
                            <label><input id="XTHGu_XuanYun" name="XTHGu_XuanYun" type="checkbox" value="眩晕" style="width:20px;"/>眩晕</label>
                            <label><input id="XTHGu_YunJue1" name="XTHGu_YunJue1" type="checkbox" value="晕厥" style="width:20px;"/>晕厥</label>
                            <label><input id="JXTHGu_JYLJianTui" name="JXTHGu_JYLJianTui" type="checkbox" value="记忆力减退" style="width:20px;"/>记忆力减退</label>
                            <label><input id="XTHGu_SLZhangAi" name="XTHGu_SLZhangAi" type="checkbox" value="视力障碍" style="width:20px;"/>视力障碍</label>
                            <label><input id="XTHGu_ShiMian" name="XTHGu_ShiMian" type="checkbox" value="失眠" style="width:20px;"/>失眠</label>
                            <label><input id="XTHGu_YSZhangAi" name="XTHGu_YSZhangAi" type="checkbox" value="意识障碍" style="width:20px;"/>意识障碍</label>
                            <label><input id="XTHGu_ChanDong" name="XTHGu_ChanDong" type="checkbox" value="颤动" style="width:20px;"/>颤动</label>
                            <label><input id="XTHGu_ChouChu" name="XTHGu_ChouChu" type="checkbox" value="抽搐" style="width:20px;"/>抽搐</label>
                            <label><input id="XTHGu_TanHuan" name="XTHGu_TanHuan" type="checkbox" value="瘫痪" style="width:20px;"/>瘫痪</label>
                            <label><input id="XTHGu_GJYiChang" name="XTHGu_GJYiChang" type="checkbox" value="感觉异常" style="width:20px;"/>感觉异常</label>
                        </span>
                    </td>
                </tr>
               <%-- <tr><td height="0" colspan="10"><hr style="width:100%;color:#000;" size="1" /></td></tr>--%>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="4">个人史</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">出生地</td>
                    <td width="70%" class="detailContent" style="height: 15px;" colspan="5">
                        <span class="detailContent" style="height: 15px">
                            <select id="GRShi_BirthProvince" name="GRShi_BirthProvince" style="width: 100px;">
                                <option value="">==请选择==</option>
                            </select><input type="hidden" id="GRShi_BirthProvinceName" name="GRShi_BirthProvinceName" />
                            <select id="GRShi_BirthCity" name="GRShi_BirthCity" style="width: 100px;">
                                <option value="">==请选择==</option>
                            </select><input type="hidden" id="GRShi_BirthCityName" name="GRShi_BirthCityName" />
                            <select id="GRShi_BirthArea" name="GRShi_BirthArea" style="width: 100px;">
                                <option value="">==请选择==</option>
                            </select><input type="hidden" id="GRShi_BirthAreaName" name="GRShi_BirthAreaName" />
                            <input type="text" id="GRShi_BirthDetailAddress" name="GRShi_BirthDetailAddress" style="width: 150px" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">从事何种工作</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="2">
                        <span class="detailContent" style="height: 15px">
                            <input type="text" id="GRShi_CSHZGongZuo" name="GRShi_CSHZGongZuo" style="width: 150px" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">地方病地区居住情况</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <textarea id="GRShi_DFBDQJZQingKuang" name="GRShi_DFBDQJZQingKuang" rows="" cols="" style="width:100%;height:30px;"></textarea>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">冶游史</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <textarea id="GRShi_YYouShi" name="GRShi_YYouShi" rows="" cols="" style="width:100%;height:30px;"></textarea>
                        </span>
                    </td>

                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">嗜烟</td>
                    <td width="10%" class="detailContent" style="height: 15px;">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="GRShi_SYanWu" name="GRShi_ShiYan" value="无" onclick="$('#GRShi_SYanNian').attr('disabled', true).val(''); $('#GRShi_SYanZhi').attr('disabled', true).val('');"/>无</label>
                            <label><input type="radio" id="GRShi_SYanYou" name="GRShi_ShiYan" value="有" onclick="$('#GRShi_SYanNian').attr('disabled', false); $('#GRShi_SYanZhi').attr('disabled', false);"/>有</label>
                        </span>
                    </td>
                    <td width="10%" class="detailContent" style="height: 15px; text-align:left;" colspan="2">
                        约<input type="text" id="GRShi_SYanNian" name="GRShi_SYanNian" style="width:50px;" />年,平均
                        <input type="text" id="GRShi_SYanZhi" name="GRShi_SYanZhi" style="width:50px;" />支/日
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">戒烟</td>
                    <td width="10%" class="detailContent" style="height: 15px;">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="GRShi_JYanWei" name="GRShi_JieYan" value="未" onclick="$('#GRShi_JYanNian').attr('disabled', true).val('');"/>未</label>
                            <label><input type="radio" id="GRShi_JYanYi" name="GRShi_JieYan" value="已" onclick="$('#GRShi_JYanNian').attr('disabled', false);"/>已</label>
                        </span>
                    </td>
                    <td width="10%" class="detailContent" style="height: 15px; text-align:left;" colspan="3">
                        约<input type="text" id="GRShi_JYanNian" name="GRShi_JYanNian" style="width:50px;" />年
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">嗜酒</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <label>
                                <input type="radio" id="GRShi_SJiuWu" name="GRShi_ShiJiu" value="无" onclick="$('#GRShi_SJiuNian').attr('disabled', true).val(''); $('#GRShi_SJiuLiang').attr('disabled', true).val('');"/>无</label>
                            <label>
                                <input type="radio" id="GRShi_SJOuYou" name="GRShi_ShiJiu" value="偶有" onclick="$('#GRShi_SJiuNian').attr('disabled', false); $('#GRShi_SJiuLiang').attr('disabled', false);"/>偶有</label>
                            <label>
                                <input type="radio" id="GRShi_SJJingChang" name="GRShi_ShiJiu" value="经常" onclick="$('#GRShi_SJiuNian').attr('disabled', false); $('#GRShi_SJiuLiang').attr('disabled', false);"/>经常</label>
                            约<input type="text" id="GRShi_SJiuNian" name="GRShi_SJiuNian" style="width:50px;" />年,平均
                        <input type="text" id="GRShi_SJiuLiang" name="GRShi_SJiuLiang" style="width:50px;" />两/日
                        </span>
                    </td>
                    
                        
                   
                    <td width="10%" class="detailTitle" style="height: 15px;">其他</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="4">
                        <span class="detailContent" style="height: 15px">
                           <input type="text" id="GRShi_SJQiTa" name="GRShi_SJQiTa" style="width:200px;" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;">婚姻史</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">结婚年龄</td>
                    <td width="10%" class="detailContent" style="height: 15px;" >
                        <span class="detailContent" style="height: 15px">
                            <input type="text" id="HYShi_JHNianLing" name="HYShi_JHNianLing" style="width: 50px" />岁
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">配偶情况</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="7">
                        <span class="detailContent" style="height: 15px">
                            <input type="text" id="HYShi_POQingKuang" name="HYShi_POQingKuang" style="width: 300px" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold; "rowspan="3">月经史和生育史</td>
                    
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="3">
                        <span class="detailContent" style="height: 15px">
                            初潮<input type="text" id="YJSHSYShi_CChaoSui" name="YJSHSYShi_CChaoSui" style="width: 50px" />岁
                            每天持续<input type="text" id="YJSHSYShi_CChaoTian" name="YJSHSYShi_CChaoTian" style="width: 50px" />天
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">末次月经日期</td>
                    <td width="10%" class="detailContent" style="height: 15px;">
                        <span class="detailContent" style="height: 15px">
                            <input type="text" id="YJSHSYShi_MCYJRiQi" name="YJSHSYShi_MCYJRiQi" style="width: 100px" onclick="WdatePicker({ maxDate: '%y-%M-%d' });"/>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">绝经年龄</td>
                    <td width="10%" class="detailContent" style="height: 15px;" >
                        <span class="detailContent" style="height: 15px">
                            <input type="text" id="YJSHSYShi_JJNianLing" name="YJSHSYShi_JJNianLing" style="width: 50px"/>岁
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">周期</td>
                    <td width="10%" class="detailContent" style="height: 15px;" >
                        <span class="detailContent" style="height: 15px">
                            <input type="text" id="YJSHSYShi_ZhouQi" name="YJSHSYShi_ZhouQi" style="width: 50px"/>天
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">经量</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="YJSHSYShi_JLiangShao" name="YJSHSYShi_JingLiang" value="少"/>少</label>
                            <label><input type="radio" id="YJSHSYShi_JLYiBan" name="YJSHSYShi_JingLiang" value="一般"/>一般</label>
                            <label><input type="radio" id="YJSHSYShi_JLiangDuo" name="YJSHSYShi_JingLiang" value="多"/>多</label>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">痛经</td>
                    <td width="10%" class="detailContent" style="height: 15px;">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="YJSHSYShi_TJingWu" name="YJSHSYShi_TongJing" value="无"/>无</label>
                            <label><input type="radio" id="YJSHSYShi_TJingYou" name="YJSHSYShi_TongJing" value="有"/>有</label>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">经期</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="YJSHSYShi_JQGuiZe" name="YJSHSYShi_JingQi" value="规则"/>规则</label>
                            <label><input type="radio" id="YJSHSYShi_JQBGuiZe" name="YJSHSYShi_JingQi" value="不规则"/>不规则</label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="5">
                        <span class="detailContent" style="height: 15px">
                            妊娠<input type="text" id="YJSHSYShi_RenShen" name="YJSHSYShi_RenShen" style="width: 50px" />次
                            顺产<input type="text" id="YJSHSYShi_ShunChan" name="YJSHSYShi_ShunChan" style="width: 50px" />胎
                            流产<input type="text" id="YJSHSYShi_LiuChan" name="YJSHSYShi_LiuChan" style="width: 50px" />胎
                            早产<input type="text" id="YJSHSYShi_ZaoChan" name="YJSHSYShi_ZaoChan" style="width: 50px" />胎
                            死产<input type="text" id="YJSHSYShi_SiChan" name="YJSHSYShi_SiChan" style="width: 50px" />胎
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">难产及病情</td>
                    <td width="10%" class="detailContent" style="height: 15px;">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="YJSHSYShi_NCJBQingYou" name="YJSHSYShi_NCJBingQing" value="有"/>有</label>
                            <label><input type="radio" id="YJSHSYShi_NCJBQingWu" name="YJSHSYShi_NCJBingQing" value="无"/>无</label>
                        </span>
                    </td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="2">
                        <span class="detailContent" style="height: 15px">
                            子<input type="text" id="YJSHSYShi_Zi" name="YJSHSYShi_Zi" style="width: 50px" />个
                            女<input type="text" id="YJSHSYShi_Nv" name="YJSHSYShi_Nv" style="width: 50px" />个
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="2">家族史</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">父</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label>
                                <input type="radio" id="JZShi_FJianZai" name="JZShi_Fu" value="健在" onclick="$('#JZShi_FSiYin').attr('disabled', true).val('');"/>健在</label>
                            <label>
                                <input type="radio" id="JZShi_FHuanBing" name="JZShi_Fu" value="患病" onclick="$('#JZShi_FSiYin').attr('disabled', true).val('');"/>患病</label>
                            <label>
                                <input type="radio" id="JZShi_FYiGu" name="JZShi_Fu" value="已故" onclick="$('#JZShi_FSiYin').attr('disabled', false);"/>已故</label>
                            死因<input type="text" id="JZShi_FSiYin" name="JZShi_FSiYin" style="width: 120px" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">母</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <label>
                                <input type="radio" id="JZShi_MJianZai" name="JZShi_Mu" value="健在" onclick="$('#JZShi_MSiYin').attr('disabled', true).val('');"/>健在</label>
                            <label>
                                <input type="radio" id="JZShi_MHuanBing" name="JZShi_Mu" value="患病" onclick="$('#JZShi_MSiYin').attr('disabled', true).val('');"/>患病</label>
                            <label>
                                <input type="radio" id="JZShi_MYiGu" name="JZShi_Mu" value="已故" onclick="$('#JZShi_MSiYin').attr('disabled', false);"/>已故</label>
                            死因<input type="text" id="JZShi_MSiYin" name="JZShi_MSiYin" style="width: 120px" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">兄弟姐妹</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <input type="text" id="JZShi_XDJieMei" name="JZShi_XDJieMei" style="width: 300px" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">子女及其他</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <input type="text" id="JZShi_ZNJQiTa" name="JZShi_ZNJQiTa" style="width: 300px" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td  style="height: 25px;text-align:center;font-weight:bold;" class="detailContent" colspan="10">体格检查</td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;">生命体征</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="9">
                        <span class="detailContent" style="height: 15px">
                            体温<input type="text" id="SMTZheng_TiWen" name="SMTZheng_TiWen" style="width: 50px" />℃
                            脉搏<input type="text" id="SMTZheng_MaiBo" name="SMTZheng_MaiBo" style="width: 50px" />次/分
                            呼吸<input type="text" id="SMTZheng_HuXi" name="SMTZheng_HuXi" style="width: 50px" />次/分
                            血压<input type="text" id="SMTZheng_XueYa1" name="SMTZheng_XueYa1" style="width: 40px" />/<input type="text" id="SMTZheng_XueYa2" name="SMTZheng_XueYa2" style="width: 40px" />mmHg
                            体重<input type="text" id="SMTZheng_TiZhong" name="SMTZheng_TiZhong" style="width: 50px" />kg
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold; "rowspan="4">一般状况</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">发育</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="YBZKuang_FYZhangChang"name="YBZKuang_FaYu"value="正常" />正常</label>
                            <label><input type="radio" id="YBZKuang_FYBuLiang"name="YBZKuang_FaYu"value="不良" />不良</label>
                            <label><input type="radio" id="YBZKuang_FYChaoChang"name="YBZKuang_FaYu"value="超长" />超长</label>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">营养</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="YBZKuang_YYLiangHao"name="YBZKuang_YingYang"value="良好" />良好</label>
                            <label><input type="radio" id="YBZKuang_YYZhongDeng"name="YBZKuang_YingYang"value="中等" />中等</label>
                            <label><input type="radio" id="YBZKuang_YYBuLiang"name="YBZKuang_YingYang"value="不良" />不良</label>
                            <label><input type="radio" id="YBZKuang_YYEBingZhi"name="YBZKuang_YingYang"value="不良" />恶病质</label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">面容</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="YBZKuang_MRWBingRong"name="YBZKuang_MianRong"value="无病容" />无病容</label>
                            <label><input type="radio" id="YBZKuang_MRJiXing"name="YBZKuang_MianRong"value="急性" />急性</label>
                            <label><input type="radio" id="YBZKuang_MRMXBingRong"name="YBZKuang_MianRong"value="慢性病容" />慢性病容</label>
                            其他<input type="text" id="YBZKuang_QiTa" name="YBZKuang_QiTa" style="width:100px;" onfocus="$('input[name=YBZKuang_MianRong]').attr('checked',false);"/>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">表情</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="YBZKuang_BQZiRu"name="YBZKuang_BiaoQing"value="自如" />自如</label>
                            <label><input type="radio" id="YBZKuang_BQTongKu"name="YBZKuang_BiaoQing"value="痛苦" />痛苦</label>
                            <label><input type="radio" id="YBZKuang_BQYouLv"name="YBZKuang_BiaoQing"value="忧虑" />忧虑</label>
                            <label><input type="radio" id="YBZKuang_BQKongJu"name="YBZKuang_BiaoQing"value="恐惧" />恐惧</label>
                            <label><input type="radio" id="YBZKuang_BQDanMo"name="YBZKuang_BiaoQing"value="淡漠" />淡漠</label>
                            <label><input type="radio" id="YBZKuang_BQXingFen"name="YBZKuang_BiaoQing"value="兴奋" />兴奋</label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">体位</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="YBZKuang_TWZiZhu"name="YBZKuang_TiWei"value="自主" onclick="$('#YBZKuang_TWForQP').attr('disabled', true).val('');"/>自主</label>
                            <label><input type="radio" id="YBZKuang_TWBeiDong"name="YBZKuang_TiWei"value="被动" onclick="$('#YBZKuang_TWForQP').attr('disabled', true).val('');"/>被动</label>
                            <label><input type="radio" id="YBZKuang_TWQiangPo"name="YBZKuang_TiWei"value="强迫" onclick="$('#YBZKuang_TWForQP').attr('disabled', false);"/>强迫</label>
                            <input type="text" id="YBZKuang_TWForQP" name="YBZKuang_TWForQP" style="width:150px;" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">步态</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="YBZKuang_BTZhengChang"name="YBZKuang_BuTai"value="正常" onclick="$('#YBZKuang_BTForBZC').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="YBZKuang_BTBZhengChang"name="YBZKuang_BuTai"value="不正常" onclick="$('#YBZKuang_BTForBZC').attr('disabled', false);"/>不正常</label>
                            <input type="text" id="YBZKuang_BTForBZC" name="YBZKuang_BTForBZC" style="width:150px;" />
                        </span>
                    </td>
                  </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">神志</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="YBZKuang_SZQingChu"name="YBZKuang_ShenZhi"value="清楚" />清楚</label>
                            <label><input type="radio" id="YBZKuang_SZShiShui"name="YBZKuang_ShenZhi"value="嗜睡" />嗜睡</label>
                            <label><input type="radio" id="YBZKuang_SZMoHu"name="YBZKuang_ShenZhi"value="模糊" />模糊</label>
                            <label><input type="radio" id="YBZKuang_SZHunShui"name="YBZKuang_ShenZhi"value="昏睡" />昏睡</label>
                            <label><input type="radio" id="YBZKuang_SZHunMi"name="YBZKuang_ShenZhi"value="昏迷" />昏迷</label>
                            <label><input type="radio" id="YBZKuang_SZZhanWang"name="YBZKuang_ShenZhi"value="谵妄" />谵妄</label>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">配合检查</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="YBZKuang_PHJCHeZuo"name="YBZKuang_PHJianCha"value="合作" />合作</label>
                            <label><input type="radio" id="YBZKuang_PHJCBHeZuo"name="YBZKuang_PHJianCha"value="合作" />不合作</label>
                        </span>
                    </td>
                  </tr>

                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold; "rowspan="4">皮肤黏膜</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">色泽</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="PFNMo_SZZhengChang"name="PFNMo_SeZe"value="正常" />正常</label>
                            <label><input type="radio" id="PFNMo_SZChaoHong"name="PFNMo_SeZe"value="潮红" />潮红</label>
                            <label><input type="radio" id="PFNMo_SZCangBai"name="PFNMo_SeZe"value="苍白" />苍白</label>
                            <label><input type="radio" id="PFNMo_SZFaGan"name="PFNMo_SeZe"value="发绀" />发绀</label>
                            <label><input type="radio" id="PFNMo_SZHuangRan"name="PFNMo_SeZe"value="黄染" />黄染</label>
                            <label><input type="radio" id="PFNMo_SZSSChenZhuo"name="PFNMo_SeZe"value="色素沉着" />色素沉着</label>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">皮疹</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="PFNMo_PZhenWu"name="PFNMo_PiZhen"value="无" onclick="$('#PFNMo_PZLXJFenBu').attr('disabled', true).val('');"/>无</label>
                            <label><input type="radio" id="PFNMo_PZhenYou"name="PFNMo_PiZhen"value="有"onclick="$('#PFNMo_PZLXJFenBu').attr('disabled', false);" />有</label>
                            类型及分布<input type="text" id="PFNMo_PZLXJFenBu" name="PFNMo_LXJFenBu"style="width:150px;" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">皮下出血</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="PFNMo_PXCXueWu"name="PFNMo_PXChuXue"value="无" onclick="$('#PFNMo_PXCXLXJFenBu').attr('disabled', true).val('');"/>无</label>
                            <label><input type="radio" id="PFNMo_PXCXueYou"name="PFNMo_PXChuXue"value="有" onclick="$('#PFNMo_PXCXLXJFenBu').attr('disabled', false);"/>有</label>
                            类型及分布<input type="text" id="PFNMo_PXCXLXJFenBu" name="PFNMo_PXCXLXJFenBu"style="width:150px;" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">毛发分布</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="PFNMo_MFFBZhengChang"name="PFNMo_MFFenBu"value="正常" onclick="$('#PFNMo_MFFBBuWei').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="PFNMo_MFFBDuoMao"name="PFNMo_MFFenBu"value="多毛" onclick="$('#PFNMo_MFFBBuWei').attr('disabled', false);"/>多毛</label>
                            <label><input type="radio" id="PFNMo_MFFBXiShu"name="PFNMo_MFFenBu"value="稀疏"onclick="$('#PFNMo_MFFBBuWei').attr('disabled', false);" />稀疏</label>
                            <label><input type="radio" id="PFNMo_MFFBTuoLuo"name="PFNMo_MFFenBu"value="脱落"onclick="$('#PFNMo_MFFBBuWei').attr('disabled', false);" />脱落</label>
                            部位<input type="text" id="PFNMo_MFFBBuWei" name="PFNMo_MFFBBuWei"style="width:150px;" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">温度与湿度</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="2">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="PFNMo_WDYSDZhengChang"name="PFNMo_WDYShiDu"value="正常" />正常</label>
                            <label><input type="radio" id="PFNMo_WDYSDuLeng"name="PFNMo_WDYShiDu"value="冷" />冷</label>
                            <label><input type="radio" id="PFNMo_WDYSDuGan"name="PFNMo_WDYShiDu"value="干" />干</label>
                            <label><input type="radio" id="PFNMo_WDYSDuShi"name="PFNMo_WDYShiDu"value="湿" />湿</label>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">弹性</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="1">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="PFNMo_TXZhengChang"name="PFNMo_TanXing"value="正常" />正常</label>
                            <label><input type="radio" id="PFNMo_TXJianTui"name="PFNMo_TanXing"value="减退" />减退</label>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">肝掌</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="PFNMo_GZhangWu"name="PFNMo_GanZhang"value="无" />无</label>
                            <label><input type="radio" id="PFNMo_GZhangYou"name="PFNMo_GanZhang"value="有" />有</label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">水肿</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="2">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="PFNMo_SZhongWu"name="PFNMo_ShuiZhong"value="无" onclick="$('#PFNMo_BWJChengDu').attr('disabled', true).val('');"/>无</label>
                            <label><input type="radio" id="PFNMo_SZhongYou"name="PFNMo_ShuiZhong"value="有" onclick="$('#PFNMo_BWJChengDu').attr('disabled', false);"/>有</label>
                            部位及程度<input type="text" id="PFNMo_BWJChengDu" name="PFNMo_BWJChengDu" style="width: 50px;" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">蜘蛛痣</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="PFNMo_ZZZhiWu"name="PFNMo_ZZhuZhi"value="无" onclick="$('#PFNMo_ZZZBuWei').attr('disabled', true).val(''); $('#PFNMo_ZZZShuMu').attr('disabled', true).val('');"/>无</label>
                            <label><input type="radio" id="PFNMo_ZZZhiYou"name="PFNMo_ZZhuZhi"value="有" onclick="$('#PFNMo_ZZZBuWei').attr('disabled', false); $('#PFNMo_ZZZShuMu').attr('disabled', false);"/>有</label>
                            部位<input type="text" id="PFNMo_ZZZBuWei" name="PFNMo_ZZZBuWei" style="width: 50px;" />
                            数目<input type="text" id="PFNMo_ZZZShuMu" name="PFNMo_ZZZShuMu" style="width: 50px;" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">其他</td>
                    <td width="10%" class="detailContent" style="height: 15px;">
                        <span class="detailContent" style="height: 15px">
                            <input type="text" id="PFNMo_QiTa" name="PFNMo_QiTa" style="width: 100px;" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold; ">淋巴结</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">全身浅表淋巴结</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="8">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="LBJie_QSQBLBJWZhongDa"name="LBJie_QSQBLBaJie"value="无肿大" onclick="$('#LBJie_QSQBLBJBWJTeZheng').attr('disabled', true).val('');"/>无肿大</label>
                            <label><input type="radio" id="LBJie_QSQBLBJZhongDa"name="LBJie_QSQBLBaJie"value="肿大" onclick="$('#LBJie_QSQBLBJBWJTeZheng').attr('disabled', false);"/>肿大</label>
                            部位及特征<input type="text" id="LBJie_QSQBLBJBWJTeZheng" name="LBJie_QSQBLBJBWJTeZheng" style="width: 300px;" />
                        </span>
                    </td>
                 </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="17">头部</td>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight: bold;" rowspan="2">头颅</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">大小</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="2">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_TLDXZhengChang"name="TBu_TLDaXiao"value="正常" />正常</label>
                            <label><input type="radio" id="TBu_TLDXiaoDa"name="TBu_TLDaXiao"value="大" />大</label>
                            <label><input type="radio" id="TBu_TLDXiaoXiao"name="TBu_TLDaXiao"value="小" />小</label>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">畸形</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_TLJXingWu"name="TBu_TLJiXing"value="无" onclick="$('#TBu_TLJXForYou').attr('disabled', true).val('');"/>无</label>
                            <label><input type="radio" id="TBu_TLJXingYou"name="TBu_TLJiXing"value="有" onclick="$('#TBu_TLJXForYou').attr('disabled', false)" />有</label>
                            <select id="TBu_TLJXForYou"name="TBu_TLJXForYou"style="width:100px;">
                                <option value="">==请选择==</option>
                                <option value="尖颅">尖颅</option>
                                <option value="方颅">方颅</option>
                                <option value="变形颅">变形颅</option>
                            </select>
                        </span>
                    </td>
                    
                 </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">其他异常</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="7">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="checkbox" id="TBu_TLQTYCYaTong"name="TBu_TLQTYiCHang"value="正常" />压痛</label>
                            <label><input type="checkbox" id="TBu_TLQTYCBaoKuai"name="TBu_TLQTYiCHang"value="包块" />包块</label>
                            <label><input type="checkbox" id="TBu_TLQTYCAoXian"name="TBu_TLQTYiCHang"value="凹陷" />凹陷</label>
                            部位<input type="text" id="TBu_TLQTYCBuWei" name="TBu_TLQTYCBuWei" style="width: 300px;" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight: bold;" rowspan="6">眼</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">眉毛稀疏</td>
                    <td width="10%" class="detailContent" style="height: 15px;" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_YMMXShuWu"name="TBu_YMMXiShu"value="无" />无</label>
                            <label><input type="radio" id="TBu_YMMXShuYou"name="TBu_YMMXiShu"value="有" />有</label>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">眉毛脱落</td>
                    <td width="10%" class="detailContent" style="height: 15px;">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_YMMTLuoWu"name="TBu_YMMTuoLuo"value="无" />无</label>
                            <label><input type="radio" id="TBu_YMMTLuoYou"name="TBu_YMMTuoLuo"value="有" />有</label>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">倒睫</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_YDJieWu"name="TBu_YDaoJie"value="无" />无</label>
                            <label><input type="radio" id="TBu_YDJieYou"name="TBu_YDaoJie"value="有" />有</label>
                        </span>
                    </td>
                    
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">眼睑</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_YYJZhengChang"name="TBu_YYanJian"value="正常" />正常</label>
                            <label><input type="radio" id="TBu_YYJShuiZhong"name="TBu_YYanJian"value="水肿" />水肿</label>
                            <label><input type="radio" id="TBu_YYJXiaChui"name="TBu_YYanJian"value="下垂" />下垂</label>
                            <label><input type="radio" id="TBu_YYJLuanSuo"name="TBu_YYanJian"value="挛缩" />挛缩</label>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">结膜</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_YJieMZhengChang"name="TBu_YJieMo"value="正常" />正常</label>
                            <label><input type="radio" id="TBu_YJieMChongXue"name="TBu_YJieMo"value="充血" />充血</label>
                            <label><input type="radio" id="TBu_YJieMShuiZhong"name="TBu_YJieMo"value="水肿" />水肿</label>
                            <label><input type="radio" id="TBu_YJieMChuXue"name="TBu_YJieMo"value="出血" />出血</label>
                        </span>
                    </td>

                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">角膜</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_YJiaoMZhengChang"name="TBu_YJiaoMo"value="正常" onclick="$('#TBu_YJiaoMForYiChang').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="TBu_YJiaoMYiChang"name="TBu_YJiaoMo"value="异常" onclick="$('#TBu_YJiaoMForYiChang').attr('disabled', false);"/>异常</label>
                            <select id="TBu_YJiaoMForYiChang" name="TBu_YJiaoMForYiChang" style="width:100px;">
                                <option value="">==请选择==</option>
                                <option value="左">左</option>
                                <option value="右">右</option>
                                <option value="左右">左右</option>
                            </select>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">巩膜</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_YGMYHuangRan"name="TBu_YGongMo"value="无黄染"/>无黄染</label>
                            <label><input type="radio" id="TBu_YGMWHuangRan"name="TBu_YGongMo"value="有黄染"/>有黄染</label>
                        </span>
                    </td>
                 </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">眼球</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="7">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_YYQZhengChang"name="TBu_YYanQiu"value="正常" onclick="$('#TBu_YYQForAll').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="TBu_YYQTuChu"name="TBu_YYanQiu"value="凸出" onclick="$('#TBu_YYQForAll').attr('disabled', false);"/>凸出</label>
                            <label><input type="radio" id="TBu_YYQAoXian"name="TBu_YYanQiu"value="凹陷" onclick="$('#TBu_YYQForAll').attr('disabled', false);"/>凹陷</label>
                            <label><input type="radio" id="TBu_YYQZhengChan"name="TBu_YYanQiu"value="震颤" onclick="$('#TBu_YYQForAll').attr('disabled', false);"/>震颤</label>
                            <label><input type="radio" id="TBu_YYQYDZhangAi"name="TBu_YYanQiu"value="运动障碍" onclick="$('#TBu_YYQForAll').attr('disabled', false);"/>运动障碍</label>
                            <select id="TBu_YYQForAll" name="TBu_YYQForAll" style="width:100px;">
                                <option value="">==请选择==</option>
                                <option value="左">左</option>
                                <option value="右">右</option>
                                <option value="左右">左右</option>
                            </select>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;"rowspan="2">瞳孔</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_YTKDengYuan"name="TBu_YTongKong"value="等圆" onclick="$('#TBu_TKForBuDengZ').attr('disabled', true).val(''); $('#TBu_TKForBuDengY').attr('disabled', true).val('');"/>等圆</label>
                            <label><input type="radio" id="TBu_YTKDengda"name="TBu_YTongKong"value="等大" onclick="$('#TBu_TKForBuDengZ').attr('disabled', true).val(''); $('#TBu_TKForBuDengY').attr('disabled', true).val('');"/>等大</label>
                            <label><input type="radio" id="TBu_YTKBuDeng"name="TBu_YTongKong"value="不等" onclick="$('#TBu_TKForBuDengZ').attr('disabled', false); $('#TBu_TKForBuDengY').attr('disabled', false)"/>不等</label>
                            左<input type="text" id="TBu_TKForBuDengZ"name="TBu_TKForBuDengZ" style="width:50px;" />mm
                            右<input type="text" id="TBu_TKForBuDengY"name="TBu_TKForBuDengY" style="width:50px;" />mm
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">对光反射</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_YTKDGFSZhengChang"name="TBu_YTKDGFanShe"value="正常" onclick="$('#TBu_YTKDGFSForAll').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="TBu_YTKDGFSChiDun"name="TBu_YTKDGFanShe"value="迟钝" onclick="$('#TBu_YTKDGFSForAll').attr('disabled', false);"/>迟钝</label>
                            <label><input type="radio" id="TBu_YTKDGFSXiaoShi"name="TBu_YTKDGFanShe"value="消失" onclick="$('#TBu_YTKDGFSForAll').attr('disabled', false);"/>消失</label>
                            <select id="TBu_YTKDGFSForAll" name="TBu_YTKDGFSForAll" style="width:100px;">
                                <option value="">==请选择==</option>
                                <option value="左">左</option>
                                <option value="右">右</option>
                                <option value="左右">左右</option>
                            </select>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3">
                        <span class="detailContent" style="height: 15px">
                            近视力
                            <label><input type="radio" id="TBu_YTKJSLSLiBiao"name="TBu_YTKJShiLi"value="视力表"/>视力表</label>
                            <label><input type="radio" id="TBu_YTKJSLYDShiLi"name="TBu_YTKJShiLi"value="阅读视力" />阅读视力</label>
                            左<input type="text" id="TBu_TKJSLForAllZ"name="TBu_TKJSLForAllZ" style="width:50px;" />
                            右<input type="text" id="TBu_TKJSLForAllY"name="TBu_TKJSLForAllY" style="width:50px;" />
                        </span>
                    </td>
                     <td width="10%" class="detailTitle" style="height: 15px;">其他</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3">
                        <span class="detailContent" style="height: 15px">
                           <input type="text" id="TBu_TKJSLQiTa"name="TBu_TKJSLQiTa" style="width:200px;" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight: bold;" rowspan="3">耳</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">耳廓</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="7" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_EEKZhengChang"name="TBu_EErKuo"value="正常" onclick="$('#TBu_EErKForAll').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="TBu_EEKJiXing"name="TBu_EErKuo"value="畸形" onclick="$('#TBu_EErKForAll').attr('disabled', false);"/>畸形</label>
                            <label><input type="radio" id="TBu_EEKEQLouGuan"name="TBu_EErKuo"value="耳前瘘管" onclick="$('#TBu_EErKForAll').attr('disabled', false);"/>耳前瘘管</label>
                            其他<input type="text" id="TBu_EEKQiTa" name="TBu_EEKQiTa" style="width:100px;" onfocus="$('input[name=TBu_EErKuo]').attr('checked',false);"/>
                            <select id="TBu_EErKForAll" name="TBu_EErKForAll" style="width:100px;">
                                <option value="">==请选择==</option>
                                <option value="左">左</option>
                                <option value="右">右</option>
                                <option value="左右">左右</option>
                            </select>
                          </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">外耳道分泌物</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="7" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_EWEDFMWuWu"name="TBu_EWEDFMiWu"value="无" onclick="$('#TBu_EWEDFMWForY').attr('disabled', true).val(''); $('#TBu_EWEDFMWXingZhi').attr('disabled', true).val('');"/>无</label>
                            <label><input type="radio" id="TBu_EWEDFMWuYou"name="TBu_EWEDFMiWu"value="有" onclick="$('#TBu_EWEDFMWForY').attr('disabled', false); $('#TBu_EWEDFMWXingZhi').attr('disabled', false);"/>有</label>
                            <select id="TBu_EWEDFMWForY" name="TBu_EWEDFMWForY" style="width:100px;">
                                <option value="">==请选择==</option>
                                <option value="左">左</option>
                                <option value="右">右</option>
                                <option value="左右">左右</option>
                            </select>
                            性质<input type="text" id="TBu_EWEDFMWXingZhi" name="TBu_EWEDFMWXingZhi" style="width:200px;"/>
                          </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">乳突压痛</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_ERTYTongWu"name="TBu_ERTYaTong"value="无" onclick="$('#TBu_ERTYTForY').attr('disabled', true).val('');"/>无</label>
                            <label><input type="radio" id="TBu_ERTYTongYou"name="TBu_ERTYaTong"value="有" onclick="$('#TBu_ERTYTForY').attr('disabled', false);"/>有</label>
                            <select id="TBu_ERTYTForY" name="TBu_ERTYTForY" style="width:100px;">
                                <option value="">==请选择==</option>
                                <option value="左">左</option>
                                <option value="右">右</option>
                                <option value="左右">左右</option>
                            </select>
                          </span>
                    </td>
                    <td width="22%" class="detailTitle" style="height: 15px;">听力粗试障碍</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_TLCSZAiWu"name="TBu_TLCSZhangAi"value="无" onclick="$('#TBu_TLCSZAForY').attr('disabled', true).val('');"/>无</label>
                            <label><input type="radio" id="TBu_TLCSZAiYou"name="TBu_TLCSZhangAi"value="有" onclick="$('#TBu_TLCSZAForY').attr('disabled', false);"/>有</label>
                            <select id="TBu_TLCSZAForY" name="TBu_TLCSZAForY" style="width:100px;">
                                <option value="">==请选择==</option>
                                <option value="左">左</option>
                                <option value="右">右</option>
                                <option value="左右">左右</option>
                            </select>
                          </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight: bold;" rowspan="2">鼻</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">外形</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_BWXZhengChang"name="TBu_BWaiXing"value="正常" onclick="$('#TBu_BForYC').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="TBu_BWXYiChang"name="TBu_BWaiXing"value="异常" onclick="$('#TBu_BForYC').attr('disabled', false);"/>异常</label>
                            <input type="text" id="TBu_BForYC"name="TBu_BForYC" style="width:200px;" />
                          </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">鼻窦压痛</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_BBDYTongWu"name="TBu_BBDYaTong"value="无" onclick="$('#TBu_BForBDYT').attr('disabled', true).val('');"/>无</label>
                            <label><input type="radio" id="TBu_BBDYTongYou"name="TBu_BBDYaTong"value="有" onclick="$('#TBu_BForBDYT').attr('disabled', false);"/>有</label>
                            部位<input type="text" id="TBu_BForBDYT"name="TBu_BForBDYT" style="width:200px;" />
                          </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">其他异常</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="7" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="checkbox" id="TBu_BQTYCBYShanDong"name="TBu_BQTYCBYShanDong"value="鼻翼扇动" />鼻翼扇动</label>
                            <label><input type="checkbox" id="TBu_BQTYCFMiWu"name="TBu_BQTYCFMiWu"value="分泌物" />分泌物</label>
                            <label><input type="checkbox" id="TBu_BQTYCChuXue"name="TBu_BQTYCChuXue"value="出血" />出血</label>
                            <label><input type="checkbox" id="TBu_BQTYCZuSe"name="TBu_BQTYCZuSe"value="阻塞" />阻塞</label>
                            <label><input type="checkbox" id="TBu_BQTYCBZGPianQu"name="TBu_BQTYCBZGPianQu"value="鼻中隔偏曲" />鼻中隔偏曲</label>
                            <label><input type="checkbox" id="TBu_BQTYCBZGChuanKong"name="TBu_BQTYCBZGChuanKong"value="鼻中隔穿孔" />鼻中隔穿孔</label>
                            </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight: bold;" rowspan="4">口腔</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">口唇</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_KQKCHongRun"name="TBu_KQKouChun"value="红润"/>红润</label>
                            <label><input type="radio" id="TBu_KQKCFaGan"name="TBu_KQKouChun"value="发绀"/>发绀</label>
                            <label><input type="radio" id="TBu_KQKCCangBai"name="TBu_KQKouChun"value="苍白"/>苍白</label>
                            <label><input type="radio" id="TBu_KQKCPaoZhen"name="TBu_KQKouChun"value="疱疹"/>疱疹</label>
                            <label><input type="radio" id="TBu_KQKCJunLie"name="TBu_KQKouChun"value="皲裂"/>皲裂</label>
                          </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">黏膜</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_KQNMZhengChang"name="TBu_KQNianMo"value="正常"onclick="$('#TBu_KQNMForYC').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="TBu_KQNMYiChang"name="TBu_KQNianMo"value="异常"onclick="$('#TBu_KQNMForYC').attr('disabled', false);"/>异常:</label>
                            <input type="text" id="TBu_KQNMForYC"name="TBu_KQNMForYC" style="width:200px;" />
                          </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">腮腺导管开口</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_KQSXDGKKZhengChang"name="TBu_KQSXDGKaiKou"value="正常"onclick="$('#TBu_KQSXDGKKForYC').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="TBu_KQSXDGKKYiChang"name="TBu_KQSXDGKaiKou"value="异常"onclick="$('#TBu_KQSXDGKKForYC').attr('disabled', false);"/>异常:</label>
                            <input type="text" id="TBu_KQSXDGKKForYC"name="TBu_KQSXDGKKForYC" style="width:200px;" />
                          </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">舌</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_KQSZhengChang"name="TBu_KQShe"value="正常"onclick="$('#TBu_KQSForYC').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="TBu_KQSYiChang"name="TBu_KQShe"value="异常"onclick="$('#TBu_KQSForYC').attr('disabled', false);"/>异常:</label>
                           <input type="text" id="TBu_KQSForYC"name="TBu_KQSForYC" style="width:200px;" />
                          </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">齿龈</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_KQCYZhengChang"name="TBu_KQChiYin"value="正常"/>正常</label>
                            <label><input type="radio" id="TBu_KQCYZhongzhang"name="TBu_KQChiYin" value="肿胀"/>肿胀</label>
                            <label><input type="radio" id="TBu_KQCYYiNong"name="TBu_KQChiYin"value="溢脓"/>溢脓</label>
                            <label><input type="radio" id="TBu_KQCYChuXue"name="TBu_KQChiYin" value="出血"/>出血</label>
                            <label><input type="radio" id="TBu_KQCYSSChenZhuo"name="TBu_KQChiYin"value="色素沉着"/>色素沉着</label>
                            <label><input type="radio" id="TBu_KQCYQianXian"name="TBu_KQChiYin" value="铅线"/>铅线</label>
                          </span>
                    </td>
                     <td width="10%" class="detailTitle" style="height: 15px;">齿列</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="4" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_KQCLieQi"name="TBu_KQChiLie"value="正常"/>齐</label>
                            <label><input type="radio" id="TBu_KQCLQueChi"name="TBu_KQChiLie" value="肿胀"/>缺齿</label>
                            <label><input type="radio" id="TBu_KQCLQuChi"name="TBu_KQChiLie"value="溢脓"/>龋齿</label>
                            <label><input type="radio" id="TBu_KQCLYiChi"name="TBu_KQChiLie" value="出血"/>义齿</label>
                            <label><input type="radio" id="TBu_KQCLCanGen"name="TBu_KQChiLie"value="色素沉着"/>残根</label>
                            <label><input type="radio" id="TBu_KQCLBYouChi"name="TBu_KQChiLie" value="铅线"/>斑釉齿</label>
                          </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">扁桃体</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_KQBTTWZhongDa"name="TBu_KQBTaoTi"value="无肿大"onclick="$('#TBu_KQBTTForZD').attr('disabled', true).val('');"/>无肿大</label>
                            <label><input type="radio" id="TBu_KQBTTZhongDa"name="TBu_KQBTaoTi"value="肿大"onclick="$('#TBu_KQBTTForZD').attr('disabled', false);"/>肿大</label>
                            <input type="text" id="TBu_KQBTTForZD"name="TBu_KQBTTForZD" style="width:100px;" />
                          </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">咽</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2" >
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_KQYWChongXue"name="TBu_KQYan"value="无充血"/>无充血</label>
                            <label><input type="radio" id="TBu_KQYChongXue"name="TBu_KQYan"value="充血"/>充血</label>
                            <label><input type="radio" id="TBu_KQYLBLPZengSheng"name="TBu_KQYan"value="淋巴滤泡增生"/>淋巴滤泡增生</label>
                          </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">声音</td>
                    <td width="10%" class="detailContent" style="height: 15px;">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="TBu_KQSYZhengChang"name="TBu_KQShengYin"value="正常"/>正常</label>
                            <label><input type="radio" id="TBu_KQSYSiYa"name="TBu_KQShengYin"value="嘶哑"/>嘶哑</label>
                          </span>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="3">颈部</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">抵抗感</td>
                    <td width="10%" class="detailContent" style="height: 15px;">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="JBu_DKGanWu"name="JBu_DKangGan"value="无" />无</label>
                            <label><input type="radio" id="JBu_DKGanYou"name="JBu_DKangGan"value="有" />有</label>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">气管</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="JBu_QGZhengZhong"name="JBu_QiGuan"value="正中" onclick="$('#JBu_QGForPY').attr('disabled', true).val('');"/>正中</label>
                            <label><input type="radio" id="JBu_QGPianYi"name="JBu_QiGuan"value="偏移" onclick="$('#JBu_QGForPY').attr('disabled', false);"/>偏移</label>
                            <select id="JBu_QGForPY" name="JBu_QGForPY" style="width:100px">
                                <option value="">==请选择==</option>
                                <option value="向左">向左</option>
                                <option value="向右">向右</option>
                            </select>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">颈静脉</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="JBu_JJMZhengChang"name="JBu_JJingMai"value="正常" />正常</label>
                            <label><input type="radio" id="JBu_JJMChongYing"name="JBu_JJingMai"value="充盈" />充盈</label>
                            <label><input type="radio" id="JBu_JJMNuZhang"name="JBu_JJingMai"value="怒张" />怒张</label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">颈动脉搏动</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="JBu_JDMBDZhengChang"name="JBu_JDMBoDoong"value="正常" onclick="$('#JBu_JDMBDForAll').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="JBu_JDMBDZengQiang"name="JBu_JDMBoDoong"value="增强" onclick="$('#JBu_JDMBDForAll').attr('disabled', false);"/>增强</label>
                            <label><input type="radio" id="JBu_JDMBDJianRuo"name="JBu_JDMBoDoong"value="减弱" onclick="$('#JBu_JDMBDForAll').attr('disabled', false);"/>减弱</label>
                            <select id="JBu_JDMBDForAll" name="JBu_JDMBDForAll" style="width:100px">
                                <option value="">==请选择==</option>
                                <option value="左">左</option>
                                <option value="右">右</option>
                                <option value="左右">左右</option>
                            </select>
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">肝颈静脉回流征</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="JBu_GJJMHLZYinXing"name="JBu_GJJMHLiuZheng"value="阴性" />阴性</label>
                            <label><input type="radio" id="JBu_GJJMHLZYangXing"name="JBu_GJJMHLiuZheng"value="阳性" />阳性</label>
                        </span>
                    </td>

                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">甲状腺</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="8">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="JBu_JZXZhengChang"name="JBu_JZhuangXian"value="正常" onclick="$('#JBu_JZXForZDZ').attr('disabled', true).val(''); $('#JBu_JZXForZDY').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="JBu_JZXZhongDa"name="JBu_JZhuangXian"value="肿大" onclick="$('#JBu_JZXForZDZ').attr('disabled', false); $('#JBu_JZXForZDY').attr('disabled', false);"/>肿大</label>
                            左<input style="width:50px;"id="JBu_JZXForZDZ"name="JBu_JZXForZDZ" />度
                            右<input style="width:50px;"id="JBu_JZXForZDY"name="JBu_JZXForZDY" />度
                            <label><input type="checkbox" id="JBu_JZXZhiRuan"name="JBu_JZXZhiRuan"value="质软" />质软</label>
                            <label><input type="checkbox" id="JBu_JZXZhiYing"name="JBu_JZXZhiYing"value="质硬" />质硬</label>
                            <label><input type="checkbox" id="JBu_JZXYaTong"name="JBu_JZXYaTong"value="压痛" />压痛</label>
                            <label><input type="checkbox" id="JBu_JZXZhenChan"name="JBu_JZXZhenChan"value="震颤" />震颤</label>
                            <label><input type="checkbox" id="JBu_JZXXGZaYin"name="JBu_JZXXGZaYin"value="血管杂音" />血管杂音</label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="1">胸部</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">胸廓</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="8">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="XBu_XKZhengChang"name="XBu_XiongKuo"value="正常" />正常</label>
                            <label><input type="radio" id="XBu_XKTZhuangXiong"name="XBu_XiongKuo"value="桶状胸" />桶状胸</label>
                            <label><input type="radio" id="XBu_XKBPingXiong"name="XBu_XiongKuo"value="扁平胸" />扁平胸</label>
                            <label><input type="radio" id="XBu_XKJiXiong"name="XBu_XiongKuo"value="鸡胸" />鸡胸</label>
                            <label><input type="radio" id="XBu_XKLDouXiong"name="XBu_XiongKuo"value="漏斗胸" />漏斗胸</label>
                            <label><input type="radio" id="XBu_XKPLHAoXian"name="XBu_XiongKuo"value="膨隆或凹陷" />膨隆或凹陷</label>
                            <label><input type="radio" id="XBu_XKXQQPengLong"name="XBu_XiongKuo"value="心前区膨隆" />心前区膨隆</label>
                            <label><input type="radio" id="XBu_XKXGKouTong"name="XBu_XiongKuo"value="胸骨叩痛" />胸骨叩痛</label>
                        </span><a style="padding-left:2em;"></a>
                        <span class="detailContent" style="height: 15px">
                            乳房<label><input type="radio" id="XBu_RFZhengChang"name="XBu_RuFang"value="正常" onclick="$('#XBu_RFForYC').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="XBu_RFYiChang"name="XBu_RuFang"value="异常" onclick="$('#XBu_RFForYC').attr('disabled', false);"/>异常:</label>
                            <input type="text" id="XBu_RFForYC"name="XBu_RFForYC" style="width:150px;" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="8">肺</td>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight: bold;">视诊</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">呼吸运动</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="Fei_SZHXYDZhengChang"name="Fei_SZHXYunDong"value="正常" onclick="$('#Fei_SZHXYDForYC').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="Fei_SZHXYDYiChang"name="Fei_SZHXYunDong"value="异常" onclick="$('#Fei_SZHXYDForYC').attr('disabled', false);"/>异常:</label>
                            <input type="text" id="Fei_SZHXYDForYC"name="Fei_SZHXYDForYC" style="width:200px;" />
                        </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">肋间隙</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="Fei_SZLJXZhengChang"name="Fei_SZLJianXi"value="正常" onclick="$('#Fei_SZLJXBWForAll').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="Fei_SZLJXZengKuan"name="Fei_SZLJianXi"value="增宽" onclick="$('#Fei_SZLJXBWForAll').attr('disabled', false);"/>增宽</label>
                            <label><input type="radio" id="Fei_SZLJXBianZhai"name="Fei_SZLJianXi"value="变窄" onclick="$('#Fei_SZLJXBWForAll').attr('disabled', false);"/>变窄</label>
                            部位<input type="text" id="Fei_SZLJXBWForAll"name="Fei_SZLJXBWForAll" style="width:150px;" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight: bold;"rowspan="2">触诊</td>
                    <td width="10%" class="detailTitle" style="height: 15px;" >语颤</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="7">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="Fei_CZYCZhengChang"name="Fei_CZYuChan"value="正常" onclick="$('#Fei_CZYCForYC').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="Fei_CZYCYiChang"name="Fei_CZYuChan"value="异常" onclick="$('#Fei_CZYCForYC').attr('disabled', false);"/>异常:</label>
                            <input type="text" id="Fei_CZYCForYC"name="Fei_CZYCForYC" style="width:200px;" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">胸膜摩擦感</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3">
                        <label><input type="radio" id="Fei_CZXMMCGanWu"name="Fei_CZXMMCaGan"value="无" onclick="$('#Fei_CZXMMCGForY').attr('disabled', true).val('');"/>无</label>
                            <label><input type="radio" id="Fei_CZXMMCGanYou"name="Fei_CZXMMCaGan"value="有" onclick="$('#Fei_CZXMMCGForY').attr('disabled', false);"/>有</label>
                            部位<input type="text" id="Fei_CZXMMCGForY"name="Fei_CZXMMCGForY" style="width:200px;" />
                     </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">皮下捻发感</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3">
                        <label><input type="radio" id="Fei_CZPXNFGanWu"name="Fei_CZPXNFaGan"value="无" onclick="$('#Fei_CZPXNFGForY').attr('disabled', true).val('');"/>无</label>
                            <label><input type="radio" id="Fei_CZPXNFGanYou"name="Fei_CZPXNFaGan"value="有" onclick="$('#Fei_CZPXNFGForY').attr('disabled', false);"/>有</label>
                            部位<input type="text" id="Fei_CZPXNFGForY"name="Fei_CZPXNFGForY" style="width:200px;" />
                     </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight: bold;">叩诊</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="8">
                        <label><input type="radio" id="Fei_KZZCQingYin"name="Fei_KouZhen"value="正常清音"/>正常清音</label>
                        <label><input type="radio" id="Fei_KZYCKZhenYin"name="Fei_KouZhen"value="异常叩诊音"/>异常叩诊音</label>
                        <label><input type="radio" id="Fei_KZZhuoYin"name="Fei_KouZhen"value="浊音"/>浊音</label>
                        <label><input type="radio" id="Fei_KZShiYin"name="Fei_KouZhen"value="实音"/>实音</label>
                        <label><input type="radio" id="Fei_KZGQingYin"name="Fei_KouZhen"value="过清音"/>过清音</label>
                        <label><input type="radio" id="Fei_KZGuYin"name="Fei_KouZhen"value="鼓音"/>鼓音</label>
                        部位<input type="text" id="Fei_KZForAll"name="Fei_KZForAll" style="width:200px;" />
                     </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight: bold;"rowspan="2">肺下界</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">肩胛线</td>
                    <td width="10%" class="detailContent" style="height: 15px;"COLSPAN="2">
                        右<input type="text" id="Fei_FXJJJiaXianY"name="Fei_FXJJJiaXianY" style="width:50px;" />肋间,
                        左<input type="text" id="Fei_FXJJJiaXianZ"name="Fei_FXJJJiaXianZ" style="width:50px;" />肋间
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">锁骨中线</td>
                    <td width="10%" class="detailContent" style="height: 15px;"COLSPAN="4">
                        右<input type="text" id="Fei_FXJSGZhongXianY"name="Fei_FXJSGZhongXianY" style="width:50px;" />肋间,
                        左<input type="text" id="Fei_FXJSGZhongXianZ"name="Fei_FXJSGZhongXianZ" style="width:50px;" />肋间
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">腋中线</td>
                    <td width="10%" class="detailContent" style="height: 15px;"COLSPAN="2">
                        右<input type="text" id="Fei_FXJYZhongXianY"name="Fei_FXJYZhongXianY" style="width:50px;" />肋间,
                        左<input type="text" id="Fei_FXJYZhongXianZ"name="Fei_FXJYZhongXianZ" style="width:50px;" />肋间
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">移动度</td>
                    <td width="10%" class="detailContent" style="height: 15px;"COLSPAN="4">
                        右<input type="text" id="Fei_FXJYDongDuY"name="Fei_FXJYDongDuY" style="width:50px;" />cm,
                        左<input type="text" id="Fei_FXJYDongDuZ"name="Fei_FXJYDongDuZ" style="width:50px;" />cm
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight: bold;"rowspan="2">听诊</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">呼吸</td>
                    <td width="10%" class="detailContent" style="height: 15px;">
                        <label><input type="radio" id="Fei_TZHXGuiZheng"name="Fei_TZHuXi" value="规整" />规整</label>
                        <label><input type="radio" id="Fei_TZHXBGuiZheng"name="Fei_TZHuXi" value="不规整" />不规整</label>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">呼吸音</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="5">
                        <label><input type="radio" id="Fei_TZHXYZhengChang"name="Fei_TZHXiYin" value="正常" onclick="$('#Fei_TZHXYForYC').attr('disabled', true).val('');"/>正常</label>
                        <label><input type="radio" id="Fei_TZHXYYiChang"name="Fei_TZHXiYin" value="异常" onclick="$('#Fei_TZHXYForYC').attr('disabled', false);"/>异常:</label>
                        <input type="text" id="Fei_TZHXYForYC"name="Fei_TZHXYForYC" style="width:200px;" />
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">啰音</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <label><input type="radio" id="Fei_TZLYinWu"name="Fei_TZLuoYing" value="无" onclick="$('#Fei_TZLYForY').attr('disabled', true).val('');"/>无</label>
                        <label><input type="radio" id="Fei_TZLYinYou"name="Fei_TZLuoYing" value="有" onclick="$('#Fei_TZLYForY').attr('disabled', false);"/>有</label>
                        <input type="text"id="Fei_TZLYForY"name="Fei_TZLYForY"style="width:150px;" />
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">语音传导</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <label><input type="radio" id="Fei_TZYYCDZhengChang"name="Fei_TZYYChuanDao" value="正常" onclick="$('#Fei_TZYYCDForYC').attr('disabled', true).val('');"/>正常</label>
                        <label><input type="radio" id="Fei_TZYYCDYiChang"name="Fei_TZYYChuanDao" value="异常" onclick="$('#Fei_TZYYCDForYC').attr('disabled', false);"/>异常:</label>
                        <input type="text"id="Fei_TZYYCDForYC"name="Fei_TZYYCDForYC"style="width:150px;" />
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">胸膜摩擦音</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <label><input type="radio" id="Fei_XMMCYinWu"name="Fei_TZXMMCaYin" value="无" onclick="$('#Fei_XMMCYForY').attr('disabled', true).val('');"/>无</label>
                        <label><input type="radio" id="Fei_XMMCYinYou"name="Fei_TZXMMCaYin" value="有" onclick="$('#Fei_XMMCYForY').attr('disabled', false);"/>有</label>
                        部位<input type="text"id="Fei_XMMCYForY"name="Fei_XMMCYForY"style="width:100px;" />
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="7">心</td>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight: bold;"rowspan="2">视诊</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">心前区隆起</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="Xin_SZXQQLQiWu"name="Xin_SZXQQLongQi"value="无"/>无</label>
                            <label><input type="radio" id="Xin_SZXQQLQiYou"name="Xin_SZXQQLongQi"value="有"/>有</label>
                         </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">心尖搏动位置</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="Xin_SZXJBDWZZhengChang"name="Xin_SZXJBDWeiZhi"value="正常" onclick="$('#Xin_SZXJBOWZForYW').attr('disabled', true).val('');"/>正常</label>
                            <label><input type="radio" id="Xin_SZXJBDWZYiWei"name="Xin_SZXJBDWeiZhi"value="移位" onclick="$('#Xin_SZXJBOWZForYW').attr('disabled', false);"/>移位</label>
                            距左锁骨中线内外<input type="text" id="Xin_SZXJBOWZForYW"name="Xin_SZXJBOWZForYW" style="width:50px;" />cm
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">心尖搏动</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="Xin_SZXJBDZhengChang"name="Xin_SZXJBoDong"value="正常"/>正常</label>
                            <label><input type="radio" id="Xin_SZXJBDWeiJian"name="Xin_SZXJBoDong"value="未见"/>未见</label>
                            <label><input type="radio" id="Xin_SZXJBDZengQiang"name="Xin_SZXJBoDong"value="增强"/>增强</label>
                            <label><input type="radio" id="Xin_SZXJBDMiSan"name="Xin_SZXJBoDong"value="弥散"/>弥散</label>
                         </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">心前区异常搏动</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="4">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="Xin_SZXQQYCBDongWu"name="Xin_SZXQQYCBoDong"value="无" onclick="$('#Xin_SZXQQYCBDForY').attr('disabled', true).val('');"/>无</label>
                            <label><input type="radio" id="Xin_SZXQQYCBDongYou"name="Xin_SZXQQYCBoDong"value="有" onclick="$('#Xin_SZXQQYCBDForY').attr('disabled', false);"/>有</label>
                            部位<input type="text" id="Xin_SZXQQYCBDForY"name="Xin_SZXQQYCBDForY" style="width:200px;" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight: bold;"rowspan="1">触诊</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">心尖搏动</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="Xin_CZXJBDZhengChang"name="Xin_CZXJBoDong"value="正常"/>正常</label>
                            <label><input type="radio" id="Xin_CZXJBDZengQiang"name="Xin_CZXJBoDong"value="增强"/>增强</label>
                            <label><input type="radio" id="Xin_CZXJBDTJuGan"name="Xin_CZXJBoDong"value="抬举感"/>抬举感</label>
                            <label><input type="radio" id="Xin_CZXJBDCBuQing"name="Xin_CZXJBoDong"value="触不清"/>触不清</label>
                         </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">震颤</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="Xin_CZZChanWu"name="Xin_CZZhenChan"value="无"onclick="$('#Xin_ZCForY').attr('disabled', true).val('');"/>无</label>
                            <label><input type="radio" id="Xin_CZZChanYou"name="Xin_CZZhenChan"value="有"onclick="$('#Xin_ZCForY').attr('disabled', false);"/>有</label>
                            部位日期<input type="text"id="Xin_ZCForY"name="Xin_ZCForY"style="width:100px;" />
                         </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">心包摩擦感</td>
                    <td width="10%" class="detailContent" style="height: 15px;">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="Xin_CZXBMCGanWu"name="Xin_CZXBMCaGan"value="无"/>无</label>
                            <label><input type="radio" id="Xin_CZXBMCGanYou"name="Xin_CZXBMCaGan"value="有"/>有</label>
                         </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight: bold;"rowspan="2">叩诊</td>
                    <td width="10%" class="detailTitle" style="height: 15px;">相对浊音界</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="7">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="Xin_KZXDZYJZhengChang"name="Xin_KZXDZYinJie"value="正常"/>正常</label>
                            <label><input type="radio" id="Xin_KZXDZYJSuoXiao"name="Xin_KZXDZYinJie"value="缩小"/>缩小</label>
                            <label><input type="radio" id="Xin_KZXDZYJKuoDa"name="Xin_KZXDZYinJie"value="扩大"/>扩大</label>
                         </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="8" style="text-align:center;width:100%;"class="detailContent">
                        <table style="border:1px solid #000;border-collapse:collapse;margin: 0 auto;text-align: center">
                            <tr>
                                <td style="text-align: center;height: 15px; border-bottom:1px solid #000;"colspan="3">心脏相对浊音界</td>
                            </tr>
                            <tr>
                                <td style="text-align: center;height:15px;">右侧（cm）</td>
                                <td style="text-align: center;height: 15px; ">肋间</td>
                                <td style="text-align: center;height: 15px;">左侧（cm）</td>
                            </tr>
                            <tr>
                                <td style="text-align: center;height:15px;"><input type="text"id="Xin_KZYEr"name="Xin_KZYEr"style="width:100px;"/></td>
                                <td style="text-align: center;height: 15px;">Ⅱ</td>
                                <td style="text-align: center;height: 15px;"><input type="text"id="Xin_KZZEr"name="Xin_KZZEr" style="width:100px;"/></td>
                            </tr>
                            <tr>
                                <td style="text-align: center;height:15px;"><input type="text"id="Xin_KZYSan"name="Xin_KZYSan"style="width:100px;"/></td>
                                <td style="text-align: center;height: 15px;">Ⅲ</td>
                                <td style="text-align: center;height: 15px;"><input type="text"id="Xin_KZZSan"name="Xin_KZZSan" style="width:100px;"/></td>
                            </tr>
                            <tr>
                                <td style="text-align: center;height:15px;"><input type="text"id="Xin_KZYSi"name="Xin_KZYSi"style="width:100px;"/></td>
                                <td style="text-align: center;height: 15px;">Ⅳ</td>
                                <td style="text-align: center;height: 15px; "><input type="text"id="Xin_KZZSi"name="Xin_KZZSi"style="width:100px;"/></td>
                            </tr>
                            <tr>
                                <td style="text-align: center;height:15px;"><input type="text"id="Xin_KZYWu"name="Xin_KZYWu" style="width:100px;"/></td>
                                <td style="text-align: center;height: 15px; ">Ⅴ</td>
                                <td style="text-align: center;height: 15px; "><input type="text"id="Xin_KZZWu"name="Xin_KZZWu" style="width:100px;"/></td>
                            </tr>
                            <tr>
                                <td style="text-align: center;height:15px;border-top:1px solid #000;"colspan="3">左锁骨中线距前正中线<input type="text"id="Xin_KZZXian"name="Xin_KZZXian"style="width:50px;" />cm</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;font-weight: bold;"rowspan="2">听诊</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <span class="detailContent" style="height: 15px">
                            心率<input type="text"id="Xin_TZXinLvC"name="Xin_TZXinLvC"style="width:50px;" />次/分
                         </span>
                    </td>
                    <td width="10%" class="detailTitle" style="height: 15px;">心律</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="5">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="radio" id="Xin_TZXLvQi"name="Xin_TZXinLv"value="齐"/>齐</label>
                            <label><input type="radio" id="Xin_TZXLBuQi"name="Xin_TZXinLv"value="不齐"/>不齐</label>
                            <label><input type="radio" id="Xin_TZXLJDBuQi"name="Xin_TZXinLv"value="绝对不齐"/>绝对不齐</label>
                         </span>
                    </td>
                </tr>
                <tr>
                    <td width="10%" class="detailTitle" style="height: 15px;">心音</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="7">
                        <span class="detailContent" style="height: 15px">
                            <input type="text"id="Xin_TZXinYin"name="Xin_TZXinYin"style="width:600px;" />
                         </span>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="1">周围血管</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="9">
                        <span class="detailContent" style="height: 15px">
                            <label><input type="checkbox" id="Xin_ZWXGWYCXGuanZheng"name="Xin_ZWXGWYCXGuanZheng"value="无异常血管征"/>无异常血管征</label>
                            <label><input type="checkbox" id="Xin_ZWXGQJiYin"name="Xin_ZWXGQJiYin"value="枪击音"/>枪击音</label>
                            <label><input type="checkbox" id="Xin_ZWXGDDSChongYin"name="Xin_ZWXGDDSChongYin"value="杜朵双重音"/>杜朵双重音</label>
                            <label><input type="checkbox" id="Xin_ZWXGSChongMai"name="Xin_ZWXGSChongMai"value="水冲脉"/>水冲脉</label>
                            <label><input type="checkbox" id="Xin_ZWXGMXXGBoDong"name="Xin_ZWXGMXXGBoDong"value="毛细血管搏动"/>毛细血管搏动</label>
                            <label><input type="checkbox" id="Xin_ZWXGMBDuanChu"name="Xin_ZWXGMBDuanChu"value="脉搏短绌"/>脉搏短绌</label>
                            <label><input type="checkbox" id="Xin_ZWXGQiMai"name="Xin_ZWXGQiMai"value="奇脉"/>奇脉</label>
                            <label><input type="checkbox" id="Xin_ZWXGJTiMai"name="Xin_ZWXGJTiMai"value="交替脉"/>交替脉</label>
                            其他<input type="text"id="Xin_ZWXGQiTa"name="Xin_ZWXGQiTa"style="width:200px;" />
                         </span>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="10">腹部</td>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="1">视诊</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="8">
                        <input type="text"id="FBu_ShiZhen"name="FBu_ShiZhen"style="width:700px;" />
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="7">触诊</td>
                    <td width="10%" class="detailContent" style="height: 15px;">
                        <label><input type="checkbox"id="FBu_CZRouRuan"name="FBu_ChuZhen"value="柔软" />柔软</label>
                    </td>
                    <td width="11%" class="detailTitle" style="height: 15px; ">腹肌紧张</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <label><input type="radio" id="FBu_CZFJJZhangWu"name="FBu_CZFJJinZhang"value="无"onclick="$('#FBu_CZFJJZForYou').attr('disabled', true).val('');"/>无</label>
                        <label><input type="radio" id="FBu_CZFJJZhangYou"name="FBu_CZFJJinZhang"value="有"onclick="$('#FBu_CZFJJZForYou').attr('disabled', false);"/>有</label>
                        部位<input type="text"id="FBu_CZFJJZForYou"name="FBu_CZFJJZForYou"style="width:100px;" />
                    </td>
                    <td width="11%" class="detailTitle" style="height: 15px; ">压痛</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="3">
                        <label><input type="radio" id="FBu_CZYTongWu"name="FBu_CZYaTong"value="无"onclick="$('#FBu_CZYTForYou').attr('disabled', true).val('');"/>无</label>
                        <label><input type="radio" id="FBu_CZYTongYou"name="FBu_CZYaTong"value="有"onclick="$('#FBu_CZYTForYou').attr('disabled', false);"/>有</label>
                        部位<input type="text"id="FBu_CZYTForYou"name="FBu_CZYTForYou"style="width:100px;" />
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; ">反跳痛</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <label><input type="radio" id="FBu_CZFTTongWu"name="FBu_CZFTiaoTong"value="无"onclick="$('#FBu_CZFTTForYou').attr('disabled', true).val('');"/>无</label>
                        <label><input type="radio" id="FBu_CZFTTongYou"name="FBu_CZFTiaoTong"value="有"onclick="$('#FBu_CZFTTForYou').attr('disabled', false);"/>有</label>
                        部位<input type="text"id="FBu_CZFTTForYou"name="FBu_CZFTTForYou"style="width:100px;" />
                    </td>
                    <td width="11%" class="detailTitle" style="height: 15px; ">液波震颤</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <label><input type="radio" id="FBu_CZYBZChanWu"name="FBu_CZYBZhenChan"value="无"/>无</label>
                        <label><input type="radio" id="FBu_CZYBZChanYou"name="FBu_CZYBZhenChan"value="有"/>有</label>
                    </td>
                    <td width="11%" class="detailTitle" style="height: 15px; ">振水声</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="1">
                        <label><input type="radio" id="FBu_CZZSShengWu"name="FBu_CZZShuiSheng"value="无"/>无</label>
                        <label><input type="radio" id="FBu_CZZSShengYou"name="FBu_CZZShuiSheng"value="有"/>有</label>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; ">腹部包块</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="8">
                        <label><input type="radio" id="FBu_CZFBBKuaiWu"name="FBu_CZFBBaoKuai"value="无"onclick="$('#FBu_CZFBBKForYou').attr('disabled', true).val('');"/>无</label>
                        <label><input type="radio" id="FBu_CZFBBKuaiYou"name="FBu_CZFBBaoKuai"value="有"onclick="$('#FBu_CZFBBKForYou').attr('disabled', false);"/>有</label>
                        部位<input type="text"id="FBu_CZFBBKForYou"name="FBu_CZFBBKForYou"style="width:100px;" />
                        特征描述<input type="text"id="FBu_CZFBBKTZMiaoShu"name="FBu_CZFBBKTZMiaoShu"style="width:300px;" />
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; ">肝</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="8">
                        <input type="text"id="FBu_CZGan"name="FBu_CZGan"style="width:600px;" />
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; ">胆囊</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="8">
                        <input type="text"id="FBu_CZDanNang"name="FBu_CZDanNang"style="width:600px;" />
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; ">脾</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="8">
                        <input type="text"id="FBu_CZPi"name="FBu_CZPi"style="width:600px;" />
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; ">肾</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="8">
                        <input type="text"id="FBu_CZShen"name="FBu_CZShen"style="width:600px;" />
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="1">叩诊</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="8">
                        肝浊音界<label><input type="radio" id="FBu_KZGZYJCunZai"name="FBu_KZGZYinJie"value="存在"/>存在</label>
                        <label><input type="radio" id="FBu_KZGZYJSuoXiao"name="FBu_KZGZYinJie"value="缩小"/>缩小</label>
                        <label><input type="radio" id="FBu_KZGZYJXioaShi"name="FBu_KZGZYinJie"value="消失"/>消失</label>
                        肝上界位于右锁骨中线<input type="text"id="FBu_KZSGZhongXian"name="FBu_KZSGZhongXian"style="width:50px;" />肋间
                        移动性浊音<label><input type="radio" id="FBu_KZYDXZYinWu"name="FBu_KZYDXZhuoYin"value="无"/>无</label>
                        <label><input type="radio" id="FBu_KZYDXZYinYou"name="FBu_KZYDXZhuoYin"value="有"/>有</label>
                        肾区叩痛<label><input type="radio" id="FBu_KZSQKTongWu"name="FBu_KZSQKouTong"value="无"/>无</label>
                        <label><input type="radio" id="FBu_KZSQKTongYou"name="FBu_KZSQKouTong"value="有"/>有</label>
                        其他<input type="text"id="FBu_KZQiTa"name="FBu_KZQiTa"style="width:150px;" />
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="1">听诊</td>
                     <td width="11%" class="detailTitle" style="height: 15px; " >肠鸣音</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <label><input type="radio" id="FBu_KZCMYZhengChang"name="FBu_TZCMinYin"value="正常"/>正常</label>
                        <label><input type="radio" id="FBu_KZCMYKangJin"name="FBu_TZCMinYin"value="亢进"/>亢进</label>
                        <label><input type="radio" id="FBu_KZCMYJianRuo"name="FBu_TZCMinYin"value="减弱"/>减弱</label>
                        <label><input type="radio" id="FBu_KZCMYXiaoShi"name="FBu_TZCMinYin"value="消失"/>消失</label>
                    </td>
                    <td width="11%" class="detailTitle" style="height: 15px; " >血管杂音</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                       <label><input type="radio" id="FBu_TZXGZYinWu"name="FBu_TZXGZaYin"value="无" onclick="$('#FBu_TZXGZYForY').attr('disabled', true).val('');"/>无</label>
                        <label><input type="radio" id="FBu_TZXGZYinYou"name="FBu_TZXGZaYin"value="有"onclick="$('#FBu_TZXGZYForY').attr('disabled', false);"/>有</label>
                        部位<input type="text"id="FBu_TZXGZYForY"name="FBu_TZXGZYForY"style="width:100px;" />
                    </td>
                    <td width="11%" class="detailTitle" style="height: 15px; " >气过水声</td>
                    <td width="10%" class="detailContent" style="height: 15px;">
                       <label><input type="radio" id="FBu_TZQGSShengWu"name="FBu_TZQGShuiSheng"value="无"/>无</label>
                        <label><input type="radio" id="FBu_TZQGSShengYou"name="FBu_TZQGShuiSheng"value="有"/>有</label>
                    </td>
                    
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="1">肛门直肠</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="9">
                        <label><input type="radio" id="GMZChang_ZhengChang"name="GMZChang"value="正常" onclick="$('#GMZChangForY').attr('disabled', true).val('');"/>正常</label>
                        <label><input type="radio" id="GMZChang_YiChang"name="GMZChang"value="异常"onclick="$('#GMZChangForY').attr('disabled', false);"/>异常:</label>
                        <input type="text"id="GMZChangForY"name="GMZChangForY"style="width:700px;" />
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="1">生殖器</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="9">
                        <label><input type="radio" id="SZQi_ZhengChang"name="SZQi"value="正常" onclick="$('#SZQiForY').attr('disabled', true).val('');"/>正常</label>
                        <label><input type="radio" id="SZQi_YiChang"name="SZQi"value="异常"onclick="$('#SZQiForY').attr('disabled', false);"/>异常:</label>
                        <input type="text"id="SZQiForY"name="SZQiForY"style="width:700px;" />
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="2">骨骼肌肉</td>
                    <td width="11%" class="detailTitle" style="height: 15px;">脊柱</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="2">
                        <label><input type="radio" id="GGJRou_JZZhengChang"name="GGJRou_JiZhu"value="正常" onclick="$('#GGJRou_JZForJX').attr('disabled', true).val('');"/>正常</label>
                        <label><input type="radio" id="GGJRou_JZJiXing"name="GGJRou_JiZhu"value="畸形"onclick="$('#GGJRou_JZForJX').attr('disabled', false);"/>畸形</label>
                        <select id="GGJRou_JZForJX"name="GGJRou_JZForJX"style="width:100px;">
                            <option value="">==请选择==</option>
                            <option value="侧凸">侧凸</option>
                            <option value="前凸">前凸</option>
                            <option value="后凸">后凸</option>
                        </select>
                    </td>
                    <td width="11%" class="detailTitle" style="height: 15px;">其他</td>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="5">
                        <span class="detailContent" style="height: 15px">
                        <input type="text"id="GGJRou_QiTa"name="GGJRou_QiTa"style="width:400px;" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px;">四肢</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="8">
                        <span class="detailContent" style="height: 15px">
                        <label><input type="radio" id="GGJRou_JSZZhengChang"name="GGJRou_SiZhi"value="正常"/>正常</label>
                        <label><input type="radio" id="GGJRou_SZYiChang"name="GGJRou_SiZhi"value="异常"/>异常</label>
                        <label><input type="radio" id="GGJRou_SZJiXing"name="GGJRou_SiZhi"value="畸形"/>畸形</label>
                        <label><input type="radio" id="GGJRou_SZGJHongZhong"name="GGJRou_SiZhi"value="关节红肿"/>关节红肿</label>
                        <label><input type="radio" id="GGJRou_SZGJQiangZhi"name="GGJRou_SiZhi"value="关节强直"/>关节强直</label>
                        <label><input type="radio" id="GGJRou_SZJRYaTong"name="GGJRou_SiZhi"value="肌肉压痛"/>肌肉压痛</label>
                        <label><input type="radio" id="GGJRou_SZJRWeiSuo"name="GGJRou_SiZhi"value="肌肉萎缩"/>肌肉萎缩</label>
                        <label><input type="radio" id="GGJRou_SZLZheng"name="GGJRou_SiZhi"value="Laseque征"/>Laseque征</label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="1">神经系统</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="9">
                       <span class="detailContent" style="height: 15px">
                           <textarea id="SJXiTong" name="SJXiTong"rows="" cols=""  style="width:100%;height:70px;"></textarea>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="1">专科情况</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="9">
                       <span class="detailContent" style="height: 15px">
                           <textarea id="ZKQingKuang" name="ZKQingKuang"rows="" cols=""  style="width:100%;height:70px;"></textarea>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td  style="height: 25px;text-align:center;font-weight:bold;" class="detailContent" colspan="10">实验室及器械检查</td>
                </tr>
                <tr>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="10">
                        <span class="detailContent" style="height: 15px">
                            <textarea id="SYSJQXJianCha" name="SYSJQXJianCha"rows="" cols=""  style="width:100%;height:100px;"></textarea>
                        </span>
                    </td>
                </tr>
                 <tr>
                    <td  style="height: 25px;text-align:center;font-weight:bold;" class="detailContent" colspan="10">病历摘要</td>
                </tr>
                <tr>
                    <td width="10%" class="detailContent" style="height: 15px;" colspan="10">
                        <span class="detailContent" style="height: 15px">
                            <textarea id="BLZhaiYao" name="BLZhaiYao"rows="" cols=""  style="width:100%;height:100px;"></textarea>
                        </span>
                    </td>
                </tr>
                 <tr>
                    <td  style="height: 25px;text-align:center;font-weight:bold;" class="detailContent" colspan="10">诊断</td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="1">初步诊断</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="9">
                       <span class="detailContent" style="height: 15px">
                           <textarea id="CBZhenDuan" name="CBZhenDuan"rows="" cols=""  style="width:100%;height:70px;"></textarea>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="1">入院诊断</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="9">
                       <span class="detailContent" style="height: 15px">
                           <textarea id="RYZhenDuan" name="RYZhenDuan"rows="" cols=""  style="width:100%;height:70px;"></textarea>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td width="11%" class="detailTitle" style="height: 15px; font-weight: bold;" rowspan="1">修正诊断</td>
                    <td width="10%" class="detailContent" style="height: 15px;"colspan="9">
                       <span class="detailContent" style="height: 15px">
                           <textarea id="XZZhenDuan" name="XZZhenDuan"rows="" cols=""  style="width:100%;height:70px;" disabled="disabled"></textarea>
                        </span>
                    </td>
                </tr>
                <tr>
                     
                    <td width="100%" class="detailContent" style="height: 25px;text-align:right;" colspan="10">
                        <table align="right">
                            <tr>
                                 
                                <td width="20%" class="detailTitle" style="height: 25px">填写人<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px">
                                    <span class="detailContent" style="height: 25px">
                                        <input type="text" id="Writor" name="Writor" style="width: 100px;"/>
                                    </span>
                                </td>
                                <td width="30%" class="detailTitle" style="height: 25px">登记日期<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px">
                                    <span class="detailContent" style="height: 25px">
                                        <input type="text" id="RegisterDate" name="RegisterDate" style="width: 100px;" onclick="WdatePicker({ maxDate: '%y-%M-%d' });"/>
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                     
                    <td width="100%" class="detailContent" style="height: 25px;text-align:right;" colspan="10">
                        <table align="right">
                            <tr>
                                 
                                <td width="20%" class="detailTitle" style="height: 25px">评审人<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px">
                                    <span class="detailContent" style="height: 25px">
                                        <input type="text" id="Reviewer" name="Reviewer" style="width: 100px;" disabled="disabled"/>
                                    </span>
                                </td>
                                <td width="30%" class="detailTitle" style="height: 25px">评审日期<span style="color: #ff0000">*</span></td>
                                <td width="20%" class="detailContent" style="height: 25px">
                                    <span class="detailContent" style="height: 25px">
                                        <input type="text" id="ReviewerDate" name="ReviewerDate" style="width: 100px;" disabled="disabled" onclick="WdatePicker({ maxDate: '%y-%M-%d' });"/>
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="last">
                    <td colspan="10" style="height: 25px; border-left: 1px solid white; border-right: 1px solid white; border-bottom: 1px solid white">
                        <div style="text-align: center; margin-top: 8px;">

                            <input id="SaveAndUpdate" name="SaveAndUpdate" type="button" style="cursor: pointer; background-image: url(../../images/save.jpg); border: none; height: 21px; width: 88px;"/>
                            <a style="padding-left: 2em"></a>
                            <input type="button" style="cursor: pointer; background-image: url(../../images/2.jpg); border: none; height: 21px; width: 88px;" onclick="form1.reset();"/>

                        </div>
                    </td>
                </tr>
            </table>

        </div>
    </form>

</body>
</html>

