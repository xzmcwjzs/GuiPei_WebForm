using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public class BigMedicalRecordsModel
    {
       
        private string _id = "newid";
        private string _studentsrealname;
        private string _studentsname;
        private string _trainingbasecode;
        private string _trainingbasename;
        private string _professionalbasecode;
        private string _professionalbasename;
        private string _deptcode;
        private string _deptname;
        private string _registerdate;
        private string _writor;
        private string _teachercheck;
        private string _kzrcheck;
        private string _basecheck;
        private string _managercheck;
        private string _teacherid;
        private string _teachername;
        private string _patientno;
        private string _inhospitalno;
        private string _patientname;
        private string _sex;
        private string _age;
        private string _job;
        private string _nation;
        private string _marriage;
        private string _birthprovincecode;
        private string _birthprovincename;
        private string _birthcitycode;
        private string _birthcityname;
        private string _birthareacode;
        private string _birthareaname;
        private string _birthdetailaddress;
        private string _company;
        private string _nowprovincecode;
        private string _nowprovincename;
        private string _nowcitycode;
        private string _nowcityname;
        private string _nowareacode;
        private string _nowareaname;
        private string _nowdetailaddress;
        private string _phone;
        private string _inhospitaldate;
        private string _recorddate;
        private string _medicalhistoryspeaker;
        private string _reliabledegree;
        private string _zsu;
        private string _xbshi;
        private string _jwshi_psjkzhuangkuang;
        private string _jwshi_chjbhcrbingshi;
        private string _jwshi_yfjzhongshi;
        private string _jwshi_gminshi;
        private string _jwshi_gminyuan;
        private string _jwshi_lcbiaoxian;
        private string _jwshi_wshangshi;
        private string _jwshi_sshushi;
        private string _xthgu_kesou;
        private string _xthgu_ketan;
        private string _xthgu_kaxie;
        private string _xthgu_chuanxi;
        private string _xthgu_xiongtong;
        private string _xthgu_hxkunnan;
        private string _xthgu_xinji;
        private string _xthgu_hdhqicu;
        private string _xthgu_xzshuizhong;
        private string _xthgu_xqqutong;
        private string _xthgu_xyzenggao;
        private string _xthgu_yunjue;
        private string _xthgu_syjiantui;
        private string _xthgu_fansuan;
        private string _xthgu_aiqi;
        private string _xthgu_exin;
        private string _xthgu_outu;
        private string _xthgu_fuzhang;
        private string _xthgu_futong;
        private string _xthgu_bianmi;
        private string _xthgu_fuxie;
        private string _xthgu_ouxue;
        private string _xthgu_heibian;
        private string _xthgu_bianxue;
        private string _xthgu_huangdan;
        private string _xthgu_yaotong;
        private string _xthgu_niaopin;
        private string _xthgu_niaoji;
        private string _xthgu_niaotong;
        private string _xthgu_pnkunnan;
        private string _xthgu_xueniao;
        private string _xthgu_nlyichang;
        private string _xthgu_ynzengduo;
        private string _xthgu_shuizhong;
        private string _xthgu_ybsaoyang;
        private string _xthgu_ybkuilan;
        private string _xthgu_fali;
        private string _xthgu_touyun;
        private string _xthgu_yanhua;
        private string _xthgu_yychuxue;
        private string _xthgu_bchuxue;
        private string _xthgu_pxchuxue;
        private string _xthgu_gutong;
        private string _xthgu_sykangjin;
        private string _xthgu_pare;
        private string _xthgu_duohan;
        private string _xthgu_weihan;
        private string _xthgu_duoyin;
        private string _xthgu_duoniao;
        private string _xthgu_sszhenchan;
        private string _xthgu_xggaibian;
        private string _xthgu_xzfeipang;
        private string _xthgu_mxxiaoshou;
        private string _xthgu_mfzengduov;
        private string _xthgu_mftuoluo;
        private string _xthgu_sschenzhuo;
        private string _xthgu_xgngaibian;
        private string _xthgu_bijing;
        private string _xthgu_gjietong;
        private string _xthgu_gjhongzhong;
        private string _xthgu_gjbianxing;
        private string _xthgu_jroutong;
        private string _xthgu_jrweisuo;
        private string _xthgu_toutong;
        private string _xthgu_xuanyun;
        private string _xthgu_yunjue1;
        private string _jxthgu_jyljiantui;
        private string _xthgu_slzhangai;
        private string _xthgu_shimian;
        private string _xthgu_yszhangai;
        private string _xthgu_chandong;
        private string _xthgu_chouchu;
        private string _xthgu_tanhuan;
        private string _xthgu_gjyichang;
        private string _grshi_birthprovincecode;
        private string _grshi_birthprovincename;
        private string _grshi_birthcitycode;
        private string _grshi_birthcityname;
        private string _grshi_birthareacode;
        private string _grshi_birthareaname;
        private string _grshi_birthdetailaddress;
        private string _grshi_cshzgongzuo;
        private string _grshi_dfbdqjzqingkuang;
        private string _grshi_yyoushi;
        private string _grshi_shiyan;
        private string _grshi_syannian;
        private string _grshi_syanzhi;
        private string _grshi_jieyan;
        private string _grshi_jyannian;
        private string _grshi_shijiu;
        private string _grshi_sjiunian;
        private string _grshi_sjiuliang;
        private string _grshi_sjqita;
        private string _hyshi_jhnianling;
        private string _hyshi_poqingkuang;
        private string _yjshsyshi_cchaosui;
        private string _yjshsyshi_cchaotian;
        private string _yjshsyshi_mcyjriqi;
        private string _yjshsyshi_jjnianling;
        private string _yjshsyshi_zhouqi;
        private string _yjshsyshi_jingliang;
        private string _yjshsyshi_tongjing;
        private string _yjshsyshi_jingqi;
        private string _yjshsyshi_renshen;
        private string _yjshsyshi_shunchan;
        private string _yjshsyshi_liuchan;
        private string _yjshsyshi_zaochan;
        private string _yjshsyshi_sichan;
        private string _yjshsyshi_ncjbingqing;
        private string _yjshsyshi_zi;
        private string _yjshsyshi_nv;
        private string _jzshi_fu;
        private string _jzshi_fsiyin;
        private string _jzshi_mu;
        private string _jzshi_msiyin;
        private string _jzshi_xdjiemei;
        private string _jzshi_znjqita;
        private string _smtzheng_tiwen;
        private string _smtzheng_maibo;
        private string _smtzheng_huxi;
        private string _smtzheng_xueya1;
        private string _smtzheng_xueya2;
        private string _smtzheng_tizhong;
        private string _ybzkuang_fayu;
        private string _ybzkuang_yingyang;
        private string _ybzkuang_mianrong;
        private string _ybzkuang_qita;
        private string _ybzkuang_biaoqing;
        private string _ybzkuang_tiwei;
        private string _ybzkuang_twforqp;
        private string _ybzkuang_butai;
        private string _ybzkuang_btforbzc;
        private string _ybzkuang_shenzhi;
        private string _ybzkuang_phjiancha;
        private string _pfnmo_seze;
        private string _pfnmo_pizhen;
        private string _pfnmo_pzlxjfenbu;
        private string _pfnmo_pxchuxue;
        private string _pfnmo_pxcxlxjfenbu;
        private string _pfnmo_mffenbu;
        private string _pfnmo_mffbbuwei;
        private string _pfnmo_wdyshidu;
        private string _pfnmo_tanxing;
        private string _pfnmo_ganzhang;
        private string _pfnmo_shuizhong;
        private string _pfnmo_bwjchengdu;
        private string _pfnmo_zzhuzhi;
        private string _pfnmo_zzzbuwei;
        private string _pfnmo_zzzshumu;
        private string _pfnmo_qita;
        private string _lbjie_qsqblbajie;
        private string _lbjie_qsqblbjbwjtezheng;
        private string _tbu_tldaxiao;
        private string _tbu_tljixing;
        private string _tbu_tljxforyou;
        private string _tbu_tlqtycyatong;
        private string _tbu_tlqtycbaokuai;
        private string _tbu_tlqtycaoxian;
        private string _tbu_tlqtycbuwei;
        private string _tbu_ymmxishu;
        private string _tbu_ymmtuoluo;
        private string _tbu_ydaojie;
        private string _tbu_yyanjian;
        private string _tbu_yjiemo;
        private string _tbu_yjiaomo;
        private string _tbu_yjiaomforyichang;
        private string _tbu_ygongmo;
        private string _tbu_yyanqiu;
        private string _tbu_yyqforall;
        private string _tbu_ytongkong;
        private string _tbu_tkforbudengz;
        private string _tbu_tkforbudengy;
        private string _tbu_ytkdgfanshe;
        private string _tbu_ytkdgfsforall;
        private string _tbu_ytkjshili;
        private string _tbu_tkjslforallz;
        private string _tbu_tkjslforally;
        private string _tbu_tkjslqita;
        private string _tbu_eerkuo;
        private string _tbu_eekqita;
        private string _tbu_eerkforall;
        private string _tbu_ewedfmiwu;
        private string _tbu_ewedfmwfory;
        private string _tbu_ewedfmwxingzhi;
        private string _tbu_ertyatong;
        private string _tbu_ertytfory;
        private string _tbu_tlcszhangai;
        private string _tbu_tlcszafory;
        private string _tbu_bwaixing;
        private string _tbu_bforyc;
        private string _tbu_bbdyatong;
        private string _tbu_bforbdyt;
        private string _tbu_bqtycbyshandong;
        private string _tbu_bqtycfmiwu;
        private string _tbu_bqtycchuxue;
        private string _tbu_bqtyczuse;
        private string _tbu_bqtycbzgpianqu;
        private string _tbu_bqtycbzgchuankong;
        private string _tbu_kqkouchun;
        private string _tbu_kqnianmo;
        private string _tbu_kqnmforyc;
        private string _tbu_kqsxdgkaikou;
        private string _tbu_kqsxdgkkforyc;
        private string _tbu_kqshe;
        private string _tbu_kqsforyc;
        private string _tbu_kqchiyin;
        private string _tbu_kqchilie;
        private string _tbu_kqbtaoti;
        private string _tbu_kqbttforzd;
        private string _tbu_kqyan;
        private string _tbu_kqshengyin;
        private string _jbu_dkanggan;
        private string _jbu_qiguan;
        private string _jbu_qgforpy;
        private string _jbu_jjingmai;
        private string _jbu_jdmbodoong;
        private string _jbu_jdmbdforall;
        private string _jbu_gjjmhliuzheng;
        private string _jbu_jzhuangxian;
        private string _jbu_jzxforzdz;
        private string _jbu_jzxforzdy;
        private string _jbu_jzxzhiruan;
        private string _jbu_jzxzhiying;
        private string _jbu_jzxyatong;
        private string _jbu_jzxzhenchan;
        private string _jbu_jzxxgzayin;
        private string _xbu_xiongkuo;
        private string _xbu_rufang;
        private string _xbu_rfforyc;
        private string _fei_szhxyundong;
        private string _fei_szhxydforyc;
        private string _fei_szljianxi;
        private string _fei_szljxbwforall;
        private string _fei_czyuchan;
        private string _fei_czycforyc;
        private string _fei_czxmmcagan;
        private string _fei_czxmmcgfory;
        private string _fei_czpxnfagan;
        private string _fei_czpxnfgfory;
        private string _fei_kouzhen;
        private string _fei_kzforall;
        private string _fei_fxjjjiaxiany;
        private string _fei_fxjjjiaxianz;
        private string _fei_fxjsgzhongxiany;
        private string _fei_fxjsgzhongxianz;
        private string _fei_fxjyzhongxiany;
        private string _fei_fxjyzhongxianz;
        private string _fei_fxjydongduy;
        private string _fei_fxjydongduz;
        private string _fei_tzhuxi;
        private string _fei_tzhxiyin;
        private string _fei_tzhxyforyc;
        private string _fei_tzluoying;
        private string _fei_tzlyfory;
        private string _fei_tzyychuandao;
        private string _fei_tzyycdforyc;
        private string _fei_tzxmmcayin;
        private string _fei_xmmcyfory;
        private string _xin_szxqqlongqi;
        private string _xin_szxjbdweizhi;
        private string _xin_szxjbowzforyw;
        private string _xin_szxjbodong;
        private string _xin_szxqqycbodong;
        private string _xin_szxqqycbdfory;
        private string _xin_czxjbodong;
        private string _xin_czzhenchan;
        private string _xin_zcfory;
        private string _xin_czxbmcagan;
        private string _xin_kzxdzyinjie;
        private string _xin_kzyer;
        private string _xin_kzzer;
        private string _xin_kzysan;
        private string _xin_kzzsan;
        private string _xin_kzysi;
        private string _xin_kzzsi;
        private string _xin_kzywu;
        private string _xin_kzzwu;
        private string _xin_kzzxian;
        private string _xin_tzxinlvc;
        private string _xin_tzxinlv;
        private string _xin_tzxinyin;
        private string _xin_zwxgwycxguanzheng;
        private string _xin_zwxgqjiyin;
        private string _xin_zwxgddschongyin;
        private string _xin_zwxgschongmai;
        private string _xin_zwxgmxxgbodong;
        private string _xin_zwxgmbduanchu;
        private string _xin_zwxgqimai;
        private string _xin_zwxgjtimai;
        private string _xin_zwxgqita;
        private string _fbu_shizhen;
        private string _fbu_czrouruan;
        private string _fbu_czfjjinzhang;
        private string _fbu_czfjjzforyou;
        private string _fbu_czyatong;
        private string _fbu_czytforyou;
        private string _fbu_czftiaotong;
        private string _fbu_czfttforyou;
        private string _fbu_czybzhenchan;
        private string _fbu_czzshuisheng;
        private string _fbu_czfbbaokuai;
        private string _fbu_czfbbkforyou;
        private string _fbu_czfbbktzmiaoshu;
        private string _fbu_czgan;
        private string _fbu_czdannang;
        private string _fbu_czpi;
        private string _fbu_czshen;
        private string _fbu_kzgzyinjie;
        private string _fbu_kzsgzhongxian;
        private string _fbu_kzydxzhuoyin;
        private string _fbu_kzsqkoutong;
        private string _fbu_kzqita;
        private string _fbu_tzcminyin;
        private string _fbu_tzxgzayin;
        private string _fbu_tzxgzyfory;
        private string _fbu_tzqgshuisheng;
        private string _gmzchang;
        private string _gmzchangfory;
        private string _szqi;
        private string _szqifory;
        private string _ggjrou_jizhu;
        private string _ggjrou_jzforjx;
        private string _ggjrou_qita;
        private string _ggjrou_sizhi;
        private string _sjxitong;
        private string _zkqingkuang;
        private string _sysjqxjiancha;
        private string _blzhaiyao;
        private string _cbzhenduan;
        private string _ryzhenduan;
        private string _xzzhenduan;
        private string _reviewer;
        private string _reviewerdate;
        private string _recordsstatus;
            public string RecordsStatus{
                set{_recordsstatus=value;}
                get{return _recordsstatus;}
            }
        /// <summary>
        /// 
        /// </summary>
        public string Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StudentsRealName
        {
            set { _studentsrealname = value; }
            get { return _studentsrealname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StudentsName
        {
            set { _studentsname = value; }
            get { return _studentsname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrainingBaseCode
        {
            set { _trainingbasecode = value; }
            get { return _trainingbasecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrainingBaseName
        {
            set { _trainingbasename = value; }
            get { return _trainingbasename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProfessionalBaseCode
        {
            set { _professionalbasecode = value; }
            get { return _professionalbasecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProfessionalBaseName
        {
            set { _professionalbasename = value; }
            get { return _professionalbasename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeptCode
        {
            set { _deptcode = value; }
            get { return _deptcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeptName
        {
            set { _deptname = value; }
            get { return _deptname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegisterDate
        {
            set { _registerdate = value; }
            get { return _registerdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Writor
        {
            set { _writor = value; }
            get { return _writor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TeacherCheck
        {
            set { _teachercheck = value; }
            get { return _teachercheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KzrCheck
        {
            set { _kzrcheck = value; }
            get { return _kzrcheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BaseCheck
        {
            set { _basecheck = value; }
            get { return _basecheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ManagerCheck
        {
            set { _managercheck = value; }
            get { return _managercheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TeacherId
        {
            set { _teacherid = value; }
            get { return _teacherid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TeacherName
        {
            set { _teachername = value; }
            get { return _teachername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PatientNo
        {
            set { _patientno = value; }
            get { return _patientno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InhospitalNo
        {
            set { _inhospitalno = value; }
            get { return _inhospitalno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PatientName
        {
            set { _patientname = value; }
            get { return _patientname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Age
        {
            set { _age = value; }
            get { return _age; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Job
        {
            set { _job = value; }
            get { return _job; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Nation
        {
            set { _nation = value; }
            get { return _nation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Marriage
        {
            set { _marriage = value; }
            get { return _marriage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BirthProvinceCode
        {
            set { _birthprovincecode = value; }
            get { return _birthprovincecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BirthProvinceName
        {
            set { _birthprovincename = value; }
            get { return _birthprovincename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BirthCityCode
        {
            set { _birthcitycode = value; }
            get { return _birthcitycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BirthCityName
        {
            set { _birthcityname = value; }
            get { return _birthcityname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BirthAreaCode
        {
            set { _birthareacode = value; }
            get { return _birthareacode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BirthAreaName
        {
            set { _birthareaname = value; }
            get { return _birthareaname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BirthDetailAddress
        {
            set { _birthdetailaddress = value; }
            get { return _birthdetailaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NowProvinceCode
        {
            set { _nowprovincecode = value; }
            get { return _nowprovincecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NowProvinceName
        {
            set { _nowprovincename = value; }
            get { return _nowprovincename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NowCityCode
        {
            set { _nowcitycode = value; }
            get { return _nowcitycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NowCityName
        {
            set { _nowcityname = value; }
            get { return _nowcityname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NowAreaCode
        {
            set { _nowareacode = value; }
            get { return _nowareacode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NowAreaName
        {
            set { _nowareaname = value; }
            get { return _nowareaname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NowDetailAddress
        {
            set { _nowdetailaddress = value; }
            get { return _nowdetailaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InhospitalDate
        {
            set { _inhospitaldate = value; }
            get { return _inhospitaldate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RecordDate
        {
            set { _recorddate = value; }
            get { return _recorddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MedicalHistorySpeaker
        {
            set { _medicalhistoryspeaker = value; }
            get { return _medicalhistoryspeaker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReliableDegree
        {
            set { _reliabledegree = value; }
            get { return _reliabledegree; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZSu
        {
            set { _zsu = value; }
            get { return _zsu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XBShi
        {
            set { _xbshi = value; }
            get { return _xbshi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JWShi_PSJKZhuangKuang
        {
            set { _jwshi_psjkzhuangkuang = value; }
            get { return _jwshi_psjkzhuangkuang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JWShi_CHJBHCRBingShi
        {
            set { _jwshi_chjbhcrbingshi = value; }
            get { return _jwshi_chjbhcrbingshi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JWShi_YFJZhongShi
        {
            set { _jwshi_yfjzhongshi = value; }
            get { return _jwshi_yfjzhongshi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JWShi_GMinShi
        {
            set { _jwshi_gminshi = value; }
            get { return _jwshi_gminshi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JWShi_GMinYuan
        {
            set { _jwshi_gminyuan = value; }
            get { return _jwshi_gminyuan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JWShi_LCBiaoXian
        {
            set { _jwshi_lcbiaoxian = value; }
            get { return _jwshi_lcbiaoxian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JWShi_WShangShi
        {
            set { _jwshi_wshangshi = value; }
            get { return _jwshi_wshangshi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JWShi_SShuShi
        {
            set { _jwshi_sshushi = value; }
            get { return _jwshi_sshushi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_KeSou
        {
            set { _xthgu_kesou = value; }
            get { return _xthgu_kesou; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_KeTan
        {
            set { _xthgu_ketan = value; }
            get { return _xthgu_ketan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_KaXie
        {
            set { _xthgu_kaxie = value; }
            get { return _xthgu_kaxie; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_ChuanXi
        {
            set { _xthgu_chuanxi = value; }
            get { return _xthgu_chuanxi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_XiongTong
        {
            set { _xthgu_xiongtong = value; }
            get { return _xthgu_xiongtong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_HXKunNan
        {
            set { _xthgu_hxkunnan = value; }
            get { return _xthgu_hxkunnan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_XinJi
        {
            set { _xthgu_xinji = value; }
            get { return _xthgu_xinji; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_HDHQiCu
        {
            set { _xthgu_hdhqicu = value; }
            get { return _xthgu_hdhqicu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_XZShuiZhong
        {
            set { _xthgu_xzshuizhong = value; }
            get { return _xthgu_xzshuizhong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_XQQuTong
        {
            set { _xthgu_xqqutong = value; }
            get { return _xthgu_xqqutong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_XYZengGao
        {
            set { _xthgu_xyzenggao = value; }
            get { return _xthgu_xyzenggao; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_YunJue
        {
            set { _xthgu_yunjue = value; }
            get { return _xthgu_yunjue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_SYJianTui
        {
            set { _xthgu_syjiantui = value; }
            get { return _xthgu_syjiantui; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_FanSuan
        {
            set { _xthgu_fansuan = value; }
            get { return _xthgu_fansuan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_AiQi
        {
            set { _xthgu_aiqi = value; }
            get { return _xthgu_aiqi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_EXin
        {
            set { _xthgu_exin = value; }
            get { return _xthgu_exin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_OuTu
        {
            set { _xthgu_outu = value; }
            get { return _xthgu_outu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_FuZhang
        {
            set { _xthgu_fuzhang = value; }
            get { return _xthgu_fuzhang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_FuTong
        {
            set { _xthgu_futong = value; }
            get { return _xthgu_futong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_BianMi
        {
            set { _xthgu_bianmi = value; }
            get { return _xthgu_bianmi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_FuXie
        {
            set { _xthgu_fuxie = value; }
            get { return _xthgu_fuxie; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_OuXue
        {
            set { _xthgu_ouxue = value; }
            get { return _xthgu_ouxue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_HeiBian
        {
            set { _xthgu_heibian = value; }
            get { return _xthgu_heibian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_BianXue
        {
            set { _xthgu_bianxue = value; }
            get { return _xthgu_bianxue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_HuangDan
        {
            set { _xthgu_huangdan = value; }
            get { return _xthgu_huangdan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_YaoTong
        {
            set { _xthgu_yaotong = value; }
            get { return _xthgu_yaotong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_NiaoPin
        {
            set { _xthgu_niaopin = value; }
            get { return _xthgu_niaopin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_NiaoJi
        {
            set { _xthgu_niaoji = value; }
            get { return _xthgu_niaoji; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_NiaoTong
        {
            set { _xthgu_niaotong = value; }
            get { return _xthgu_niaotong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_PNKunNan
        {
            set { _xthgu_pnkunnan = value; }
            get { return _xthgu_pnkunnan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_XueNiao
        {
            set { _xthgu_xueniao = value; }
            get { return _xthgu_xueniao; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_NLYiChang
        {
            set { _xthgu_nlyichang = value; }
            get { return _xthgu_nlyichang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_YNZengDuo
        {
            set { _xthgu_ynzengduo = value; }
            get { return _xthgu_ynzengduo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_ShuiZhong
        {
            set { _xthgu_shuizhong = value; }
            get { return _xthgu_shuizhong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_YBSaoYang
        {
            set { _xthgu_ybsaoyang = value; }
            get { return _xthgu_ybsaoyang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_YBKuiLan
        {
            set { _xthgu_ybkuilan = value; }
            get { return _xthgu_ybkuilan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_FaLi
        {
            set { _xthgu_fali = value; }
            get { return _xthgu_fali; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_TouYun
        {
            set { _xthgu_touyun = value; }
            get { return _xthgu_touyun; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_YanHua
        {
            set { _xthgu_yanhua = value; }
            get { return _xthgu_yanhua; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_YYChuXue
        {
            set { _xthgu_yychuxue = value; }
            get { return _xthgu_yychuxue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_BChuXue
        {
            set { _xthgu_bchuxue = value; }
            get { return _xthgu_bchuxue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_PXChuXue
        {
            set { _xthgu_pxchuxue = value; }
            get { return _xthgu_pxchuxue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_GuTong
        {
            set { _xthgu_gutong = value; }
            get { return _xthgu_gutong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_SYKangJin
        {
            set { _xthgu_sykangjin = value; }
            get { return _xthgu_sykangjin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_PaRe
        {
            set { _xthgu_pare = value; }
            get { return _xthgu_pare; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_DuoHan
        {
            set { _xthgu_duohan = value; }
            get { return _xthgu_duohan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_WeiHan
        {
            set { _xthgu_weihan = value; }
            get { return _xthgu_weihan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_DuoYin
        {
            set { _xthgu_duoyin = value; }
            get { return _xthgu_duoyin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_DuoNiao
        {
            set { _xthgu_duoniao = value; }
            get { return _xthgu_duoniao; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_SSZhenChan
        {
            set { _xthgu_sszhenchan = value; }
            get { return _xthgu_sszhenchan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_XGGaiBian
        {
            set { _xthgu_xggaibian = value; }
            get { return _xthgu_xggaibian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_XZFeiPang
        {
            set { _xthgu_xzfeipang = value; }
            get { return _xthgu_xzfeipang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_MXXiaoShou
        {
            set { _xthgu_mxxiaoshou = value; }
            get { return _xthgu_mxxiaoshou; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_MFZengDuov
        {
            set { _xthgu_mfzengduov = value; }
            get { return _xthgu_mfzengduov; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_MFTuoLuo
        {
            set { _xthgu_mftuoluo = value; }
            get { return _xthgu_mftuoluo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_SSChenZhuo
        {
            set { _xthgu_sschenzhuo = value; }
            get { return _xthgu_sschenzhuo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_XGNGaiBian
        {
            set { _xthgu_xgngaibian = value; }
            get { return _xthgu_xgngaibian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_BiJing
        {
            set { _xthgu_bijing = value; }
            get { return _xthgu_bijing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_GJieTong
        {
            set { _xthgu_gjietong = value; }
            get { return _xthgu_gjietong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_GJHongZhong
        {
            set { _xthgu_gjhongzhong = value; }
            get { return _xthgu_gjhongzhong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_GJBianXing
        {
            set { _xthgu_gjbianxing = value; }
            get { return _xthgu_gjbianxing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_JRouTong
        {
            set { _xthgu_jroutong = value; }
            get { return _xthgu_jroutong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_JRWeiSuo
        {
            set { _xthgu_jrweisuo = value; }
            get { return _xthgu_jrweisuo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_TouTong
        {
            set { _xthgu_toutong = value; }
            get { return _xthgu_toutong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_XuanYun
        {
            set { _xthgu_xuanyun = value; }
            get { return _xthgu_xuanyun; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_YunJue1
        {
            set { _xthgu_yunjue1 = value; }
            get { return _xthgu_yunjue1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JXTHGu_JYLJianTui
        {
            set { _jxthgu_jyljiantui = value; }
            get { return _jxthgu_jyljiantui; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_SLZhangAi
        {
            set { _xthgu_slzhangai = value; }
            get { return _xthgu_slzhangai; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_ShiMian
        {
            set { _xthgu_shimian = value; }
            get { return _xthgu_shimian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_YSZhangAi
        {
            set { _xthgu_yszhangai = value; }
            get { return _xthgu_yszhangai; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_ChanDong
        {
            set { _xthgu_chandong = value; }
            get { return _xthgu_chandong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_ChouChu
        {
            set { _xthgu_chouchu = value; }
            get { return _xthgu_chouchu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_TanHuan
        {
            set { _xthgu_tanhuan = value; }
            get { return _xthgu_tanhuan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XTHGu_GJYiChang
        {
            set { _xthgu_gjyichang = value; }
            get { return _xthgu_gjyichang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_BirthProvinceCode
        {
            set { _grshi_birthprovincecode = value; }
            get { return _grshi_birthprovincecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_BirthProvinceName
        {
            set { _grshi_birthprovincename = value; }
            get { return _grshi_birthprovincename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_BirthCityCode
        {
            set { _grshi_birthcitycode = value; }
            get { return _grshi_birthcitycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_BirthCityName
        {
            set { _grshi_birthcityname = value; }
            get { return _grshi_birthcityname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_BirthAreaCode
        {
            set { _grshi_birthareacode = value; }
            get { return _grshi_birthareacode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_BirthAreaName
        {
            set { _grshi_birthareaname = value; }
            get { return _grshi_birthareaname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_BirthDetailAddress
        {
            set { _grshi_birthdetailaddress = value; }
            get { return _grshi_birthdetailaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_CSHZGongZuo
        {
            set { _grshi_cshzgongzuo = value; }
            get { return _grshi_cshzgongzuo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_DFBDQJZQingKuang
        {
            set { _grshi_dfbdqjzqingkuang = value; }
            get { return _grshi_dfbdqjzqingkuang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_YYouShi
        {
            set { _grshi_yyoushi = value; }
            get { return _grshi_yyoushi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_ShiYan
        {
            set { _grshi_shiyan = value; }
            get { return _grshi_shiyan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_SYanNian
        {
            set { _grshi_syannian = value; }
            get { return _grshi_syannian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_SYanZhi
        {
            set { _grshi_syanzhi = value; }
            get { return _grshi_syanzhi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_JieYan
        {
            set { _grshi_jieyan = value; }
            get { return _grshi_jieyan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_JYanNian
        {
            set { _grshi_jyannian = value; }
            get { return _grshi_jyannian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_ShiJiu
        {
            set { _grshi_shijiu = value; }
            get { return _grshi_shijiu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_SJiuNian
        {
            set { _grshi_sjiunian = value; }
            get { return _grshi_sjiunian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_SJiuLiang
        {
            set { _grshi_sjiuliang = value; }
            get { return _grshi_sjiuliang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GRShi_SJQiTa
        {
            set { _grshi_sjqita = value; }
            get { return _grshi_sjqita; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HYShi_JHNianLing
        {
            set { _hyshi_jhnianling = value; }
            get { return _hyshi_jhnianling; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HYShi_POQingKuang
        {
            set { _hyshi_poqingkuang = value; }
            get { return _hyshi_poqingkuang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_CChaoSui
        {
            set { _yjshsyshi_cchaosui = value; }
            get { return _yjshsyshi_cchaosui; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_CChaoTian
        {
            set { _yjshsyshi_cchaotian = value; }
            get { return _yjshsyshi_cchaotian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_MCYJRiQi
        {
            set { _yjshsyshi_mcyjriqi = value; }
            get { return _yjshsyshi_mcyjriqi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_JJNianLing
        {
            set { _yjshsyshi_jjnianling = value; }
            get { return _yjshsyshi_jjnianling; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_ZhouQi
        {
            set { _yjshsyshi_zhouqi = value; }
            get { return _yjshsyshi_zhouqi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_JingLiang
        {
            set { _yjshsyshi_jingliang = value; }
            get { return _yjshsyshi_jingliang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_TongJing
        {
            set { _yjshsyshi_tongjing = value; }
            get { return _yjshsyshi_tongjing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_JingQi
        {
            set { _yjshsyshi_jingqi = value; }
            get { return _yjshsyshi_jingqi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_RenShen
        {
            set { _yjshsyshi_renshen = value; }
            get { return _yjshsyshi_renshen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_ShunChan
        {
            set { _yjshsyshi_shunchan = value; }
            get { return _yjshsyshi_shunchan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_LiuChan
        {
            set { _yjshsyshi_liuchan = value; }
            get { return _yjshsyshi_liuchan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_ZaoChan
        {
            set { _yjshsyshi_zaochan = value; }
            get { return _yjshsyshi_zaochan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_SiChan
        {
            set { _yjshsyshi_sichan = value; }
            get { return _yjshsyshi_sichan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_NCJBingQing
        {
            set { _yjshsyshi_ncjbingqing = value; }
            get { return _yjshsyshi_ncjbingqing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_Zi
        {
            set { _yjshsyshi_zi = value; }
            get { return _yjshsyshi_zi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YJSHSYShi_Nv
        {
            set { _yjshsyshi_nv = value; }
            get { return _yjshsyshi_nv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JZShi_Fu
        {
            set { _jzshi_fu = value; }
            get { return _jzshi_fu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JZShi_FSiYin
        {
            set { _jzshi_fsiyin = value; }
            get { return _jzshi_fsiyin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JZShi_Mu
        {
            set { _jzshi_mu = value; }
            get { return _jzshi_mu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JZShi_MSiYin
        {
            set { _jzshi_msiyin = value; }
            get { return _jzshi_msiyin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JZShi_XDJieMei
        {
            set { _jzshi_xdjiemei = value; }
            get { return _jzshi_xdjiemei; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JZShi_ZNJQiTa
        {
            set { _jzshi_znjqita = value; }
            get { return _jzshi_znjqita; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SMTZheng_TiWen
        {
            set { _smtzheng_tiwen = value; }
            get { return _smtzheng_tiwen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SMTZheng_MaiBo
        {
            set { _smtzheng_maibo = value; }
            get { return _smtzheng_maibo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SMTZheng_HuXi
        {
            set { _smtzheng_huxi = value; }
            get { return _smtzheng_huxi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SMTZheng_XueYa1
        {
            set { _smtzheng_xueya1 = value; }
            get { return _smtzheng_xueya1; }
        }
        public string SMTZheng_XueYa2
        {
            set { _smtzheng_xueya2 = value; }
            get { return _smtzheng_xueya2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SMTZheng_TiZhong
        {
            set { _smtzheng_tizhong = value; }
            get { return _smtzheng_tizhong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YBZKuang_FaYu
        {
            set { _ybzkuang_fayu = value; }
            get { return _ybzkuang_fayu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YBZKuang_YingYang
        {
            set { _ybzkuang_yingyang = value; }
            get { return _ybzkuang_yingyang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YBZKuang_MianRong
        {
            set { _ybzkuang_mianrong = value; }
            get { return _ybzkuang_mianrong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YBZKuang_QiTa
        {
            set { _ybzkuang_qita = value; }
            get { return _ybzkuang_qita; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YBZKuang_BiaoQing
        {
            set { _ybzkuang_biaoqing = value; }
            get { return _ybzkuang_biaoqing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YBZKuang_TiWei
        {
            set { _ybzkuang_tiwei = value; }
            get { return _ybzkuang_tiwei; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YBZKuang_TWForQP
        {
            set { _ybzkuang_twforqp = value; }
            get { return _ybzkuang_twforqp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YBZKuang_BuTai
        {
            set { _ybzkuang_butai = value; }
            get { return _ybzkuang_butai; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YBZKuang_BTForBZC
        {
            set { _ybzkuang_btforbzc = value; }
            get { return _ybzkuang_btforbzc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YBZKuang_ShenZhi
        {
            set { _ybzkuang_shenzhi = value; }
            get { return _ybzkuang_shenzhi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YBZKuang_PHJianCha
        {
            set { _ybzkuang_phjiancha = value; }
            get { return _ybzkuang_phjiancha; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_SeZe
        {
            set { _pfnmo_seze = value; }
            get { return _pfnmo_seze; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_PiZhen
        {
            set { _pfnmo_pizhen = value; }
            get { return _pfnmo_pizhen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_PZLXJFenBu
        {
            set { _pfnmo_pzlxjfenbu = value; }
            get { return _pfnmo_pzlxjfenbu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_PXChuXue
        {
            set { _pfnmo_pxchuxue = value; }
            get { return _pfnmo_pxchuxue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_PXCXLXJFenBu
        {
            set { _pfnmo_pxcxlxjfenbu = value; }
            get { return _pfnmo_pxcxlxjfenbu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_MFFenBu
        {
            set { _pfnmo_mffenbu = value; }
            get { return _pfnmo_mffenbu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_MFFBBuWei
        {
            set { _pfnmo_mffbbuwei = value; }
            get { return _pfnmo_mffbbuwei; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_WDYShiDu
        {
            set { _pfnmo_wdyshidu = value; }
            get { return _pfnmo_wdyshidu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_TanXing
        {
            set { _pfnmo_tanxing = value; }
            get { return _pfnmo_tanxing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_GanZhang
        {
            set { _pfnmo_ganzhang = value; }
            get { return _pfnmo_ganzhang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_ShuiZhong
        {
            set { _pfnmo_shuizhong = value; }
            get { return _pfnmo_shuizhong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_BWJChengDu
        {
            set { _pfnmo_bwjchengdu = value; }
            get { return _pfnmo_bwjchengdu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_ZZhuZhi
        {
            set { _pfnmo_zzhuzhi = value; }
            get { return _pfnmo_zzhuzhi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_ZZZBuWei
        {
            set { _pfnmo_zzzbuwei = value; }
            get { return _pfnmo_zzzbuwei; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_ZZZShuMu
        {
            set { _pfnmo_zzzshumu = value; }
            get { return _pfnmo_zzzshumu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFNMo_QiTa
        {
            set { _pfnmo_qita = value; }
            get { return _pfnmo_qita; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LBJie_QSQBLBaJie
        {
            set { _lbjie_qsqblbajie = value; }
            get { return _lbjie_qsqblbajie; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LBJie_QSQBLBJBWJTeZheng
        {
            set { _lbjie_qsqblbjbwjtezheng = value; }
            get { return _lbjie_qsqblbjbwjtezheng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_TLDaXiao
        {
            set { _tbu_tldaxiao = value; }
            get { return _tbu_tldaxiao; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_TLJiXing
        {
            set { _tbu_tljixing = value; }
            get { return _tbu_tljixing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_TLJXForYou
        {
            set { _tbu_tljxforyou = value; }
            get { return _tbu_tljxforyou; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_TLQTYCYaTong
        {
            set { _tbu_tlqtycyatong = value; }
            get { return _tbu_tlqtycyatong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_TLQTYCBaoKuai
        {
            set { _tbu_tlqtycbaokuai = value; }
            get { return _tbu_tlqtycbaokuai; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_TLQTYCAoXian
        {
            set { _tbu_tlqtycaoxian = value; }
            get { return _tbu_tlqtycaoxian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_TLQTYCBuWei
        {
            set { _tbu_tlqtycbuwei = value; }
            get { return _tbu_tlqtycbuwei; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_YMMXiShu
        {
            set { _tbu_ymmxishu = value; }
            get { return _tbu_ymmxishu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_YMMTuoLuo
        {
            set { _tbu_ymmtuoluo = value; }
            get { return _tbu_ymmtuoluo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_YDaoJie
        {
            set { _tbu_ydaojie = value; }
            get { return _tbu_ydaojie; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_YYanJian
        {
            set { _tbu_yyanjian = value; }
            get { return _tbu_yyanjian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_YJieMo
        {
            set { _tbu_yjiemo = value; }
            get { return _tbu_yjiemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_YJiaoMo
        {
            set { _tbu_yjiaomo = value; }
            get { return _tbu_yjiaomo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_YJiaoMForYiChang
        {
            set { _tbu_yjiaomforyichang = value; }
            get { return _tbu_yjiaomforyichang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_YGongMo
        {
            set { _tbu_ygongmo = value; }
            get { return _tbu_ygongmo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_YYanQiu
        {
            set { _tbu_yyanqiu = value; }
            get { return _tbu_yyanqiu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_YYQForAll
        {
            set { _tbu_yyqforall = value; }
            get { return _tbu_yyqforall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_YTongKong
        {
            set { _tbu_ytongkong = value; }
            get { return _tbu_ytongkong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_TKForBuDengZ
        {
            set { _tbu_tkforbudengz = value; }
            get { return _tbu_tkforbudengz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_TKForBuDengY
        {
            set { _tbu_tkforbudengy = value; }
            get { return _tbu_tkforbudengy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_YTKDGFanShe
        {
            set { _tbu_ytkdgfanshe = value; }
            get { return _tbu_ytkdgfanshe; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_YTKDGFSForAll
        {
            set { _tbu_ytkdgfsforall = value; }
            get { return _tbu_ytkdgfsforall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_YTKJShiLi
        {
            set { _tbu_ytkjshili = value; }
            get { return _tbu_ytkjshili; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_TKJSLForAllZ
        {
            set { _tbu_tkjslforallz = value; }
            get { return _tbu_tkjslforallz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_TKJSLForAllY
        {
            set { _tbu_tkjslforally = value; }
            get { return _tbu_tkjslforally; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_TKJSLQiTa
        {
            set { _tbu_tkjslqita = value; }
            get { return _tbu_tkjslqita; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_EErKuo
        {
            set { _tbu_eerkuo = value; }
            get { return _tbu_eerkuo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_EEKQiTa
        {
            set { _tbu_eekqita = value; }
            get { return _tbu_eekqita; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_EErKForAll
        {
            set { _tbu_eerkforall = value; }
            get { return _tbu_eerkforall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_EWEDFMiWu
        {
            set { _tbu_ewedfmiwu = value; }
            get { return _tbu_ewedfmiwu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_EWEDFMWForY
        {
            set { _tbu_ewedfmwfory = value; }
            get { return _tbu_ewedfmwfory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_EWEDFMWXingZhi
        {
            set { _tbu_ewedfmwxingzhi = value; }
            get { return _tbu_ewedfmwxingzhi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_ERTYaTong
        {
            set { _tbu_ertyatong = value; }
            get { return _tbu_ertyatong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_ERTYTForY
        {
            set { _tbu_ertytfory = value; }
            get { return _tbu_ertytfory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_TLCSZhangAi
        {
            set { _tbu_tlcszhangai = value; }
            get { return _tbu_tlcszhangai; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_TLCSZAForY
        {
            set { _tbu_tlcszafory = value; }
            get { return _tbu_tlcszafory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_BWaiXing
        {
            set { _tbu_bwaixing = value; }
            get { return _tbu_bwaixing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_BForYC
        {
            set { _tbu_bforyc = value; }
            get { return _tbu_bforyc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_BBDYaTong
        {
            set { _tbu_bbdyatong = value; }
            get { return _tbu_bbdyatong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_BForBDYT
        {
            set { _tbu_bforbdyt = value; }
            get { return _tbu_bforbdyt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_BQTYCBYShanDong
        {
            set { _tbu_bqtycbyshandong = value; }
            get { return _tbu_bqtycbyshandong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_BQTYCFMiWu
        {
            set { _tbu_bqtycfmiwu = value; }
            get { return _tbu_bqtycfmiwu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_BQTYCChuXue
        {
            set { _tbu_bqtycchuxue = value; }
            get { return _tbu_bqtycchuxue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_BQTYCZuSe
        {
            set { _tbu_bqtyczuse = value; }
            get { return _tbu_bqtyczuse; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_BQTYCBZGPianQu
        {
            set { _tbu_bqtycbzgpianqu = value; }
            get { return _tbu_bqtycbzgpianqu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_BQTYCBZGChuanKong
        {
            set { _tbu_bqtycbzgchuankong = value; }
            get { return _tbu_bqtycbzgchuankong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_KQKouChun
        {
            set { _tbu_kqkouchun = value; }
            get { return _tbu_kqkouchun; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_KQNianMo
        {
            set { _tbu_kqnianmo = value; }
            get { return _tbu_kqnianmo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_KQNMForYC
        {
            set { _tbu_kqnmforyc = value; }
            get { return _tbu_kqnmforyc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_KQSXDGKaiKou
        {
            set { _tbu_kqsxdgkaikou = value; }
            get { return _tbu_kqsxdgkaikou; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_KQSXDGKKForYC
        {
            set { _tbu_kqsxdgkkforyc = value; }
            get { return _tbu_kqsxdgkkforyc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_KQShe
        {
            set { _tbu_kqshe = value; }
            get { return _tbu_kqshe; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_KQSForYC
        {
            set { _tbu_kqsforyc = value; }
            get { return _tbu_kqsforyc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_KQChiYin
        {
            set { _tbu_kqchiyin = value; }
            get { return _tbu_kqchiyin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_KQChiLie
        {
            set { _tbu_kqchilie = value; }
            get { return _tbu_kqchilie; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_KQBTaoTi
        {
            set { _tbu_kqbtaoti = value; }
            get { return _tbu_kqbtaoti; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_KQBTTForZD
        {
            set { _tbu_kqbttforzd = value; }
            get { return _tbu_kqbttforzd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_KQYan
        {
            set { _tbu_kqyan = value; }
            get { return _tbu_kqyan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TBu_KQShengYin
        {
            set { _tbu_kqshengyin = value; }
            get { return _tbu_kqshengyin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JBu_DKangGan
        {
            set { _jbu_dkanggan = value; }
            get { return _jbu_dkanggan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JBu_QiGuan
        {
            set { _jbu_qiguan = value; }
            get { return _jbu_qiguan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JBu_QGForPY
        {
            set { _jbu_qgforpy = value; }
            get { return _jbu_qgforpy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JBu_JJingMai
        {
            set { _jbu_jjingmai = value; }
            get { return _jbu_jjingmai; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JBu_JDMBoDoong
        {
            set { _jbu_jdmbodoong = value; }
            get { return _jbu_jdmbodoong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JBu_JDMBDForAll
        {
            set { _jbu_jdmbdforall = value; }
            get { return _jbu_jdmbdforall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JBu_GJJMHLiuZheng
        {
            set { _jbu_gjjmhliuzheng = value; }
            get { return _jbu_gjjmhliuzheng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JBu_JZhuangXian
        {
            set { _jbu_jzhuangxian = value; }
            get { return _jbu_jzhuangxian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JBu_JZXForZDZ
        {
            set { _jbu_jzxforzdz = value; }
            get { return _jbu_jzxforzdz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JBu_JZXForZDY
        {
            set { _jbu_jzxforzdy = value; }
            get { return _jbu_jzxforzdy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JBu_JZXZhiRuan
        {
            set { _jbu_jzxzhiruan = value; }
            get { return _jbu_jzxzhiruan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JBu_JZXZhiYing
        {
            set { _jbu_jzxzhiying = value; }
            get { return _jbu_jzxzhiying; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JBu_JZXYaTong
        {
            set { _jbu_jzxyatong = value; }
            get { return _jbu_jzxyatong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JBu_JZXZhenChan
        {
            set { _jbu_jzxzhenchan = value; }
            get { return _jbu_jzxzhenchan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JBu_JZXXGZaYin
        {
            set { _jbu_jzxxgzayin = value; }
            get { return _jbu_jzxxgzayin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XBu_XiongKuo
        {
            set { _xbu_xiongkuo = value; }
            get { return _xbu_xiongkuo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XBu_RuFang
        {
            set { _xbu_rufang = value; }
            get { return _xbu_rufang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XBu_RFForYC
        {
            set { _xbu_rfforyc = value; }
            get { return _xbu_rfforyc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_SZHXYunDong
        {
            set { _fei_szhxyundong = value; }
            get { return _fei_szhxyundong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_SZHXYDForYC
        {
            set { _fei_szhxydforyc = value; }
            get { return _fei_szhxydforyc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_SZLJianXi
        {
            set { _fei_szljianxi = value; }
            get { return _fei_szljianxi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_SZLJXBWForAll
        {
            set { _fei_szljxbwforall = value; }
            get { return _fei_szljxbwforall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_CZYuChan
        {
            set { _fei_czyuchan = value; }
            get { return _fei_czyuchan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_CZYCForYC
        {
            set { _fei_czycforyc = value; }
            get { return _fei_czycforyc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_CZXMMCaGan
        {
            set { _fei_czxmmcagan = value; }
            get { return _fei_czxmmcagan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_CZXMMCGForY
        {
            set { _fei_czxmmcgfory = value; }
            get { return _fei_czxmmcgfory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_CZPXNFaGan
        {
            set { _fei_czpxnfagan = value; }
            get { return _fei_czpxnfagan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_CZPXNFGForY
        {
            set { _fei_czpxnfgfory = value; }
            get { return _fei_czpxnfgfory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_KouZhen
        {
            set { _fei_kouzhen = value; }
            get { return _fei_kouzhen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_KZForAll
        {
            set { _fei_kzforall = value; }
            get { return _fei_kzforall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_FXJJJiaXianY
        {
            set { _fei_fxjjjiaxiany = value; }
            get { return _fei_fxjjjiaxiany; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_FXJJJiaXianZ
        {
            set { _fei_fxjjjiaxianz = value; }
            get { return _fei_fxjjjiaxianz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_FXJSGZhongXianY
        {
            set { _fei_fxjsgzhongxiany = value; }
            get { return _fei_fxjsgzhongxiany; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_FXJSGZhongXianZ
        {
            set { _fei_fxjsgzhongxianz = value; }
            get { return _fei_fxjsgzhongxianz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_FXJYZhongXianY
        {
            set { _fei_fxjyzhongxiany = value; }
            get { return _fei_fxjyzhongxiany; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_FXJYZhongXianZ
        {
            set { _fei_fxjyzhongxianz = value; }
            get { return _fei_fxjyzhongxianz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_FXJYDongDuY
        {
            set { _fei_fxjydongduy = value; }
            get { return _fei_fxjydongduy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_FXJYDongDuZ
        {
            set { _fei_fxjydongduz = value; }
            get { return _fei_fxjydongduz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_TZHuXi
        {
            set { _fei_tzhuxi = value; }
            get { return _fei_tzhuxi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_TZHXiYin
        {
            set { _fei_tzhxiyin = value; }
            get { return _fei_tzhxiyin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_TZHXYForYC
        {
            set { _fei_tzhxyforyc = value; }
            get { return _fei_tzhxyforyc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_TZLuoYing
        {
            set { _fei_tzluoying = value; }
            get { return _fei_tzluoying; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_TZLYForY
        {
            set { _fei_tzlyfory = value; }
            get { return _fei_tzlyfory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_TZYYChuanDao
        {
            set { _fei_tzyychuandao = value; }
            get { return _fei_tzyychuandao; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_TZYYCDForYC
        {
            set { _fei_tzyycdforyc = value; }
            get { return _fei_tzyycdforyc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_TZXMMCaYin
        {
            set { _fei_tzxmmcayin = value; }
            get { return _fei_tzxmmcayin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fei_XMMCYForY
        {
            set { _fei_xmmcyfory = value; }
            get { return _fei_xmmcyfory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_SZXQQLongQi
        {
            set { _xin_szxqqlongqi = value; }
            get { return _xin_szxqqlongqi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_SZXJBDWeiZhi
        {
            set { _xin_szxjbdweizhi = value; }
            get { return _xin_szxjbdweizhi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_SZXJBOWZForYW
        {
            set { _xin_szxjbowzforyw = value; }
            get { return _xin_szxjbowzforyw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_SZXJBoDong
        {
            set { _xin_szxjbodong = value; }
            get { return _xin_szxjbodong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_SZXQQYCBoDong
        {
            set { _xin_szxqqycbodong = value; }
            get { return _xin_szxqqycbodong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_SZXQQYCBDForY
        {
            set { _xin_szxqqycbdfory = value; }
            get { return _xin_szxqqycbdfory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_CZXJBoDong
        {
            set { _xin_czxjbodong = value; }
            get { return _xin_czxjbodong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_CZZhenChan
        {
            set { _xin_czzhenchan = value; }
            get { return _xin_czzhenchan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_ZCForY
        {
            set { _xin_zcfory = value; }
            get { return _xin_zcfory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_CZXBMCaGan
        {
            set { _xin_czxbmcagan = value; }
            get { return _xin_czxbmcagan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_KZXDZYinJie
        {
            set { _xin_kzxdzyinjie = value; }
            get { return _xin_kzxdzyinjie; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_KZYEr
        {
            set { _xin_kzyer = value; }
            get { return _xin_kzyer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_KZZEr
        {
            set { _xin_kzzer = value; }
            get { return _xin_kzzer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_KZYSan
        {
            set { _xin_kzysan = value; }
            get { return _xin_kzysan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_KZZSan
        {
            set { _xin_kzzsan = value; }
            get { return _xin_kzzsan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_KZYSi
        {
            set { _xin_kzysi = value; }
            get { return _xin_kzysi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_KZZSi
        {
            set { _xin_kzzsi = value; }
            get { return _xin_kzzsi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_KZYWu
        {
            set { _xin_kzywu = value; }
            get { return _xin_kzywu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_KZZWu
        {
            set { _xin_kzzwu = value; }
            get { return _xin_kzzwu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_KZZXian
        {
            set { _xin_kzzxian = value; }
            get { return _xin_kzzxian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_TZXinLvC
        {
            set { _xin_tzxinlvc = value; }
            get { return _xin_tzxinlvc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_TZXinLv
        {
            set { _xin_tzxinlv = value; }
            get { return _xin_tzxinlv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_TZXinYin
        {
            set { _xin_tzxinyin = value; }
            get { return _xin_tzxinyin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_ZWXGWYCXGuanZheng
        {
            set { _xin_zwxgwycxguanzheng = value; }
            get { return _xin_zwxgwycxguanzheng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_ZWXGQJiYin
        {
            set { _xin_zwxgqjiyin = value; }
            get { return _xin_zwxgqjiyin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_ZWXGDDSChongYin
        {
            set { _xin_zwxgddschongyin = value; }
            get { return _xin_zwxgddschongyin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_ZWXGSChongMai
        {
            set { _xin_zwxgschongmai = value; }
            get { return _xin_zwxgschongmai; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_ZWXGMXXGBoDong
        {
            set { _xin_zwxgmxxgbodong = value; }
            get { return _xin_zwxgmxxgbodong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_ZWXGMBDuanChu
        {
            set { _xin_zwxgmbduanchu = value; }
            get { return _xin_zwxgmbduanchu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_ZWXGQiMai
        {
            set { _xin_zwxgqimai = value; }
            get { return _xin_zwxgqimai; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_ZWXGJTiMai
        {
            set { _xin_zwxgjtimai = value; }
            get { return _xin_zwxgjtimai; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Xin_ZWXGQiTa
        {
            set { _xin_zwxgqita = value; }
            get { return _xin_zwxgqita; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_ShiZhen
        {
            set { _fbu_shizhen = value; }
            get { return _fbu_shizhen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZRouRuan
        {
            set { _fbu_czrouruan = value; }
            get { return _fbu_czrouruan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZFJJinZhang
        {
            set { _fbu_czfjjinzhang = value; }
            get { return _fbu_czfjjinzhang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZFJJZForYou
        {
            set { _fbu_czfjjzforyou = value; }
            get { return _fbu_czfjjzforyou; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZYaTong
        {
            set { _fbu_czyatong = value; }
            get { return _fbu_czyatong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZYTForYou
        {
            set { _fbu_czytforyou = value; }
            get { return _fbu_czytforyou; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZFTiaoTong
        {
            set { _fbu_czftiaotong = value; }
            get { return _fbu_czftiaotong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZFTTForYou
        {
            set { _fbu_czfttforyou = value; }
            get { return _fbu_czfttforyou; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZYBZhenChan
        {
            set { _fbu_czybzhenchan = value; }
            get { return _fbu_czybzhenchan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZZShuiSheng
        {
            set { _fbu_czzshuisheng = value; }
            get { return _fbu_czzshuisheng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZFBBaoKuai
        {
            set { _fbu_czfbbaokuai = value; }
            get { return _fbu_czfbbaokuai; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZFBBKForYou
        {
            set { _fbu_czfbbkforyou = value; }
            get { return _fbu_czfbbkforyou; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZFBBKTZMiaoShu
        {
            set { _fbu_czfbbktzmiaoshu = value; }
            get { return _fbu_czfbbktzmiaoshu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZGan
        {
            set { _fbu_czgan = value; }
            get { return _fbu_czgan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZDanNang
        {
            set { _fbu_czdannang = value; }
            get { return _fbu_czdannang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZPi
        {
            set { _fbu_czpi = value; }
            get { return _fbu_czpi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_CZShen
        {
            set { _fbu_czshen = value; }
            get { return _fbu_czshen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_KZGZYinJie
        {
            set { _fbu_kzgzyinjie = value; }
            get { return _fbu_kzgzyinjie; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_KZSGZhongXian
        {
            set { _fbu_kzsgzhongxian = value; }
            get { return _fbu_kzsgzhongxian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_KZYDXZhuoYin
        {
            set { _fbu_kzydxzhuoyin = value; }
            get { return _fbu_kzydxzhuoyin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_KZSQKouTong
        {
            set { _fbu_kzsqkoutong = value; }
            get { return _fbu_kzsqkoutong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_KZQiTa
        {
            set { _fbu_kzqita = value; }
            get { return _fbu_kzqita; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_TZCMinYin
        {
            set { _fbu_tzcminyin = value; }
            get { return _fbu_tzcminyin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_TZXGZaYin
        {
            set { _fbu_tzxgzayin = value; }
            get { return _fbu_tzxgzayin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_TZXGZYForY
        {
            set { _fbu_tzxgzyfory = value; }
            get { return _fbu_tzxgzyfory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FBu_TZQGShuiSheng
        {
            set { _fbu_tzqgshuisheng = value; }
            get { return _fbu_tzqgshuisheng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GMZChang
        {
            set { _gmzchang = value; }
            get { return _gmzchang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GMZChangForY
        {
            set { _gmzchangfory = value; }
            get { return _gmzchangfory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SZQi
        {
            set { _szqi = value; }
            get { return _szqi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SZQiForY
        {
            set { _szqifory = value; }
            get { return _szqifory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GGJRou_JiZhu
        {
            set { _ggjrou_jizhu = value; }
            get { return _ggjrou_jizhu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GGJRou_JZForJX
        {
            set { _ggjrou_jzforjx = value; }
            get { return _ggjrou_jzforjx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GGJRou_QiTa
        {
            set { _ggjrou_qita = value; }
            get { return _ggjrou_qita; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GGJRou_SiZhi
        {
            set { _ggjrou_sizhi = value; }
            get { return _ggjrou_sizhi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SJXiTong
        {
            set { _sjxitong = value; }
            get { return _sjxitong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZKQingKuang
        {
            set { _zkqingkuang = value; }
            get { return _zkqingkuang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SYSJQXJianCha
        {
            set { _sysjqxjiancha = value; }
            get { return _sysjqxjiancha; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BLZhaiYao
        {
            set { _blzhaiyao = value; }
            get { return _blzhaiyao; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CBZhenDuan
        {
            set { _cbzhenduan = value; }
            get { return _cbzhenduan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RYZhenDuan
        {
            set { _ryzhenduan = value; }
            get { return _ryzhenduan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XZZhenDuan
        {
            set { _xzzhenduan = value; }
            get { return _xzzhenduan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Reviewer
        {
            set { _reviewer = value; }
            get { return _reviewer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReviewerDate
        {
            set { _reviewerdate = value; }
            get { return _reviewerdate; }
        }
    }
}
