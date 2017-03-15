using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Common;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
   public class BigMedicalRecordsDAL
    {
       SqlHelper db = new SqlHelper();

       #region Add(BigMedicalRecordsDAL model)
       public bool Add(BigMedicalRecordsModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_BigMedicalRecords(");
           strSql.Append("Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,TeacherId,TeacherName,PatientNo,InhospitalNo,PatientName,sex,Age,Job,Nation,Marriage,BirthProvinceCode,BirthProvinceName,BirthCityCode,BirthCityName,BirthAreaCode,BirthAreaName,BirthDetailAddress,Company,NowProvinceCode,NowProvinceName,NowCityCode,NowCityName,NowAreaCode,NowAreaName,NowDetailAddress,Phone,InhospitalDate,RecordDate,MedicalHistorySpeaker,ReliableDegree,ZSu,XBShi,JWShi_PSJKZhuangKuang,JWShi_CHJBHCRBingShi,JWShi_YFJZhongShi,JWShi_GMinShi,JWShi_GMinYuan,JWShi_LCBiaoXian,JWShi_WShangShi,JWShi_SShuShi,XTHGu_KeSou,XTHGu_KeTan,XTHGu_KaXie,XTHGu_ChuanXi,XTHGu_XiongTong,XTHGu_HXKunNan,XTHGu_XinJi,XTHGu_HDHQiCu,XTHGu_XZShuiZhong,XTHGu_XQQuTong,XTHGu_XYZengGao,XTHGu_YunJue,XTHGu_SYJianTui,XTHGu_FanSuan,XTHGu_AiQi,XTHGu_EXin,XTHGu_OuTu,XTHGu_FuZhang,XTHGu_FuTong,XTHGu_BianMi,XTHGu_FuXie,XTHGu_OuXue,XTHGu_HeiBian,XTHGu_BianXue,XTHGu_HuangDan,XTHGu_YaoTong,XTHGu_NiaoPin,XTHGu_NiaoJi,XTHGu_NiaoTong,XTHGu_PNKunNan,XTHGu_XueNiao,XTHGu_NLYiChang,XTHGu_YNZengDuo,XTHGu_ShuiZhong,XTHGu_YBSaoYang,XTHGu_YBKuiLan,XTHGu_FaLi,XTHGu_TouYun,XTHGu_YanHua,XTHGu_YYChuXue,XTHGu_BChuXue,XTHGu_PXChuXue,XTHGu_GuTong,XTHGu_SYKangJin,XTHGu_PaRe,XTHGu_DuoHan,XTHGu_WeiHan,XTHGu_DuoYin,XTHGu_DuoNiao,XTHGu_SSZhenChan,XTHGu_XGGaiBian,XTHGu_XZFeiPang,XTHGu_MXXiaoShou,XTHGu_MFZengDuov,XTHGu_MFTuoLuo,XTHGu_SSChenZhuo,XTHGu_XGNGaiBian,XTHGu_BiJing,XTHGu_GJieTong,XTHGu_GJHongZhong,XTHGu_GJBianXing,XTHGu_JRouTong,XTHGu_JRWeiSuo,XTHGu_TouTong,XTHGu_XuanYun,XTHGu_YunJue1,JXTHGu_JYLJianTui,XTHGu_SLZhangAi,XTHGu_ShiMian,XTHGu_YSZhangAi,XTHGu_ChanDong,XTHGu_ChouChu,XTHGu_TanHuan,XTHGu_GJYiChang,GRShi_BirthProvinceCode,GRShi_BirthProvinceName,GRShi_BirthCityCode,GRShi_BirthCityName,GRShi_BirthAreaCode,GRShi_BirthAreaName,GRShi_BirthDetailAddress,GRShi_CSHZGongZuo,GRShi_DFBDQJZQingKuang,GRShi_YYouShi,GRShi_ShiYan,GRShi_SYanNian,GRShi_SYanZhi,GRShi_JieYan,GRShi_JYanNian,GRShi_ShiJiu,GRShi_SJiuNian,GRShi_SJiuLiang,GRShi_SJQiTa,HYShi_JHNianLing,HYShi_POQingKuang,YJSHSYShi_CChaoSui,YJSHSYShi_CChaoTian,YJSHSYShi_MCYJRiQi,YJSHSYShi_JJNianLing,YJSHSYShi_ZhouQi,YJSHSYShi_JingLiang,YJSHSYShi_TongJing,YJSHSYShi_JingQi,YJSHSYShi_RenShen,YJSHSYShi_ShunChan,YJSHSYShi_LiuChan,YJSHSYShi_ZaoChan,YJSHSYShi_SiChan,YJSHSYShi_NCJBingQing,YJSHSYShi_Zi,YJSHSYShi_Nv,JZShi_Fu,JZShi_FSiYin,JZShi_Mu,JZShi_MSiYin,JZShi_XDJieMei,JZShi_ZNJQiTa,SMTZheng_TiWen,SMTZheng_MaiBo,SMTZheng_HuXi,SMTZheng_XueYa1,SMTZheng_XueYa2,SMTZheng_TiZhong,YBZKuang_FaYu,YBZKuang_YingYang,YBZKuang_MianRong,YBZKuang_QiTa,YBZKuang_BiaoQing,YBZKuang_TiWei,YBZKuang_TWForQP,YBZKuang_BuTai,YBZKuang_BTForBZC,YBZKuang_ShenZhi,YBZKuang_PHJianCha,PFNMo_SeZe,PFNMo_PiZhen,PFNMo_PZLXJFenBu,PFNMo_PXChuXue,PFNMo_PXCXLXJFenBu,PFNMo_MFFenBu,PFNMo_MFFBBuWei,PFNMo_WDYShiDu,PFNMo_TanXing,PFNMo_GanZhang,PFNMo_ShuiZhong,PFNMo_BWJChengDu,PFNMo_ZZhuZhi,PFNMo_ZZZBuWei,PFNMo_ZZZShuMu,PFNMo_QiTa,LBJie_QSQBLBaJie,LBJie_QSQBLBJBWJTeZheng,TBu_TLDaXiao,TBu_TLJiXing,TBu_TLJXForYou,TBu_TLQTYCYaTong,TBu_TLQTYCBaoKuai,TBu_TLQTYCAoXian,TBu_TLQTYCBuWei,TBu_YMMXiShu,TBu_YMMTuoLuo,TBu_YDaoJie,TBu_YYanJian,TBu_YJieMo,TBu_YJiaoMo,TBu_YJiaoMForYiChang,TBu_YGongMo,TBu_YYanQiu,TBu_YYQForAll,TBu_YTongKong,TBu_TKForBuDengZ,TBu_TKForBuDengY,TBu_YTKDGFanShe,TBu_YTKDGFSForAll,TBu_YTKJShiLi,TBu_TKJSLForAllZ,TBu_TKJSLForAllY,TBu_TKJSLQiTa,TBu_EErKuo,TBu_EEKQiTa,TBu_EErKForAll,TBu_EWEDFMiWu,TBu_EWEDFMWForY,TBu_EWEDFMWXingZhi,TBu_ERTYaTong,TBu_ERTYTForY,TBu_TLCSZhangAi,TBu_TLCSZAForY,TBu_BWaiXing,TBu_BForYC,TBu_BBDYaTong,TBu_BForBDYT,TBu_BQTYCBYShanDong,TBu_BQTYCFMiWu,TBu_BQTYCChuXue,TBu_BQTYCZuSe,TBu_BQTYCBZGPianQu,TBu_BQTYCBZGChuanKong,TBu_KQKouChun,TBu_KQNianMo,TBu_KQNMForYC,TBu_KQSXDGKaiKou,TBu_KQSXDGKKForYC,TBu_KQShe,TBu_KQSForYC,TBu_KQChiYin,TBu_KQChiLie,TBu_KQBTaoTi,TBu_KQBTTForZD,TBu_KQYan,TBu_KQShengYin,JBu_DKangGan,JBu_QiGuan,JBu_QGForPY,JBu_JJingMai,JBu_JDMBoDoong,JBu_JDMBDForAll,JBu_GJJMHLiuZheng,JBu_JZhuangXian,JBu_JZXForZDZ,JBu_JZXForZDY,JBu_JZXZhiRuan,JBu_JZXZhiYing,JBu_JZXYaTong,JBu_JZXZhenChan,JBu_JZXXGZaYin,XBu_XiongKuo,XBu_RuFang,XBu_RFForYC,Fei_SZHXYunDong,Fei_SZHXYDForYC,Fei_SZLJianXi,Fei_SZLJXBWForAll,Fei_CZYuChan,Fei_CZYCForYC,Fei_CZXMMCaGan,Fei_CZXMMCGForY,Fei_CZPXNFaGan,Fei_CZPXNFGForY,Fei_KouZhen,Fei_KZForAll,Fei_FXJJJiaXianY,Fei_FXJJJiaXianZ,Fei_FXJSGZhongXianY,Fei_FXJSGZhongXianZ,Fei_FXJYZhongXianY,Fei_FXJYZhongXianZ,Fei_FXJYDongDuY,Fei_FXJYDongDuZ,Fei_TZHuXi,Fei_TZHXiYin,Fei_TZHXYForYC,Fei_TZLuoYing,Fei_TZLYForY,Fei_TZYYChuanDao,Fei_TZYYCDForYC,Fei_TZXMMCaYin,Fei_XMMCYForY,Xin_SZXQQLongQi,Xin_SZXJBDWeiZhi,Xin_SZXJBOWZForYW,Xin_SZXJBoDong,Xin_SZXQQYCBoDong,Xin_SZXQQYCBDForY,Xin_CZXJBoDong,Xin_CZZhenChan,Xin_ZCForY,Xin_CZXBMCaGan,Xin_KZXDZYinJie,Xin_KZYEr,Xin_KZZEr,Xin_KZYSan,Xin_KZZSan,Xin_KZYSi,Xin_KZZSi,Xin_KZYWu,Xin_KZZWu,Xin_KZZXian,Xin_TZXinLvC,Xin_TZXinLv,Xin_TZXinYin,Xin_ZWXGWYCXGuanZheng,Xin_ZWXGQJiYin,Xin_ZWXGDDSChongYin,Xin_ZWXGSChongMai,Xin_ZWXGMXXGBoDong,Xin_ZWXGMBDuanChu,Xin_ZWXGQiMai,Xin_ZWXGJTiMai,Xin_ZWXGQiTa,FBu_ShiZhen,FBu_CZRouRuan,FBu_CZFJJinZhang,FBu_CZFJJZForYou,FBu_CZYaTong,FBu_CZYTForYou,FBu_CZFTiaoTong,FBu_CZFTTForYou,FBu_CZYBZhenChan,FBu_CZZShuiSheng,FBu_CZFBBaoKuai,FBu_CZFBBKForYou,FBu_CZFBBKTZMiaoShu,FBu_CZGan,FBu_CZDanNang,FBu_CZPi,FBu_CZShen,FBu_KZGZYinJie,FBu_KZSGZhongXian,FBu_KZYDXZhuoYin,FBu_KZSQKouTong,FBu_KZQiTa,FBu_TZCMinYin,FBu_TZXGZaYin,FBu_TZXGZYForY,FBu_TZQGShuiSheng,GMZChang,GMZChangForY,SZQi,SZQiForY,GGJRou_JiZhu,GGJRou_JZForJX,GGJRou_QiTa,GGJRou_SiZhi,SJXiTong,ZKQingKuang,SYSJQXJianCha,BLZhaiYao,CBZhenDuan,RYZhenDuan,XZZhenDuan,Reviewer,ReviewerDate,RecordsStatus)");
           strSql.Append(" values (");
           strSql.Append("@Id,@StudentsRealName,@StudentsName,@TrainingBaseCode,@TrainingBaseName,@ProfessionalBaseCode,@ProfessionalBaseName,@DeptCode,@DeptName,@RegisterDate,@Writor,@TeacherCheck,@KzrCheck,@BaseCheck,@ManagerCheck,@TeacherId,@TeacherName,@PatientNo,@InhospitalNo,@PatientName,@sex,@Age,@Job,@Nation,@Marriage,@BirthProvinceCode,@BirthProvinceName,@BirthCityCode,@BirthCityName,@BirthAreaCode,@BirthAreaName,@BirthDetailAddress,@Company,@NowProvinceCode,@NowProvinceName,@NowCityCode,@NowCityName,@NowAreaCode,@NowAreaName,@NowDetailAddress,@Phone,@InhospitalDate,@RecordDate,@MedicalHistorySpeaker,@ReliableDegree,@ZSu,@XBShi,@JWShi_PSJKZhuangKuang,@JWShi_CHJBHCRBingShi,@JWShi_YFJZhongShi,@JWShi_GMinShi,@JWShi_GMinYuan,@JWShi_LCBiaoXian,@JWShi_WShangShi,@JWShi_SShuShi,@XTHGu_KeSou,@XTHGu_KeTan,@XTHGu_KaXie,@XTHGu_ChuanXi,@XTHGu_XiongTong,@XTHGu_HXKunNan,@XTHGu_XinJi,@XTHGu_HDHQiCu,@XTHGu_XZShuiZhong,@XTHGu_XQQuTong,@XTHGu_XYZengGao,@XTHGu_YunJue,@XTHGu_SYJianTui,@XTHGu_FanSuan,@XTHGu_AiQi,@XTHGu_EXin,@XTHGu_OuTu,@XTHGu_FuZhang,@XTHGu_FuTong,@XTHGu_BianMi,@XTHGu_FuXie,@XTHGu_OuXue,@XTHGu_HeiBian,@XTHGu_BianXue,@XTHGu_HuangDan,@XTHGu_YaoTong,@XTHGu_NiaoPin,@XTHGu_NiaoJi,@XTHGu_NiaoTong,@XTHGu_PNKunNan,@XTHGu_XueNiao,@XTHGu_NLYiChang,@XTHGu_YNZengDuo,@XTHGu_ShuiZhong,@XTHGu_YBSaoYang,@XTHGu_YBKuiLan,@XTHGu_FaLi,@XTHGu_TouYun,@XTHGu_YanHua,@XTHGu_YYChuXue,@XTHGu_BChuXue,@XTHGu_PXChuXue,@XTHGu_GuTong,@XTHGu_SYKangJin,@XTHGu_PaRe,@XTHGu_DuoHan,@XTHGu_WeiHan,@XTHGu_DuoYin,@XTHGu_DuoNiao,@XTHGu_SSZhenChan,@XTHGu_XGGaiBian,@XTHGu_XZFeiPang,@XTHGu_MXXiaoShou,@XTHGu_MFZengDuov,@XTHGu_MFTuoLuo,@XTHGu_SSChenZhuo,@XTHGu_XGNGaiBian,@XTHGu_BiJing,@XTHGu_GJieTong,@XTHGu_GJHongZhong,@XTHGu_GJBianXing,@XTHGu_JRouTong,@XTHGu_JRWeiSuo,@XTHGu_TouTong,@XTHGu_XuanYun,@XTHGu_YunJue1,@JXTHGu_JYLJianTui,@XTHGu_SLZhangAi,@XTHGu_ShiMian,@XTHGu_YSZhangAi,@XTHGu_ChanDong,@XTHGu_ChouChu,@XTHGu_TanHuan,@XTHGu_GJYiChang,@GRShi_BirthProvinceCode,@GRShi_BirthProvinceName,@GRShi_BirthCityCode,@GRShi_BirthCityName,@GRShi_BirthAreaCode,@GRShi_BirthAreaName,@GRShi_BirthDetailAddress,@GRShi_CSHZGongZuo,@GRShi_DFBDQJZQingKuang,@GRShi_YYouShi,@GRShi_ShiYan,@GRShi_SYanNian,@GRShi_SYanZhi,@GRShi_JieYan,@GRShi_JYanNian,@GRShi_ShiJiu,@GRShi_SJiuNian,@GRShi_SJiuLiang,@GRShi_SJQiTa,@HYShi_JHNianLing,@HYShi_POQingKuang,@YJSHSYShi_CChaoSui,@YJSHSYShi_CChaoTian,@YJSHSYShi_MCYJRiQi,@YJSHSYShi_JJNianLing,@YJSHSYShi_ZhouQi,@YJSHSYShi_JingLiang,@YJSHSYShi_TongJing,@YJSHSYShi_JingQi,@YJSHSYShi_RenShen,@YJSHSYShi_ShunChan,@YJSHSYShi_LiuChan,@YJSHSYShi_ZaoChan,@YJSHSYShi_SiChan,@YJSHSYShi_NCJBingQing,@YJSHSYShi_Zi,@YJSHSYShi_Nv,@JZShi_Fu,@JZShi_FSiYin,@JZShi_Mu,@JZShi_MSiYin,@JZShi_XDJieMei,@JZShi_ZNJQiTa,@SMTZheng_TiWen,@SMTZheng_MaiBo,@SMTZheng_HuXi,@SMTZheng_XueYa1,@SMTZheng_XueYa2,@SMTZheng_TiZhong,@YBZKuang_FaYu,@YBZKuang_YingYang,@YBZKuang_MianRong,@YBZKuang_QiTa,@YBZKuang_BiaoQing,@YBZKuang_TiWei,@YBZKuang_TWForQP,@YBZKuang_BuTai,@YBZKuang_BTForBZC,@YBZKuang_ShenZhi,@YBZKuang_PHJianCha,@PFNMo_SeZe,@PFNMo_PiZhen,@PFNMo_PZLXJFenBu,@PFNMo_PXChuXue,@PFNMo_PXCXLXJFenBu,@PFNMo_MFFenBu,@PFNMo_MFFBBuWei,@PFNMo_WDYShiDu,@PFNMo_TanXing,@PFNMo_GanZhang,@PFNMo_ShuiZhong,@PFNMo_BWJChengDu,@PFNMo_ZZhuZhi,@PFNMo_ZZZBuWei,@PFNMo_ZZZShuMu,@PFNMo_QiTa,@LBJie_QSQBLBaJie,@LBJie_QSQBLBJBWJTeZheng,@TBu_TLDaXiao,@TBu_TLJiXing,@TBu_TLJXForYou,@TBu_TLQTYCYaTong,@TBu_TLQTYCBaoKuai,@TBu_TLQTYCAoXian,@TBu_TLQTYCBuWei,@TBu_YMMXiShu,@TBu_YMMTuoLuo,@TBu_YDaoJie,@TBu_YYanJian,@TBu_YJieMo,@TBu_YJiaoMo,@TBu_YJiaoMForYiChang,@TBu_YGongMo,@TBu_YYanQiu,@TBu_YYQForAll,@TBu_YTongKong,@TBu_TKForBuDengZ,@TBu_TKForBuDengY,@TBu_YTKDGFanShe,@TBu_YTKDGFSForAll,@TBu_YTKJShiLi,@TBu_TKJSLForAllZ,@TBu_TKJSLForAllY,@TBu_TKJSLQiTa,@TBu_EErKuo,@TBu_EEKQiTa,@TBu_EErKForAll,@TBu_EWEDFMiWu,@TBu_EWEDFMWForY,@TBu_EWEDFMWXingZhi,@TBu_ERTYaTong,@TBu_ERTYTForY,@TBu_TLCSZhangAi,@TBu_TLCSZAForY,@TBu_BWaiXing,@TBu_BForYC,@TBu_BBDYaTong,@TBu_BForBDYT,@TBu_BQTYCBYShanDong,@TBu_BQTYCFMiWu,@TBu_BQTYCChuXue,@TBu_BQTYCZuSe,@TBu_BQTYCBZGPianQu,@TBu_BQTYCBZGChuanKong,@TBu_KQKouChun,@TBu_KQNianMo,@TBu_KQNMForYC,@TBu_KQSXDGKaiKou,@TBu_KQSXDGKKForYC,@TBu_KQShe,@TBu_KQSForYC,@TBu_KQChiYin,@TBu_KQChiLie,@TBu_KQBTaoTi,@TBu_KQBTTForZD,@TBu_KQYan,@TBu_KQShengYin,@JBu_DKangGan,@JBu_QiGuan,@JBu_QGForPY,@JBu_JJingMai,@JBu_JDMBoDoong,@JBu_JDMBDForAll,@JBu_GJJMHLiuZheng,@JBu_JZhuangXian,@JBu_JZXForZDZ,@JBu_JZXForZDY,@JBu_JZXZhiRuan,@JBu_JZXZhiYing,@JBu_JZXYaTong,@JBu_JZXZhenChan,@JBu_JZXXGZaYin,@XBu_XiongKuo,@XBu_RuFang,@XBu_RFForYC,@Fei_SZHXYunDong,@Fei_SZHXYDForYC,@Fei_SZLJianXi,@Fei_SZLJXBWForAll,@Fei_CZYuChan,@Fei_CZYCForYC,@Fei_CZXMMCaGan,@Fei_CZXMMCGForY,@Fei_CZPXNFaGan,@Fei_CZPXNFGForY,@Fei_KouZhen,@Fei_KZForAll,@Fei_FXJJJiaXianY,@Fei_FXJJJiaXianZ,@Fei_FXJSGZhongXianY,@Fei_FXJSGZhongXianZ,@Fei_FXJYZhongXianY,@Fei_FXJYZhongXianZ,@Fei_FXJYDongDuY,@Fei_FXJYDongDuZ,@Fei_TZHuXi,@Fei_TZHXiYin,@Fei_TZHXYForYC,@Fei_TZLuoYing,@Fei_TZLYForY,@Fei_TZYYChuanDao,@Fei_TZYYCDForYC,@Fei_TZXMMCaYin,@Fei_XMMCYForY,@Xin_SZXQQLongQi,@Xin_SZXJBDWeiZhi,@Xin_SZXJBOWZForYW,@Xin_SZXJBoDong,@Xin_SZXQQYCBoDong,@Xin_SZXQQYCBDForY,@Xin_CZXJBoDong,@Xin_CZZhenChan,@Xin_ZCForY,@Xin_CZXBMCaGan,@Xin_KZXDZYinJie,@Xin_KZYEr,@Xin_KZZEr,@Xin_KZYSan,@Xin_KZZSan,@Xin_KZYSi,@Xin_KZZSi,@Xin_KZYWu,@Xin_KZZWu,@Xin_KZZXian,@Xin_TZXinLvC,@Xin_TZXinLv,@Xin_TZXinYin,@Xin_ZWXGWYCXGuanZheng,@Xin_ZWXGQJiYin,@Xin_ZWXGDDSChongYin,@Xin_ZWXGSChongMai,@Xin_ZWXGMXXGBoDong,@Xin_ZWXGMBDuanChu,@Xin_ZWXGQiMai,@Xin_ZWXGJTiMai,@Xin_ZWXGQiTa,@FBu_ShiZhen,@FBu_CZRouRuan,@FBu_CZFJJinZhang,@FBu_CZFJJZForYou,@FBu_CZYaTong,@FBu_CZYTForYou,@FBu_CZFTiaoTong,@FBu_CZFTTForYou,@FBu_CZYBZhenChan,@FBu_CZZShuiSheng,@FBu_CZFBBaoKuai,@FBu_CZFBBKForYou,@FBu_CZFBBKTZMiaoShu,@FBu_CZGan,@FBu_CZDanNang,@FBu_CZPi,@FBu_CZShen,@FBu_KZGZYinJie,@FBu_KZSGZhongXian,@FBu_KZYDXZhuoYin,@FBu_KZSQKouTong,@FBu_KZQiTa,@FBu_TZCMinYin,@FBu_TZXGZaYin,@FBu_TZXGZYForY,@FBu_TZQGShuiSheng,@GMZChang,@GMZChangForY,@SZQi,@SZQiForY,@GGJRou_JiZhu,@GGJRou_JZForJX,@GGJRou_QiTa,@GGJRou_SiZhi,@SJXiTong,@ZKQingKuang,@SYSJQXJianCha,@BLZhaiYao,@CBZhenDuan,@RYZhenDuan,@XZZhenDuan,@Reviewer,@ReviewerDate,@RecordsStatus)");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentsRealName", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentsName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@DeptCode", SqlDbType.NVarChar,50),
					new SqlParameter("@DeptName", SqlDbType.NVarChar,500),
					new SqlParameter("@RegisterDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Writor", SqlDbType.NVarChar,50),
					new SqlParameter("@TeacherCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@KzrCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@BaseCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@ManagerCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@TeacherId", SqlDbType.NVarChar,50),
					new SqlParameter("@TeacherName", SqlDbType.NVarChar,50),
					new SqlParameter("@PatientNo", SqlDbType.NVarChar,50),
					new SqlParameter("@InhospitalNo", SqlDbType.NVarChar,50),
					new SqlParameter("@PatientName", SqlDbType.NVarChar,50),
					new SqlParameter("@sex", SqlDbType.NVarChar,50),
					new SqlParameter("@Age", SqlDbType.NVarChar,50),
					new SqlParameter("@Job", SqlDbType.NVarChar,500),
					new SqlParameter("@Nation", SqlDbType.NVarChar,50),
					new SqlParameter("@Marriage", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthProvinceCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthProvinceName", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthCityCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthCityName", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthAreaCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthDetailAddress", SqlDbType.NVarChar,500),
					new SqlParameter("@Company", SqlDbType.NVarChar,50),
					new SqlParameter("@NowProvinceCode", SqlDbType.NVarChar,50),
					new SqlParameter("@NowProvinceName", SqlDbType.NVarChar,50),
					new SqlParameter("@NowCityCode", SqlDbType.NVarChar,50),
					new SqlParameter("@NowCityName", SqlDbType.NVarChar,50),
					new SqlParameter("@NowAreaCode", SqlDbType.NVarChar,50),
					new SqlParameter("@NowAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@NowDetailAddress", SqlDbType.NVarChar,500),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@InhospitalDate", SqlDbType.NVarChar,50),
					new SqlParameter("@RecordDate", SqlDbType.NVarChar,50),
					new SqlParameter("@MedicalHistorySpeaker", SqlDbType.NVarChar,50),
					new SqlParameter("@ReliableDegree", SqlDbType.NVarChar,50),
					new SqlParameter("@ZSu", SqlDbType.NVarChar,2000),
					new SqlParameter("@XBShi", SqlDbType.NVarChar,2000),
					new SqlParameter("@JWShi_PSJKZhuangKuang", SqlDbType.NVarChar,50),
					new SqlParameter("@JWShi_CHJBHCRBingShi", SqlDbType.NVarChar,1000),
					new SqlParameter("@JWShi_YFJZhongShi", SqlDbType.NVarChar,1000),
					new SqlParameter("@JWShi_GMinShi", SqlDbType.NVarChar,50),
					new SqlParameter("@JWShi_GMinYuan", SqlDbType.NVarChar,500),
					new SqlParameter("@JWShi_LCBiaoXian", SqlDbType.NVarChar,1000),
					new SqlParameter("@JWShi_WShangShi", SqlDbType.NVarChar,1000),
					new SqlParameter("@JWShi_SShuShi", SqlDbType.NVarChar,1000),
					new SqlParameter("@XTHGu_KeSou", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_KeTan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_KaXie", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_ChuanXi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XiongTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_HXKunNan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XinJi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_HDHQiCu", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XZShuiZhong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XQQuTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XYZengGao", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YunJue", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_SYJianTui", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_FanSuan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_AiQi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_EXin", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_OuTu", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_FuZhang", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_FuTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_BianMi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_FuXie", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_OuXue", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_HeiBian", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_BianXue", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_HuangDan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YaoTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_NiaoPin", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_NiaoJi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_NiaoTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_PNKunNan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XueNiao", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_NLYiChang", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YNZengDuo", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_ShuiZhong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YBSaoYang", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YBKuiLan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_FaLi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_TouYun", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YanHua", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YYChuXue", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_BChuXue", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_PXChuXue", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_GuTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_SYKangJin", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_PaRe", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_DuoHan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_WeiHan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_DuoYin", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_DuoNiao", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_SSZhenChan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XGGaiBian", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XZFeiPang", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_MXXiaoShou", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_MFZengDuov", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_MFTuoLuo", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_SSChenZhuo", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XGNGaiBian", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_BiJing", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_GJieTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_GJHongZhong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_GJBianXing", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_JRouTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_JRWeiSuo", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_TouTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XuanYun", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YunJue1", SqlDbType.NVarChar,50),
					new SqlParameter("@JXTHGu_JYLJianTui", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_SLZhangAi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_ShiMian", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YSZhangAi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_ChanDong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_ChouChu", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_TanHuan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_GJYiChang", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_BirthProvinceCode", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_BirthProvinceName", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_BirthCityCode", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_BirthCityName", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_BirthAreaCode", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_BirthAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_BirthDetailAddress", SqlDbType.NVarChar,500),
					new SqlParameter("@GRShi_CSHZGongZuo", SqlDbType.NVarChar,500),
					new SqlParameter("@GRShi_DFBDQJZQingKuang", SqlDbType.NVarChar,1000),
					new SqlParameter("@GRShi_YYouShi", SqlDbType.NVarChar,1000),
					new SqlParameter("@GRShi_ShiYan", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_SYanNian", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_SYanZhi", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_JieYan", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_JYanNian", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_ShiJiu", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_SJiuNian", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_SJiuLiang", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_SJQiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@HYShi_JHNianLing", SqlDbType.NVarChar,50),
					new SqlParameter("@HYShi_POQingKuang", SqlDbType.NVarChar,500),
					new SqlParameter("@YJSHSYShi_CChaoSui", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_CChaoTian", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_MCYJRiQi", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_JJNianLing", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_ZhouQi", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_JingLiang", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_TongJing", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_JingQi", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_RenShen", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_ShunChan", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_LiuChan", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_ZaoChan", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_SiChan", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_NCJBingQing", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_Zi", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_Nv", SqlDbType.NVarChar,50),
					new SqlParameter("@JZShi_Fu", SqlDbType.NVarChar,50),
					new SqlParameter("@JZShi_FSiYin", SqlDbType.NVarChar,500),
					new SqlParameter("@JZShi_Mu", SqlDbType.NVarChar,50),
					new SqlParameter("@JZShi_MSiYin", SqlDbType.NVarChar,500),
					new SqlParameter("@JZShi_XDJieMei", SqlDbType.NVarChar,500),
					new SqlParameter("@JZShi_ZNJQiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@SMTZheng_TiWen", SqlDbType.NVarChar,50),
					new SqlParameter("@SMTZheng_MaiBo", SqlDbType.NVarChar,50),
					new SqlParameter("@SMTZheng_HuXi", SqlDbType.NVarChar,50),
					new SqlParameter("@SMTZheng_XueYa1", SqlDbType.NVarChar,50),
					new SqlParameter("@SMTZheng_TiZhong", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_FaYu", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_YingYang", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_MianRong", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_QiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@YBZKuang_BiaoQing", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_TiWei", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_TWForQP", SqlDbType.NVarChar,500),
					new SqlParameter("@YBZKuang_BuTai", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_BTForBZC", SqlDbType.NVarChar,500),
					new SqlParameter("@YBZKuang_ShenZhi", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_PHJianCha", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_SeZe", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_PiZhen", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_PZLXJFenBu", SqlDbType.NVarChar,500),
					new SqlParameter("@PFNMo_PXChuXue", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_PXCXLXJFenBu", SqlDbType.NVarChar,500),
					new SqlParameter("@PFNMo_MFFenBu", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_MFFBBuWei", SqlDbType.NVarChar,500),
					new SqlParameter("@PFNMo_WDYShiDu", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_TanXing", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_GanZhang", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_ShuiZhong", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_BWJChengDu", SqlDbType.NVarChar,500),
					new SqlParameter("@PFNMo_ZZhuZhi", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_ZZZBuWei", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_ZZZShuMu", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_QiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@LBJie_QSQBLBaJie", SqlDbType.NVarChar,50),
					new SqlParameter("@LBJie_QSQBLBJBWJTeZheng", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_TLDaXiao", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLJiXing", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLJXForYou", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLQTYCYaTong", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLQTYCBaoKuai", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLQTYCAoXian", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLQTYCBuWei", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_YMMXiShu", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YMMTuoLuo", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YDaoJie", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YYanJian", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YJieMo", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YJiaoMo", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YJiaoMForYiChang", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YGongMo", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YYanQiu", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YYQForAll", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YTongKong", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TKForBuDengZ", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TKForBuDengY", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YTKDGFanShe", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YTKDGFSForAll", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YTKJShiLi", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TKJSLForAllZ", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TKJSLForAllY", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TKJSLQiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_EErKuo", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_EEKQiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_EErKForAll", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_EWEDFMiWu", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_EWEDFMWForY", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_EWEDFMWXingZhi", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_ERTYaTong", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_ERTYTForY", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLCSZhangAi", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLCSZAForY", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BWaiXing", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_BBDYaTong", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BForBDYT", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_BQTYCBYShanDong", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BQTYCFMiWu", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BQTYCChuXue", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BQTYCZuSe", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BQTYCBZGPianQu", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BQTYCBZGChuanKong", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_KQKouChun", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_KQNianMo", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_KQNMForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQSXDGKaiKou", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQSXDGKKForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQShe", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQSForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQChiYin", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQChiLie", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQBTaoTi", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQBTTForZD", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQYan", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQShengYin", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_DKangGan", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_QiGuan", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_QGForPY", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JJingMai", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JDMBoDoong", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JDMBDForAll", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_GJJMHLiuZheng", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZhuangXian", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZXForZDZ", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZXForZDY", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZXZhiRuan", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZXZhiYing", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZXYaTong", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZXZhenChan", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZXXGZaYin", SqlDbType.NVarChar,500),
					new SqlParameter("@XBu_XiongKuo", SqlDbType.NVarChar,500),
					new SqlParameter("@XBu_RuFang", SqlDbType.NVarChar,500),
					new SqlParameter("@XBu_RFForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_SZHXYunDong", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_SZHXYDForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_SZLJianXi", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_SZLJXBWForAll", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_CZYuChan", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_CZYCForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_CZXMMCaGan", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_CZXMMCGForY", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_CZPXNFaGan", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_CZPXNFGForY", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_KouZhen", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_KZForAll", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJJJiaXianY", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJJJiaXianZ", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJSGZhongXianY", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJSGZhongXianZ", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJYZhongXianY", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJYZhongXianZ", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJYDongDuY", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJYDongDuZ", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZHuXi", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZHXiYin", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZHXYForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZLuoYing", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZLYForY", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZYYChuanDao", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZYYCDForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZXMMCaYin", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_XMMCYForY", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_SZXQQLongQi", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_SZXJBDWeiZhi", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_SZXJBOWZForYW", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_SZXJBoDong", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_SZXQQYCBoDong", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_SZXQQYCBDForY", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_CZXJBoDong", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_CZZhenChan", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZCForY", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_CZXBMCaGan", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZXDZYinJie", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZYEr", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZZEr", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZYSan", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZZSan", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZYSi", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZZSi", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZYWu", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZZWu", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZZXian", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_TZXinLvC", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_TZXinLv", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_TZXinYin", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGWYCXGuanZheng", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGQJiYin", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGDDSChongYin", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGSChongMai", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGMXXGBoDong", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGMBDuanChu", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGQiMai", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGJTiMai", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGQiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_ShiZhen", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZRouRuan", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZFJJinZhang", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZFJJZForYou", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZYaTong", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZYTForYou", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZFTiaoTong", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZFTTForYou", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZYBZhenChan", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZZShuiSheng", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZFBBaoKuai", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZFBBKForYou", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZFBBKTZMiaoShu", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZGan", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZDanNang", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZPi", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZShen", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_KZGZYinJie", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_KZSGZhongXian", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_KZYDXZhuoYin", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_KZSQKouTong", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_KZQiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_TZCMinYin", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_TZXGZaYin", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_TZXGZYForY", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_TZQGShuiSheng", SqlDbType.NVarChar,500),
					new SqlParameter("@GMZChang", SqlDbType.NVarChar,500),
					new SqlParameter("@GMZChangForY", SqlDbType.NVarChar,500),
					new SqlParameter("@SZQi", SqlDbType.NVarChar,500),
					new SqlParameter("@SZQiForY", SqlDbType.NVarChar,500),
					new SqlParameter("@GGJRou_JiZhu", SqlDbType.NVarChar,500),
					new SqlParameter("@GGJRou_JZForJX", SqlDbType.NVarChar,500),
					new SqlParameter("@GGJRou_QiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@GGJRou_SiZhi", SqlDbType.NVarChar,500),
					new SqlParameter("@SJXiTong", SqlDbType.NVarChar,1000),
					new SqlParameter("@ZKQingKuang", SqlDbType.NVarChar,1000),
					new SqlParameter("@SYSJQXJianCha", SqlDbType.NVarChar,1000),
					new SqlParameter("@BLZhaiYao", SqlDbType.NVarChar,1000),
					new SqlParameter("@CBZhenDuan", SqlDbType.NVarChar,1000),
					new SqlParameter("@RYZhenDuan", SqlDbType.NVarChar,1000),
					new SqlParameter("@XZZhenDuan", SqlDbType.NVarChar,1000),
					new SqlParameter("@Reviewer", SqlDbType.NVarChar,50),
					new SqlParameter("@ReviewerDate", SqlDbType.NVarChar,50),
                                     new SqlParameter("@RecordsStatus", SqlDbType.NVarChar,50),
                                      new SqlParameter("@SMTZheng_XueYa2", SqlDbType.NVarChar,50) };
           parameters[0].Value = model.Id;
           parameters[1].Value = model.StudentsRealName;
           parameters[2].Value = model.StudentsName;
           parameters[3].Value = model.TrainingBaseCode;
           parameters[4].Value = model.TrainingBaseName;
           parameters[5].Value = model.ProfessionalBaseCode;
           parameters[6].Value = model.ProfessionalBaseName;
           parameters[7].Value = model.DeptCode;
           parameters[8].Value = model.DeptName;
           parameters[9].Value = model.RegisterDate;
           parameters[10].Value = model.Writor;
           parameters[11].Value = model.TeacherCheck;
           parameters[12].Value = model.KzrCheck;
           parameters[13].Value = model.BaseCheck;
           parameters[14].Value = model.ManagerCheck;
           parameters[15].Value = model.TeacherId;
           parameters[16].Value = model.TeacherName;
           parameters[17].Value = model.PatientNo;
           parameters[18].Value = model.InhospitalNo;
           parameters[19].Value = model.PatientName;
           parameters[20].Value = model.sex;
           parameters[21].Value = model.Age;
           parameters[22].Value = model.Job;
           parameters[23].Value = model.Nation;
           parameters[24].Value = model.Marriage;
           parameters[25].Value = model.BirthProvinceCode;
           parameters[26].Value = model.BirthProvinceName;
           parameters[27].Value = model.BirthCityCode;
           parameters[28].Value = model.BirthCityName;
           parameters[29].Value = model.BirthAreaCode;
           parameters[30].Value = model.BirthAreaName;
           parameters[31].Value = model.BirthDetailAddress;
           parameters[32].Value = model.Company;
           parameters[33].Value = model.NowProvinceCode;
           parameters[34].Value = model.NowProvinceName;
           parameters[35].Value = model.NowCityCode;
           parameters[36].Value = model.NowCityName;
           parameters[37].Value = model.NowAreaCode;
           parameters[38].Value = model.NowAreaName;
           parameters[39].Value = model.NowDetailAddress;
           parameters[40].Value = model.Phone;
           parameters[41].Value = model.InhospitalDate;
           parameters[42].Value = model.RecordDate;
           parameters[43].Value = model.MedicalHistorySpeaker;
           parameters[44].Value = model.ReliableDegree;
           parameters[45].Value = model.ZSu;
           parameters[46].Value = model.XBShi;
           parameters[47].Value = model.JWShi_PSJKZhuangKuang;
           parameters[48].Value = model.JWShi_CHJBHCRBingShi;
           parameters[49].Value = model.JWShi_YFJZhongShi;
           parameters[50].Value = model.JWShi_GMinShi;
           parameters[51].Value = model.JWShi_GMinYuan;
           parameters[52].Value = model.JWShi_LCBiaoXian;
           parameters[53].Value = model.JWShi_WShangShi;
           parameters[54].Value = model.JWShi_SShuShi;
           parameters[55].Value = model.XTHGu_KeSou;
           parameters[56].Value = model.XTHGu_KeTan;
           parameters[57].Value = model.XTHGu_KaXie;
           parameters[58].Value = model.XTHGu_ChuanXi;
           parameters[59].Value = model.XTHGu_XiongTong;
           parameters[60].Value = model.XTHGu_HXKunNan;
           parameters[61].Value = model.XTHGu_XinJi;
           parameters[62].Value = model.XTHGu_HDHQiCu;
           parameters[63].Value = model.XTHGu_XZShuiZhong;
           parameters[64].Value = model.XTHGu_XQQuTong;
           parameters[65].Value = model.XTHGu_XYZengGao;
           parameters[66].Value = model.XTHGu_YunJue;
           parameters[67].Value = model.XTHGu_SYJianTui;
           parameters[68].Value = model.XTHGu_FanSuan;
           parameters[69].Value = model.XTHGu_AiQi;
           parameters[70].Value = model.XTHGu_EXin;
           parameters[71].Value = model.XTHGu_OuTu;
           parameters[72].Value = model.XTHGu_FuZhang;
           parameters[73].Value = model.XTHGu_FuTong;
           parameters[74].Value = model.XTHGu_BianMi;
           parameters[75].Value = model.XTHGu_FuXie;
           parameters[76].Value = model.XTHGu_OuXue;
           parameters[77].Value = model.XTHGu_HeiBian;
           parameters[78].Value = model.XTHGu_BianXue;
           parameters[79].Value = model.XTHGu_HuangDan;
           parameters[80].Value = model.XTHGu_YaoTong;
           parameters[81].Value = model.XTHGu_NiaoPin;
           parameters[82].Value = model.XTHGu_NiaoJi;
           parameters[83].Value = model.XTHGu_NiaoTong;
           parameters[84].Value = model.XTHGu_PNKunNan;
           parameters[85].Value = model.XTHGu_XueNiao;
           parameters[86].Value = model.XTHGu_NLYiChang;
           parameters[87].Value = model.XTHGu_YNZengDuo;
           parameters[88].Value = model.XTHGu_ShuiZhong;
           parameters[89].Value = model.XTHGu_YBSaoYang;
           parameters[90].Value = model.XTHGu_YBKuiLan;
           parameters[91].Value = model.XTHGu_FaLi;
           parameters[92].Value = model.XTHGu_TouYun;
           parameters[93].Value = model.XTHGu_YanHua;
           parameters[94].Value = model.XTHGu_YYChuXue;
           parameters[95].Value = model.XTHGu_BChuXue;
           parameters[96].Value = model.XTHGu_PXChuXue;
           parameters[97].Value = model.XTHGu_GuTong;
           parameters[98].Value = model.XTHGu_SYKangJin;
           parameters[99].Value = model.XTHGu_PaRe;
           parameters[100].Value = model.XTHGu_DuoHan;
           parameters[101].Value = model.XTHGu_WeiHan;
           parameters[102].Value = model.XTHGu_DuoYin;
           parameters[103].Value = model.XTHGu_DuoNiao;
           parameters[104].Value = model.XTHGu_SSZhenChan;
           parameters[105].Value = model.XTHGu_XGGaiBian;
           parameters[106].Value = model.XTHGu_XZFeiPang;
           parameters[107].Value = model.XTHGu_MXXiaoShou;
           parameters[108].Value = model.XTHGu_MFZengDuov;
           parameters[109].Value = model.XTHGu_MFTuoLuo;
           parameters[110].Value = model.XTHGu_SSChenZhuo;
           parameters[111].Value = model.XTHGu_XGNGaiBian;
           parameters[112].Value = model.XTHGu_BiJing;
           parameters[113].Value = model.XTHGu_GJieTong;
           parameters[114].Value = model.XTHGu_GJHongZhong;
           parameters[115].Value = model.XTHGu_GJBianXing;
           parameters[116].Value = model.XTHGu_JRouTong;
           parameters[117].Value = model.XTHGu_JRWeiSuo;
           parameters[118].Value = model.XTHGu_TouTong;
           parameters[119].Value = model.XTHGu_XuanYun;
           parameters[120].Value = model.XTHGu_YunJue1;
           parameters[121].Value = model.JXTHGu_JYLJianTui;
           parameters[122].Value = model.XTHGu_SLZhangAi;
           parameters[123].Value = model.XTHGu_ShiMian;
           parameters[124].Value = model.XTHGu_YSZhangAi;
           parameters[125].Value = model.XTHGu_ChanDong;
           parameters[126].Value = model.XTHGu_ChouChu;
           parameters[127].Value = model.XTHGu_TanHuan;
           parameters[128].Value = model.XTHGu_GJYiChang;
           parameters[129].Value = model.GRShi_BirthProvinceCode;
           parameters[130].Value = model.GRShi_BirthProvinceName;
           parameters[131].Value = model.GRShi_BirthCityCode;
           parameters[132].Value = model.GRShi_BirthCityName;
           parameters[133].Value = model.GRShi_BirthAreaCode;
           parameters[134].Value = model.GRShi_BirthAreaName;
           parameters[135].Value = model.GRShi_BirthDetailAddress;
           parameters[136].Value = model.GRShi_CSHZGongZuo;
           parameters[137].Value = model.GRShi_DFBDQJZQingKuang;
           parameters[138].Value = model.GRShi_YYouShi;
           parameters[139].Value = model.GRShi_ShiYan;
           parameters[140].Value = model.GRShi_SYanNian;
           parameters[141].Value = model.GRShi_SYanZhi;
           parameters[142].Value = model.GRShi_JieYan;
           parameters[143].Value = model.GRShi_JYanNian;
           parameters[144].Value = model.GRShi_ShiJiu;
           parameters[145].Value = model.GRShi_SJiuNian;
           parameters[146].Value = model.GRShi_SJiuLiang;
           parameters[147].Value = model.GRShi_SJQiTa;
           parameters[148].Value = model.HYShi_JHNianLing;
           parameters[149].Value = model.HYShi_POQingKuang;
           parameters[150].Value = model.YJSHSYShi_CChaoSui;
           parameters[151].Value = model.YJSHSYShi_CChaoTian;
           parameters[152].Value = model.YJSHSYShi_MCYJRiQi;
           parameters[153].Value = model.YJSHSYShi_JJNianLing;
           parameters[154].Value = model.YJSHSYShi_ZhouQi;
           parameters[155].Value = model.YJSHSYShi_JingLiang;
           parameters[156].Value = model.YJSHSYShi_TongJing;
           parameters[157].Value = model.YJSHSYShi_JingQi;
           parameters[158].Value = model.YJSHSYShi_RenShen;
           parameters[159].Value = model.YJSHSYShi_ShunChan;
           parameters[160].Value = model.YJSHSYShi_LiuChan;
           parameters[161].Value = model.YJSHSYShi_ZaoChan;
           parameters[162].Value = model.YJSHSYShi_SiChan;
           parameters[163].Value = model.YJSHSYShi_NCJBingQing;
           parameters[164].Value = model.YJSHSYShi_Zi;
           parameters[165].Value = model.YJSHSYShi_Nv;
           parameters[166].Value = model.JZShi_Fu;
           parameters[167].Value = model.JZShi_FSiYin;
           parameters[168].Value = model.JZShi_Mu;
           parameters[169].Value = model.JZShi_MSiYin;
           parameters[170].Value = model.JZShi_XDJieMei;
           parameters[171].Value = model.JZShi_ZNJQiTa;
           parameters[172].Value = model.SMTZheng_TiWen;
           parameters[173].Value = model.SMTZheng_MaiBo;
           parameters[174].Value = model.SMTZheng_HuXi;
           parameters[175].Value = model.SMTZheng_XueYa1;
           parameters[176].Value = model.SMTZheng_TiZhong;
           parameters[177].Value = model.YBZKuang_FaYu;
           parameters[178].Value = model.YBZKuang_YingYang;
           parameters[179].Value = model.YBZKuang_MianRong;
           parameters[180].Value = model.YBZKuang_QiTa;
           parameters[181].Value = model.YBZKuang_BiaoQing;
           parameters[182].Value = model.YBZKuang_TiWei;
           parameters[183].Value = model.YBZKuang_TWForQP;
           parameters[184].Value = model.YBZKuang_BuTai;
           parameters[185].Value = model.YBZKuang_BTForBZC;
           parameters[186].Value = model.YBZKuang_ShenZhi;
           parameters[187].Value = model.YBZKuang_PHJianCha;
           parameters[188].Value = model.PFNMo_SeZe;
           parameters[189].Value = model.PFNMo_PiZhen;
           parameters[190].Value = model.PFNMo_PZLXJFenBu;
           parameters[191].Value = model.PFNMo_PXChuXue;
           parameters[192].Value = model.PFNMo_PXCXLXJFenBu;
           parameters[193].Value = model.PFNMo_MFFenBu;
           parameters[194].Value = model.PFNMo_MFFBBuWei;
           parameters[195].Value = model.PFNMo_WDYShiDu;
           parameters[196].Value = model.PFNMo_TanXing;
           parameters[197].Value = model.PFNMo_GanZhang;
           parameters[198].Value = model.PFNMo_ShuiZhong;
           parameters[199].Value = model.PFNMo_BWJChengDu;
           parameters[200].Value = model.PFNMo_ZZhuZhi;
           parameters[201].Value = model.PFNMo_ZZZBuWei;
           parameters[202].Value = model.PFNMo_ZZZShuMu;
           parameters[203].Value = model.PFNMo_QiTa;
           parameters[204].Value = model.LBJie_QSQBLBaJie;
           parameters[205].Value = model.LBJie_QSQBLBJBWJTeZheng;
           parameters[206].Value = model.TBu_TLDaXiao;
           parameters[207].Value = model.TBu_TLJiXing;
           parameters[208].Value = model.TBu_TLJXForYou;
           parameters[209].Value = model.TBu_TLQTYCYaTong;
           parameters[210].Value = model.TBu_TLQTYCBaoKuai;
           parameters[211].Value = model.TBu_TLQTYCAoXian;
           parameters[212].Value = model.TBu_TLQTYCBuWei;
           parameters[213].Value = model.TBu_YMMXiShu;
           parameters[214].Value = model.TBu_YMMTuoLuo;
           parameters[215].Value = model.TBu_YDaoJie;
           parameters[216].Value = model.TBu_YYanJian;
           parameters[217].Value = model.TBu_YJieMo;
           parameters[218].Value = model.TBu_YJiaoMo;
           parameters[219].Value = model.TBu_YJiaoMForYiChang;
           parameters[220].Value = model.TBu_YGongMo;
           parameters[221].Value = model.TBu_YYanQiu;
           parameters[222].Value = model.TBu_YYQForAll;
           parameters[223].Value = model.TBu_YTongKong;
           parameters[224].Value = model.TBu_TKForBuDengZ;
           parameters[225].Value = model.TBu_TKForBuDengY;
           parameters[226].Value = model.TBu_YTKDGFanShe;
           parameters[227].Value = model.TBu_YTKDGFSForAll;
           parameters[228].Value = model.TBu_YTKJShiLi;
           parameters[229].Value = model.TBu_TKJSLForAllZ;
           parameters[230].Value = model.TBu_TKJSLForAllY;
           parameters[231].Value = model.TBu_TKJSLQiTa;
           parameters[232].Value = model.TBu_EErKuo;
           parameters[233].Value = model.TBu_EEKQiTa;
           parameters[234].Value = model.TBu_EErKForAll;
           parameters[235].Value = model.TBu_EWEDFMiWu;
           parameters[236].Value = model.TBu_EWEDFMWForY;
           parameters[237].Value = model.TBu_EWEDFMWXingZhi;
           parameters[238].Value = model.TBu_ERTYaTong;
           parameters[239].Value = model.TBu_ERTYTForY;
           parameters[240].Value = model.TBu_TLCSZhangAi;
           parameters[241].Value = model.TBu_TLCSZAForY;
           parameters[242].Value = model.TBu_BWaiXing;
           parameters[243].Value = model.TBu_BForYC;
           parameters[244].Value = model.TBu_BBDYaTong;
           parameters[245].Value = model.TBu_BForBDYT;
           parameters[246].Value = model.TBu_BQTYCBYShanDong;
           parameters[247].Value = model.TBu_BQTYCFMiWu;
           parameters[248].Value = model.TBu_BQTYCChuXue;
           parameters[249].Value = model.TBu_BQTYCZuSe;
           parameters[250].Value = model.TBu_BQTYCBZGPianQu;
           parameters[251].Value = model.TBu_BQTYCBZGChuanKong;
           parameters[252].Value = model.TBu_KQKouChun;
           parameters[253].Value = model.TBu_KQNianMo;
           parameters[254].Value = model.TBu_KQNMForYC;
           parameters[255].Value = model.TBu_KQSXDGKaiKou;
           parameters[256].Value = model.TBu_KQSXDGKKForYC;
           parameters[257].Value = model.TBu_KQShe;
           parameters[258].Value = model.TBu_KQSForYC;
           parameters[259].Value = model.TBu_KQChiYin;
           parameters[260].Value = model.TBu_KQChiLie;
           parameters[261].Value = model.TBu_KQBTaoTi;
           parameters[262].Value = model.TBu_KQBTTForZD;
           parameters[263].Value = model.TBu_KQYan;
           parameters[264].Value = model.TBu_KQShengYin;
           parameters[265].Value = model.JBu_DKangGan;
           parameters[266].Value = model.JBu_QiGuan;
           parameters[267].Value = model.JBu_QGForPY;
           parameters[268].Value = model.JBu_JJingMai;
           parameters[269].Value = model.JBu_JDMBoDoong;
           parameters[270].Value = model.JBu_JDMBDForAll;
           parameters[271].Value = model.JBu_GJJMHLiuZheng;
           parameters[272].Value = model.JBu_JZhuangXian;
           parameters[273].Value = model.JBu_JZXForZDZ;
           parameters[274].Value = model.JBu_JZXForZDY;
           parameters[275].Value = model.JBu_JZXZhiRuan;
           parameters[276].Value = model.JBu_JZXZhiYing;
           parameters[277].Value = model.JBu_JZXYaTong;
           parameters[278].Value = model.JBu_JZXZhenChan;
           parameters[279].Value = model.JBu_JZXXGZaYin;
           parameters[280].Value = model.XBu_XiongKuo;
           parameters[281].Value = model.XBu_RuFang;
           parameters[282].Value = model.XBu_RFForYC;
           parameters[283].Value = model.Fei_SZHXYunDong;
           parameters[284].Value = model.Fei_SZHXYDForYC;
           parameters[285].Value = model.Fei_SZLJianXi;
           parameters[286].Value = model.Fei_SZLJXBWForAll;
           parameters[287].Value = model.Fei_CZYuChan;
           parameters[288].Value = model.Fei_CZYCForYC;
           parameters[289].Value = model.Fei_CZXMMCaGan;
           parameters[290].Value = model.Fei_CZXMMCGForY;
           parameters[291].Value = model.Fei_CZPXNFaGan;
           parameters[292].Value = model.Fei_CZPXNFGForY;
           parameters[293].Value = model.Fei_KouZhen;
           parameters[294].Value = model.Fei_KZForAll;
           parameters[295].Value = model.Fei_FXJJJiaXianY;
           parameters[296].Value = model.Fei_FXJJJiaXianZ;
           parameters[297].Value = model.Fei_FXJSGZhongXianY;
           parameters[298].Value = model.Fei_FXJSGZhongXianZ;
           parameters[299].Value = model.Fei_FXJYZhongXianY;
           parameters[300].Value = model.Fei_FXJYZhongXianZ;
           parameters[301].Value = model.Fei_FXJYDongDuY;
           parameters[302].Value = model.Fei_FXJYDongDuZ;
           parameters[303].Value = model.Fei_TZHuXi;
           parameters[304].Value = model.Fei_TZHXiYin;
           parameters[305].Value = model.Fei_TZHXYForYC;
           parameters[306].Value = model.Fei_TZLuoYing;
           parameters[307].Value = model.Fei_TZLYForY;
           parameters[308].Value = model.Fei_TZYYChuanDao;
           parameters[309].Value = model.Fei_TZYYCDForYC;
           parameters[310].Value = model.Fei_TZXMMCaYin;
           parameters[311].Value = model.Fei_XMMCYForY;
           parameters[312].Value = model.Xin_SZXQQLongQi;
           parameters[313].Value = model.Xin_SZXJBDWeiZhi;
           parameters[314].Value = model.Xin_SZXJBOWZForYW;
           parameters[315].Value = model.Xin_SZXJBoDong;
           parameters[316].Value = model.Xin_SZXQQYCBoDong;
           parameters[317].Value = model.Xin_SZXQQYCBDForY;
           parameters[318].Value = model.Xin_CZXJBoDong;
           parameters[319].Value = model.Xin_CZZhenChan;
           parameters[320].Value = model.Xin_ZCForY;
           parameters[321].Value = model.Xin_CZXBMCaGan;
           parameters[322].Value = model.Xin_KZXDZYinJie;
           parameters[323].Value = model.Xin_KZYEr;
           parameters[324].Value = model.Xin_KZZEr;
           parameters[325].Value = model.Xin_KZYSan;
           parameters[326].Value = model.Xin_KZZSan;
           parameters[327].Value = model.Xin_KZYSi;
           parameters[328].Value = model.Xin_KZZSi;
           parameters[329].Value = model.Xin_KZYWu;
           parameters[330].Value = model.Xin_KZZWu;
           parameters[331].Value = model.Xin_KZZXian;
           parameters[332].Value = model.Xin_TZXinLvC;
           parameters[333].Value = model.Xin_TZXinLv;
           parameters[334].Value = model.Xin_TZXinYin;
           parameters[335].Value = model.Xin_ZWXGWYCXGuanZheng;
           parameters[336].Value = model.Xin_ZWXGQJiYin;
           parameters[337].Value = model.Xin_ZWXGDDSChongYin;
           parameters[338].Value = model.Xin_ZWXGSChongMai;
           parameters[339].Value = model.Xin_ZWXGMXXGBoDong;
           parameters[340].Value = model.Xin_ZWXGMBDuanChu;
           parameters[341].Value = model.Xin_ZWXGQiMai;
           parameters[342].Value = model.Xin_ZWXGJTiMai;
           parameters[343].Value = model.Xin_ZWXGQiTa;
           parameters[344].Value = model.FBu_ShiZhen;
           parameters[345].Value = model.FBu_CZRouRuan;
           parameters[346].Value = model.FBu_CZFJJinZhang;
           parameters[347].Value = model.FBu_CZFJJZForYou;
           parameters[348].Value = model.FBu_CZYaTong;
           parameters[349].Value = model.FBu_CZYTForYou;
           parameters[350].Value = model.FBu_CZFTiaoTong;
           parameters[351].Value = model.FBu_CZFTTForYou;
           parameters[352].Value = model.FBu_CZYBZhenChan;
           parameters[353].Value = model.FBu_CZZShuiSheng;
           parameters[354].Value = model.FBu_CZFBBaoKuai;
           parameters[355].Value = model.FBu_CZFBBKForYou;
           parameters[356].Value = model.FBu_CZFBBKTZMiaoShu;
           parameters[357].Value = model.FBu_CZGan;
           parameters[358].Value = model.FBu_CZDanNang;
           parameters[359].Value = model.FBu_CZPi;
           parameters[360].Value = model.FBu_CZShen;
           parameters[361].Value = model.FBu_KZGZYinJie;
           parameters[362].Value = model.FBu_KZSGZhongXian;
           parameters[363].Value = model.FBu_KZYDXZhuoYin;
           parameters[364].Value = model.FBu_KZSQKouTong;
           parameters[365].Value = model.FBu_KZQiTa;
           parameters[366].Value = model.FBu_TZCMinYin;
           parameters[367].Value = model.FBu_TZXGZaYin;
           parameters[368].Value = model.FBu_TZXGZYForY;
           parameters[369].Value = model.FBu_TZQGShuiSheng;
           parameters[370].Value = model.GMZChang;
           parameters[371].Value = model.GMZChangForY;
           parameters[372].Value = model.SZQi;
           parameters[373].Value = model.SZQiForY;
           parameters[374].Value = model.GGJRou_JiZhu;
           parameters[375].Value = model.GGJRou_JZForJX;
           parameters[376].Value = model.GGJRou_QiTa;
           parameters[377].Value = model.GGJRou_SiZhi;
           parameters[378].Value = model.SJXiTong;
           parameters[379].Value = model.ZKQingKuang;
           parameters[380].Value = model.SYSJQXJianCha;
           parameters[381].Value = model.BLZhaiYao;
           parameters[382].Value = model.CBZhenDuan;
           parameters[383].Value = model.RYZhenDuan;
           parameters[384].Value = model.XZZhenDuan;
           parameters[385].Value = model.Reviewer;
           parameters[386].Value = model.ReviewerDate;
           parameters[387].Value = model.RecordsStatus;
           parameters[388].Value = model.SMTZheng_XueYa2;
           int rows = db.ExecuteSql(strSql.ToString(), parameters);
           if (rows > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
       } 
       #endregion

       #region 分页
       public List<Model.BigMedicalRecordsModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
           string TeacherName, string RegisterDate, string PatientNo, string InhospitalNo,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_BigMedicalRecords where StudentsName='" + StudentsName + "' and TrainingBaseCode='" + TrainingBaseCode + "'";

           if (!string.IsNullOrEmpty(DeptName))
           {
               sql += "and DeptName like '%" + DeptName + "%'";
           }
           if (!string.IsNullOrEmpty(TeacherName))
           {
               sql += "and TeacherName like '%" + TeacherName + "%'";
           }
           if (!string.IsNullOrEmpty(RegisterDate))
           {
               sql += "and RegisterDate like '%" + RegisterDate + "%'";
           }
           if (!string.IsNullOrEmpty(PatientNo))
           {
               sql += "and PatientNo like '%" + PatientNo + "%'";
           }
           if (!string.IsNullOrEmpty(InhospitalNo))
           {
               sql += "and InhospitalNo like '%" + InhospitalNo + "%'";
           }
           sql += ")as t where t.num>=@start and t.num<=@end";


           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<BigMedicalRecordsModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<BigMedicalRecordsModel>();
               BigMedicalRecordsModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new BigMedicalRecordsModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
           string TeacherName, string RegisterDate, string PatientNo, string InhospitalNo)
       {
           string sql = "select count(*) from GP_BigMedicalRecords where TrainingBaseCode='" + TrainingBaseCode
               + "' and StudentsName='" + StudentsName + "'";
           if (!string.IsNullOrEmpty(DeptName))
           {
               sql += "and DeptName like '%" + DeptName + "%'";
           }
           if (!string.IsNullOrEmpty(TeacherName))
           {
               sql += "and TeacherName like '%" + TeacherName + "%'";
           }
           if (!string.IsNullOrEmpty(RegisterDate))
           {
               sql += "and RegisterDate like '%" + RegisterDate + "%'";
           }
           if (!string.IsNullOrEmpty(PatientNo))
           {
               sql += "and PatientNo like '%" + PatientNo + "%'";
           }
           if (!string.IsNullOrEmpty(InhospitalNo))
           {
               sql += "and InhospitalNo like '%" + InhospitalNo + "%'";
           }

           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion
       #region BigMedicalRecordsModel GetListById(string Id)
       public List<BigMedicalRecordsModel> GetListById(string Id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,TeacherId,TeacherName,PatientNo,InhospitalNo,PatientName,sex,Age,Job,Nation,Marriage,BirthProvinceCode,BirthProvinceName,BirthCityCode,BirthCityName,BirthAreaCode,BirthAreaName,BirthDetailAddress,Company,NowProvinceCode,NowProvinceName,NowCityCode,NowCityName,NowAreaCode,NowAreaName,NowDetailAddress,Phone,InhospitalDate,RecordDate,MedicalHistorySpeaker,ReliableDegree,ZSu,XBShi,JWShi_PSJKZhuangKuang,JWShi_CHJBHCRBingShi,JWShi_YFJZhongShi,JWShi_GMinShi,JWShi_GMinYuan,JWShi_LCBiaoXian,JWShi_WShangShi,JWShi_SShuShi,XTHGu_KeSou,XTHGu_KeTan,XTHGu_KaXie,XTHGu_ChuanXi,XTHGu_XiongTong,XTHGu_HXKunNan,XTHGu_XinJi,XTHGu_HDHQiCu,XTHGu_XZShuiZhong,XTHGu_XQQuTong,XTHGu_XYZengGao,XTHGu_YunJue,XTHGu_SYJianTui,XTHGu_FanSuan,XTHGu_AiQi,XTHGu_EXin,XTHGu_OuTu,XTHGu_FuZhang,XTHGu_FuTong,XTHGu_BianMi,XTHGu_FuXie,XTHGu_OuXue,XTHGu_HeiBian,XTHGu_BianXue,XTHGu_HuangDan,XTHGu_YaoTong,XTHGu_NiaoPin,XTHGu_NiaoJi,XTHGu_NiaoTong,XTHGu_PNKunNan,XTHGu_XueNiao,XTHGu_NLYiChang,XTHGu_YNZengDuo,XTHGu_ShuiZhong,XTHGu_YBSaoYang,XTHGu_YBKuiLan,XTHGu_FaLi,XTHGu_TouYun,XTHGu_YanHua,XTHGu_YYChuXue,XTHGu_BChuXue,XTHGu_PXChuXue,XTHGu_GuTong,XTHGu_SYKangJin,XTHGu_PaRe,XTHGu_DuoHan,XTHGu_WeiHan,XTHGu_DuoYin,XTHGu_DuoNiao,XTHGu_SSZhenChan,XTHGu_XGGaiBian,XTHGu_XZFeiPang,XTHGu_MXXiaoShou,XTHGu_MFZengDuov,XTHGu_MFTuoLuo,XTHGu_SSChenZhuo,XTHGu_XGNGaiBian,XTHGu_BiJing,XTHGu_GJieTong,XTHGu_GJHongZhong,XTHGu_GJBianXing,XTHGu_JRouTong,XTHGu_JRWeiSuo,XTHGu_TouTong,XTHGu_XuanYun,XTHGu_YunJue1,JXTHGu_JYLJianTui,XTHGu_SLZhangAi,XTHGu_ShiMian,XTHGu_YSZhangAi,XTHGu_ChanDong,XTHGu_ChouChu,XTHGu_TanHuan,XTHGu_GJYiChang,GRShi_BirthProvinceCode,GRShi_BirthProvinceName,GRShi_BirthCityCode,GRShi_BirthCityName,GRShi_BirthAreaCode,GRShi_BirthAreaName,GRShi_BirthDetailAddress,GRShi_CSHZGongZuo,GRShi_DFBDQJZQingKuang,GRShi_YYouShi,GRShi_ShiYan,GRShi_SYanNian,GRShi_SYanZhi,GRShi_JieYan,GRShi_JYanNian,GRShi_ShiJiu,GRShi_SJiuNian,GRShi_SJiuLiang,GRShi_SJQiTa,HYShi_JHNianLing,HYShi_POQingKuang,YJSHSYShi_CChaoSui,YJSHSYShi_CChaoTian,YJSHSYShi_MCYJRiQi,YJSHSYShi_JJNianLing,YJSHSYShi_ZhouQi,YJSHSYShi_JingLiang,YJSHSYShi_TongJing,YJSHSYShi_JingQi,YJSHSYShi_RenShen,YJSHSYShi_ShunChan,YJSHSYShi_LiuChan,YJSHSYShi_ZaoChan,YJSHSYShi_SiChan,YJSHSYShi_NCJBingQing,YJSHSYShi_Zi,YJSHSYShi_Nv,JZShi_Fu,JZShi_FSiYin,JZShi_Mu,JZShi_MSiYin,JZShi_XDJieMei,JZShi_ZNJQiTa,SMTZheng_TiWen,SMTZheng_MaiBo,SMTZheng_HuXi,SMTZheng_XueYa1,SMTZheng_XueYa2,SMTZheng_TiZhong,YBZKuang_FaYu,YBZKuang_YingYang,YBZKuang_MianRong,YBZKuang_QiTa,YBZKuang_BiaoQing,YBZKuang_TiWei,YBZKuang_TWForQP,YBZKuang_BuTai,YBZKuang_BTForBZC,YBZKuang_ShenZhi,YBZKuang_PHJianCha,PFNMo_SeZe,PFNMo_PiZhen,PFNMo_PZLXJFenBu,PFNMo_PXChuXue,PFNMo_PXCXLXJFenBu,PFNMo_MFFenBu,PFNMo_MFFBBuWei,PFNMo_WDYShiDu,PFNMo_TanXing,PFNMo_GanZhang,PFNMo_ShuiZhong,PFNMo_BWJChengDu,PFNMo_ZZhuZhi,PFNMo_ZZZBuWei,PFNMo_ZZZShuMu,PFNMo_QiTa,LBJie_QSQBLBaJie,LBJie_QSQBLBJBWJTeZheng,TBu_TLDaXiao,TBu_TLJiXing,TBu_TLJXForYou,TBu_TLQTYCYaTong,TBu_TLQTYCBaoKuai,TBu_TLQTYCAoXian,TBu_TLQTYCBuWei,TBu_YMMXiShu,TBu_YMMTuoLuo,TBu_YDaoJie,TBu_YYanJian,TBu_YJieMo,TBu_YJiaoMo,TBu_YJiaoMForYiChang,TBu_YGongMo,TBu_YYanQiu,TBu_YYQForAll,TBu_YTongKong,TBu_TKForBuDengZ,TBu_TKForBuDengY,TBu_YTKDGFanShe,TBu_YTKDGFSForAll,TBu_YTKJShiLi,TBu_TKJSLForAllZ,TBu_TKJSLForAllY,TBu_TKJSLQiTa,TBu_EErKuo,TBu_EEKQiTa,TBu_EErKForAll,TBu_EWEDFMiWu,TBu_EWEDFMWForY,TBu_EWEDFMWXingZhi,TBu_ERTYaTong,TBu_ERTYTForY,TBu_TLCSZhangAi,TBu_TLCSZAForY,TBu_BWaiXing,TBu_BForYC,TBu_BBDYaTong,TBu_BForBDYT,TBu_BQTYCBYShanDong,TBu_BQTYCFMiWu,TBu_BQTYCChuXue,TBu_BQTYCZuSe,TBu_BQTYCBZGPianQu,TBu_BQTYCBZGChuanKong,TBu_KQKouChun,TBu_KQNianMo,TBu_KQNMForYC,TBu_KQSXDGKaiKou,TBu_KQSXDGKKForYC,TBu_KQShe,TBu_KQSForYC,TBu_KQChiYin,TBu_KQChiLie,TBu_KQBTaoTi,TBu_KQBTTForZD,TBu_KQYan,TBu_KQShengYin,JBu_DKangGan,JBu_QiGuan,JBu_QGForPY,JBu_JJingMai,JBu_JDMBoDoong,JBu_JDMBDForAll,JBu_GJJMHLiuZheng,JBu_JZhuangXian,JBu_JZXForZDZ,JBu_JZXForZDY,JBu_JZXZhiRuan,JBu_JZXZhiYing,JBu_JZXYaTong,JBu_JZXZhenChan,JBu_JZXXGZaYin,XBu_XiongKuo,XBu_RuFang,XBu_RFForYC,Fei_SZHXYunDong,Fei_SZHXYDForYC,Fei_SZLJianXi,Fei_SZLJXBWForAll,Fei_CZYuChan,Fei_CZYCForYC,Fei_CZXMMCaGan,Fei_CZXMMCGForY,Fei_CZPXNFaGan,Fei_CZPXNFGForY,Fei_KouZhen,Fei_KZForAll,Fei_FXJJJiaXianY,Fei_FXJJJiaXianZ,Fei_FXJSGZhongXianY,Fei_FXJSGZhongXianZ,Fei_FXJYZhongXianY,Fei_FXJYZhongXianZ,Fei_FXJYDongDuY,Fei_FXJYDongDuZ,Fei_TZHuXi,Fei_TZHXiYin,Fei_TZHXYForYC,Fei_TZLuoYing,Fei_TZLYForY,Fei_TZYYChuanDao,Fei_TZYYCDForYC,Fei_TZXMMCaYin,Fei_XMMCYForY,Xin_SZXQQLongQi,Xin_SZXJBDWeiZhi,Xin_SZXJBOWZForYW,Xin_SZXJBoDong,Xin_SZXQQYCBoDong,Xin_SZXQQYCBDForY,Xin_CZXJBoDong,Xin_CZZhenChan,Xin_ZCForY,Xin_CZXBMCaGan,Xin_KZXDZYinJie,Xin_KZYEr,Xin_KZZEr,Xin_KZYSan,Xin_KZZSan,Xin_KZYSi,Xin_KZZSi,Xin_KZYWu,Xin_KZZWu,Xin_KZZXian,Xin_TZXinLvC,Xin_TZXinLv,Xin_TZXinYin,Xin_ZWXGWYCXGuanZheng,Xin_ZWXGQJiYin,Xin_ZWXGDDSChongYin,Xin_ZWXGSChongMai,Xin_ZWXGMXXGBoDong,Xin_ZWXGMBDuanChu,Xin_ZWXGQiMai,Xin_ZWXGJTiMai,Xin_ZWXGQiTa,FBu_ShiZhen,FBu_CZRouRuan,FBu_CZFJJinZhang,FBu_CZFJJZForYou,FBu_CZYaTong,FBu_CZYTForYou,FBu_CZFTiaoTong,FBu_CZFTTForYou,FBu_CZYBZhenChan,FBu_CZZShuiSheng,FBu_CZFBBaoKuai,FBu_CZFBBKForYou,FBu_CZFBBKTZMiaoShu,FBu_CZGan,FBu_CZDanNang,FBu_CZPi,FBu_CZShen,FBu_KZGZYinJie,FBu_KZSGZhongXian,FBu_KZYDXZhuoYin,FBu_KZSQKouTong,FBu_KZQiTa,FBu_TZCMinYin,FBu_TZXGZaYin,FBu_TZXGZYForY,FBu_TZQGShuiSheng,GMZChang,GMZChangForY,SZQi,SZQiForY,GGJRou_JiZhu,GGJRou_JZForJX,GGJRou_QiTa,GGJRou_SiZhi,SJXiTong,ZKQingKuang,SYSJQXJianCha,BLZhaiYao,CBZhenDuan,RYZhenDuan,XZZhenDuan,Reviewer,ReviewerDate,RecordsStatus from GP_BigMedicalRecords ");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50)			};
           parameters[0].Value = Id;

           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           List<BigMedicalRecordsModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<BigMedicalRecordsModel>();
               BigMedicalRecordsModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new BigMedicalRecordsModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }

           }
           return list;
       } 
       #endregion
       #region DataRowToModel(DataRow row)
       public BigMedicalRecordsModel DataRowToModel(DataRow row)
       {
           BigMedicalRecordsModel model = new BigMedicalRecordsModel();
           if (row != null)
           {
               if (row["Id"] != null)
               {
                   model.Id = row["Id"].ToString();
               }
               if (row["StudentsRealName"] != null)
               {
                   model.StudentsRealName = row["StudentsRealName"].ToString();
               }
               if (row["StudentsName"] != null)
               {
                   model.StudentsName = row["StudentsName"].ToString();
               }
               if (row["TrainingBaseCode"] != null)
               {
                   model.TrainingBaseCode = row["TrainingBaseCode"].ToString();
               }
               if (row["TrainingBaseName"] != null)
               {
                   model.TrainingBaseName = row["TrainingBaseName"].ToString();
               }
               if (row["ProfessionalBaseCode"] != null)
               {
                   model.ProfessionalBaseCode = row["ProfessionalBaseCode"].ToString();
               }
               if (row["ProfessionalBaseName"] != null)
               {
                   model.ProfessionalBaseName = row["ProfessionalBaseName"].ToString();
               }
               if (row["DeptCode"] != null)
               {
                   model.DeptCode = row["DeptCode"].ToString();
               }
               if (row["DeptName"] != null)
               {
                   model.DeptName = row["DeptName"].ToString();
               }
               if (row["RegisterDate"] != null)
               {
                   model.RegisterDate = row["RegisterDate"].ToString();
               }
               if (row["Writor"] != null)
               {
                   model.Writor = row["Writor"].ToString();
               }
               if (row["TeacherCheck"] != null)
               {
                   model.TeacherCheck = row["TeacherCheck"].ToString();
               }
               if (row["KzrCheck"] != null)
               {
                   model.KzrCheck = row["KzrCheck"].ToString();
               }
               if (row["BaseCheck"] != null)
               {
                   model.BaseCheck = row["BaseCheck"].ToString();
               }
               if (row["ManagerCheck"] != null)
               {
                   model.ManagerCheck = row["ManagerCheck"].ToString();
               }
               if (row["TeacherId"] != null)
               {
                   model.TeacherId = row["TeacherId"].ToString();
               }
               if (row["TeacherName"] != null)
               {
                   model.TeacherName = row["TeacherName"].ToString();
               }
               if (row["PatientNo"] != null)
               {
                   model.PatientNo = row["PatientNo"].ToString();
               }
               if (row["InhospitalNo"] != null)
               {
                   model.InhospitalNo = row["InhospitalNo"].ToString();
               }
               if (row["PatientName"] != null)
               {
                   model.PatientName = row["PatientName"].ToString();
               }
               if (row["sex"] != null)
               {
                   model.sex = row["sex"].ToString();
               }
               if (row["Age"] != null)
               {
                   model.Age = row["Age"].ToString();
               }
               if (row["Job"] != null)
               {
                   model.Job = row["Job"].ToString();
               }
               if (row["Nation"] != null)
               {
                   model.Nation = row["Nation"].ToString();
               }
               if (row["Marriage"] != null)
               {
                   model.Marriage = row["Marriage"].ToString();
               }
               if (row["BirthProvinceCode"] != null)
               {
                   model.BirthProvinceCode = row["BirthProvinceCode"].ToString();
               }
               if (row["BirthProvinceName"] != null)
               {
                   model.BirthProvinceName = row["BirthProvinceName"].ToString();
               }
               if (row["BirthCityCode"] != null)
               {
                   model.BirthCityCode = row["BirthCityCode"].ToString();
               }
               if (row["BirthCityName"] != null)
               {
                   model.BirthCityName = row["BirthCityName"].ToString();
               }
               if (row["BirthAreaCode"] != null)
               {
                   model.BirthAreaCode = row["BirthAreaCode"].ToString();
               }
               if (row["BirthAreaName"] != null)
               {
                   model.BirthAreaName = row["BirthAreaName"].ToString();
               }
               if (row["BirthDetailAddress"] != null)
               {
                   model.BirthDetailAddress = row["BirthDetailAddress"].ToString();
               }
               if (row["Company"] != null)
               {
                   model.Company = row["Company"].ToString();
               }
               if (row["NowProvinceCode"] != null)
               {
                   model.NowProvinceCode = row["NowProvinceCode"].ToString();
               }
               if (row["NowProvinceName"] != null)
               {
                   model.NowProvinceName = row["NowProvinceName"].ToString();
               }
               if (row["NowCityCode"] != null)
               {
                   model.NowCityCode = row["NowCityCode"].ToString();
               }
               if (row["NowCityName"] != null)
               {
                   model.NowCityName = row["NowCityName"].ToString();
               }
               if (row["NowAreaCode"] != null)
               {
                   model.NowAreaCode = row["NowAreaCode"].ToString();
               }
               if (row["NowAreaName"] != null)
               {
                   model.NowAreaName = row["NowAreaName"].ToString();
               }
               if (row["NowDetailAddress"] != null)
               {
                   model.NowDetailAddress = row["NowDetailAddress"].ToString();
               }
               if (row["Phone"] != null)
               {
                   model.Phone = row["Phone"].ToString();
               }
               if (row["InhospitalDate"] != null)
               {
                   model.InhospitalDate = row["InhospitalDate"].ToString();
               }
               if (row["RecordDate"] != null)
               {
                   model.RecordDate = row["RecordDate"].ToString();
               }
               if (row["MedicalHistorySpeaker"] != null)
               {
                   model.MedicalHistorySpeaker = row["MedicalHistorySpeaker"].ToString();
               }
               if (row["ReliableDegree"] != null)
               {
                   model.ReliableDegree = row["ReliableDegree"].ToString();
               }
               if (row["ZSu"] != null)
               {
                   model.ZSu = row["ZSu"].ToString();
               }
               if (row["XBShi"] != null)
               {
                   model.XBShi = row["XBShi"].ToString();
               }
               if (row["JWShi_PSJKZhuangKuang"] != null)
               {
                   model.JWShi_PSJKZhuangKuang = row["JWShi_PSJKZhuangKuang"].ToString();
               }
               if (row["JWShi_CHJBHCRBingShi"] != null)
               {
                   model.JWShi_CHJBHCRBingShi = row["JWShi_CHJBHCRBingShi"].ToString();
               }
               if (row["JWShi_YFJZhongShi"] != null)
               {
                   model.JWShi_YFJZhongShi = row["JWShi_YFJZhongShi"].ToString();
               }
               if (row["JWShi_GMinShi"] != null)
               {
                   model.JWShi_GMinShi = row["JWShi_GMinShi"].ToString();
               }
               if (row["JWShi_GMinYuan"] != null)
               {
                   model.JWShi_GMinYuan = row["JWShi_GMinYuan"].ToString();
               }
               if (row["JWShi_LCBiaoXian"] != null)
               {
                   model.JWShi_LCBiaoXian = row["JWShi_LCBiaoXian"].ToString();
               }
               if (row["JWShi_WShangShi"] != null)
               {
                   model.JWShi_WShangShi = row["JWShi_WShangShi"].ToString();
               }
               if (row["JWShi_SShuShi"] != null)
               {
                   model.JWShi_SShuShi = row["JWShi_SShuShi"].ToString();
               }
               if (row["XTHGu_KeSou"] != null)
               {
                   model.XTHGu_KeSou = row["XTHGu_KeSou"].ToString();
               }
               if (row["XTHGu_KeTan"] != null)
               {
                   model.XTHGu_KeTan = row["XTHGu_KeTan"].ToString();
               }
               if (row["XTHGu_KaXie"] != null)
               {
                   model.XTHGu_KaXie = row["XTHGu_KaXie"].ToString();
               }
               if (row["XTHGu_ChuanXi"] != null)
               {
                   model.XTHGu_ChuanXi = row["XTHGu_ChuanXi"].ToString();
               }
               if (row["XTHGu_XiongTong"] != null)
               {
                   model.XTHGu_XiongTong = row["XTHGu_XiongTong"].ToString();
               }
               if (row["XTHGu_HXKunNan"] != null)
               {
                   model.XTHGu_HXKunNan = row["XTHGu_HXKunNan"].ToString();
               }
               if (row["XTHGu_XinJi"] != null)
               {
                   model.XTHGu_XinJi = row["XTHGu_XinJi"].ToString();
               }
               if (row["XTHGu_HDHQiCu"] != null)
               {
                   model.XTHGu_HDHQiCu = row["XTHGu_HDHQiCu"].ToString();
               }
               if (row["XTHGu_XZShuiZhong"] != null)
               {
                   model.XTHGu_XZShuiZhong = row["XTHGu_XZShuiZhong"].ToString();
               }
               if (row["XTHGu_XQQuTong"] != null)
               {
                   model.XTHGu_XQQuTong = row["XTHGu_XQQuTong"].ToString();
               }
               if (row["XTHGu_XYZengGao"] != null)
               {
                   model.XTHGu_XYZengGao = row["XTHGu_XYZengGao"].ToString();
               }
               if (row["XTHGu_YunJue"] != null)
               {
                   model.XTHGu_YunJue = row["XTHGu_YunJue"].ToString();
               }
               if (row["XTHGu_SYJianTui"] != null)
               {
                   model.XTHGu_SYJianTui = row["XTHGu_SYJianTui"].ToString();
               }
               if (row["XTHGu_FanSuan"] != null)
               {
                   model.XTHGu_FanSuan = row["XTHGu_FanSuan"].ToString();
               }
               if (row["XTHGu_AiQi"] != null)
               {
                   model.XTHGu_AiQi = row["XTHGu_AiQi"].ToString();
               }
               if (row["XTHGu_EXin"] != null)
               {
                   model.XTHGu_EXin = row["XTHGu_EXin"].ToString();
               }
               if (row["XTHGu_OuTu"] != null)
               {
                   model.XTHGu_OuTu = row["XTHGu_OuTu"].ToString();
               }
               if (row["XTHGu_FuZhang"] != null)
               {
                   model.XTHGu_FuZhang = row["XTHGu_FuZhang"].ToString();
               }
               if (row["XTHGu_FuTong"] != null)
               {
                   model.XTHGu_FuTong = row["XTHGu_FuTong"].ToString();
               }
               if (row["XTHGu_BianMi"] != null)
               {
                   model.XTHGu_BianMi = row["XTHGu_BianMi"].ToString();
               }
               if (row["XTHGu_FuXie"] != null)
               {
                   model.XTHGu_FuXie = row["XTHGu_FuXie"].ToString();
               }
               if (row["XTHGu_OuXue"] != null)
               {
                   model.XTHGu_OuXue = row["XTHGu_OuXue"].ToString();
               }
               if (row["XTHGu_HeiBian"] != null)
               {
                   model.XTHGu_HeiBian = row["XTHGu_HeiBian"].ToString();
               }
               if (row["XTHGu_BianXue"] != null)
               {
                   model.XTHGu_BianXue = row["XTHGu_BianXue"].ToString();
               }
               if (row["XTHGu_HuangDan"] != null)
               {
                   model.XTHGu_HuangDan = row["XTHGu_HuangDan"].ToString();
               }
               if (row["XTHGu_YaoTong"] != null)
               {
                   model.XTHGu_YaoTong = row["XTHGu_YaoTong"].ToString();
               }
               if (row["XTHGu_NiaoPin"] != null)
               {
                   model.XTHGu_NiaoPin = row["XTHGu_NiaoPin"].ToString();
               }
               if (row["XTHGu_NiaoJi"] != null)
               {
                   model.XTHGu_NiaoJi = row["XTHGu_NiaoJi"].ToString();
               }
               if (row["XTHGu_NiaoTong"] != null)
               {
                   model.XTHGu_NiaoTong = row["XTHGu_NiaoTong"].ToString();
               }
               if (row["XTHGu_PNKunNan"] != null)
               {
                   model.XTHGu_PNKunNan = row["XTHGu_PNKunNan"].ToString();
               }
               if (row["XTHGu_XueNiao"] != null)
               {
                   model.XTHGu_XueNiao = row["XTHGu_XueNiao"].ToString();
               }
               if (row["XTHGu_NLYiChang"] != null)
               {
                   model.XTHGu_NLYiChang = row["XTHGu_NLYiChang"].ToString();
               }
               if (row["XTHGu_YNZengDuo"] != null)
               {
                   model.XTHGu_YNZengDuo = row["XTHGu_YNZengDuo"].ToString();
               }
               if (row["XTHGu_ShuiZhong"] != null)
               {
                   model.XTHGu_ShuiZhong = row["XTHGu_ShuiZhong"].ToString();
               }
               if (row["XTHGu_YBSaoYang"] != null)
               {
                   model.XTHGu_YBSaoYang = row["XTHGu_YBSaoYang"].ToString();
               }
               if (row["XTHGu_YBKuiLan"] != null)
               {
                   model.XTHGu_YBKuiLan = row["XTHGu_YBKuiLan"].ToString();
               }
               if (row["XTHGu_FaLi"] != null)
               {
                   model.XTHGu_FaLi = row["XTHGu_FaLi"].ToString();
               }
               if (row["XTHGu_TouYun"] != null)
               {
                   model.XTHGu_TouYun = row["XTHGu_TouYun"].ToString();
               }
               if (row["XTHGu_YanHua"] != null)
               {
                   model.XTHGu_YanHua = row["XTHGu_YanHua"].ToString();
               }
               if (row["XTHGu_YYChuXue"] != null)
               {
                   model.XTHGu_YYChuXue = row["XTHGu_YYChuXue"].ToString();
               }
               if (row["XTHGu_BChuXue"] != null)
               {
                   model.XTHGu_BChuXue = row["XTHGu_BChuXue"].ToString();
               }
               if (row["XTHGu_PXChuXue"] != null)
               {
                   model.XTHGu_PXChuXue = row["XTHGu_PXChuXue"].ToString();
               }
               if (row["XTHGu_GuTong"] != null)
               {
                   model.XTHGu_GuTong = row["XTHGu_GuTong"].ToString();
               }
               if (row["XTHGu_SYKangJin"] != null)
               {
                   model.XTHGu_SYKangJin = row["XTHGu_SYKangJin"].ToString();
               }
               if (row["XTHGu_PaRe"] != null)
               {
                   model.XTHGu_PaRe = row["XTHGu_PaRe"].ToString();
               }
               if (row["XTHGu_DuoHan"] != null)
               {
                   model.XTHGu_DuoHan = row["XTHGu_DuoHan"].ToString();
               }
               if (row["XTHGu_WeiHan"] != null)
               {
                   model.XTHGu_WeiHan = row["XTHGu_WeiHan"].ToString();
               }
               if (row["XTHGu_DuoYin"] != null)
               {
                   model.XTHGu_DuoYin = row["XTHGu_DuoYin"].ToString();
               }
               if (row["XTHGu_DuoNiao"] != null)
               {
                   model.XTHGu_DuoNiao = row["XTHGu_DuoNiao"].ToString();
               }
               if (row["XTHGu_SSZhenChan"] != null)
               {
                   model.XTHGu_SSZhenChan = row["XTHGu_SSZhenChan"].ToString();
               }
               if (row["XTHGu_XGGaiBian"] != null)
               {
                   model.XTHGu_XGGaiBian = row["XTHGu_XGGaiBian"].ToString();
               }
               if (row["XTHGu_XZFeiPang"] != null)
               {
                   model.XTHGu_XZFeiPang = row["XTHGu_XZFeiPang"].ToString();
               }
               if (row["XTHGu_MXXiaoShou"] != null)
               {
                   model.XTHGu_MXXiaoShou = row["XTHGu_MXXiaoShou"].ToString();
               }
               if (row["XTHGu_MFZengDuov"] != null)
               {
                   model.XTHGu_MFZengDuov = row["XTHGu_MFZengDuov"].ToString();
               }
               if (row["XTHGu_MFTuoLuo"] != null)
               {
                   model.XTHGu_MFTuoLuo = row["XTHGu_MFTuoLuo"].ToString();
               }
               if (row["XTHGu_SSChenZhuo"] != null)
               {
                   model.XTHGu_SSChenZhuo = row["XTHGu_SSChenZhuo"].ToString();
               }
               if (row["XTHGu_XGNGaiBian"] != null)
               {
                   model.XTHGu_XGNGaiBian = row["XTHGu_XGNGaiBian"].ToString();
               }
               if (row["XTHGu_BiJing"] != null)
               {
                   model.XTHGu_BiJing = row["XTHGu_BiJing"].ToString();
               }
               if (row["XTHGu_GJieTong"] != null)
               {
                   model.XTHGu_GJieTong = row["XTHGu_GJieTong"].ToString();
               }
               if (row["XTHGu_GJHongZhong"] != null)
               {
                   model.XTHGu_GJHongZhong = row["XTHGu_GJHongZhong"].ToString();
               }
               if (row["XTHGu_GJBianXing"] != null)
               {
                   model.XTHGu_GJBianXing = row["XTHGu_GJBianXing"].ToString();
               }
               if (row["XTHGu_JRouTong"] != null)
               {
                   model.XTHGu_JRouTong = row["XTHGu_JRouTong"].ToString();
               }
               if (row["XTHGu_JRWeiSuo"] != null)
               {
                   model.XTHGu_JRWeiSuo = row["XTHGu_JRWeiSuo"].ToString();
               }
               if (row["XTHGu_TouTong"] != null)
               {
                   model.XTHGu_TouTong = row["XTHGu_TouTong"].ToString();
               }
               if (row["XTHGu_XuanYun"] != null)
               {
                   model.XTHGu_XuanYun = row["XTHGu_XuanYun"].ToString();
               }
               if (row["XTHGu_YunJue1"] != null)
               {
                   model.XTHGu_YunJue1 = row["XTHGu_YunJue1"].ToString();
               }
               if (row["JXTHGu_JYLJianTui"] != null)
               {
                   model.JXTHGu_JYLJianTui = row["JXTHGu_JYLJianTui"].ToString();
               }
               if (row["XTHGu_SLZhangAi"] != null)
               {
                   model.XTHGu_SLZhangAi = row["XTHGu_SLZhangAi"].ToString();
               }
               if (row["XTHGu_ShiMian"] != null)
               {
                   model.XTHGu_ShiMian = row["XTHGu_ShiMian"].ToString();
               }
               if (row["XTHGu_YSZhangAi"] != null)
               {
                   model.XTHGu_YSZhangAi = row["XTHGu_YSZhangAi"].ToString();
               }
               if (row["XTHGu_ChanDong"] != null)
               {
                   model.XTHGu_ChanDong = row["XTHGu_ChanDong"].ToString();
               }
               if (row["XTHGu_ChouChu"] != null)
               {
                   model.XTHGu_ChouChu = row["XTHGu_ChouChu"].ToString();
               }
               if (row["XTHGu_TanHuan"] != null)
               {
                   model.XTHGu_TanHuan = row["XTHGu_TanHuan"].ToString();
               }
               if (row["XTHGu_GJYiChang"] != null)
               {
                   model.XTHGu_GJYiChang = row["XTHGu_GJYiChang"].ToString();
               }
               if (row["GRShi_BirthProvinceCode"] != null)
               {
                   model.GRShi_BirthProvinceCode = row["GRShi_BirthProvinceCode"].ToString();
               }
               if (row["GRShi_BirthProvinceName"] != null)
               {
                   model.GRShi_BirthProvinceName = row["GRShi_BirthProvinceName"].ToString();
               }
               if (row["GRShi_BirthCityCode"] != null)
               {
                   model.GRShi_BirthCityCode = row["GRShi_BirthCityCode"].ToString();
               }
               if (row["GRShi_BirthCityName"] != null)
               {
                   model.GRShi_BirthCityName = row["GRShi_BirthCityName"].ToString();
               }
               if (row["GRShi_BirthAreaCode"] != null)
               {
                   model.GRShi_BirthAreaCode = row["GRShi_BirthAreaCode"].ToString();
               }
               if (row["GRShi_BirthAreaName"] != null)
               {
                   model.GRShi_BirthAreaName = row["GRShi_BirthAreaName"].ToString();
               }
               if (row["GRShi_BirthDetailAddress"] != null)
               {
                   model.GRShi_BirthDetailAddress = row["GRShi_BirthDetailAddress"].ToString();
               }
               if (row["GRShi_CSHZGongZuo"] != null)
               {
                   model.GRShi_CSHZGongZuo = row["GRShi_CSHZGongZuo"].ToString();
               }
               if (row["GRShi_DFBDQJZQingKuang"] != null)
               {
                   model.GRShi_DFBDQJZQingKuang = row["GRShi_DFBDQJZQingKuang"].ToString();
               }
               if (row["GRShi_YYouShi"] != null)
               {
                   model.GRShi_YYouShi = row["GRShi_YYouShi"].ToString();
               }
               if (row["GRShi_ShiYan"] != null)
               {
                   model.GRShi_ShiYan = row["GRShi_ShiYan"].ToString();
               }
               if (row["GRShi_SYanNian"] != null)
               {
                   model.GRShi_SYanNian = row["GRShi_SYanNian"].ToString();
               }
               if (row["GRShi_SYanZhi"] != null)
               {
                   model.GRShi_SYanZhi = row["GRShi_SYanZhi"].ToString();
               }
               if (row["GRShi_JieYan"] != null)
               {
                   model.GRShi_JieYan = row["GRShi_JieYan"].ToString();
               }
               if (row["GRShi_JYanNian"] != null)
               {
                   model.GRShi_JYanNian = row["GRShi_JYanNian"].ToString();
               }
               if (row["GRShi_ShiJiu"] != null)
               {
                   model.GRShi_ShiJiu = row["GRShi_ShiJiu"].ToString();
               }
               if (row["GRShi_SJiuNian"] != null)
               {
                   model.GRShi_SJiuNian = row["GRShi_SJiuNian"].ToString();
               }
               if (row["GRShi_SJiuLiang"] != null)
               {
                   model.GRShi_SJiuLiang = row["GRShi_SJiuLiang"].ToString();
               }
               if (row["GRShi_SJQiTa"] != null)
               {
                   model.GRShi_SJQiTa = row["GRShi_SJQiTa"].ToString();
               }
               if (row["HYShi_JHNianLing"] != null)
               {
                   model.HYShi_JHNianLing = row["HYShi_JHNianLing"].ToString();
               }
               if (row["HYShi_POQingKuang"] != null)
               {
                   model.HYShi_POQingKuang = row["HYShi_POQingKuang"].ToString();
               }
               if (row["YJSHSYShi_CChaoSui"] != null)
               {
                   model.YJSHSYShi_CChaoSui = row["YJSHSYShi_CChaoSui"].ToString();
               }
               if (row["YJSHSYShi_CChaoTian"] != null)
               {
                   model.YJSHSYShi_CChaoTian = row["YJSHSYShi_CChaoTian"].ToString();
               }
               if (row["YJSHSYShi_MCYJRiQi"] != null)
               {
                   model.YJSHSYShi_MCYJRiQi = row["YJSHSYShi_MCYJRiQi"].ToString();
               }
               if (row["YJSHSYShi_JJNianLing"] != null)
               {
                   model.YJSHSYShi_JJNianLing = row["YJSHSYShi_JJNianLing"].ToString();
               }
               if (row["YJSHSYShi_ZhouQi"] != null)
               {
                   model.YJSHSYShi_ZhouQi = row["YJSHSYShi_ZhouQi"].ToString();
               }
               if (row["YJSHSYShi_JingLiang"] != null)
               {
                   model.YJSHSYShi_JingLiang = row["YJSHSYShi_JingLiang"].ToString();
               }
               if (row["YJSHSYShi_TongJing"] != null)
               {
                   model.YJSHSYShi_TongJing = row["YJSHSYShi_TongJing"].ToString();
               }
               if (row["YJSHSYShi_JingQi"] != null)
               {
                   model.YJSHSYShi_JingQi = row["YJSHSYShi_JingQi"].ToString();
               }
               if (row["YJSHSYShi_RenShen"] != null)
               {
                   model.YJSHSYShi_RenShen = row["YJSHSYShi_RenShen"].ToString();
               }
               if (row["YJSHSYShi_ShunChan"] != null)
               {
                   model.YJSHSYShi_ShunChan = row["YJSHSYShi_ShunChan"].ToString();
               }
               if (row["YJSHSYShi_LiuChan"] != null)
               {
                   model.YJSHSYShi_LiuChan = row["YJSHSYShi_LiuChan"].ToString();
               }
               if (row["YJSHSYShi_ZaoChan"] != null)
               {
                   model.YJSHSYShi_ZaoChan = row["YJSHSYShi_ZaoChan"].ToString();
               }
               if (row["YJSHSYShi_SiChan"] != null)
               {
                   model.YJSHSYShi_SiChan = row["YJSHSYShi_SiChan"].ToString();
               }
               if (row["YJSHSYShi_NCJBingQing"] != null)
               {
                   model.YJSHSYShi_NCJBingQing = row["YJSHSYShi_NCJBingQing"].ToString();
               }
               if (row["YJSHSYShi_Zi"] != null)
               {
                   model.YJSHSYShi_Zi = row["YJSHSYShi_Zi"].ToString();
               }
               if (row["YJSHSYShi_Nv"] != null)
               {
                   model.YJSHSYShi_Nv = row["YJSHSYShi_Nv"].ToString();
               }
               if (row["JZShi_Fu"] != null)
               {
                   model.JZShi_Fu = row["JZShi_Fu"].ToString();
               }
               if (row["JZShi_FSiYin"] != null)
               {
                   model.JZShi_FSiYin = row["JZShi_FSiYin"].ToString();
               }
               if (row["JZShi_Mu"] != null)
               {
                   model.JZShi_Mu = row["JZShi_Mu"].ToString();
               }
               if (row["JZShi_MSiYin"] != null)
               {
                   model.JZShi_MSiYin = row["JZShi_MSiYin"].ToString();
               }
               if (row["JZShi_XDJieMei"] != null)
               {
                   model.JZShi_XDJieMei = row["JZShi_XDJieMei"].ToString();
               }
               if (row["JZShi_ZNJQiTa"] != null)
               {
                   model.JZShi_ZNJQiTa = row["JZShi_ZNJQiTa"].ToString();
               }
               if (row["SMTZheng_TiWen"] != null)
               {
                   model.SMTZheng_TiWen = row["SMTZheng_TiWen"].ToString();
               }
               if (row["SMTZheng_MaiBo"] != null)
               {
                   model.SMTZheng_MaiBo = row["SMTZheng_MaiBo"].ToString();
               }
               if (row["SMTZheng_HuXi"] != null)
               {
                   model.SMTZheng_HuXi = row["SMTZheng_HuXi"].ToString();
               }
               if (row["SMTZheng_XueYa1"] != null)
               {
                   model.SMTZheng_XueYa1 = row["SMTZheng_XueYa1"].ToString();
               }
               if (row["SMTZheng_XueYa2"] != null)
               {
                   model.SMTZheng_XueYa2 = row["SMTZheng_XueYa2"].ToString();
               }
               if (row["SMTZheng_TiZhong"] != null)
               {
                   model.SMTZheng_TiZhong = row["SMTZheng_TiZhong"].ToString();
               }
               if (row["YBZKuang_FaYu"] != null)
               {
                   model.YBZKuang_FaYu = row["YBZKuang_FaYu"].ToString();
               }
               if (row["YBZKuang_YingYang"] != null)
               {
                   model.YBZKuang_YingYang = row["YBZKuang_YingYang"].ToString();
               }
               if (row["YBZKuang_MianRong"] != null)
               {
                   model.YBZKuang_MianRong = row["YBZKuang_MianRong"].ToString();
               }
               if (row["YBZKuang_QiTa"] != null)
               {
                   model.YBZKuang_QiTa = row["YBZKuang_QiTa"].ToString();
               }
               if (row["YBZKuang_BiaoQing"] != null)
               {
                   model.YBZKuang_BiaoQing = row["YBZKuang_BiaoQing"].ToString();
               }
               if (row["YBZKuang_TiWei"] != null)
               {
                   model.YBZKuang_TiWei = row["YBZKuang_TiWei"].ToString();
               }
               if (row["YBZKuang_TWForQP"] != null)
               {
                   model.YBZKuang_TWForQP = row["YBZKuang_TWForQP"].ToString();
               }
               if (row["YBZKuang_BuTai"] != null)
               {
                   model.YBZKuang_BuTai = row["YBZKuang_BuTai"].ToString();
               }
               if (row["YBZKuang_BTForBZC"] != null)
               {
                   model.YBZKuang_BTForBZC = row["YBZKuang_BTForBZC"].ToString();
               }
               if (row["YBZKuang_ShenZhi"] != null)
               {
                   model.YBZKuang_ShenZhi = row["YBZKuang_ShenZhi"].ToString();
               }
               if (row["YBZKuang_PHJianCha"] != null)
               {
                   model.YBZKuang_PHJianCha = row["YBZKuang_PHJianCha"].ToString();
               }
               if (row["PFNMo_SeZe"] != null)
               {
                   model.PFNMo_SeZe = row["PFNMo_SeZe"].ToString();
               }
               if (row["PFNMo_PiZhen"] != null)
               {
                   model.PFNMo_PiZhen = row["PFNMo_PiZhen"].ToString();
               }
               if (row["PFNMo_PZLXJFenBu"] != null)
               {
                   model.PFNMo_PZLXJFenBu = row["PFNMo_PZLXJFenBu"].ToString();
               }
               if (row["PFNMo_PXChuXue"] != null)
               {
                   model.PFNMo_PXChuXue = row["PFNMo_PXChuXue"].ToString();
               }
               if (row["PFNMo_PXCXLXJFenBu"] != null)
               {
                   model.PFNMo_PXCXLXJFenBu = row["PFNMo_PXCXLXJFenBu"].ToString();
               }
               if (row["PFNMo_MFFenBu"] != null)
               {
                   model.PFNMo_MFFenBu = row["PFNMo_MFFenBu"].ToString();
               }
               if (row["PFNMo_MFFBBuWei"] != null)
               {
                   model.PFNMo_MFFBBuWei = row["PFNMo_MFFBBuWei"].ToString();
               }
               if (row["PFNMo_WDYShiDu"] != null)
               {
                   model.PFNMo_WDYShiDu = row["PFNMo_WDYShiDu"].ToString();
               }
               if (row["PFNMo_TanXing"] != null)
               {
                   model.PFNMo_TanXing = row["PFNMo_TanXing"].ToString();
               }
               if (row["PFNMo_GanZhang"] != null)
               {
                   model.PFNMo_GanZhang = row["PFNMo_GanZhang"].ToString();
               }
               if (row["PFNMo_ShuiZhong"] != null)
               {
                   model.PFNMo_ShuiZhong = row["PFNMo_ShuiZhong"].ToString();
               }
               if (row["PFNMo_BWJChengDu"] != null)
               {
                   model.PFNMo_BWJChengDu = row["PFNMo_BWJChengDu"].ToString();
               }
               if (row["PFNMo_ZZhuZhi"] != null)
               {
                   model.PFNMo_ZZhuZhi = row["PFNMo_ZZhuZhi"].ToString();
               }
               if (row["PFNMo_ZZZBuWei"] != null)
               {
                   model.PFNMo_ZZZBuWei = row["PFNMo_ZZZBuWei"].ToString();
               }
               if (row["PFNMo_ZZZShuMu"] != null)
               {
                   model.PFNMo_ZZZShuMu = row["PFNMo_ZZZShuMu"].ToString();
               }
               if (row["PFNMo_QiTa"] != null)
               {
                   model.PFNMo_QiTa = row["PFNMo_QiTa"].ToString();
               }
               if (row["LBJie_QSQBLBaJie"] != null)
               {
                   model.LBJie_QSQBLBaJie = row["LBJie_QSQBLBaJie"].ToString();
               }
               if (row["LBJie_QSQBLBJBWJTeZheng"] != null)
               {
                   model.LBJie_QSQBLBJBWJTeZheng = row["LBJie_QSQBLBJBWJTeZheng"].ToString();
               }
               if (row["TBu_TLDaXiao"] != null)
               {
                   model.TBu_TLDaXiao = row["TBu_TLDaXiao"].ToString();
               }
               if (row["TBu_TLJiXing"] != null)
               {
                   model.TBu_TLJiXing = row["TBu_TLJiXing"].ToString();
               }
               if (row["TBu_TLJXForYou"] != null)
               {
                   model.TBu_TLJXForYou = row["TBu_TLJXForYou"].ToString();
               }
               if (row["TBu_TLQTYCYaTong"] != null)
               {
                   model.TBu_TLQTYCYaTong = row["TBu_TLQTYCYaTong"].ToString();
               }
               if (row["TBu_TLQTYCBaoKuai"] != null)
               {
                   model.TBu_TLQTYCBaoKuai = row["TBu_TLQTYCBaoKuai"].ToString();
               }
               if (row["TBu_TLQTYCAoXian"] != null)
               {
                   model.TBu_TLQTYCAoXian = row["TBu_TLQTYCAoXian"].ToString();
               }
               if (row["TBu_TLQTYCBuWei"] != null)
               {
                   model.TBu_TLQTYCBuWei = row["TBu_TLQTYCBuWei"].ToString();
               }
               if (row["TBu_YMMXiShu"] != null)
               {
                   model.TBu_YMMXiShu = row["TBu_YMMXiShu"].ToString();
               }
               if (row["TBu_YMMTuoLuo"] != null)
               {
                   model.TBu_YMMTuoLuo = row["TBu_YMMTuoLuo"].ToString();
               }
               if (row["TBu_YDaoJie"] != null)
               {
                   model.TBu_YDaoJie = row["TBu_YDaoJie"].ToString();
               }
               if (row["TBu_YYanJian"] != null)
               {
                   model.TBu_YYanJian = row["TBu_YYanJian"].ToString();
               }
               if (row["TBu_YJieMo"] != null)
               {
                   model.TBu_YJieMo = row["TBu_YJieMo"].ToString();
               }
               if (row["TBu_YJiaoMo"] != null)
               {
                   model.TBu_YJiaoMo = row["TBu_YJiaoMo"].ToString();
               }
               if (row["TBu_YJiaoMForYiChang"] != null)
               {
                   model.TBu_YJiaoMForYiChang = row["TBu_YJiaoMForYiChang"].ToString();
               }
               if (row["TBu_YGongMo"] != null)
               {
                   model.TBu_YGongMo = row["TBu_YGongMo"].ToString();
               }
               if (row["TBu_YYanQiu"] != null)
               {
                   model.TBu_YYanQiu = row["TBu_YYanQiu"].ToString();
               }
               if (row["TBu_YYQForAll"] != null)
               {
                   model.TBu_YYQForAll = row["TBu_YYQForAll"].ToString();
               }
               if (row["TBu_YTongKong"] != null)
               {
                   model.TBu_YTongKong = row["TBu_YTongKong"].ToString();
               }
               if (row["TBu_TKForBuDengZ"] != null)
               {
                   model.TBu_TKForBuDengZ = row["TBu_TKForBuDengZ"].ToString();
               }
               if (row["TBu_TKForBuDengY"] != null)
               {
                   model.TBu_TKForBuDengY = row["TBu_TKForBuDengY"].ToString();
               }
               if (row["TBu_YTKDGFanShe"] != null)
               {
                   model.TBu_YTKDGFanShe = row["TBu_YTKDGFanShe"].ToString();
               }
               if (row["TBu_YTKDGFSForAll"] != null)
               {
                   model.TBu_YTKDGFSForAll = row["TBu_YTKDGFSForAll"].ToString();
               }
               if (row["TBu_YTKJShiLi"] != null)
               {
                   model.TBu_YTKJShiLi = row["TBu_YTKJShiLi"].ToString();
               }
               if (row["TBu_TKJSLForAllZ"] != null)
               {
                   model.TBu_TKJSLForAllZ = row["TBu_TKJSLForAllZ"].ToString();
               }
               if (row["TBu_TKJSLForAllY"] != null)
               {
                   model.TBu_TKJSLForAllY = row["TBu_TKJSLForAllY"].ToString();
               }
               if (row["TBu_TKJSLQiTa"] != null)
               {
                   model.TBu_TKJSLQiTa = row["TBu_TKJSLQiTa"].ToString();
               }
               if (row["TBu_EErKuo"] != null)
               {
                   model.TBu_EErKuo = row["TBu_EErKuo"].ToString();
               }
               if (row["TBu_EEKQiTa"] != null)
               {
                   model.TBu_EEKQiTa = row["TBu_EEKQiTa"].ToString();
               }
               if (row["TBu_EErKForAll"] != null)
               {
                   model.TBu_EErKForAll = row["TBu_EErKForAll"].ToString();
               }
               if (row["TBu_EWEDFMiWu"] != null)
               {
                   model.TBu_EWEDFMiWu = row["TBu_EWEDFMiWu"].ToString();
               }
               if (row["TBu_EWEDFMWForY"] != null)
               {
                   model.TBu_EWEDFMWForY = row["TBu_EWEDFMWForY"].ToString();
               }
               if (row["TBu_EWEDFMWXingZhi"] != null)
               {
                   model.TBu_EWEDFMWXingZhi = row["TBu_EWEDFMWXingZhi"].ToString();
               }
               if (row["TBu_ERTYaTong"] != null)
               {
                   model.TBu_ERTYaTong = row["TBu_ERTYaTong"].ToString();
               }
               if (row["TBu_ERTYTForY"] != null)
               {
                   model.TBu_ERTYTForY = row["TBu_ERTYTForY"].ToString();
               }
               if (row["TBu_TLCSZhangAi"] != null)
               {
                   model.TBu_TLCSZhangAi = row["TBu_TLCSZhangAi"].ToString();
               }
               if (row["TBu_TLCSZAForY"] != null)
               {
                   model.TBu_TLCSZAForY = row["TBu_TLCSZAForY"].ToString();
               }
               if (row["TBu_BWaiXing"] != null)
               {
                   model.TBu_BWaiXing = row["TBu_BWaiXing"].ToString();
               }
               if (row["TBu_BForYC"] != null)
               {
                   model.TBu_BForYC = row["TBu_BForYC"].ToString();
               }
               if (row["TBu_BBDYaTong"] != null)
               {
                   model.TBu_BBDYaTong = row["TBu_BBDYaTong"].ToString();
               }
               if (row["TBu_BForBDYT"] != null)
               {
                   model.TBu_BForBDYT = row["TBu_BForBDYT"].ToString();
               }
               if (row["TBu_BQTYCBYShanDong"] != null)
               {
                   model.TBu_BQTYCBYShanDong = row["TBu_BQTYCBYShanDong"].ToString();
               }
               if (row["TBu_BQTYCFMiWu"] != null)
               {
                   model.TBu_BQTYCFMiWu = row["TBu_BQTYCFMiWu"].ToString();
               }
               if (row["TBu_BQTYCChuXue"] != null)
               {
                   model.TBu_BQTYCChuXue = row["TBu_BQTYCChuXue"].ToString();
               }
               if (row["TBu_BQTYCZuSe"] != null)
               {
                   model.TBu_BQTYCZuSe = row["TBu_BQTYCZuSe"].ToString();
               }
               if (row["TBu_BQTYCBZGPianQu"] != null)
               {
                   model.TBu_BQTYCBZGPianQu = row["TBu_BQTYCBZGPianQu"].ToString();
               }
               if (row["TBu_BQTYCBZGChuanKong"] != null)
               {
                   model.TBu_BQTYCBZGChuanKong = row["TBu_BQTYCBZGChuanKong"].ToString();
               }
               if (row["TBu_KQKouChun"] != null)
               {
                   model.TBu_KQKouChun = row["TBu_KQKouChun"].ToString();
               }
               if (row["TBu_KQNianMo"] != null)
               {
                   model.TBu_KQNianMo = row["TBu_KQNianMo"].ToString();
               }
               if (row["TBu_KQNMForYC"] != null)
               {
                   model.TBu_KQNMForYC = row["TBu_KQNMForYC"].ToString();
               }
               if (row["TBu_KQSXDGKaiKou"] != null)
               {
                   model.TBu_KQSXDGKaiKou = row["TBu_KQSXDGKaiKou"].ToString();
               }
               if (row["TBu_KQSXDGKKForYC"] != null)
               {
                   model.TBu_KQSXDGKKForYC = row["TBu_KQSXDGKKForYC"].ToString();
               }
               if (row["TBu_KQShe"] != null)
               {
                   model.TBu_KQShe = row["TBu_KQShe"].ToString();
               }
               if (row["TBu_KQSForYC"] != null)
               {
                   model.TBu_KQSForYC = row["TBu_KQSForYC"].ToString();
               }
               if (row["TBu_KQChiYin"] != null)
               {
                   model.TBu_KQChiYin = row["TBu_KQChiYin"].ToString();
               }
               if (row["TBu_KQChiLie"] != null)
               {
                   model.TBu_KQChiLie = row["TBu_KQChiLie"].ToString();
               }
               if (row["TBu_KQBTaoTi"] != null)
               {
                   model.TBu_KQBTaoTi = row["TBu_KQBTaoTi"].ToString();
               }
               if (row["TBu_KQBTTForZD"] != null)
               {
                   model.TBu_KQBTTForZD = row["TBu_KQBTTForZD"].ToString();
               }
               if (row["TBu_KQYan"] != null)
               {
                   model.TBu_KQYan = row["TBu_KQYan"].ToString();
               }
               if (row["TBu_KQShengYin"] != null)
               {
                   model.TBu_KQShengYin = row["TBu_KQShengYin"].ToString();
               }
               if (row["JBu_DKangGan"] != null)
               {
                   model.JBu_DKangGan = row["JBu_DKangGan"].ToString();
               }
               if (row["JBu_QiGuan"] != null)
               {
                   model.JBu_QiGuan = row["JBu_QiGuan"].ToString();
               }
               if (row["JBu_QGForPY"] != null)
               {
                   model.JBu_QGForPY = row["JBu_QGForPY"].ToString();
               }
               if (row["JBu_JJingMai"] != null)
               {
                   model.JBu_JJingMai = row["JBu_JJingMai"].ToString();
               }
               if (row["JBu_JDMBoDoong"] != null)
               {
                   model.JBu_JDMBoDoong = row["JBu_JDMBoDoong"].ToString();
               }
               if (row["JBu_JDMBDForAll"] != null)
               {
                   model.JBu_JDMBDForAll = row["JBu_JDMBDForAll"].ToString();
               }
               if (row["JBu_GJJMHLiuZheng"] != null)
               {
                   model.JBu_GJJMHLiuZheng = row["JBu_GJJMHLiuZheng"].ToString();
               }
               if (row["JBu_JZhuangXian"] != null)
               {
                   model.JBu_JZhuangXian = row["JBu_JZhuangXian"].ToString();
               }
               if (row["JBu_JZXForZDZ"] != null)
               {
                   model.JBu_JZXForZDZ = row["JBu_JZXForZDZ"].ToString();
               }
               if (row["JBu_JZXForZDY"] != null)
               {
                   model.JBu_JZXForZDY = row["JBu_JZXForZDY"].ToString();
               }
               if (row["JBu_JZXZhiRuan"] != null)
               {
                   model.JBu_JZXZhiRuan = row["JBu_JZXZhiRuan"].ToString();
               }
               if (row["JBu_JZXZhiYing"] != null)
               {
                   model.JBu_JZXZhiYing = row["JBu_JZXZhiYing"].ToString();
               }
               if (row["JBu_JZXYaTong"] != null)
               {
                   model.JBu_JZXYaTong = row["JBu_JZXYaTong"].ToString();
               }
               if (row["JBu_JZXZhenChan"] != null)
               {
                   model.JBu_JZXZhenChan = row["JBu_JZXZhenChan"].ToString();
               }
               if (row["JBu_JZXXGZaYin"] != null)
               {
                   model.JBu_JZXXGZaYin = row["JBu_JZXXGZaYin"].ToString();
               }
               if (row["XBu_XiongKuo"] != null)
               {
                   model.XBu_XiongKuo = row["XBu_XiongKuo"].ToString();
               }
               if (row["XBu_RuFang"] != null)
               {
                   model.XBu_RuFang = row["XBu_RuFang"].ToString();
               }
               if (row["XBu_RFForYC"] != null)
               {
                   model.XBu_RFForYC = row["XBu_RFForYC"].ToString();
               }
               if (row["Fei_SZHXYunDong"] != null)
               {
                   model.Fei_SZHXYunDong = row["Fei_SZHXYunDong"].ToString();
               }
               if (row["Fei_SZHXYDForYC"] != null)
               {
                   model.Fei_SZHXYDForYC = row["Fei_SZHXYDForYC"].ToString();
               }
               if (row["Fei_SZLJianXi"] != null)
               {
                   model.Fei_SZLJianXi = row["Fei_SZLJianXi"].ToString();
               }
               if (row["Fei_SZLJXBWForAll"] != null)
               {
                   model.Fei_SZLJXBWForAll = row["Fei_SZLJXBWForAll"].ToString();
               }
               if (row["Fei_CZYuChan"] != null)
               {
                   model.Fei_CZYuChan = row["Fei_CZYuChan"].ToString();
               }
               if (row["Fei_CZYCForYC"] != null)
               {
                   model.Fei_CZYCForYC = row["Fei_CZYCForYC"].ToString();
               }
               if (row["Fei_CZXMMCaGan"] != null)
               {
                   model.Fei_CZXMMCaGan = row["Fei_CZXMMCaGan"].ToString();
               }
               if (row["Fei_CZXMMCGForY"] != null)
               {
                   model.Fei_CZXMMCGForY = row["Fei_CZXMMCGForY"].ToString();
               }
               if (row["Fei_CZPXNFaGan"] != null)
               {
                   model.Fei_CZPXNFaGan = row["Fei_CZPXNFaGan"].ToString();
               }
               if (row["Fei_CZPXNFGForY"] != null)
               {
                   model.Fei_CZPXNFGForY = row["Fei_CZPXNFGForY"].ToString();
               }
               if (row["Fei_KouZhen"] != null)
               {
                   model.Fei_KouZhen = row["Fei_KouZhen"].ToString();
               }
               if (row["Fei_KZForAll"] != null)
               {
                   model.Fei_KZForAll = row["Fei_KZForAll"].ToString();
               }
               if (row["Fei_FXJJJiaXianY"] != null)
               {
                   model.Fei_FXJJJiaXianY = row["Fei_FXJJJiaXianY"].ToString();
               }
               if (row["Fei_FXJJJiaXianZ"] != null)
               {
                   model.Fei_FXJJJiaXianZ = row["Fei_FXJJJiaXianZ"].ToString();
               }
               if (row["Fei_FXJSGZhongXianY"] != null)
               {
                   model.Fei_FXJSGZhongXianY = row["Fei_FXJSGZhongXianY"].ToString();
               }
               if (row["Fei_FXJSGZhongXianZ"] != null)
               {
                   model.Fei_FXJSGZhongXianZ = row["Fei_FXJSGZhongXianZ"].ToString();
               }
               if (row["Fei_FXJYZhongXianY"] != null)
               {
                   model.Fei_FXJYZhongXianY = row["Fei_FXJYZhongXianY"].ToString();
               }
               if (row["Fei_FXJYZhongXianZ"] != null)
               {
                   model.Fei_FXJYZhongXianZ = row["Fei_FXJYZhongXianZ"].ToString();
               }
               if (row["Fei_FXJYDongDuY"] != null)
               {
                   model.Fei_FXJYDongDuY = row["Fei_FXJYDongDuY"].ToString();
               }
               if (row["Fei_FXJYDongDuZ"] != null)
               {
                   model.Fei_FXJYDongDuZ = row["Fei_FXJYDongDuZ"].ToString();
               }
               if (row["Fei_TZHuXi"] != null)
               {
                   model.Fei_TZHuXi = row["Fei_TZHuXi"].ToString();
               }
               if (row["Fei_TZHXiYin"] != null)
               {
                   model.Fei_TZHXiYin = row["Fei_TZHXiYin"].ToString();
               }
               if (row["Fei_TZHXYForYC"] != null)
               {
                   model.Fei_TZHXYForYC = row["Fei_TZHXYForYC"].ToString();
               }
               if (row["Fei_TZLuoYing"] != null)
               {
                   model.Fei_TZLuoYing = row["Fei_TZLuoYing"].ToString();
               }
               if (row["Fei_TZLYForY"] != null)
               {
                   model.Fei_TZLYForY = row["Fei_TZLYForY"].ToString();
               }
               if (row["Fei_TZYYChuanDao"] != null)
               {
                   model.Fei_TZYYChuanDao = row["Fei_TZYYChuanDao"].ToString();
               }
               if (row["Fei_TZYYCDForYC"] != null)
               {
                   model.Fei_TZYYCDForYC = row["Fei_TZYYCDForYC"].ToString();
               }
               if (row["Fei_TZXMMCaYin"] != null)
               {
                   model.Fei_TZXMMCaYin = row["Fei_TZXMMCaYin"].ToString();
               }
               if (row["Fei_XMMCYForY"] != null)
               {
                   model.Fei_XMMCYForY = row["Fei_XMMCYForY"].ToString();
               }
               if (row["Xin_SZXQQLongQi"] != null)
               {
                   model.Xin_SZXQQLongQi = row["Xin_SZXQQLongQi"].ToString();
               }
               if (row["Xin_SZXJBDWeiZhi"] != null)
               {
                   model.Xin_SZXJBDWeiZhi = row["Xin_SZXJBDWeiZhi"].ToString();
               }
               if (row["Xin_SZXJBOWZForYW"] != null)
               {
                   model.Xin_SZXJBOWZForYW = row["Xin_SZXJBOWZForYW"].ToString();
               }
               if (row["Xin_SZXJBoDong"] != null)
               {
                   model.Xin_SZXJBoDong = row["Xin_SZXJBoDong"].ToString();
               }
               if (row["Xin_SZXQQYCBoDong"] != null)
               {
                   model.Xin_SZXQQYCBoDong = row["Xin_SZXQQYCBoDong"].ToString();
               }
               if (row["Xin_SZXQQYCBDForY"] != null)
               {
                   model.Xin_SZXQQYCBDForY = row["Xin_SZXQQYCBDForY"].ToString();
               }
               if (row["Xin_CZXJBoDong"] != null)
               {
                   model.Xin_CZXJBoDong = row["Xin_CZXJBoDong"].ToString();
               }
               if (row["Xin_CZZhenChan"] != null)
               {
                   model.Xin_CZZhenChan = row["Xin_CZZhenChan"].ToString();
               }
               if (row["Xin_ZCForY"] != null)
               {
                   model.Xin_ZCForY = row["Xin_ZCForY"].ToString();
               }
               if (row["Xin_CZXBMCaGan"] != null)
               {
                   model.Xin_CZXBMCaGan = row["Xin_CZXBMCaGan"].ToString();
               }
               if (row["Xin_KZXDZYinJie"] != null)
               {
                   model.Xin_KZXDZYinJie = row["Xin_KZXDZYinJie"].ToString();
               }
               if (row["Xin_KZYEr"] != null)
               {
                   model.Xin_KZYEr = row["Xin_KZYEr"].ToString();
               }
               if (row["Xin_KZZEr"] != null)
               {
                   model.Xin_KZZEr = row["Xin_KZZEr"].ToString();
               }
               if (row["Xin_KZYSan"] != null)
               {
                   model.Xin_KZYSan = row["Xin_KZYSan"].ToString();
               }
               if (row["Xin_KZZSan"] != null)
               {
                   model.Xin_KZZSan = row["Xin_KZZSan"].ToString();
               }
               if (row["Xin_KZYSi"] != null)
               {
                   model.Xin_KZYSi = row["Xin_KZYSi"].ToString();
               }
               if (row["Xin_KZZSi"] != null)
               {
                   model.Xin_KZZSi = row["Xin_KZZSi"].ToString();
               }
               if (row["Xin_KZYWu"] != null)
               {
                   model.Xin_KZYWu = row["Xin_KZYWu"].ToString();
               }
               if (row["Xin_KZZWu"] != null)
               {
                   model.Xin_KZZWu = row["Xin_KZZWu"].ToString();
               }
               if (row["Xin_KZZXian"] != null)
               {
                   model.Xin_KZZXian = row["Xin_KZZXian"].ToString();
               }
               if (row["Xin_TZXinLvC"] != null)
               {
                   model.Xin_TZXinLvC = row["Xin_TZXinLvC"].ToString();
               }
               if (row["Xin_TZXinLv"] != null)
               {
                   model.Xin_TZXinLv = row["Xin_TZXinLv"].ToString();
               }
               if (row["Xin_TZXinYin"] != null)
               {
                   model.Xin_TZXinYin = row["Xin_TZXinYin"].ToString();
               }
               if (row["Xin_ZWXGWYCXGuanZheng"] != null)
               {
                   model.Xin_ZWXGWYCXGuanZheng = row["Xin_ZWXGWYCXGuanZheng"].ToString();
               }
               if (row["Xin_ZWXGQJiYin"] != null)
               {
                   model.Xin_ZWXGQJiYin = row["Xin_ZWXGQJiYin"].ToString();
               }
               if (row["Xin_ZWXGDDSChongYin"] != null)
               {
                   model.Xin_ZWXGDDSChongYin = row["Xin_ZWXGDDSChongYin"].ToString();
               }
               if (row["Xin_ZWXGSChongMai"] != null)
               {
                   model.Xin_ZWXGSChongMai = row["Xin_ZWXGSChongMai"].ToString();
               }
               if (row["Xin_ZWXGMXXGBoDong"] != null)
               {
                   model.Xin_ZWXGMXXGBoDong = row["Xin_ZWXGMXXGBoDong"].ToString();
               }
               if (row["Xin_ZWXGMBDuanChu"] != null)
               {
                   model.Xin_ZWXGMBDuanChu = row["Xin_ZWXGMBDuanChu"].ToString();
               }
               if (row["Xin_ZWXGQiMai"] != null)
               {
                   model.Xin_ZWXGQiMai = row["Xin_ZWXGQiMai"].ToString();
               }
               if (row["Xin_ZWXGJTiMai"] != null)
               {
                   model.Xin_ZWXGJTiMai = row["Xin_ZWXGJTiMai"].ToString();
               }
               if (row["Xin_ZWXGQiTa"] != null)
               {
                   model.Xin_ZWXGQiTa = row["Xin_ZWXGQiTa"].ToString();
               }
               if (row["FBu_ShiZhen"] != null)
               {
                   model.FBu_ShiZhen = row["FBu_ShiZhen"].ToString();
               }
               if (row["FBu_CZRouRuan"] != null)
               {
                   model.FBu_CZRouRuan = row["FBu_CZRouRuan"].ToString();
               }
               if (row["FBu_CZFJJinZhang"] != null)
               {
                   model.FBu_CZFJJinZhang = row["FBu_CZFJJinZhang"].ToString();
               }
               if (row["FBu_CZFJJZForYou"] != null)
               {
                   model.FBu_CZFJJZForYou = row["FBu_CZFJJZForYou"].ToString();
               }
               if (row["FBu_CZYaTong"] != null)
               {
                   model.FBu_CZYaTong = row["FBu_CZYaTong"].ToString();
               }
               if (row["FBu_CZYTForYou"] != null)
               {
                   model.FBu_CZYTForYou = row["FBu_CZYTForYou"].ToString();
               }
               if (row["FBu_CZFTiaoTong"] != null)
               {
                   model.FBu_CZFTiaoTong = row["FBu_CZFTiaoTong"].ToString();
               }
               if (row["FBu_CZFTTForYou"] != null)
               {
                   model.FBu_CZFTTForYou = row["FBu_CZFTTForYou"].ToString();
               }
               if (row["FBu_CZYBZhenChan"] != null)
               {
                   model.FBu_CZYBZhenChan = row["FBu_CZYBZhenChan"].ToString();
               }
               if (row["FBu_CZZShuiSheng"] != null)
               {
                   model.FBu_CZZShuiSheng = row["FBu_CZZShuiSheng"].ToString();
               }
               if (row["FBu_CZFBBaoKuai"] != null)
               {
                   model.FBu_CZFBBaoKuai = row["FBu_CZFBBaoKuai"].ToString();
               }
               if (row["FBu_CZFBBKForYou"] != null)
               {
                   model.FBu_CZFBBKForYou = row["FBu_CZFBBKForYou"].ToString();
               }
               if (row["FBu_CZFBBKTZMiaoShu"] != null)
               {
                   model.FBu_CZFBBKTZMiaoShu = row["FBu_CZFBBKTZMiaoShu"].ToString();
               }
               if (row["FBu_CZGan"] != null)
               {
                   model.FBu_CZGan = row["FBu_CZGan"].ToString();
               }
               if (row["FBu_CZDanNang"] != null)
               {
                   model.FBu_CZDanNang = row["FBu_CZDanNang"].ToString();
               }
               if (row["FBu_CZPi"] != null)
               {
                   model.FBu_CZPi = row["FBu_CZPi"].ToString();
               }
               if (row["FBu_CZShen"] != null)
               {
                   model.FBu_CZShen = row["FBu_CZShen"].ToString();
               }
               if (row["FBu_KZGZYinJie"] != null)
               {
                   model.FBu_KZGZYinJie = row["FBu_KZGZYinJie"].ToString();
               }
               if (row["FBu_KZSGZhongXian"] != null)
               {
                   model.FBu_KZSGZhongXian = row["FBu_KZSGZhongXian"].ToString();
               }
               if (row["FBu_KZYDXZhuoYin"] != null)
               {
                   model.FBu_KZYDXZhuoYin = row["FBu_KZYDXZhuoYin"].ToString();
               }
               if (row["FBu_KZSQKouTong"] != null)
               {
                   model.FBu_KZSQKouTong = row["FBu_KZSQKouTong"].ToString();
               }
               if (row["FBu_KZQiTa"] != null)
               {
                   model.FBu_KZQiTa = row["FBu_KZQiTa"].ToString();
               }
               if (row["FBu_TZCMinYin"] != null)
               {
                   model.FBu_TZCMinYin = row["FBu_TZCMinYin"].ToString();
               }
               if (row["FBu_TZXGZaYin"] != null)
               {
                   model.FBu_TZXGZaYin = row["FBu_TZXGZaYin"].ToString();
               }
               if (row["FBu_TZXGZYForY"] != null)
               {
                   model.FBu_TZXGZYForY = row["FBu_TZXGZYForY"].ToString();
               }
               if (row["FBu_TZQGShuiSheng"] != null)
               {
                   model.FBu_TZQGShuiSheng = row["FBu_TZQGShuiSheng"].ToString();
               }
               if (row["GMZChang"] != null)
               {
                   model.GMZChang = row["GMZChang"].ToString();
               }
               if (row["GMZChangForY"] != null)
               {
                   model.GMZChangForY = row["GMZChangForY"].ToString();
               }
               if (row["SZQi"] != null)
               {
                   model.SZQi = row["SZQi"].ToString();
               }
               if (row["SZQiForY"] != null)
               {
                   model.SZQiForY = row["SZQiForY"].ToString();
               }
               if (row["GGJRou_JiZhu"] != null)
               {
                   model.GGJRou_JiZhu = row["GGJRou_JiZhu"].ToString();
               }
               if (row["GGJRou_JZForJX"] != null)
               {
                   model.GGJRou_JZForJX = row["GGJRou_JZForJX"].ToString();
               }
               if (row["GGJRou_QiTa"] != null)
               {
                   model.GGJRou_QiTa = row["GGJRou_QiTa"].ToString();
               }
               if (row["GGJRou_SiZhi"] != null)
               {
                   model.GGJRou_SiZhi = row["GGJRou_SiZhi"].ToString();
               }
               if (row["SJXiTong"] != null)
               {
                   model.SJXiTong = row["SJXiTong"].ToString();
               }
               if (row["ZKQingKuang"] != null)
               {
                   model.ZKQingKuang = row["ZKQingKuang"].ToString();
               }
               if (row["SYSJQXJianCha"] != null)
               {
                   model.SYSJQXJianCha = row["SYSJQXJianCha"].ToString();
               }
               if (row["BLZhaiYao"] != null)
               {
                   model.BLZhaiYao = row["BLZhaiYao"].ToString();
               }
               if (row["CBZhenDuan"] != null)
               {
                   model.CBZhenDuan = row["CBZhenDuan"].ToString();
               }
               if (row["RYZhenDuan"] != null)
               {
                   model.RYZhenDuan = row["RYZhenDuan"].ToString();
               }
               if (row["XZZhenDuan"] != null)
               {
                   model.XZZhenDuan = row["XZZhenDuan"].ToString();
               }
               if (row["Reviewer"] != null)
               {
                   model.Reviewer = row["Reviewer"].ToString();
               }
               if (row["ReviewerDate"] != null)
               {
                   model.ReviewerDate = row["ReviewerDate"].ToString();
               }
               if (row["RecordsStatus"] != null)
               {
                   model.RecordsStatus = row["RecordsStatus"].ToString();
               }
           }
           return model;
       } 
       #endregion
       #region  Update(BigMedicalRecordsModel model)
       public bool Update(BigMedicalRecordsModel model)
       {
           StringBuilder strSql=new StringBuilder();
			strSql.Append("update GP_BigMedicalRecords set ");
			strSql.Append("StudentsRealName=@StudentsRealName,");
			strSql.Append("StudentsName=@StudentsName,");
			strSql.Append("TrainingBaseCode=@TrainingBaseCode,");
			strSql.Append("TrainingBaseName=@TrainingBaseName,");
			strSql.Append("ProfessionalBaseCode=@ProfessionalBaseCode,");
			strSql.Append("ProfessionalBaseName=@ProfessionalBaseName,");
			strSql.Append("DeptCode=@DeptCode,");
			strSql.Append("DeptName=@DeptName,");
			strSql.Append("RegisterDate=@RegisterDate,");
			strSql.Append("Writor=@Writor,");
			strSql.Append("TeacherId=@TeacherId,");
			strSql.Append("TeacherName=@TeacherName,");
			strSql.Append("PatientNo=@PatientNo,");
			strSql.Append("InhospitalNo=@InhospitalNo,");
			strSql.Append("PatientName=@PatientName,");
			strSql.Append("sex=@sex,");
			strSql.Append("Age=@Age,");
			strSql.Append("Job=@Job,");
			strSql.Append("Nation=@Nation,");
			strSql.Append("Marriage=@Marriage,");
			strSql.Append("BirthProvinceCode=@BirthProvinceCode,");
			strSql.Append("BirthProvinceName=@BirthProvinceName,");
			strSql.Append("BirthCityCode=@BirthCityCode,");
			strSql.Append("BirthCityName=@BirthCityName,");
			strSql.Append("BirthAreaCode=@BirthAreaCode,");
			strSql.Append("BirthAreaName=@BirthAreaName,");
			strSql.Append("BirthDetailAddress=@BirthDetailAddress,");
			strSql.Append("Company=@Company,");
			strSql.Append("NowProvinceCode=@NowProvinceCode,");
			strSql.Append("NowProvinceName=@NowProvinceName,");
			strSql.Append("NowCityCode=@NowCityCode,");
			strSql.Append("NowCityName=@NowCityName,");
			strSql.Append("NowAreaCode=@NowAreaCode,");
			strSql.Append("NowAreaName=@NowAreaName,");
			strSql.Append("NowDetailAddress=@NowDetailAddress,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("InhospitalDate=@InhospitalDate,");
			strSql.Append("RecordDate=@RecordDate,");
			strSql.Append("MedicalHistorySpeaker=@MedicalHistorySpeaker,");
			strSql.Append("ReliableDegree=@ReliableDegree,");
			strSql.Append("ZSu=@ZSu,");
			strSql.Append("XBShi=@XBShi,");
			strSql.Append("JWShi_PSJKZhuangKuang=@JWShi_PSJKZhuangKuang,");
			strSql.Append("JWShi_CHJBHCRBingShi=@JWShi_CHJBHCRBingShi,");
			strSql.Append("JWShi_YFJZhongShi=@JWShi_YFJZhongShi,");
			strSql.Append("JWShi_GMinShi=@JWShi_GMinShi,");
			strSql.Append("JWShi_GMinYuan=@JWShi_GMinYuan,");
			strSql.Append("JWShi_LCBiaoXian=@JWShi_LCBiaoXian,");
			strSql.Append("JWShi_WShangShi=@JWShi_WShangShi,");
			strSql.Append("JWShi_SShuShi=@JWShi_SShuShi,");
			strSql.Append("XTHGu_KeSou=@XTHGu_KeSou,");
			strSql.Append("XTHGu_KeTan=@XTHGu_KeTan,");
			strSql.Append("XTHGu_KaXie=@XTHGu_KaXie,");
			strSql.Append("XTHGu_ChuanXi=@XTHGu_ChuanXi,");
			strSql.Append("XTHGu_XiongTong=@XTHGu_XiongTong,");
			strSql.Append("XTHGu_HXKunNan=@XTHGu_HXKunNan,");
			strSql.Append("XTHGu_XinJi=@XTHGu_XinJi,");
			strSql.Append("XTHGu_HDHQiCu=@XTHGu_HDHQiCu,");
			strSql.Append("XTHGu_XZShuiZhong=@XTHGu_XZShuiZhong,");
			strSql.Append("XTHGu_XQQuTong=@XTHGu_XQQuTong,");
			strSql.Append("XTHGu_XYZengGao=@XTHGu_XYZengGao,");
			strSql.Append("XTHGu_YunJue=@XTHGu_YunJue,");
			strSql.Append("XTHGu_SYJianTui=@XTHGu_SYJianTui,");
			strSql.Append("XTHGu_FanSuan=@XTHGu_FanSuan,");
			strSql.Append("XTHGu_AiQi=@XTHGu_AiQi,");
			strSql.Append("XTHGu_EXin=@XTHGu_EXin,");
			strSql.Append("XTHGu_OuTu=@XTHGu_OuTu,");
			strSql.Append("XTHGu_FuZhang=@XTHGu_FuZhang,");
			strSql.Append("XTHGu_FuTong=@XTHGu_FuTong,");
			strSql.Append("XTHGu_BianMi=@XTHGu_BianMi,");
			strSql.Append("XTHGu_FuXie=@XTHGu_FuXie,");
			strSql.Append("XTHGu_OuXue=@XTHGu_OuXue,");
			strSql.Append("XTHGu_HeiBian=@XTHGu_HeiBian,");
			strSql.Append("XTHGu_BianXue=@XTHGu_BianXue,");
			strSql.Append("XTHGu_HuangDan=@XTHGu_HuangDan,");
			strSql.Append("XTHGu_YaoTong=@XTHGu_YaoTong,");
			strSql.Append("XTHGu_NiaoPin=@XTHGu_NiaoPin,");
			strSql.Append("XTHGu_NiaoJi=@XTHGu_NiaoJi,");
			strSql.Append("XTHGu_NiaoTong=@XTHGu_NiaoTong,");
			strSql.Append("XTHGu_PNKunNan=@XTHGu_PNKunNan,");
			strSql.Append("XTHGu_XueNiao=@XTHGu_XueNiao,");
			strSql.Append("XTHGu_NLYiChang=@XTHGu_NLYiChang,");
			strSql.Append("XTHGu_YNZengDuo=@XTHGu_YNZengDuo,");
			strSql.Append("XTHGu_ShuiZhong=@XTHGu_ShuiZhong,");
			strSql.Append("XTHGu_YBSaoYang=@XTHGu_YBSaoYang,");
			strSql.Append("XTHGu_YBKuiLan=@XTHGu_YBKuiLan,");
			strSql.Append("XTHGu_FaLi=@XTHGu_FaLi,");
			strSql.Append("XTHGu_TouYun=@XTHGu_TouYun,");
			strSql.Append("XTHGu_YanHua=@XTHGu_YanHua,");
			strSql.Append("XTHGu_YYChuXue=@XTHGu_YYChuXue,");
			strSql.Append("XTHGu_BChuXue=@XTHGu_BChuXue,");
			strSql.Append("XTHGu_PXChuXue=@XTHGu_PXChuXue,");
			strSql.Append("XTHGu_GuTong=@XTHGu_GuTong,");
			strSql.Append("XTHGu_SYKangJin=@XTHGu_SYKangJin,");
			strSql.Append("XTHGu_PaRe=@XTHGu_PaRe,");
			strSql.Append("XTHGu_DuoHan=@XTHGu_DuoHan,");
			strSql.Append("XTHGu_WeiHan=@XTHGu_WeiHan,");
			strSql.Append("XTHGu_DuoYin=@XTHGu_DuoYin,");
			strSql.Append("XTHGu_DuoNiao=@XTHGu_DuoNiao,");
			strSql.Append("XTHGu_SSZhenChan=@XTHGu_SSZhenChan,");
			strSql.Append("XTHGu_XGGaiBian=@XTHGu_XGGaiBian,");
			strSql.Append("XTHGu_XZFeiPang=@XTHGu_XZFeiPang,");
			strSql.Append("XTHGu_MXXiaoShou=@XTHGu_MXXiaoShou,");
			strSql.Append("XTHGu_MFZengDuov=@XTHGu_MFZengDuov,");
			strSql.Append("XTHGu_MFTuoLuo=@XTHGu_MFTuoLuo,");
			strSql.Append("XTHGu_SSChenZhuo=@XTHGu_SSChenZhuo,");
			strSql.Append("XTHGu_XGNGaiBian=@XTHGu_XGNGaiBian,");
			strSql.Append("XTHGu_BiJing=@XTHGu_BiJing,");
			strSql.Append("XTHGu_GJieTong=@XTHGu_GJieTong,");
			strSql.Append("XTHGu_GJHongZhong=@XTHGu_GJHongZhong,");
			strSql.Append("XTHGu_GJBianXing=@XTHGu_GJBianXing,");
			strSql.Append("XTHGu_JRouTong=@XTHGu_JRouTong,");
			strSql.Append("XTHGu_JRWeiSuo=@XTHGu_JRWeiSuo,");
			strSql.Append("XTHGu_TouTong=@XTHGu_TouTong,");
			strSql.Append("XTHGu_XuanYun=@XTHGu_XuanYun,");
			strSql.Append("XTHGu_YunJue1=@XTHGu_YunJue1,");
			strSql.Append("JXTHGu_JYLJianTui=@JXTHGu_JYLJianTui,");
			strSql.Append("XTHGu_SLZhangAi=@XTHGu_SLZhangAi,");
			strSql.Append("XTHGu_ShiMian=@XTHGu_ShiMian,");
			strSql.Append("XTHGu_YSZhangAi=@XTHGu_YSZhangAi,");
			strSql.Append("XTHGu_ChanDong=@XTHGu_ChanDong,");
			strSql.Append("XTHGu_ChouChu=@XTHGu_ChouChu,");
			strSql.Append("XTHGu_TanHuan=@XTHGu_TanHuan,");
			strSql.Append("XTHGu_GJYiChang=@XTHGu_GJYiChang,");
			strSql.Append("GRShi_BirthProvinceCode=@GRShi_BirthProvinceCode,");
			strSql.Append("GRShi_BirthProvinceName=@GRShi_BirthProvinceName,");
			strSql.Append("GRShi_BirthCityCode=@GRShi_BirthCityCode,");
			strSql.Append("GRShi_BirthCityName=@GRShi_BirthCityName,");
			strSql.Append("GRShi_BirthAreaCode=@GRShi_BirthAreaCode,");
			strSql.Append("GRShi_BirthAreaName=@GRShi_BirthAreaName,");
			strSql.Append("GRShi_BirthDetailAddress=@GRShi_BirthDetailAddress,");
			strSql.Append("GRShi_CSHZGongZuo=@GRShi_CSHZGongZuo,");
			strSql.Append("GRShi_DFBDQJZQingKuang=@GRShi_DFBDQJZQingKuang,");
			strSql.Append("GRShi_YYouShi=@GRShi_YYouShi,");
			strSql.Append("GRShi_ShiYan=@GRShi_ShiYan,");
			strSql.Append("GRShi_SYanNian=@GRShi_SYanNian,");
			strSql.Append("GRShi_SYanZhi=@GRShi_SYanZhi,");
			strSql.Append("GRShi_JieYan=@GRShi_JieYan,");
			strSql.Append("GRShi_JYanNian=@GRShi_JYanNian,");
			strSql.Append("GRShi_ShiJiu=@GRShi_ShiJiu,");
			strSql.Append("GRShi_SJiuNian=@GRShi_SJiuNian,");
			strSql.Append("GRShi_SJiuLiang=@GRShi_SJiuLiang,");
			strSql.Append("GRShi_SJQiTa=@GRShi_SJQiTa,");
			strSql.Append("HYShi_JHNianLing=@HYShi_JHNianLing,");
			strSql.Append("HYShi_POQingKuang=@HYShi_POQingKuang,");
			strSql.Append("YJSHSYShi_CChaoSui=@YJSHSYShi_CChaoSui,");
			strSql.Append("YJSHSYShi_CChaoTian=@YJSHSYShi_CChaoTian,");
			strSql.Append("YJSHSYShi_MCYJRiQi=@YJSHSYShi_MCYJRiQi,");
			strSql.Append("YJSHSYShi_JJNianLing=@YJSHSYShi_JJNianLing,");
			strSql.Append("YJSHSYShi_ZhouQi=@YJSHSYShi_ZhouQi,");
			strSql.Append("YJSHSYShi_JingLiang=@YJSHSYShi_JingLiang,");
			strSql.Append("YJSHSYShi_TongJing=@YJSHSYShi_TongJing,");
			strSql.Append("YJSHSYShi_JingQi=@YJSHSYShi_JingQi,");
			strSql.Append("YJSHSYShi_RenShen=@YJSHSYShi_RenShen,");
			strSql.Append("YJSHSYShi_ShunChan=@YJSHSYShi_ShunChan,");
			strSql.Append("YJSHSYShi_LiuChan=@YJSHSYShi_LiuChan,");
			strSql.Append("YJSHSYShi_ZaoChan=@YJSHSYShi_ZaoChan,");
			strSql.Append("YJSHSYShi_SiChan=@YJSHSYShi_SiChan,");
			strSql.Append("YJSHSYShi_NCJBingQing=@YJSHSYShi_NCJBingQing,");
			strSql.Append("YJSHSYShi_Zi=@YJSHSYShi_Zi,");
			strSql.Append("YJSHSYShi_Nv=@YJSHSYShi_Nv,");
			strSql.Append("JZShi_Fu=@JZShi_Fu,");
			strSql.Append("JZShi_FSiYin=@JZShi_FSiYin,");
			strSql.Append("JZShi_Mu=@JZShi_Mu,");
			strSql.Append("JZShi_MSiYin=@JZShi_MSiYin,");
			strSql.Append("JZShi_XDJieMei=@JZShi_XDJieMei,");
			strSql.Append("JZShi_ZNJQiTa=@JZShi_ZNJQiTa,");
			strSql.Append("SMTZheng_TiWen=@SMTZheng_TiWen,");
			strSql.Append("SMTZheng_MaiBo=@SMTZheng_MaiBo,");
			strSql.Append("SMTZheng_HuXi=@SMTZheng_HuXi,");
			strSql.Append("SMTZheng_XueYa1=@SMTZheng_XueYa1,");
			strSql.Append("SMTZheng_XueYa2=@SMTZheng_XueYa2,");
			strSql.Append("SMTZheng_TiZhong=@SMTZheng_TiZhong,");
			strSql.Append("YBZKuang_FaYu=@YBZKuang_FaYu,");
			strSql.Append("YBZKuang_YingYang=@YBZKuang_YingYang,");
			strSql.Append("YBZKuang_MianRong=@YBZKuang_MianRong,");
			strSql.Append("YBZKuang_QiTa=@YBZKuang_QiTa,");
			strSql.Append("YBZKuang_BiaoQing=@YBZKuang_BiaoQing,");
			strSql.Append("YBZKuang_TiWei=@YBZKuang_TiWei,");
			strSql.Append("YBZKuang_TWForQP=@YBZKuang_TWForQP,");
			strSql.Append("YBZKuang_BuTai=@YBZKuang_BuTai,");
			strSql.Append("YBZKuang_BTForBZC=@YBZKuang_BTForBZC,");
			strSql.Append("YBZKuang_ShenZhi=@YBZKuang_ShenZhi,");
			strSql.Append("YBZKuang_PHJianCha=@YBZKuang_PHJianCha,");
			strSql.Append("PFNMo_SeZe=@PFNMo_SeZe,");
			strSql.Append("PFNMo_PiZhen=@PFNMo_PiZhen,");
			strSql.Append("PFNMo_PZLXJFenBu=@PFNMo_PZLXJFenBu,");
			strSql.Append("PFNMo_PXChuXue=@PFNMo_PXChuXue,");
			strSql.Append("PFNMo_PXCXLXJFenBu=@PFNMo_PXCXLXJFenBu,");
			strSql.Append("PFNMo_MFFenBu=@PFNMo_MFFenBu,");
			strSql.Append("PFNMo_MFFBBuWei=@PFNMo_MFFBBuWei,");
			strSql.Append("PFNMo_WDYShiDu=@PFNMo_WDYShiDu,");
			strSql.Append("PFNMo_TanXing=@PFNMo_TanXing,");
			strSql.Append("PFNMo_GanZhang=@PFNMo_GanZhang,");
			strSql.Append("PFNMo_ShuiZhong=@PFNMo_ShuiZhong,");
			strSql.Append("PFNMo_BWJChengDu=@PFNMo_BWJChengDu,");
			strSql.Append("PFNMo_ZZhuZhi=@PFNMo_ZZhuZhi,");
			strSql.Append("PFNMo_ZZZBuWei=@PFNMo_ZZZBuWei,");
			strSql.Append("PFNMo_ZZZShuMu=@PFNMo_ZZZShuMu,");
			strSql.Append("PFNMo_QiTa=@PFNMo_QiTa,");
			strSql.Append("LBJie_QSQBLBaJie=@LBJie_QSQBLBaJie,");
			strSql.Append("LBJie_QSQBLBJBWJTeZheng=@LBJie_QSQBLBJBWJTeZheng,");
			strSql.Append("TBu_TLDaXiao=@TBu_TLDaXiao,");
			strSql.Append("TBu_TLJiXing=@TBu_TLJiXing,");
			strSql.Append("TBu_TLJXForYou=@TBu_TLJXForYou,");
			strSql.Append("TBu_TLQTYCYaTong=@TBu_TLQTYCYaTong,");
			strSql.Append("TBu_TLQTYCBaoKuai=@TBu_TLQTYCBaoKuai,");
			strSql.Append("TBu_TLQTYCAoXian=@TBu_TLQTYCAoXian,");
			strSql.Append("TBu_TLQTYCBuWei=@TBu_TLQTYCBuWei,");
			strSql.Append("TBu_YMMXiShu=@TBu_YMMXiShu,");
			strSql.Append("TBu_YMMTuoLuo=@TBu_YMMTuoLuo,");
			strSql.Append("TBu_YDaoJie=@TBu_YDaoJie,");
			strSql.Append("TBu_YYanJian=@TBu_YYanJian,");
			strSql.Append("TBu_YJieMo=@TBu_YJieMo,");
			strSql.Append("TBu_YJiaoMo=@TBu_YJiaoMo,");
			strSql.Append("TBu_YJiaoMForYiChang=@TBu_YJiaoMForYiChang,");
			strSql.Append("TBu_YGongMo=@TBu_YGongMo,");
			strSql.Append("TBu_YYanQiu=@TBu_YYanQiu,");
			strSql.Append("TBu_YYQForAll=@TBu_YYQForAll,");
			strSql.Append("TBu_YTongKong=@TBu_YTongKong,");
			strSql.Append("TBu_TKForBuDengZ=@TBu_TKForBuDengZ,");
			strSql.Append("TBu_TKForBuDengY=@TBu_TKForBuDengY,");
			strSql.Append("TBu_YTKDGFanShe=@TBu_YTKDGFanShe,");
			strSql.Append("TBu_YTKDGFSForAll=@TBu_YTKDGFSForAll,");
			strSql.Append("TBu_YTKJShiLi=@TBu_YTKJShiLi,");
			strSql.Append("TBu_TKJSLForAllZ=@TBu_TKJSLForAllZ,");
			strSql.Append("TBu_TKJSLForAllY=@TBu_TKJSLForAllY,");
			strSql.Append("TBu_TKJSLQiTa=@TBu_TKJSLQiTa,");
			strSql.Append("TBu_EErKuo=@TBu_EErKuo,");
			strSql.Append("TBu_EEKQiTa=@TBu_EEKQiTa,");
			strSql.Append("TBu_EErKForAll=@TBu_EErKForAll,");
			strSql.Append("TBu_EWEDFMiWu=@TBu_EWEDFMiWu,");
			strSql.Append("TBu_EWEDFMWForY=@TBu_EWEDFMWForY,");
			strSql.Append("TBu_EWEDFMWXingZhi=@TBu_EWEDFMWXingZhi,");
			strSql.Append("TBu_ERTYaTong=@TBu_ERTYaTong,");
			strSql.Append("TBu_ERTYTForY=@TBu_ERTYTForY,");
			strSql.Append("TBu_TLCSZhangAi=@TBu_TLCSZhangAi,");
			strSql.Append("TBu_TLCSZAForY=@TBu_TLCSZAForY,");
			strSql.Append("TBu_BWaiXing=@TBu_BWaiXing,");
			strSql.Append("TBu_BForYC=@TBu_BForYC,");
			strSql.Append("TBu_BBDYaTong=@TBu_BBDYaTong,");
			strSql.Append("TBu_BForBDYT=@TBu_BForBDYT,");
			strSql.Append("TBu_BQTYCBYShanDong=@TBu_BQTYCBYShanDong,");
			strSql.Append("TBu_BQTYCFMiWu=@TBu_BQTYCFMiWu,");
			strSql.Append("TBu_BQTYCChuXue=@TBu_BQTYCChuXue,");
			strSql.Append("TBu_BQTYCZuSe=@TBu_BQTYCZuSe,");
			strSql.Append("TBu_BQTYCBZGPianQu=@TBu_BQTYCBZGPianQu,");
			strSql.Append("TBu_BQTYCBZGChuanKong=@TBu_BQTYCBZGChuanKong,");
			strSql.Append("TBu_KQKouChun=@TBu_KQKouChun,");
			strSql.Append("TBu_KQNianMo=@TBu_KQNianMo,");
			strSql.Append("TBu_KQNMForYC=@TBu_KQNMForYC,");
			strSql.Append("TBu_KQSXDGKaiKou=@TBu_KQSXDGKaiKou,");
			strSql.Append("TBu_KQSXDGKKForYC=@TBu_KQSXDGKKForYC,");
			strSql.Append("TBu_KQShe=@TBu_KQShe,");
			strSql.Append("TBu_KQSForYC=@TBu_KQSForYC,");
			strSql.Append("TBu_KQChiYin=@TBu_KQChiYin,");
			strSql.Append("TBu_KQChiLie=@TBu_KQChiLie,");
			strSql.Append("TBu_KQBTaoTi=@TBu_KQBTaoTi,");
			strSql.Append("TBu_KQBTTForZD=@TBu_KQBTTForZD,");
			strSql.Append("TBu_KQYan=@TBu_KQYan,");
			strSql.Append("TBu_KQShengYin=@TBu_KQShengYin,");
			strSql.Append("JBu_DKangGan=@JBu_DKangGan,");
			strSql.Append("JBu_QiGuan=@JBu_QiGuan,");
			strSql.Append("JBu_QGForPY=@JBu_QGForPY,");
			strSql.Append("JBu_JJingMai=@JBu_JJingMai,");
			strSql.Append("JBu_JDMBoDoong=@JBu_JDMBoDoong,");
			strSql.Append("JBu_JDMBDForAll=@JBu_JDMBDForAll,");
			strSql.Append("JBu_GJJMHLiuZheng=@JBu_GJJMHLiuZheng,");
			strSql.Append("JBu_JZhuangXian=@JBu_JZhuangXian,");
			strSql.Append("JBu_JZXForZDZ=@JBu_JZXForZDZ,");
			strSql.Append("JBu_JZXForZDY=@JBu_JZXForZDY,");
			strSql.Append("JBu_JZXZhiRuan=@JBu_JZXZhiRuan,");
			strSql.Append("JBu_JZXZhiYing=@JBu_JZXZhiYing,");
			strSql.Append("JBu_JZXYaTong=@JBu_JZXYaTong,");
			strSql.Append("JBu_JZXZhenChan=@JBu_JZXZhenChan,");
			strSql.Append("JBu_JZXXGZaYin=@JBu_JZXXGZaYin,");
			strSql.Append("XBu_XiongKuo=@XBu_XiongKuo,");
			strSql.Append("XBu_RuFang=@XBu_RuFang,");
			strSql.Append("XBu_RFForYC=@XBu_RFForYC,");
			strSql.Append("Fei_SZHXYunDong=@Fei_SZHXYunDong,");
			strSql.Append("Fei_SZHXYDForYC=@Fei_SZHXYDForYC,");
			strSql.Append("Fei_SZLJianXi=@Fei_SZLJianXi,");
			strSql.Append("Fei_SZLJXBWForAll=@Fei_SZLJXBWForAll,");
			strSql.Append("Fei_CZYuChan=@Fei_CZYuChan,");
			strSql.Append("Fei_CZYCForYC=@Fei_CZYCForYC,");
			strSql.Append("Fei_CZXMMCaGan=@Fei_CZXMMCaGan,");
			strSql.Append("Fei_CZXMMCGForY=@Fei_CZXMMCGForY,");
			strSql.Append("Fei_CZPXNFaGan=@Fei_CZPXNFaGan,");
			strSql.Append("Fei_CZPXNFGForY=@Fei_CZPXNFGForY,");
			strSql.Append("Fei_KouZhen=@Fei_KouZhen,");
			strSql.Append("Fei_KZForAll=@Fei_KZForAll,");
			strSql.Append("Fei_FXJJJiaXianY=@Fei_FXJJJiaXianY,");
			strSql.Append("Fei_FXJJJiaXianZ=@Fei_FXJJJiaXianZ,");
			strSql.Append("Fei_FXJSGZhongXianY=@Fei_FXJSGZhongXianY,");
			strSql.Append("Fei_FXJSGZhongXianZ=@Fei_FXJSGZhongXianZ,");
			strSql.Append("Fei_FXJYZhongXianY=@Fei_FXJYZhongXianY,");
			strSql.Append("Fei_FXJYZhongXianZ=@Fei_FXJYZhongXianZ,");
			strSql.Append("Fei_FXJYDongDuY=@Fei_FXJYDongDuY,");
			strSql.Append("Fei_FXJYDongDuZ=@Fei_FXJYDongDuZ,");
			strSql.Append("Fei_TZHuXi=@Fei_TZHuXi,");
			strSql.Append("Fei_TZHXiYin=@Fei_TZHXiYin,");
			strSql.Append("Fei_TZHXYForYC=@Fei_TZHXYForYC,");
			strSql.Append("Fei_TZLuoYing=@Fei_TZLuoYing,");
			strSql.Append("Fei_TZLYForY=@Fei_TZLYForY,");
			strSql.Append("Fei_TZYYChuanDao=@Fei_TZYYChuanDao,");
			strSql.Append("Fei_TZYYCDForYC=@Fei_TZYYCDForYC,");
			strSql.Append("Fei_TZXMMCaYin=@Fei_TZXMMCaYin,");
			strSql.Append("Fei_XMMCYForY=@Fei_XMMCYForY,");
			strSql.Append("Xin_SZXQQLongQi=@Xin_SZXQQLongQi,");
			strSql.Append("Xin_SZXJBDWeiZhi=@Xin_SZXJBDWeiZhi,");
			strSql.Append("Xin_SZXJBOWZForYW=@Xin_SZXJBOWZForYW,");
			strSql.Append("Xin_SZXJBoDong=@Xin_SZXJBoDong,");
			strSql.Append("Xin_SZXQQYCBoDong=@Xin_SZXQQYCBoDong,");
			strSql.Append("Xin_SZXQQYCBDForY=@Xin_SZXQQYCBDForY,");
			strSql.Append("Xin_CZXJBoDong=@Xin_CZXJBoDong,");
			strSql.Append("Xin_CZZhenChan=@Xin_CZZhenChan,");
			strSql.Append("Xin_ZCForY=@Xin_ZCForY,");
			strSql.Append("Xin_CZXBMCaGan=@Xin_CZXBMCaGan,");
			strSql.Append("Xin_KZXDZYinJie=@Xin_KZXDZYinJie,");
			strSql.Append("Xin_KZYEr=@Xin_KZYEr,");
			strSql.Append("Xin_KZZEr=@Xin_KZZEr,");
			strSql.Append("Xin_KZYSan=@Xin_KZYSan,");
			strSql.Append("Xin_KZZSan=@Xin_KZZSan,");
			strSql.Append("Xin_KZYSi=@Xin_KZYSi,");
			strSql.Append("Xin_KZZSi=@Xin_KZZSi,");
			strSql.Append("Xin_KZYWu=@Xin_KZYWu,");
			strSql.Append("Xin_KZZWu=@Xin_KZZWu,");
			strSql.Append("Xin_KZZXian=@Xin_KZZXian,");
			strSql.Append("Xin_TZXinLvC=@Xin_TZXinLvC,");
			strSql.Append("Xin_TZXinLv=@Xin_TZXinLv,");
			strSql.Append("Xin_TZXinYin=@Xin_TZXinYin,");
			strSql.Append("Xin_ZWXGWYCXGuanZheng=@Xin_ZWXGWYCXGuanZheng,");
			strSql.Append("Xin_ZWXGQJiYin=@Xin_ZWXGQJiYin,");
			strSql.Append("Xin_ZWXGDDSChongYin=@Xin_ZWXGDDSChongYin,");
			strSql.Append("Xin_ZWXGSChongMai=@Xin_ZWXGSChongMai,");
			strSql.Append("Xin_ZWXGMXXGBoDong=@Xin_ZWXGMXXGBoDong,");
			strSql.Append("Xin_ZWXGMBDuanChu=@Xin_ZWXGMBDuanChu,");
			strSql.Append("Xin_ZWXGQiMai=@Xin_ZWXGQiMai,");
			strSql.Append("Xin_ZWXGJTiMai=@Xin_ZWXGJTiMai,");
			strSql.Append("Xin_ZWXGQiTa=@Xin_ZWXGQiTa,");
			strSql.Append("FBu_ShiZhen=@FBu_ShiZhen,");
			strSql.Append("FBu_CZRouRuan=@FBu_CZRouRuan,");
			strSql.Append("FBu_CZFJJinZhang=@FBu_CZFJJinZhang,");
			strSql.Append("FBu_CZFJJZForYou=@FBu_CZFJJZForYou,");
			strSql.Append("FBu_CZYaTong=@FBu_CZYaTong,");
			strSql.Append("FBu_CZYTForYou=@FBu_CZYTForYou,");
			strSql.Append("FBu_CZFTiaoTong=@FBu_CZFTiaoTong,");
			strSql.Append("FBu_CZFTTForYou=@FBu_CZFTTForYou,");
			strSql.Append("FBu_CZYBZhenChan=@FBu_CZYBZhenChan,");
			strSql.Append("FBu_CZZShuiSheng=@FBu_CZZShuiSheng,");
			strSql.Append("FBu_CZFBBaoKuai=@FBu_CZFBBaoKuai,");
			strSql.Append("FBu_CZFBBKForYou=@FBu_CZFBBKForYou,");
			strSql.Append("FBu_CZFBBKTZMiaoShu=@FBu_CZFBBKTZMiaoShu,");
			strSql.Append("FBu_CZGan=@FBu_CZGan,");
			strSql.Append("FBu_CZDanNang=@FBu_CZDanNang,");
			strSql.Append("FBu_CZPi=@FBu_CZPi,");
			strSql.Append("FBu_CZShen=@FBu_CZShen,");
			strSql.Append("FBu_KZGZYinJie=@FBu_KZGZYinJie,");
			strSql.Append("FBu_KZSGZhongXian=@FBu_KZSGZhongXian,");
			strSql.Append("FBu_KZYDXZhuoYin=@FBu_KZYDXZhuoYin,");
			strSql.Append("FBu_KZSQKouTong=@FBu_KZSQKouTong,");
			strSql.Append("FBu_KZQiTa=@FBu_KZQiTa,");
			strSql.Append("FBu_TZCMinYin=@FBu_TZCMinYin,");
			strSql.Append("FBu_TZXGZaYin=@FBu_TZXGZaYin,");
			strSql.Append("FBu_TZXGZYForY=@FBu_TZXGZYForY,");
			strSql.Append("FBu_TZQGShuiSheng=@FBu_TZQGShuiSheng,");
			strSql.Append("GMZChang=@GMZChang,");
			strSql.Append("GMZChangForY=@GMZChangForY,");
			strSql.Append("SZQi=@SZQi,");
			strSql.Append("SZQiForY=@SZQiForY,");
			strSql.Append("GGJRou_JiZhu=@GGJRou_JiZhu,");
			strSql.Append("GGJRou_JZForJX=@GGJRou_JZForJX,");
			strSql.Append("GGJRou_QiTa=@GGJRou_QiTa,");
			strSql.Append("GGJRou_SiZhi=@GGJRou_SiZhi,");
			strSql.Append("SJXiTong=@SJXiTong,");
			strSql.Append("ZKQingKuang=@ZKQingKuang,");
			strSql.Append("SYSJQXJianCha=@SYSJQXJianCha,");
			strSql.Append("BLZhaiYao=@BLZhaiYao,");
			strSql.Append("CBZhenDuan=@CBZhenDuan,");
			strSql.Append("RYZhenDuan=@RYZhenDuan,");
			strSql.Append("XZZhenDuan=@XZZhenDuan,");
			strSql.Append("Reviewer=@Reviewer,");
			strSql.Append("ReviewerDate=@ReviewerDate");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@StudentsRealName", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentsName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@DeptCode", SqlDbType.NVarChar,50),
					new SqlParameter("@DeptName", SqlDbType.NVarChar,500),
					new SqlParameter("@RegisterDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Writor", SqlDbType.NVarChar,50),
					new SqlParameter("@TeacherId", SqlDbType.NVarChar,50),
					new SqlParameter("@TeacherName", SqlDbType.NVarChar,50),
					new SqlParameter("@PatientNo", SqlDbType.NVarChar,50),
					new SqlParameter("@InhospitalNo", SqlDbType.NVarChar,50),
					new SqlParameter("@PatientName", SqlDbType.NVarChar,50),
					new SqlParameter("@sex", SqlDbType.NVarChar,50),
					new SqlParameter("@Age", SqlDbType.NVarChar,50),
					new SqlParameter("@Job", SqlDbType.NVarChar,500),
					new SqlParameter("@Nation", SqlDbType.NVarChar,50),
					new SqlParameter("@Marriage", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthProvinceCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthProvinceName", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthCityCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthCityName", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthAreaCode", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthDetailAddress", SqlDbType.NVarChar,500),
					new SqlParameter("@Company", SqlDbType.NVarChar,50),
					new SqlParameter("@NowProvinceCode", SqlDbType.NVarChar,50),
					new SqlParameter("@NowProvinceName", SqlDbType.NVarChar,50),
					new SqlParameter("@NowCityCode", SqlDbType.NVarChar,50),
					new SqlParameter("@NowCityName", SqlDbType.NVarChar,50),
					new SqlParameter("@NowAreaCode", SqlDbType.NVarChar,50),
					new SqlParameter("@NowAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@NowDetailAddress", SqlDbType.NVarChar,500),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@InhospitalDate", SqlDbType.NVarChar,50),
					new SqlParameter("@RecordDate", SqlDbType.NVarChar,50),
					new SqlParameter("@MedicalHistorySpeaker", SqlDbType.NVarChar,50),
					new SqlParameter("@ReliableDegree", SqlDbType.NVarChar,50),
					new SqlParameter("@ZSu", SqlDbType.NVarChar,2000),
					new SqlParameter("@XBShi", SqlDbType.NVarChar,2000),
					new SqlParameter("@JWShi_PSJKZhuangKuang", SqlDbType.NVarChar,50),
					new SqlParameter("@JWShi_CHJBHCRBingShi", SqlDbType.NVarChar,1000),
					new SqlParameter("@JWShi_YFJZhongShi", SqlDbType.NVarChar,1000),
					new SqlParameter("@JWShi_GMinShi", SqlDbType.NVarChar,50),
					new SqlParameter("@JWShi_GMinYuan", SqlDbType.NVarChar,500),
					new SqlParameter("@JWShi_LCBiaoXian", SqlDbType.NVarChar,1000),
					new SqlParameter("@JWShi_WShangShi", SqlDbType.NVarChar,1000),
					new SqlParameter("@JWShi_SShuShi", SqlDbType.NVarChar,1000),
					new SqlParameter("@XTHGu_KeSou", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_KeTan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_KaXie", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_ChuanXi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XiongTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_HXKunNan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XinJi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_HDHQiCu", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XZShuiZhong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XQQuTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XYZengGao", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YunJue", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_SYJianTui", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_FanSuan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_AiQi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_EXin", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_OuTu", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_FuZhang", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_FuTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_BianMi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_FuXie", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_OuXue", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_HeiBian", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_BianXue", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_HuangDan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YaoTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_NiaoPin", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_NiaoJi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_NiaoTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_PNKunNan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XueNiao", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_NLYiChang", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YNZengDuo", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_ShuiZhong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YBSaoYang", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YBKuiLan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_FaLi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_TouYun", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YanHua", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YYChuXue", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_BChuXue", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_PXChuXue", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_GuTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_SYKangJin", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_PaRe", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_DuoHan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_WeiHan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_DuoYin", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_DuoNiao", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_SSZhenChan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XGGaiBian", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XZFeiPang", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_MXXiaoShou", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_MFZengDuov", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_MFTuoLuo", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_SSChenZhuo", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XGNGaiBian", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_BiJing", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_GJieTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_GJHongZhong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_GJBianXing", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_JRouTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_JRWeiSuo", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_TouTong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_XuanYun", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YunJue1", SqlDbType.NVarChar,50),
					new SqlParameter("@JXTHGu_JYLJianTui", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_SLZhangAi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_ShiMian", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_YSZhangAi", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_ChanDong", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_ChouChu", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_TanHuan", SqlDbType.NVarChar,50),
					new SqlParameter("@XTHGu_GJYiChang", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_BirthProvinceCode", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_BirthProvinceName", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_BirthCityCode", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_BirthCityName", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_BirthAreaCode", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_BirthAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_BirthDetailAddress", SqlDbType.NVarChar,500),
					new SqlParameter("@GRShi_CSHZGongZuo", SqlDbType.NVarChar,500),
					new SqlParameter("@GRShi_DFBDQJZQingKuang", SqlDbType.NVarChar,1000),
					new SqlParameter("@GRShi_YYouShi", SqlDbType.NVarChar,1000),
					new SqlParameter("@GRShi_ShiYan", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_SYanNian", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_SYanZhi", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_JieYan", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_JYanNian", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_ShiJiu", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_SJiuNian", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_SJiuLiang", SqlDbType.NVarChar,50),
					new SqlParameter("@GRShi_SJQiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@HYShi_JHNianLing", SqlDbType.NVarChar,50),
					new SqlParameter("@HYShi_POQingKuang", SqlDbType.NVarChar,500),
					new SqlParameter("@YJSHSYShi_CChaoSui", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_CChaoTian", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_MCYJRiQi", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_JJNianLing", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_ZhouQi", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_JingLiang", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_TongJing", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_JingQi", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_RenShen", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_ShunChan", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_LiuChan", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_ZaoChan", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_SiChan", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_NCJBingQing", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_Zi", SqlDbType.NVarChar,50),
					new SqlParameter("@YJSHSYShi_Nv", SqlDbType.NVarChar,50),
					new SqlParameter("@JZShi_Fu", SqlDbType.NVarChar,50),
					new SqlParameter("@JZShi_FSiYin", SqlDbType.NVarChar,500),
					new SqlParameter("@JZShi_Mu", SqlDbType.NVarChar,50),
					new SqlParameter("@JZShi_MSiYin", SqlDbType.NVarChar,500),
					new SqlParameter("@JZShi_XDJieMei", SqlDbType.NVarChar,500),
					new SqlParameter("@JZShi_ZNJQiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@SMTZheng_TiWen", SqlDbType.NVarChar,50),
					new SqlParameter("@SMTZheng_MaiBo", SqlDbType.NVarChar,50),
					new SqlParameter("@SMTZheng_HuXi", SqlDbType.NVarChar,50),
					new SqlParameter("@SMTZheng_XueYa1", SqlDbType.NVarChar,50),
					new SqlParameter("@SMTZheng_XueYa2", SqlDbType.NVarChar,50),
					new SqlParameter("@SMTZheng_TiZhong", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_FaYu", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_YingYang", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_MianRong", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_QiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@YBZKuang_BiaoQing", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_TiWei", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_TWForQP", SqlDbType.NVarChar,500),
					new SqlParameter("@YBZKuang_BuTai", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_BTForBZC", SqlDbType.NVarChar,500),
					new SqlParameter("@YBZKuang_ShenZhi", SqlDbType.NVarChar,50),
					new SqlParameter("@YBZKuang_PHJianCha", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_SeZe", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_PiZhen", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_PZLXJFenBu", SqlDbType.NVarChar,500),
					new SqlParameter("@PFNMo_PXChuXue", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_PXCXLXJFenBu", SqlDbType.NVarChar,500),
					new SqlParameter("@PFNMo_MFFenBu", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_MFFBBuWei", SqlDbType.NVarChar,500),
					new SqlParameter("@PFNMo_WDYShiDu", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_TanXing", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_GanZhang", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_ShuiZhong", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_BWJChengDu", SqlDbType.NVarChar,500),
					new SqlParameter("@PFNMo_ZZhuZhi", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_ZZZBuWei", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_ZZZShuMu", SqlDbType.NVarChar,50),
					new SqlParameter("@PFNMo_QiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@LBJie_QSQBLBaJie", SqlDbType.NVarChar,50),
					new SqlParameter("@LBJie_QSQBLBJBWJTeZheng", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_TLDaXiao", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLJiXing", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLJXForYou", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLQTYCYaTong", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLQTYCBaoKuai", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLQTYCAoXian", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLQTYCBuWei", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_YMMXiShu", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YMMTuoLuo", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YDaoJie", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YYanJian", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YJieMo", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YJiaoMo", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YJiaoMForYiChang", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YGongMo", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YYanQiu", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YYQForAll", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YTongKong", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TKForBuDengZ", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TKForBuDengY", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YTKDGFanShe", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YTKDGFSForAll", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_YTKJShiLi", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TKJSLForAllZ", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TKJSLForAllY", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TKJSLQiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_EErKuo", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_EEKQiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_EErKForAll", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_EWEDFMiWu", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_EWEDFMWForY", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_EWEDFMWXingZhi", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_ERTYaTong", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_ERTYTForY", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLCSZhangAi", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_TLCSZAForY", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BWaiXing", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_BBDYaTong", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BForBDYT", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_BQTYCBYShanDong", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BQTYCFMiWu", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BQTYCChuXue", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BQTYCZuSe", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BQTYCBZGPianQu", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_BQTYCBZGChuanKong", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_KQKouChun", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_KQNianMo", SqlDbType.NVarChar,50),
					new SqlParameter("@TBu_KQNMForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQSXDGKaiKou", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQSXDGKKForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQShe", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQSForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQChiYin", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQChiLie", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQBTaoTi", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQBTTForZD", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQYan", SqlDbType.NVarChar,500),
					new SqlParameter("@TBu_KQShengYin", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_DKangGan", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_QiGuan", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_QGForPY", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JJingMai", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JDMBoDoong", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JDMBDForAll", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_GJJMHLiuZheng", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZhuangXian", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZXForZDZ", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZXForZDY", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZXZhiRuan", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZXZhiYing", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZXYaTong", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZXZhenChan", SqlDbType.NVarChar,500),
					new SqlParameter("@JBu_JZXXGZaYin", SqlDbType.NVarChar,500),
					new SqlParameter("@XBu_XiongKuo", SqlDbType.NVarChar,500),
					new SqlParameter("@XBu_RuFang", SqlDbType.NVarChar,500),
					new SqlParameter("@XBu_RFForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_SZHXYunDong", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_SZHXYDForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_SZLJianXi", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_SZLJXBWForAll", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_CZYuChan", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_CZYCForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_CZXMMCaGan", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_CZXMMCGForY", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_CZPXNFaGan", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_CZPXNFGForY", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_KouZhen", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_KZForAll", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJJJiaXianY", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJJJiaXianZ", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJSGZhongXianY", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJSGZhongXianZ", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJYZhongXianY", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJYZhongXianZ", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJYDongDuY", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_FXJYDongDuZ", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZHuXi", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZHXiYin", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZHXYForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZLuoYing", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZLYForY", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZYYChuanDao", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZYYCDForYC", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_TZXMMCaYin", SqlDbType.NVarChar,500),
					new SqlParameter("@Fei_XMMCYForY", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_SZXQQLongQi", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_SZXJBDWeiZhi", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_SZXJBOWZForYW", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_SZXJBoDong", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_SZXQQYCBoDong", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_SZXQQYCBDForY", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_CZXJBoDong", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_CZZhenChan", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZCForY", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_CZXBMCaGan", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZXDZYinJie", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZYEr", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZZEr", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZYSan", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZZSan", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZYSi", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZZSi", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZYWu", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZZWu", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_KZZXian", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_TZXinLvC", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_TZXinLv", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_TZXinYin", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGWYCXGuanZheng", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGQJiYin", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGDDSChongYin", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGSChongMai", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGMXXGBoDong", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGMBDuanChu", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGQiMai", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGJTiMai", SqlDbType.NVarChar,500),
					new SqlParameter("@Xin_ZWXGQiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_ShiZhen", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZRouRuan", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZFJJinZhang", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZFJJZForYou", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZYaTong", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZYTForYou", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZFTiaoTong", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZFTTForYou", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZYBZhenChan", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZZShuiSheng", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZFBBaoKuai", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZFBBKForYou", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZFBBKTZMiaoShu", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZGan", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZDanNang", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZPi", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_CZShen", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_KZGZYinJie", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_KZSGZhongXian", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_KZYDXZhuoYin", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_KZSQKouTong", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_KZQiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_TZCMinYin", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_TZXGZaYin", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_TZXGZYForY", SqlDbType.NVarChar,500),
					new SqlParameter("@FBu_TZQGShuiSheng", SqlDbType.NVarChar,500),
					new SqlParameter("@GMZChang", SqlDbType.NVarChar,500),
					new SqlParameter("@GMZChangForY", SqlDbType.NVarChar,500),
					new SqlParameter("@SZQi", SqlDbType.NVarChar,500),
					new SqlParameter("@SZQiForY", SqlDbType.NVarChar,500),
					new SqlParameter("@GGJRou_JiZhu", SqlDbType.NVarChar,500),
					new SqlParameter("@GGJRou_JZForJX", SqlDbType.NVarChar,500),
					new SqlParameter("@GGJRou_QiTa", SqlDbType.NVarChar,500),
					new SqlParameter("@GGJRou_SiZhi", SqlDbType.NVarChar,500),
					new SqlParameter("@SJXiTong", SqlDbType.NVarChar,1000),
					new SqlParameter("@ZKQingKuang", SqlDbType.NVarChar,1000),
					new SqlParameter("@SYSJQXJianCha", SqlDbType.NVarChar,1000),
					new SqlParameter("@BLZhaiYao", SqlDbType.NVarChar,1000),
					new SqlParameter("@CBZhenDuan", SqlDbType.NVarChar,1000),
					new SqlParameter("@RYZhenDuan", SqlDbType.NVarChar,1000),
					new SqlParameter("@XZZhenDuan", SqlDbType.NVarChar,1000),
					new SqlParameter("@Reviewer", SqlDbType.NVarChar,50),
					new SqlParameter("@ReviewerDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.StudentsRealName;
			parameters[1].Value = model.StudentsName;
			parameters[2].Value = model.TrainingBaseCode;
			parameters[3].Value = model.TrainingBaseName;
			parameters[4].Value = model.ProfessionalBaseCode;
			parameters[5].Value = model.ProfessionalBaseName;
			parameters[6].Value = model.DeptCode;
			parameters[7].Value = model.DeptName;
			parameters[8].Value = model.RegisterDate;
			parameters[9].Value = model.Writor;
			parameters[10].Value = model.TeacherId;
			parameters[11].Value = model.TeacherName;
			parameters[12].Value = model.PatientNo;
			parameters[13].Value = model.InhospitalNo;
			parameters[14].Value = model.PatientName;
			parameters[15].Value = model.sex;
			parameters[16].Value = model.Age;
			parameters[17].Value = model.Job;
			parameters[18].Value = model.Nation;
			parameters[19].Value = model.Marriage;
			parameters[20].Value = model.BirthProvinceCode;
			parameters[21].Value = model.BirthProvinceName;
			parameters[22].Value = model.BirthCityCode;
			parameters[23].Value = model.BirthCityName;
			parameters[24].Value = model.BirthAreaCode;
			parameters[25].Value = model.BirthAreaName;
			parameters[26].Value = model.BirthDetailAddress;
			parameters[27].Value = model.Company;
			parameters[28].Value = model.NowProvinceCode;
			parameters[29].Value = model.NowProvinceName;
			parameters[30].Value = model.NowCityCode;
			parameters[31].Value = model.NowCityName;
			parameters[32].Value = model.NowAreaCode;
			parameters[33].Value = model.NowAreaName;
			parameters[34].Value = model.NowDetailAddress;
			parameters[35].Value = model.Phone;
			parameters[36].Value = model.InhospitalDate;
			parameters[37].Value = model.RecordDate;
			parameters[38].Value = model.MedicalHistorySpeaker;
			parameters[39].Value = model.ReliableDegree;
			parameters[40].Value = model.ZSu;
			parameters[41].Value = model.XBShi;
			parameters[42].Value = model.JWShi_PSJKZhuangKuang;
			parameters[43].Value = model.JWShi_CHJBHCRBingShi;
			parameters[44].Value = model.JWShi_YFJZhongShi;
			parameters[45].Value = model.JWShi_GMinShi;
			parameters[46].Value = model.JWShi_GMinYuan;
			parameters[47].Value = model.JWShi_LCBiaoXian;
			parameters[48].Value = model.JWShi_WShangShi;
			parameters[49].Value = model.JWShi_SShuShi;
			parameters[50].Value = model.XTHGu_KeSou;
			parameters[51].Value = model.XTHGu_KeTan;
			parameters[52].Value = model.XTHGu_KaXie;
			parameters[53].Value = model.XTHGu_ChuanXi;
			parameters[54].Value = model.XTHGu_XiongTong;
			parameters[55].Value = model.XTHGu_HXKunNan;
			parameters[56].Value = model.XTHGu_XinJi;
			parameters[57].Value = model.XTHGu_HDHQiCu;
			parameters[58].Value = model.XTHGu_XZShuiZhong;
			parameters[59].Value = model.XTHGu_XQQuTong;
			parameters[60].Value = model.XTHGu_XYZengGao;
			parameters[61].Value = model.XTHGu_YunJue;
			parameters[62].Value = model.XTHGu_SYJianTui;
			parameters[63].Value = model.XTHGu_FanSuan;
			parameters[64].Value = model.XTHGu_AiQi;
			parameters[65].Value = model.XTHGu_EXin;
			parameters[66].Value = model.XTHGu_OuTu;
			parameters[67].Value = model.XTHGu_FuZhang;
			parameters[68].Value = model.XTHGu_FuTong;
			parameters[69].Value = model.XTHGu_BianMi;
			parameters[70].Value = model.XTHGu_FuXie;
			parameters[71].Value = model.XTHGu_OuXue;
			parameters[72].Value = model.XTHGu_HeiBian;
			parameters[73].Value = model.XTHGu_BianXue;
			parameters[74].Value = model.XTHGu_HuangDan;
			parameters[75].Value = model.XTHGu_YaoTong;
			parameters[76].Value = model.XTHGu_NiaoPin;
			parameters[77].Value = model.XTHGu_NiaoJi;
			parameters[78].Value = model.XTHGu_NiaoTong;
			parameters[79].Value = model.XTHGu_PNKunNan;
			parameters[80].Value = model.XTHGu_XueNiao;
			parameters[81].Value = model.XTHGu_NLYiChang;
			parameters[82].Value = model.XTHGu_YNZengDuo;
			parameters[83].Value = model.XTHGu_ShuiZhong;
			parameters[84].Value = model.XTHGu_YBSaoYang;
			parameters[85].Value = model.XTHGu_YBKuiLan;
			parameters[86].Value = model.XTHGu_FaLi;
			parameters[87].Value = model.XTHGu_TouYun;
			parameters[88].Value = model.XTHGu_YanHua;
			parameters[89].Value = model.XTHGu_YYChuXue;
			parameters[90].Value = model.XTHGu_BChuXue;
			parameters[91].Value = model.XTHGu_PXChuXue;
			parameters[92].Value = model.XTHGu_GuTong;
			parameters[93].Value = model.XTHGu_SYKangJin;
			parameters[94].Value = model.XTHGu_PaRe;
			parameters[95].Value = model.XTHGu_DuoHan;
			parameters[96].Value = model.XTHGu_WeiHan;
			parameters[97].Value = model.XTHGu_DuoYin;
			parameters[98].Value = model.XTHGu_DuoNiao;
			parameters[99].Value = model.XTHGu_SSZhenChan;
			parameters[100].Value = model.XTHGu_XGGaiBian;
			parameters[101].Value = model.XTHGu_XZFeiPang;
			parameters[102].Value = model.XTHGu_MXXiaoShou;
			parameters[103].Value = model.XTHGu_MFZengDuov;
			parameters[104].Value = model.XTHGu_MFTuoLuo;
			parameters[105].Value = model.XTHGu_SSChenZhuo;
			parameters[106].Value = model.XTHGu_XGNGaiBian;
			parameters[107].Value = model.XTHGu_BiJing;
			parameters[108].Value = model.XTHGu_GJieTong;
			parameters[109].Value = model.XTHGu_GJHongZhong;
			parameters[110].Value = model.XTHGu_GJBianXing;
			parameters[111].Value = model.XTHGu_JRouTong;
			parameters[112].Value = model.XTHGu_JRWeiSuo;
			parameters[113].Value = model.XTHGu_TouTong;
			parameters[114].Value = model.XTHGu_XuanYun;
			parameters[115].Value = model.XTHGu_YunJue1;
			parameters[116].Value = model.JXTHGu_JYLJianTui;
			parameters[117].Value = model.XTHGu_SLZhangAi;
			parameters[118].Value = model.XTHGu_ShiMian;
			parameters[119].Value = model.XTHGu_YSZhangAi;
			parameters[120].Value = model.XTHGu_ChanDong;
			parameters[121].Value = model.XTHGu_ChouChu;
			parameters[122].Value = model.XTHGu_TanHuan;
			parameters[123].Value = model.XTHGu_GJYiChang;
			parameters[124].Value = model.GRShi_BirthProvinceCode;
			parameters[125].Value = model.GRShi_BirthProvinceName;
			parameters[126].Value = model.GRShi_BirthCityCode;
			parameters[127].Value = model.GRShi_BirthCityName;
			parameters[128].Value = model.GRShi_BirthAreaCode;
			parameters[129].Value = model.GRShi_BirthAreaName;
			parameters[130].Value = model.GRShi_BirthDetailAddress;
			parameters[131].Value = model.GRShi_CSHZGongZuo;
			parameters[132].Value = model.GRShi_DFBDQJZQingKuang;
			parameters[133].Value = model.GRShi_YYouShi;
			parameters[134].Value = model.GRShi_ShiYan;
			parameters[135].Value = model.GRShi_SYanNian;
			parameters[136].Value = model.GRShi_SYanZhi;
			parameters[137].Value = model.GRShi_JieYan;
			parameters[138].Value = model.GRShi_JYanNian;
			parameters[139].Value = model.GRShi_ShiJiu;
			parameters[140].Value = model.GRShi_SJiuNian;
			parameters[141].Value = model.GRShi_SJiuLiang;
			parameters[142].Value = model.GRShi_SJQiTa;
			parameters[143].Value = model.HYShi_JHNianLing;
			parameters[144].Value = model.HYShi_POQingKuang;
			parameters[145].Value = model.YJSHSYShi_CChaoSui;
			parameters[146].Value = model.YJSHSYShi_CChaoTian;
			parameters[147].Value = model.YJSHSYShi_MCYJRiQi;
			parameters[148].Value = model.YJSHSYShi_JJNianLing;
			parameters[149].Value = model.YJSHSYShi_ZhouQi;
			parameters[150].Value = model.YJSHSYShi_JingLiang;
			parameters[151].Value = model.YJSHSYShi_TongJing;
			parameters[152].Value = model.YJSHSYShi_JingQi;
			parameters[153].Value = model.YJSHSYShi_RenShen;
			parameters[154].Value = model.YJSHSYShi_ShunChan;
			parameters[155].Value = model.YJSHSYShi_LiuChan;
			parameters[156].Value = model.YJSHSYShi_ZaoChan;
			parameters[157].Value = model.YJSHSYShi_SiChan;
			parameters[158].Value = model.YJSHSYShi_NCJBingQing;
			parameters[159].Value = model.YJSHSYShi_Zi;
			parameters[160].Value = model.YJSHSYShi_Nv;
			parameters[161].Value = model.JZShi_Fu;
			parameters[162].Value = model.JZShi_FSiYin;
			parameters[163].Value = model.JZShi_Mu;
			parameters[164].Value = model.JZShi_MSiYin;
			parameters[165].Value = model.JZShi_XDJieMei;
			parameters[166].Value = model.JZShi_ZNJQiTa;
			parameters[167].Value = model.SMTZheng_TiWen;
			parameters[168].Value = model.SMTZheng_MaiBo;
			parameters[169].Value = model.SMTZheng_HuXi;
			parameters[170].Value = model.SMTZheng_XueYa1;
			parameters[171].Value = model.SMTZheng_XueYa2;
			parameters[172].Value = model.SMTZheng_TiZhong;
			parameters[173].Value = model.YBZKuang_FaYu;
			parameters[174].Value = model.YBZKuang_YingYang;
			parameters[175].Value = model.YBZKuang_MianRong;
			parameters[176].Value = model.YBZKuang_QiTa;
			parameters[177].Value = model.YBZKuang_BiaoQing;
			parameters[178].Value = model.YBZKuang_TiWei;
			parameters[179].Value = model.YBZKuang_TWForQP;
			parameters[180].Value = model.YBZKuang_BuTai;
			parameters[181].Value = model.YBZKuang_BTForBZC;
			parameters[182].Value = model.YBZKuang_ShenZhi;
			parameters[183].Value = model.YBZKuang_PHJianCha;
			parameters[184].Value = model.PFNMo_SeZe;
			parameters[185].Value = model.PFNMo_PiZhen;
			parameters[186].Value = model.PFNMo_PZLXJFenBu;
			parameters[187].Value = model.PFNMo_PXChuXue;
			parameters[188].Value = model.PFNMo_PXCXLXJFenBu;
			parameters[189].Value = model.PFNMo_MFFenBu;
			parameters[190].Value = model.PFNMo_MFFBBuWei;
			parameters[191].Value = model.PFNMo_WDYShiDu;
			parameters[192].Value = model.PFNMo_TanXing;
			parameters[193].Value = model.PFNMo_GanZhang;
			parameters[194].Value = model.PFNMo_ShuiZhong;
			parameters[195].Value = model.PFNMo_BWJChengDu;
			parameters[196].Value = model.PFNMo_ZZhuZhi;
			parameters[197].Value = model.PFNMo_ZZZBuWei;
			parameters[198].Value = model.PFNMo_ZZZShuMu;
			parameters[199].Value = model.PFNMo_QiTa;
			parameters[200].Value = model.LBJie_QSQBLBaJie;
			parameters[201].Value = model.LBJie_QSQBLBJBWJTeZheng;
			parameters[202].Value = model.TBu_TLDaXiao;
			parameters[203].Value = model.TBu_TLJiXing;
			parameters[204].Value = model.TBu_TLJXForYou;
			parameters[205].Value = model.TBu_TLQTYCYaTong;
			parameters[206].Value = model.TBu_TLQTYCBaoKuai;
			parameters[207].Value = model.TBu_TLQTYCAoXian;
			parameters[208].Value = model.TBu_TLQTYCBuWei;
			parameters[209].Value = model.TBu_YMMXiShu;
			parameters[210].Value = model.TBu_YMMTuoLuo;
			parameters[211].Value = model.TBu_YDaoJie;
			parameters[212].Value = model.TBu_YYanJian;
			parameters[213].Value = model.TBu_YJieMo;
			parameters[214].Value = model.TBu_YJiaoMo;
			parameters[215].Value = model.TBu_YJiaoMForYiChang;
			parameters[216].Value = model.TBu_YGongMo;
			parameters[217].Value = model.TBu_YYanQiu;
			parameters[218].Value = model.TBu_YYQForAll;
			parameters[219].Value = model.TBu_YTongKong;
			parameters[220].Value = model.TBu_TKForBuDengZ;
			parameters[221].Value = model.TBu_TKForBuDengY;
			parameters[222].Value = model.TBu_YTKDGFanShe;
			parameters[223].Value = model.TBu_YTKDGFSForAll;
			parameters[224].Value = model.TBu_YTKJShiLi;
			parameters[225].Value = model.TBu_TKJSLForAllZ;
			parameters[226].Value = model.TBu_TKJSLForAllY;
			parameters[227].Value = model.TBu_TKJSLQiTa;
			parameters[228].Value = model.TBu_EErKuo;
			parameters[229].Value = model.TBu_EEKQiTa;
			parameters[230].Value = model.TBu_EErKForAll;
			parameters[231].Value = model.TBu_EWEDFMiWu;
			parameters[232].Value = model.TBu_EWEDFMWForY;
			parameters[233].Value = model.TBu_EWEDFMWXingZhi;
			parameters[234].Value = model.TBu_ERTYaTong;
			parameters[235].Value = model.TBu_ERTYTForY;
			parameters[236].Value = model.TBu_TLCSZhangAi;
			parameters[237].Value = model.TBu_TLCSZAForY;
			parameters[238].Value = model.TBu_BWaiXing;
			parameters[239].Value = model.TBu_BForYC;
			parameters[240].Value = model.TBu_BBDYaTong;
			parameters[241].Value = model.TBu_BForBDYT;
			parameters[242].Value = model.TBu_BQTYCBYShanDong;
			parameters[243].Value = model.TBu_BQTYCFMiWu;
			parameters[244].Value = model.TBu_BQTYCChuXue;
			parameters[245].Value = model.TBu_BQTYCZuSe;
			parameters[246].Value = model.TBu_BQTYCBZGPianQu;
			parameters[247].Value = model.TBu_BQTYCBZGChuanKong;
			parameters[248].Value = model.TBu_KQKouChun;
			parameters[249].Value = model.TBu_KQNianMo;
			parameters[250].Value = model.TBu_KQNMForYC;
			parameters[251].Value = model.TBu_KQSXDGKaiKou;
			parameters[252].Value = model.TBu_KQSXDGKKForYC;
			parameters[253].Value = model.TBu_KQShe;
			parameters[254].Value = model.TBu_KQSForYC;
			parameters[255].Value = model.TBu_KQChiYin;
			parameters[256].Value = model.TBu_KQChiLie;
			parameters[257].Value = model.TBu_KQBTaoTi;
			parameters[258].Value = model.TBu_KQBTTForZD;
			parameters[259].Value = model.TBu_KQYan;
			parameters[260].Value = model.TBu_KQShengYin;
			parameters[261].Value = model.JBu_DKangGan;
			parameters[262].Value = model.JBu_QiGuan;
			parameters[263].Value = model.JBu_QGForPY;
			parameters[264].Value = model.JBu_JJingMai;
			parameters[265].Value = model.JBu_JDMBoDoong;
			parameters[266].Value = model.JBu_JDMBDForAll;
			parameters[267].Value = model.JBu_GJJMHLiuZheng;
			parameters[268].Value = model.JBu_JZhuangXian;
			parameters[269].Value = model.JBu_JZXForZDZ;
			parameters[270].Value = model.JBu_JZXForZDY;
			parameters[271].Value = model.JBu_JZXZhiRuan;
			parameters[272].Value = model.JBu_JZXZhiYing;
			parameters[273].Value = model.JBu_JZXYaTong;
			parameters[274].Value = model.JBu_JZXZhenChan;
			parameters[275].Value = model.JBu_JZXXGZaYin;
			parameters[276].Value = model.XBu_XiongKuo;
			parameters[277].Value = model.XBu_RuFang;
			parameters[278].Value = model.XBu_RFForYC;
			parameters[279].Value = model.Fei_SZHXYunDong;
			parameters[280].Value = model.Fei_SZHXYDForYC;
			parameters[281].Value = model.Fei_SZLJianXi;
			parameters[282].Value = model.Fei_SZLJXBWForAll;
			parameters[283].Value = model.Fei_CZYuChan;
			parameters[284].Value = model.Fei_CZYCForYC;
			parameters[285].Value = model.Fei_CZXMMCaGan;
			parameters[286].Value = model.Fei_CZXMMCGForY;
			parameters[287].Value = model.Fei_CZPXNFaGan;
			parameters[288].Value = model.Fei_CZPXNFGForY;
			parameters[289].Value = model.Fei_KouZhen;
			parameters[290].Value = model.Fei_KZForAll;
			parameters[291].Value = model.Fei_FXJJJiaXianY;
			parameters[292].Value = model.Fei_FXJJJiaXianZ;
			parameters[293].Value = model.Fei_FXJSGZhongXianY;
			parameters[294].Value = model.Fei_FXJSGZhongXianZ;
			parameters[295].Value = model.Fei_FXJYZhongXianY;
			parameters[296].Value = model.Fei_FXJYZhongXianZ;
			parameters[297].Value = model.Fei_FXJYDongDuY;
			parameters[298].Value = model.Fei_FXJYDongDuZ;
			parameters[299].Value = model.Fei_TZHuXi;
			parameters[300].Value = model.Fei_TZHXiYin;
			parameters[301].Value = model.Fei_TZHXYForYC;
			parameters[302].Value = model.Fei_TZLuoYing;
			parameters[303].Value = model.Fei_TZLYForY;
			parameters[304].Value = model.Fei_TZYYChuanDao;
			parameters[305].Value = model.Fei_TZYYCDForYC;
			parameters[306].Value = model.Fei_TZXMMCaYin;
			parameters[307].Value = model.Fei_XMMCYForY;
			parameters[308].Value = model.Xin_SZXQQLongQi;
			parameters[309].Value = model.Xin_SZXJBDWeiZhi;
			parameters[310].Value = model.Xin_SZXJBOWZForYW;
			parameters[311].Value = model.Xin_SZXJBoDong;
			parameters[312].Value = model.Xin_SZXQQYCBoDong;
			parameters[313].Value = model.Xin_SZXQQYCBDForY;
			parameters[314].Value = model.Xin_CZXJBoDong;
			parameters[315].Value = model.Xin_CZZhenChan;
			parameters[316].Value = model.Xin_ZCForY;
			parameters[317].Value = model.Xin_CZXBMCaGan;
			parameters[318].Value = model.Xin_KZXDZYinJie;
			parameters[319].Value = model.Xin_KZYEr;
			parameters[320].Value = model.Xin_KZZEr;
			parameters[321].Value = model.Xin_KZYSan;
			parameters[322].Value = model.Xin_KZZSan;
			parameters[323].Value = model.Xin_KZYSi;
			parameters[324].Value = model.Xin_KZZSi;
			parameters[325].Value = model.Xin_KZYWu;
			parameters[326].Value = model.Xin_KZZWu;
			parameters[327].Value = model.Xin_KZZXian;
			parameters[328].Value = model.Xin_TZXinLvC;
			parameters[329].Value = model.Xin_TZXinLv;
			parameters[330].Value = model.Xin_TZXinYin;
			parameters[331].Value = model.Xin_ZWXGWYCXGuanZheng;
			parameters[332].Value = model.Xin_ZWXGQJiYin;
			parameters[333].Value = model.Xin_ZWXGDDSChongYin;
			parameters[334].Value = model.Xin_ZWXGSChongMai;
			parameters[335].Value = model.Xin_ZWXGMXXGBoDong;
			parameters[336].Value = model.Xin_ZWXGMBDuanChu;
			parameters[337].Value = model.Xin_ZWXGQiMai;
			parameters[338].Value = model.Xin_ZWXGJTiMai;
			parameters[339].Value = model.Xin_ZWXGQiTa;
			parameters[340].Value = model.FBu_ShiZhen;
			parameters[341].Value = model.FBu_CZRouRuan;
			parameters[342].Value = model.FBu_CZFJJinZhang;
			parameters[343].Value = model.FBu_CZFJJZForYou;
			parameters[344].Value = model.FBu_CZYaTong;
			parameters[345].Value = model.FBu_CZYTForYou;
			parameters[346].Value = model.FBu_CZFTiaoTong;
			parameters[347].Value = model.FBu_CZFTTForYou;
			parameters[348].Value = model.FBu_CZYBZhenChan;
			parameters[349].Value = model.FBu_CZZShuiSheng;
			parameters[350].Value = model.FBu_CZFBBaoKuai;
			parameters[351].Value = model.FBu_CZFBBKForYou;
			parameters[352].Value = model.FBu_CZFBBKTZMiaoShu;
			parameters[353].Value = model.FBu_CZGan;
			parameters[354].Value = model.FBu_CZDanNang;
			parameters[355].Value = model.FBu_CZPi;
			parameters[356].Value = model.FBu_CZShen;
			parameters[357].Value = model.FBu_KZGZYinJie;
			parameters[358].Value = model.FBu_KZSGZhongXian;
			parameters[359].Value = model.FBu_KZYDXZhuoYin;
			parameters[360].Value = model.FBu_KZSQKouTong;
			parameters[361].Value = model.FBu_KZQiTa;
			parameters[362].Value = model.FBu_TZCMinYin;
			parameters[363].Value = model.FBu_TZXGZaYin;
			parameters[364].Value = model.FBu_TZXGZYForY;
			parameters[365].Value = model.FBu_TZQGShuiSheng;
			parameters[366].Value = model.GMZChang;
			parameters[367].Value = model.GMZChangForY;
			parameters[368].Value = model.SZQi;
			parameters[369].Value = model.SZQiForY;
			parameters[370].Value = model.GGJRou_JiZhu;
			parameters[371].Value = model.GGJRou_JZForJX;
			parameters[372].Value = model.GGJRou_QiTa;
			parameters[373].Value = model.GGJRou_SiZhi;
			parameters[374].Value = model.SJXiTong;
			parameters[375].Value = model.ZKQingKuang;
			parameters[376].Value = model.SYSJQXJianCha;
			parameters[377].Value = model.BLZhaiYao;
			parameters[378].Value = model.CBZhenDuan;
			parameters[379].Value = model.RYZhenDuan;
			parameters[380].Value = model.XZZhenDuan;
			parameters[381].Value = model.Reviewer;
			parameters[382].Value = model.ReviewerDate;
			parameters[383].Value = model.Id;

			int rows=db.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
       } 
       #endregion

       #region UpdateRecordsStatus(BigMedicalRecordsModel model)
       public bool UpdateRecordsStatus(BigMedicalRecordsModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_BigMedicalRecords set ");
           strSql.Append("RecordsStatus=@RecordsStatus");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@RecordsStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.RecordsStatus;
           parameters[1].Value = model.Id;

           int rows = db.ExecuteSql(strSql.ToString(), parameters);
           if (rows > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
       } 
       #endregion

       #region Common分页
       public List<Model.BigMedicalRecordsModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
           string PatientNo, string InhospitalNo,string PatientName,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_BigMedicalRecords where TrainingBaseCode like '%" + TrainingBaseCode + "%' and RecordsStatus='已提交'";

           if (!string.IsNullOrEmpty(StudentsRealName))
           {
               sql += "and StudentsRealName like '%" + StudentsRealName + "%'";
           }
           if (!string.IsNullOrEmpty(ProfessionalBaseCode))
           {
               sql += "and ProfessionalBaseCode like '%" + ProfessionalBaseCode + "%'";
           }
           if (!string.IsNullOrEmpty(DeptCode))
           {
               sql += "and DeptCode like '%" + DeptCode + "%'";
           }
           if (!string.IsNullOrEmpty(TeachersName))
           {
               sql += "and TeacherId like '%" + TeachersName + "%'";
           }
           if (!string.IsNullOrEmpty(ProfessionalBaseName))
           {
               sql += "and ProfessionalBaseName like '%" + ProfessionalBaseName + "%'";
           }
           if (!string.IsNullOrEmpty(DeptName))
           {
               sql += "and DeptName like '%" + DeptName + "%'";
           }
           if (!string.IsNullOrEmpty(TeachersRealName))
           {
               sql += "and TeacherName like '%" + TeachersRealName + "%'";
           }
           if (!string.IsNullOrEmpty(PatientNo))
           {
               sql += "and PatientNo like '%" + PatientNo + "%'";
           }
           if (!string.IsNullOrEmpty(InhospitalNo))
           {
               sql += "and InhospitalNo like '%" + InhospitalNo + "%'";
           }
           if (!string.IsNullOrEmpty(PatientName))
           {
               sql += "and PatientName like '%" + PatientName + "%'";
           }
           sql += ")as t where t.num>=@start and t.num<=@end";


           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<BigMedicalRecordsModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<BigMedicalRecordsModel>();
               BigMedicalRecordsModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new BigMedicalRecordsModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string  DeptName,string TeachersRealName,
           string PatientNo, string InhospitalNo, string PatientName)
       {
           string sql = "select count(*) from GP_BigMedicalRecords where TrainingBaseCode like '%" + TrainingBaseCode + "%' and RecordsStatus='已提交'";
           if (!string.IsNullOrEmpty(StudentsRealName))
           {
               sql += "and StudentsRealName like '%" + StudentsRealName + "%'";
           }
           if (!string.IsNullOrEmpty(ProfessionalBaseCode))
           {
               sql += "and ProfessionalBaseCode like '%" + ProfessionalBaseCode + "%'";
           }
           if (!string.IsNullOrEmpty(DeptCode))
           {
               sql += "and DeptCode like '%" + DeptCode + "%'";
           }
           if (!string.IsNullOrEmpty(TeachersName))
           {
               sql += "and TeacherId like '%" + TeachersName + "%'";
           }
           if (!string.IsNullOrEmpty(ProfessionalBaseName))
           {
               sql += "and ProfessionalBaseName like '%" + ProfessionalBaseName + "%'";
           }
           if (!string.IsNullOrEmpty(DeptName))
           {
               sql += "and DeptName like '%" + DeptName + "%'";
           }
           if (!string.IsNullOrEmpty(TeachersRealName))
           {
               sql += "and TeacherName like '%" + TeachersRealName + "%'";
           }
           if (!string.IsNullOrEmpty(PatientNo))
           {
               sql += "and PatientNo like '%" + PatientNo + "%'";
           }
           if (!string.IsNullOrEmpty(InhospitalNo))
           {
               sql += "and InhospitalNo like '%" + InhospitalNo + "%'";
           }
           if (!string.IsNullOrEmpty(PatientName))
           {
               sql += "and PatientName like '%" + PatientName + "%'";
           }

           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion

       #region UpdateCheckByTeacher(BigMedicalRecordsModel model)
       public bool UpdateCheckByTeacher(BigMedicalRecordsModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_BigMedicalRecords set ");
           strSql.Append("TeacherCheck=@TeacherCheck");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@TeacherCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.TeacherCheck;
           parameters[1].Value = model.Id;

           int rows = db.ExecuteSql(strSql.ToString(), parameters);
           if (rows > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
       } 
       #endregion

       #region UpdateRedirect(BigMedicalRecordsModel model)
       public bool UpdateRedirect(BigMedicalRecordsModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_BigMedicalRecords set ");
           strSql.Append("XZZhenDuan=@XZZhenDuan,");
           strSql.Append("Reviewer=@Reviewer,");
           strSql.Append("ReviewerDate=@ReviewerDate");
           strSql.Append(" where Id=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@XZZhenDuan", SqlDbType.NVarChar,1000),
					new SqlParameter("@Reviewer", SqlDbType.NVarChar,50),
					new SqlParameter("@ReviewerDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.XZZhenDuan;
           parameters[1].Value = model.Reviewer;
           parameters[2].Value = model.ReviewerDate;
           parameters[3].Value = model.Id;

           int rows = db.ExecuteSql(strSql.ToString(), parameters);
           if (rows > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
       } 
       #endregion
    }
}
