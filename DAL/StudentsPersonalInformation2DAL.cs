using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Common;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public class StudentsPersonalInformation2DAL
    {
       SqlHelper db = new SqlHelper();

       #region GetDt(string Name)
       public DataTable GetDt(string Name)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 Id,Name,RealName,ImagePath,Sex,IdNumber,DateBirth,MinZu,Telephon,Mail,BkSchool,BkMajor,GraduationTime,HighEducation,HighSchool,HighMajor,HighEducationTime,IdentityType,SendUnit,TrainingBaseProvinceCode,TrainingBaseProvinceName,TrainingBaseCode,TrainingBaseName,CollaborativeUnit,ProfessionalBaseCode,ProfessionalBaseName,TrainingTime,PlanTrainingTime,Tag1,Tag2,Tag3 from GP_StudentsPersonalInformation2 ");
           strSql.Append(" where Name=@Name ");
           SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50)			};
           parameters[0].Value = Name;

           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           if (dt.Rows.Count > 0)
           {
               return dt;
           }
           else
           {
               return null;
           }
       } 
       #endregion

       #region DataRowToModel(DataRow row)
       public StudentsPersonalInformation2Model DataRowToModel(DataRow row)
       {
           StudentsPersonalInformation2Model model = new StudentsPersonalInformation2Model();
           if (row != null)
           {
               if (row["Id"] != null)
               {
                   model.Id = row["Id"].ToString();
               }
               if (row["Name"] != null)
               {
                   model.Name = row["Name"].ToString();
               }
               if (row["RealName"] != null)
               {
                   model.RealName = row["RealName"].ToString();
               }
               if (row["ImagePath"] != null)
               {
                   model.ImagePath = row["ImagePath"].ToString();
               }
               if (row["Sex"] != null)
               {
                   model.Sex = row["Sex"].ToString();
               }
               if (row["IdNumber"] != null)
               {
                   model.IdNumber = row["IdNumber"].ToString();
               }
               if (row["DateBirth"] != null)
               {
                   model.DateBirth = row["DateBirth"].ToString();
               }
               if (row["MinZu"] != null)
               {
                   model.MinZu = row["MinZu"].ToString();
               }
               if (row["Telephon"] != null)
               {
                   model.Telephon = row["Telephon"].ToString();
               }
               if (row["Mail"] != null)
               {
                   model.Mail = row["Mail"].ToString();
               }
               if (row["BkSchool"] != null)
               {
                   model.BkSchool = row["BkSchool"].ToString();
               }
               if (row["BkMajor"] != null)
               {
                   model.BkMajor = row["BkMajor"].ToString();
               }
               if (row["GraduationTime"] != null)
               {
                   model.GraduationTime = row["GraduationTime"].ToString();
               }
               if (row["HighEducation"] != null)
               {
                   model.HighEducation = row["HighEducation"].ToString();
               }
               if (row["HighSchool"] != null)
               {
                   model.HighSchool = row["HighSchool"].ToString();
               }
               if (row["HighMajor"] != null)
               {
                   model.HighMajor = row["HighMajor"].ToString();
               }
               if (row["HighEducationTime"] != null)
               {
                   model.HighEducationTime = row["HighEducationTime"].ToString();
               }
               if (row["IdentityType"] != null)
               {
                   model.IdentityType = row["IdentityType"].ToString();
               }
               if (row["SendUnit"] != null)
               {
                   model.SendUnit = row["SendUnit"].ToString();
               }
               if (row["TrainingBaseProvinceCode"] != null)
               {
                   model.TrainingBaseProvinceCode = row["TrainingBaseProvinceCode"].ToString();
               }
               if (row["TrainingBaseProvinceName"] != null)
               {
                   model.TrainingBaseProvinceName = row["TrainingBaseProvinceName"].ToString();
               }
               if (row["TrainingBaseCode"] != null)
               {
                   model.TrainingBaseCode = row["TrainingBaseCode"].ToString();
               }
               if (row["TrainingBaseName"] != null)
               {
                   model.TrainingBaseName = row["TrainingBaseName"].ToString();
               }
               if (row["CollaborativeUnit"] != null)
               {
                   model.CollaborativeUnit = row["CollaborativeUnit"].ToString();
               }
               if (row["ProfessionalBaseCode"] != null)
               {
                   model.ProfessionalBaseCode = row["ProfessionalBaseCode"].ToString();
               }
               if (row["ProfessionalBaseName"] != null)
               {
                   model.ProfessionalBaseName = row["ProfessionalBaseName"].ToString();
               }
               if (row["TrainingTime"] != null)
               {
                   model.TrainingTime = row["TrainingTime"].ToString();
               }
               if (row["PlanTrainingTime"] != null)
               {
                   model.PlanTrainingTime = row["PlanTrainingTime"].ToString();
               }
               if (row["Tag1"] != null)
               {
                   model.Tag1 = row["Tag1"].ToString();
               }
               if (row["Tag2"] != null)
               {
                   model.Tag2 = row["Tag2"].ToString();
               }
               if (row["Tag3"] != null)
               {
                   model.Tag3 = row["Tag3"].ToString();
               }
           }
           return model;
       } 
       #endregion

       #region Add(StudentsPersonalInformation2Model model)
       public bool Add(StudentsPersonalInformation2Model model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_StudentsPersonalInformation2(");
           strSql.Append("Id,Name,RealName,ImagePath,Sex,IdNumber,DateBirth,MinZu,Telephon,Mail,BkSchool,BkMajor,GraduationTime,HighEducation,HighSchool,HighMajor,HighEducationTime,IdentityType,SendUnit,TrainingBaseProvinceCode,TrainingBaseProvinceName,TrainingBaseCode,TrainingBaseName,CollaborativeUnit,ProfessionalBaseCode,ProfessionalBaseName,TrainingTime,PlanTrainingTime,Tag1,Tag2,Tag3)");
           strSql.Append(" values (");
           strSql.Append("@Id,@Name,@RealName,@ImagePath,@Sex,@IdNumber,@DateBirth,@MinZu,@Telephon,@Mail,@BkSchool,@BkMajor,@GraduationTime,@HighEducation,@HighSchool,@HighMajor,@HighEducationTime,@IdentityType,@SendUnit,@TrainingBaseProvinceCode,@TrainingBaseProvinceName,@TrainingBaseCode,@TrainingBaseName,@CollaborativeUnit,@ProfessionalBaseCode,@ProfessionalBaseName,@TrainingTime,@PlanTrainingTime,@Tag1,@Tag2,@Tag3)");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@ImagePath", SqlDbType.NVarChar,500),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@IdNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@DateBirth", SqlDbType.NVarChar,50),
					new SqlParameter("@MinZu", SqlDbType.NVarChar,50),
					new SqlParameter("@Telephon", SqlDbType.NVarChar,50),
					new SqlParameter("@Mail", SqlDbType.NVarChar,50),
					new SqlParameter("@BkSchool", SqlDbType.NVarChar,50),
					new SqlParameter("@BkMajor", SqlDbType.NVarChar,50),
					new SqlParameter("@GraduationTime", SqlDbType.NVarChar,50),
					new SqlParameter("@HighEducation", SqlDbType.NVarChar,50),
					new SqlParameter("@HighSchool", SqlDbType.NVarChar,50),
					new SqlParameter("@HighMajor", SqlDbType.NVarChar,50),
					new SqlParameter("@HighEducationTime", SqlDbType.NVarChar,50),
					new SqlParameter("@IdentityType", SqlDbType.NVarChar,50),
					new SqlParameter("@SendUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseProvinceCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseProvinceName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@CollaborativeUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingTime", SqlDbType.NVarChar,50),
					new SqlParameter("@PlanTrainingTime", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag1", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag2", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag3", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.Id;
           parameters[1].Value = model.Name;
           parameters[2].Value = model.RealName;
           parameters[3].Value = model.ImagePath;
           parameters[4].Value = model.Sex;
           parameters[5].Value = model.IdNumber;
           parameters[6].Value = model.DateBirth;
           parameters[7].Value = model.MinZu;
           parameters[8].Value = model.Telephon;
           parameters[9].Value = model.Mail;
           parameters[10].Value = model.BkSchool;
           parameters[11].Value = model.BkMajor;
           parameters[12].Value = model.GraduationTime;
           parameters[13].Value = model.HighEducation;
           parameters[14].Value = model.HighSchool;
           parameters[15].Value = model.HighMajor;
           parameters[16].Value = model.HighEducationTime;
           parameters[17].Value = model.IdentityType;
           parameters[18].Value = model.SendUnit;
           parameters[19].Value = model.TrainingBaseProvinceCode;
           parameters[20].Value = model.TrainingBaseProvinceName;
           parameters[21].Value = model.TrainingBaseCode;
           parameters[22].Value = model.TrainingBaseName;
           parameters[23].Value = model.CollaborativeUnit;
           parameters[24].Value = model.ProfessionalBaseCode;
           parameters[25].Value = model.ProfessionalBaseName;
           parameters[26].Value = model.TrainingTime;
           parameters[27].Value = model.PlanTrainingTime;
           parameters[28].Value = model.Tag1;
           parameters[29].Value = model.Tag2;
           parameters[30].Value = model.Tag3;

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

       #region Update(StudentsPersonalInformation2Model model)
       public bool Update(StudentsPersonalInformation2Model model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_StudentsPersonalInformation2 set ");
           strSql.Append("Name=@Name,");
           strSql.Append("RealName=@RealName,");
           strSql.Append("ImagePath=@ImagePath,");
           strSql.Append("Sex=@Sex,");
           strSql.Append("IdNumber=@IdNumber,");
           strSql.Append("DateBirth=@DateBirth,");
           strSql.Append("MinZu=@MinZu,");
           strSql.Append("Telephon=@Telephon,");
           strSql.Append("Mail=@Mail,");
           strSql.Append("BkSchool=@BkSchool,");
           strSql.Append("BkMajor=@BkMajor,");
           strSql.Append("GraduationTime=@GraduationTime,");
           strSql.Append("HighEducation=@HighEducation,");
           strSql.Append("HighSchool=@HighSchool,");
           strSql.Append("HighMajor=@HighMajor,");
           strSql.Append("HighEducationTime=@HighEducationTime,");
           strSql.Append("IdentityType=@IdentityType,");
           strSql.Append("SendUnit=@SendUnit,");
           strSql.Append("TrainingBaseProvinceCode=@TrainingBaseProvinceCode,");
           strSql.Append("TrainingBaseProvinceName=@TrainingBaseProvinceName,");
           strSql.Append("TrainingBaseCode=@TrainingBaseCode,");
           strSql.Append("TrainingBaseName=@TrainingBaseName,");
           strSql.Append("CollaborativeUnit=@CollaborativeUnit,");
           strSql.Append("ProfessionalBaseCode=@ProfessionalBaseCode,");
           strSql.Append("ProfessionalBaseName=@ProfessionalBaseName,");
           strSql.Append("TrainingTime=@TrainingTime,");
           strSql.Append("PlanTrainingTime=@PlanTrainingTime,");
           strSql.Append("Tag1=@Tag1,");
           strSql.Append("Tag2=@Tag2,");
           strSql.Append("Tag3=@Tag3");
           strSql.Append(" where Name=@Name ");
           SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@ImagePath", SqlDbType.NVarChar,500),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@IdNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@DateBirth", SqlDbType.NVarChar,50),
					new SqlParameter("@MinZu", SqlDbType.NVarChar,50),
					new SqlParameter("@Telephon", SqlDbType.NVarChar,50),
					new SqlParameter("@Mail", SqlDbType.NVarChar,50),
					new SqlParameter("@BkSchool", SqlDbType.NVarChar,50),
					new SqlParameter("@BkMajor", SqlDbType.NVarChar,50),
					new SqlParameter("@GraduationTime", SqlDbType.NVarChar,50),
					new SqlParameter("@HighEducation", SqlDbType.NVarChar,50),
					new SqlParameter("@HighSchool", SqlDbType.NVarChar,50),
					new SqlParameter("@HighMajor", SqlDbType.NVarChar,50),
					new SqlParameter("@HighEducationTime", SqlDbType.NVarChar,50),
					new SqlParameter("@IdentityType", SqlDbType.NVarChar,50),
					new SqlParameter("@SendUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseProvinceCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseProvinceName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@CollaborativeUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProfessionalBaseName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingTime", SqlDbType.NVarChar,50),
					new SqlParameter("@PlanTrainingTime", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag1", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag2", SqlDbType.NVarChar,50),
					new SqlParameter("@Tag3", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.Name;
           parameters[1].Value = model.RealName;
           parameters[2].Value = model.ImagePath;
           parameters[3].Value = model.Sex;
           parameters[4].Value = model.IdNumber;
           parameters[5].Value = model.DateBirth;
           parameters[6].Value = model.MinZu;
           parameters[7].Value = model.Telephon;
           parameters[8].Value = model.Mail;
           parameters[9].Value = model.BkSchool;
           parameters[10].Value = model.BkMajor;
           parameters[11].Value = model.GraduationTime;
           parameters[12].Value = model.HighEducation;
           parameters[13].Value = model.HighSchool;
           parameters[14].Value = model.HighMajor;
           parameters[15].Value = model.HighEducationTime;
           parameters[16].Value = model.IdentityType;
           parameters[17].Value = model.SendUnit;
           parameters[18].Value = model.TrainingBaseProvinceCode;
           parameters[19].Value = model.TrainingBaseProvinceName;
           parameters[20].Value = model.TrainingBaseCode;
           parameters[21].Value = model.TrainingBaseName;
           parameters[22].Value = model.CollaborativeUnit;
           parameters[23].Value = model.ProfessionalBaseCode;
           parameters[24].Value = model.ProfessionalBaseName;
           parameters[25].Value = model.TrainingTime;
           parameters[26].Value = model.PlanTrainingTime;
           parameters[27].Value = model.Tag1;
           parameters[28].Value = model.Tag2;
           parameters[29].Value = model.Tag3;
           parameters[30].Value = model.Id;

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


       #region GetModelByNameTBCode(string name, string training_base_code)
       public Model.StudentsPersonalInformation2Model GetModelByNameTBCode(string Name, string TrainingBaseCode)
       {
           string sql = string.Format("select * from GP_StudentsPersonalInformation2 where Name=@Name and TrainingBaseCode=@TrainingBaseCode");
           SqlParameter[] prams = { db.MakeInParam("@Name", SqlDbType.NVarChar, 50, Name),
                                    db.MakeInParam("@TrainingBaseCode", SqlDbType.NVarChar, 50, TrainingBaseCode)
                                   };
           DataTable dt = db.RunDataTable(sql, prams);
           StudentsPersonalInformation2Model studentsPersonalInformationModel = new StudentsPersonalInformation2Model();
           studentsPersonalInformationModel = (StudentsPersonalInformation2Model)ConvertTo.convertToModel(dt, studentsPersonalInformationModel);

           return studentsPersonalInformationModel;
       }
       #endregion

       #region  GetModelById(string id)
       public Model.StudentsPersonalInformation2Model GetModelById(string id)
       {

           string sql = string.Format("select * from GP_StudentsPersonalInformation2 where Id=@Id");
           SqlParameter[] prams = { db.MakeInParam("@Id", SqlDbType.NVarChar, 50, id) };
           DataTable dt = db.RunDataTable(sql, prams);
           StudentsPersonalInformation2Model studentsPersonalInformationModel = new StudentsPersonalInformation2Model();
           studentsPersonalInformationModel = (StudentsPersonalInformation2Model)ConvertTo.convertToModel(dt, studentsPersonalInformationModel);

           return studentsPersonalInformationModel;
       }
       #endregion


       #region Common分页
       public List<Model.StudentsPersonalInformation2Model> CommonGetPagedList(string TrainingBaseCode, string ProfessionalBaseCode,
           string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
           string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by TrainingTime desc) as num,* from GP_StudentsPersonalInformation2 where TrainingBaseCode like '%" + TrainingBaseCode + "%'";

           if (!string.IsNullOrEmpty(ProfessionalBaseCode))
           {
               sql += "and ProfessionalBaseCode like '%" + ProfessionalBaseCode + "%'";
           }
           if (!string.IsNullOrEmpty(StudentsRealName))
           {
               sql += "and RealName like '%" + StudentsRealName + "%'";
           }
           if (!string.IsNullOrEmpty(Sex))
           {
               sql += "and Sex ='" + Sex + "'";
           }
           if (!string.IsNullOrEmpty(MinZu))
           {
               sql += "and MinZu like '%" + MinZu + "%'";
           }
           if (!string.IsNullOrEmpty(HighEducation))
           {
               sql += "and HighEducation like '%" + HighEducation + "%'";
           }
           if (!string.IsNullOrEmpty(HighSchool))
           {
               sql += "and HighSchool like '%" + HighSchool + "%'";
           }
           if (!string.IsNullOrEmpty(IdentityType))
           {
               sql += "and IdentityType like '%" + IdentityType + "%'";
           }
           if (!string.IsNullOrEmpty(SendUnit))
           {
               sql += "and SendUnit = '" + SendUnit + "'";
           }
           if (!string.IsNullOrEmpty(CollaborativeUnit))
           {
               sql += "and CollaborativeUnit like '%" + CollaborativeUnit + "%'";
           }
           if (!string.IsNullOrEmpty(TrainingTime))
           {
               sql += "and TrainingTime like '%" + TrainingTime + "%'";
           }
           if (!string.IsNullOrEmpty(PlanTrainingTime))
           {
               sql += "and PlanTrainingTime = '" + PlanTrainingTime + "'";
           }
           sql += ")as t where t.num>=@start and t.num<=@end";


           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<StudentsPersonalInformation2Model> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<StudentsPersonalInformation2Model>();
               StudentsPersonalInformation2Model model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new StudentsPersonalInformation2Model();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int CommonGetRecordCount(string TrainingBaseCode, string ProfessionalBaseCode,
           string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
           string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime)
       {
           string sql = "select count(*) from GP_StudentsPersonalInformation2 where TrainingBaseCode like '%" + TrainingBaseCode + "%'";
           if (!string.IsNullOrEmpty(ProfessionalBaseCode))
           {
               sql += "and ProfessionalBaseCode like '%" + ProfessionalBaseCode + "%'";
           }
           if (!string.IsNullOrEmpty(StudentsRealName))
           {
               sql += "and RealName like '%" + StudentsRealName + "%'";
           }
           if (!string.IsNullOrEmpty(Sex))
           {
               sql += "and Sex ='" + Sex + "'";
           }
           if (!string.IsNullOrEmpty(MinZu))
           {
               sql += "and MinZu like '%" + MinZu + "%'";
           }
           if (!string.IsNullOrEmpty(HighEducation))
           {
               sql += "and HighEducationHighEducation like '%" + HighEducation + "%'";
           }
           if (!string.IsNullOrEmpty(HighSchool))
           {
               sql += "and HighSchool like '%" + HighSchool + "%'";
           }
           if (!string.IsNullOrEmpty(IdentityType))
           {
               sql += "and IdentityType like '%" + IdentityType + "%'";
           }
           if (!string.IsNullOrEmpty(SendUnit))
           {
               sql += "and SendUnit = '" + SendUnit + "'";
           }
           if (!string.IsNullOrEmpty(CollaborativeUnit))
           {
               sql += "and CollaborativeUnit like '%" + CollaborativeUnit + "%'";
           }
           if (!string.IsNullOrEmpty(TrainingTime))
           {
               sql += "and TrainingTime like '%" + TrainingTime + "%'";
           }
           if (!string.IsNullOrEmpty(PlanTrainingTime))
           {
               sql += "and PlanTrainingTime = '" + PlanTrainingTime + "'";
           }

           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion

       #region GetDtByNT(string Name, string TrainingBaseCode)
       public DataTable GetDtByNT(string Name, string TrainingBaseCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 Id,Name,RealName,ImagePath,Sex,IdNumber,DateBirth,MinZu,Telephon,Mail,BkSchool,BkMajor,GraduationTime,HighEducation,HighSchool,HighMajor,HighEducationTime,IdentityType,SendUnit,TrainingBaseCode,TrainingBaseName,CollaborativeUnit,ProfessionalBaseCode,ProfessionalBaseName,TrainingTime,PlanTrainingTime,Tag1,Tag2,Tag3,TrainingBaseProvinceCode,TrainingBaseProvinceName from GP_StudentsPersonalInformation2 ");
           strSql.Append(" where Name=@Name and TrainingBaseCode=@TrainingBaseCode ");
           SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = Name;
           parameters[1].Value = TrainingBaseCode;


           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           if (dt.Rows.Count > 0)
           {
               return dt;
           }
           else
           {
               return null;
           }
       } 
       #endregion

       #region StaticsPB
       public DataTable StaticsPB(string TrainingBaseCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select ProfessionalBaseName,COUNT(ProfessionalBaseName) as CountPB from GP_StudentsPersonalInformation2");
           strSql.Append(" where TrainingBaseCode like @TrainingBaseCode group by ProfessionalBaseName");
           SqlParameter[] parameters = {
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value ='%'+TrainingBaseCode+'%';
 
           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           if (dt.Rows.Count > 0)
           {
               return dt;
           }
           else
           {
               return null;
           }
       } 
       #endregion

       #region StaticsSU
       public DataTable StaticsSU(string TrainingBaseCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select SendUnit,COUNT(SendUnit) as CountSU from GP_StudentsPersonalInformation2");
           strSql.Append(" where TrainingBaseCode like @TrainingBaseCode group by SendUnit");
           SqlParameter[] parameters = {
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = '%' + TrainingBaseCode + '%';

           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           if (dt.Rows.Count > 0)
           {
               return dt;
           }
           else
           {
               return null;
           }
       }
       #endregion

       #region StaticsCU
       public DataTable StaticsCU(string TrainingBaseCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select CollaborativeUnit,COUNT(CollaborativeUnit) as CountCU from GP_StudentsPersonalInformation2");
           strSql.Append(" where TrainingBaseCode like @TrainingBaseCode group by CollaborativeUnit");
           SqlParameter[] parameters = {
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = '%' + TrainingBaseCode + '%';

           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           if (dt.Rows.Count > 0)
           {
               return dt;
           }
           else
           {
               return null;
           }
       }
       #endregion
       #region StaticsIT
       public DataTable StaticsIT(string TrainingBaseCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select IdentityType,COUNT(IdentityType) as CountIT from GP_StudentsPersonalInformation2");
           strSql.Append(" where TrainingBaseCode like @TrainingBaseCode group by IdentityType");
           SqlParameter[] parameters = {
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = '%' + TrainingBaseCode + '%';

           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           if (dt.Rows.Count > 0)
           {
               return dt;
           }
           else
           {
               return null;
           }
       }
       #endregion
       #region StaticsTT
       public DataTable StaticsTT(string TrainingBaseCode)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select TrainingTime,COUNT(TrainingTime) as CountTT from GP_StudentsPersonalInformation2");
           strSql.Append(" where TrainingBaseCode like @TrainingBaseCode group by TrainingTime");
           SqlParameter[] parameters = {
					new SqlParameter("@TrainingBaseCode", SqlDbType.NVarChar,50)			};
           parameters[0].Value = '%' + TrainingBaseCode + '%';

           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           if (dt.Rows.Count > 0)
           {
               return dt;
           }
           else
           {
               return null;
           }
       }
       #endregion
    }
}
