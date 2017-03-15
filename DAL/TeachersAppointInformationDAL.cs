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
   public class TeachersAppointInformationDAL
    {
       SqlHelper db = new SqlHelper();
       //#region Insert1
       //public bool Insert(TeachersAppointInformationModel model)
       //{
       //    StringBuilder strSql = new StringBuilder();
       //    strSql.Append("insert into GP_Teachers_Appoint_Information(");
       //    strSql.Append("id,teachers_name,teachers_real_name,appoint_begin_time,appoint_end_time,training_content,total_num,class_num,each_class_num,comment,is_pass,type,training_base_code,training_base_name,professional_base_code,professional_base_name,dept_code,dept_name,register_date)");
       //    strSql.Append(" values (");
       //    strSql.Append("@id,@teachers_name,@teachers_real_name,@appoint_begin_time,@appoint_end_time,@training_content,@total_num,@class_num,@each_class_num,@comment,@is_pass,@type,@training_base_code,@training_base_name,@professional_base_code,@professional_base_name,@dept_code,@dept_name,@register_date)");
       //    SqlParameter[] parameters = {
       //             new SqlParameter("@id", SqlDbType.NVarChar,50),
       //             new SqlParameter("@teachers_name", SqlDbType.NVarChar,50),
       //             new SqlParameter("@teachers_real_name", SqlDbType.NVarChar,50),
       //             new SqlParameter("@appoint_begin_time", SqlDbType.NVarChar,50),
       //             new SqlParameter("@appoint_end_time", SqlDbType.NVarChar,50),
       //             new SqlParameter("@training_content", SqlDbType.NVarChar,2000),
       //             new SqlParameter("@total_num", SqlDbType.NVarChar,50),
       //             new SqlParameter("@class_num", SqlDbType.NVarChar,50),
       //             new SqlParameter("@each_class_num", SqlDbType.NVarChar,50),
       //             new SqlParameter("@comment", SqlDbType.NVarChar,2000),
       //             new SqlParameter("@is_pass", SqlDbType.NVarChar,50),
       //             new SqlParameter("@type", SqlDbType.NVarChar,50),
       //             new SqlParameter("@training_base_code", SqlDbType.NVarChar,50),
       //             new SqlParameter("@training_base_name", SqlDbType.NVarChar,50),
       //             new SqlParameter("@professional_base_code", SqlDbType.NVarChar,50),
       //             new SqlParameter("@professional_base_name", SqlDbType.NVarChar,50),
       //             new SqlParameter("@dept_code", SqlDbType.NVarChar,50),
       //             new SqlParameter("@dept_name", SqlDbType.NVarChar,50),
       //             new SqlParameter("@register_date", SqlDbType.NVarChar,50)};
       //    parameters[0].Value = model.id;
       //    parameters[1].Value = model.teachers_name;
       //    parameters[2].Value = model.teachers_real_name;
       //    parameters[3].Value = model.appoint_begin_time;
       //    parameters[4].Value = model.appoint_end_time;
       //    parameters[5].Value = model.training_content;
       //    parameters[6].Value = model.total_num;
       //    parameters[7].Value = model.class_num;
       //    parameters[8].Value = model.each_class_num;
       //    parameters[9].Value = model.comment;
       //    parameters[10].Value = model.is_pass;
       //    parameters[11].Value = model.type;
       //    parameters[12].Value = model.training_base_code;
       //    parameters[13].Value = model.training_base_name;
       //    parameters[14].Value = model.professional_base_code;
       //    parameters[15].Value = model.professional_base_name;
       //    parameters[16].Value = model.dept_code;
       //    parameters[17].Value = model.dept_name;
       //    parameters[18].Value = model.register_date;

       //    int rows = db.ExecuteSql(strSql.ToString(), parameters);
       //    if (rows > 0)
       //    {
       //        return true;
       //    }
       //    else
       //    {
       //        return false;
       //    }
       //}
      //#endregion
       #region Insert(TeachersAppointInformationModel model)
       public bool Insert(TeachersAppointInformationModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_Teachers_Appoint_Information(");
           strSql.Append("id,teachers_name,teachers_real_name,appoint_begin_time,appoint_end_time,training_content,total_num,class_num,each_class_num,comment,is_pass,type,training_base_code,training_base_name,professional_base_code,professional_base_name,dept_code,dept_name,register_date,FileName,FilePath,IsReceive)");
           strSql.Append(" values (");
           strSql.Append("@id,@teachers_name,@teachers_real_name,@appoint_begin_time,@appoint_end_time,@training_content,@total_num,@class_num,@each_class_num,@comment,@is_pass,@type,@training_base_code,@training_base_name,@professional_base_code,@professional_base_name,@dept_code,@dept_name,@register_date,@FileName,@FilePath,@IsReceive)");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50),
					new SqlParameter("@teachers_name", SqlDbType.NVarChar,50),
					new SqlParameter("@teachers_real_name", SqlDbType.NVarChar,50),
					new SqlParameter("@appoint_begin_time", SqlDbType.NVarChar,50),
					new SqlParameter("@appoint_end_time", SqlDbType.NVarChar,50),
					new SqlParameter("@training_content", SqlDbType.NVarChar,2000),
					new SqlParameter("@total_num", SqlDbType.NVarChar,50),
					new SqlParameter("@class_num", SqlDbType.NVarChar,50),
					new SqlParameter("@each_class_num", SqlDbType.NVarChar,50),
					new SqlParameter("@comment", SqlDbType.NVarChar,2000),
					new SqlParameter("@is_pass", SqlDbType.NVarChar,50),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@dept_code", SqlDbType.NVarChar,50),
					new SqlParameter("@dept_name", SqlDbType.NVarChar,50),
					new SqlParameter("@register_date", SqlDbType.NVarChar,50),
					new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,500),
					new SqlParameter("@IsReceive", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.id;
           parameters[1].Value = model.teachers_name;
           parameters[2].Value = model.teachers_real_name;
           parameters[3].Value = model.appoint_begin_time;
           parameters[4].Value = model.appoint_end_time;
           parameters[5].Value = model.training_content;
           parameters[6].Value = model.total_num;
           parameters[7].Value = model.class_num;
           parameters[8].Value = model.each_class_num;
           parameters[9].Value = model.comment;
           parameters[10].Value = model.is_pass;
           parameters[11].Value = model.type;
           parameters[12].Value = model.training_base_code;
           parameters[13].Value = model.training_base_name;
           parameters[14].Value = model.professional_base_code;
           parameters[15].Value = model.professional_base_name;
           parameters[16].Value = model.dept_code;
           parameters[17].Value = model.dept_name;
           parameters[18].Value = model.register_date;
           parameters[19].Value = model.FileName;
           parameters[20].Value = model.FilePath;
           parameters[21].Value = model.IsReceive;

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


       #region Update

       public bool Update(TeachersAppointInformationModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_Teachers_Appoint_Information set ");
           strSql.Append("appoint_begin_time=@appoint_begin_time,");
           strSql.Append("appoint_end_time=@appoint_end_time,");
           strSql.Append("training_content=@training_content,");
           strSql.Append("total_num=@total_num,");
           strSql.Append("class_num=@class_num,");
           strSql.Append("each_class_num=@each_class_num,");
           strSql.Append("comment=@comment,");
           strSql.Append("register_date=@register_date");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
                    new SqlParameter("@appoint_begin_time", SqlDbType.NVarChar,50),
                    new SqlParameter("@appoint_end_time", SqlDbType.NVarChar,50),
                    new SqlParameter("@training_content", SqlDbType.NVarChar,2000),
                    new SqlParameter("@total_num", SqlDbType.NVarChar,50),
                    new SqlParameter("@class_num", SqlDbType.NVarChar,50),
                    new SqlParameter("@each_class_num", SqlDbType.NVarChar,50),
                    new SqlParameter("@comment", SqlDbType.NVarChar,2000),
                    new SqlParameter("@register_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@id", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.appoint_begin_time;
           parameters[1].Value = model.appoint_end_time;
           parameters[2].Value = model.training_content;
           parameters[3].Value = model.total_num;
           parameters[4].Value = model.class_num;
           parameters[5].Value = model.each_class_num;
           parameters[6].Value = model.comment;
           parameters[7].Value = model.register_date;
           parameters[8].Value = model.id;

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
      
      // #region SelectModelById1
       //public TeachersAppointInformationModel SelectModelById(string id)
       //{

       //    StringBuilder strSql = new StringBuilder();
       //    strSql.Append("select  appoint_begin_time,appoint_end_time,training_content,total_num,class_num,each_class_num,comment,register_date from GP_Teachers_Appoint_Information ");
       //    strSql.Append(" where id=@id ");
       //    SqlParameter[] parameters = {
       //             new SqlParameter("@id", SqlDbType.NVarChar,50)};
       //    parameters[0].Value = id;

       //   TeachersAppointInformationModel model = new TeachersAppointInformationModel();
       //    DataSet ds = db.RunDataSet(strSql.ToString(), parameters,"tbName");
       //    if (ds.Tables[0].Rows.Count > 0)
       //    {
       //        return DataRowToModel(ds.Tables[0].Rows[0]);
       //    }
       //    else
       //    {
       //        return null;
       //    }
       //}
       //public TeachersAppointInformationModel DataRowToModel(DataRow row)
       //{
       //    TeachersAppointInformationModel model = new TeachersAppointInformationModel();
       //    if (row != null)
       //    {
       //        if (row["appoint_begin_time"] != null)
       //        {
       //            model.appoint_begin_time = row["appoint_begin_time"].ToString();
       //        }
       //        if (row["appoint_end_time"] != null)
       //        {
       //            model.appoint_end_time = row["appoint_end_time"].ToString();
       //        }
       //        if (row["training_content"] != null)
       //        {
       //            model.training_content = row["training_content"].ToString();
       //        }
       //        if (row["total_num"] != null)
       //        {
       //            model.total_num = row["total_num"].ToString();
       //        }
       //        if (row["class_num"] != null)
       //        {
       //            model.class_num = row["class_num"].ToString();
       //        }
       //        if (row["each_class_num"] != null)
       //        {
       //            model.each_class_num = row["each_class_num"].ToString();
       //        }
       //        if (row["comment"] != null)
       //        {
       //            model.comment = row["comment"].ToString();
       //        }
       //        if (row["register_date"] != null)
       //        {
       //            model.register_date = row["register_date"].ToString();
       //        }
       //    }
       //    return model;
       //}
      // #endregion

       #region SelectModelById(string id)
       public TeachersAppointInformationModel SelectModelById(string id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 id,teachers_name,teachers_real_name,appoint_begin_time,appoint_end_time,training_content,total_num,class_num,each_class_num,comment,is_pass,type,training_base_code,training_base_name,professional_base_code,professional_base_name,dept_code,dept_name,register_date,FileName,FilePath,IsReceive from GP_Teachers_Appoint_Information ");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50)			};
           parameters[0].Value = id;

           TeachersAppointInformationModel model = new TeachersAppointInformationModel();
           DataSet ds = db.RunDataSet(strSql.ToString(), parameters, "tbName");
           if (ds.Tables[0].Rows.Count > 0)
           {
               return DataRowToModel(ds.Tables[0].Rows[0]);
           }
           else
           {
               return null;
           }
       } 
       #endregion


       #region DataRowToModel(DataRow row)
       public TeachersAppointInformationModel DataRowToModel(DataRow row)
       {
           TeachersAppointInformationModel model = new TeachersAppointInformationModel();
           if (row != null)
           {
               if (row["id"] != null)
               {
                   model.id = row["id"].ToString();
               }
               if (row["teachers_name"] != null)
               {
                   model.teachers_name = row["teachers_name"].ToString();
               }
               if (row["teachers_real_name"] != null)
               {
                   model.teachers_real_name = row["teachers_real_name"].ToString();
               }
               if (row["appoint_begin_time"] != null)
               {
                   model.appoint_begin_time = row["appoint_begin_time"].ToString();
               }
               if (row["appoint_end_time"] != null)
               {
                   model.appoint_end_time = row["appoint_end_time"].ToString();
               }
               if (row["training_content"] != null)
               {
                   model.training_content = row["training_content"].ToString();
               }
               if (row["total_num"] != null)
               {
                   model.total_num = row["total_num"].ToString();
               }
               if (row["class_num"] != null)
               {
                   model.class_num = row["class_num"].ToString();
               }
               if (row["each_class_num"] != null)
               {
                   model.each_class_num = row["each_class_num"].ToString();
               }
               if (row["comment"] != null)
               {
                   model.comment = row["comment"].ToString();
               }
               if (row["is_pass"] != null)
               {
                   model.is_pass = row["is_pass"].ToString();
               }
               if (row["type"] != null)
               {
                   model.type = row["type"].ToString();
               }
               if (row["training_base_code"] != null)
               {
                   model.training_base_code = row["training_base_code"].ToString();
               }
               if (row["training_base_name"] != null)
               {
                   model.training_base_name = row["training_base_name"].ToString();
               }
               if (row["professional_base_code"] != null)
               {
                   model.professional_base_code = row["professional_base_code"].ToString();
               }
               if (row["professional_base_name"] != null)
               {
                   model.professional_base_name = row["professional_base_name"].ToString();
               }
               if (row["dept_code"] != null)
               {
                   model.dept_code = row["dept_code"].ToString();
               }
               if (row["dept_name"] != null)
               {
                   model.dept_name = row["dept_name"].ToString();
               }
               if (row["register_date"] != null)
               {
                   model.register_date = row["register_date"].ToString();
               }
               if (row["FileName"] != null)
               {
                   model.FileName = row["FileName"].ToString();
               }
               if (row["FilePath"] != null)
               {
                   model.FilePath = row["FilePath"].ToString();
               }
               if (row["IsReceive"] != null)
               {
                   model.IsReceive = row["IsReceive"].ToString();
               }
           }
           return model;
       } 
       #endregion

        #region GetPageList
       public DataTable GetPageList(string training_base_code, string dept_code, string teachers_name, string teachers_real_name, string appoint_begin_time, string appoint_end_time, string is_pass, int pageIndex, int pageSize, out int rowCount, out int pageCount)
       {

           string sq = "training_base_code='" + training_base_code
               + "' and dept_code='" + dept_code + "' and teachers_name='" + teachers_name + "' and teachers_real_name='" + teachers_real_name + "'";
           
           if (!string.IsNullOrEmpty(appoint_begin_time))
           {
               sq += "and appoint_begin_time >='" + appoint_begin_time + "'";
           }
           if (!string.IsNullOrEmpty(appoint_end_time))
           {
               sq += "and appoint_end_time <='" + appoint_end_time + "'";
           }
           
           if (!string.IsNullOrEmpty(is_pass))
           {
               sq += "and is_pass='" + is_pass + "'";
           }
           DataTable dt = db.RunPagedDataPro("GetPageList", "id,teachers_name,teachers_real_name,appoint_begin_time,appoint_end_time,training_content,total_num,class_num,each_class_num,comment,is_pass,type,training_base_code,training_base_name,professional_base_code,professional_base_name,dept_code,dept_name,register_date,FileName,FilePath,IsReceive",
               "GP_Teachers_Appoint_Information", sq, "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

           
           return dt;

       }

       //public TeachersAppointInformationModel DataRowToModel2(DataRow row)
       //{
       //    TeachersAppointInformationModel model = new TeachersAppointInformationModel();
       //    if (row != null)
       //    {
       //        if (row["id"] != null)
       //        {
       //            model.id = row["id"].ToString();
       //        }
       //        if (row["teachers_name"] != null)
       //        {
       //            model.teachers_name = row["teachers_name"].ToString();
       //        }
       //        if (row["teachers_real_name"] != null)
       //        {
       //            model.teachers_real_name = row["teachers_real_name"].ToString();
       //        }
       //        if (row["appoint_begin_time"] != null)
       //        {
       //            model.appoint_begin_time = row["appoint_begin_time"].ToString();
       //        }
       //        if (row["appoint_end_time"] != null)
       //        {
       //            model.appoint_end_time = row["appoint_end_time"].ToString();
       //        }
       //        if (row["training_content"] != null)
       //        {
       //            model.training_content = row["training_content"].ToString();
       //        }
       //        if (row["total_num"] != null)
       //        {
       //            model.total_num = row["total_num"].ToString();
       //        }
       //        if (row["class_num"] != null)
       //        {
       //            model.class_num = row["class_num"].ToString();
       //        }
       //        if (row["each_class_num"] != null)
       //        {
       //            model.each_class_num = row["each_class_num"].ToString();
       //        }
       //        if (row["comment"] != null)
       //        {
       //            model.comment = row["comment"].ToString();
       //        }
       //        if (row["is_pass"] != null)
       //        {
       //            model.is_pass = row["is_pass"].ToString();
       //        }
       //        if (row["type"] != null)
       //        {
       //            model.type = row["type"].ToString();
       //        }
       //        if (row["training_base_code"] != null)
       //        {
       //            model.training_base_code = row["training_base_code"].ToString();
       //        }
       //        if (row["training_base_name"] != null)
       //        {
       //            model.training_base_name = row["training_base_name"].ToString();
       //        }
       //        if (row["professional_base_code"] != null)
       //        {
       //            model.professional_base_code = row["professional_base_code"].ToString();
       //        }
       //        if (row["professional_base_name"] != null)
       //        {
       //            model.professional_base_name = row["professional_base_name"].ToString();
       //        }
       //        if (row["dept_code"] != null)
       //        {
       //            model.dept_code = row["dept_code"].ToString();
       //        }
       //        if (row["dept_name"] != null)
       //        {
       //            model.dept_name = row["dept_name"].ToString();
       //        }
       //        if (row["register_date"] != null)
       //        {
       //            model.register_date = row["register_date"].ToString();
       //        }
       //    }
       //    return model;
       //}
        #endregion

       #region GetBasesPagedList
       public List<Model.TeachersAppointInformationModel> GetBasesPagedList(string BasesName, string TrainingBaseCode, string ProfessionalBaseCode,
           string AppointBeginTime, string AppointEndTime, string IsPass,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by register_date desc) as num,* from GP_Teachers_Appoint_Information where teachers_name='" + BasesName + "' and training_base_code = '" + TrainingBaseCode + "' and professional_base_code='"+ProfessionalBaseCode+"' and type='专业基地'";

           if (!string.IsNullOrEmpty(AppointBeginTime))
           {
               sql += "and appoint_begin_time = '" + AppointBeginTime + "'";
           }
           if (!string.IsNullOrEmpty(AppointEndTime))
           {
               sql += "and appoint_end_time = '" + AppointEndTime + "'";
           }
           if (!string.IsNullOrEmpty(IsPass))
           {
               sql += "and is_pass like '" + IsPass + "%'";
           }
           sql += ")as t where t.num>=@start and t.num<=@end";


           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<TeachersAppointInformationModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<TeachersAppointInformationModel>();
               TeachersAppointInformationModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new TeachersAppointInformationModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int GetBasesRecordCount(string BasesName, string TrainingBaseCode, string ProfessionalBaseCode,
           string AppointBeginTime, string AppointEndTime, string IsPass)
       {
           string sql = "select count(*) from GP_Teachers_Appoint_Information where training_base_code='" + TrainingBaseCode
               + "' and teachers_name='" + BasesName + "' and professional_base_code='"+ProfessionalBaseCode+"' and type='专业基地'";
           if (!string.IsNullOrEmpty(AppointBeginTime))
           {
               sql += "and appoint_begin_time = '" + AppointBeginTime + "'";
           }
           if (!string.IsNullOrEmpty(AppointEndTime))
           {
               sql += "and appoint_end_time = '" + AppointEndTime + "'";
           }
           if (!string.IsNullOrEmpty(IsPass))
           {
               sql += "and is_pass like '%" + IsPass + "%'";
           }

           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion

       #region SelectListById(string id)
       public List<TeachersAppointInformationModel> SelectListById(string id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 id,teachers_name,teachers_real_name,appoint_begin_time,appoint_end_time,training_content,total_num,class_num,each_class_num,comment,is_pass,type,training_base_code,training_base_name,professional_base_code,professional_base_name,dept_code,dept_name,register_date,FileName,FilePath,IsReceive from GP_Teachers_Appoint_Information ");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50)			};
           parameters[0].Value = id;

           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           List<TeachersAppointInformationModel> list = null;
           if (dt.Rows.Count > 0)
           {
               TeachersAppointInformationModel model = null;
               list = new List<TeachersAppointInformationModel>();
               foreach (DataRow row in dt.Rows)
               {
                   model = new TeachersAppointInformationModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }  
       #endregion


       #region managersGetPagedList
       public List<Model.TeachersAppointInformationModel> managersGetPagedList(string TrainingBaseCode,string RealName, string ProfessionalBaseName,string DeptName,
           string AppointBeginTime, string AppointEndTime, string IsPass,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by register_date desc) as num,* from GP_Teachers_Appoint_Information where training_base_code like '%" + TrainingBaseCode + "%'";

           if (!string.IsNullOrEmpty(RealName))
           {
               sql += "and teachers_real_name like '%" + RealName + "%'";
           }
           if (!string.IsNullOrEmpty(ProfessionalBaseName))
           {
               sql += "and professional_base_name = '" + ProfessionalBaseName + "'";
           }
           if (!string.IsNullOrEmpty(DeptName))
           {
               sql += "and dept_name like '" + DeptName + "%'";
           }

           if (!string.IsNullOrEmpty(AppointBeginTime))
           {
               sql += "and appoint_begin_time = '" + AppointBeginTime + "'";
           }
           if (!string.IsNullOrEmpty(AppointEndTime))
           {
               sql += "and appoint_end_time = '" + AppointEndTime + "'";
           }
           if (!string.IsNullOrEmpty(IsPass))
           {
               sql += "and is_pass like '" + IsPass + "%'";
           }
           sql += ")as t where t.num>=@start and t.num<=@end";


           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<TeachersAppointInformationModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<TeachersAppointInformationModel>();
               TeachersAppointInformationModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new TeachersAppointInformationModel();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int managersGetRecordCount(string TrainingBaseCode, string RealName, string ProfessionalBaseName, string DeptName,
           string AppointBeginTime, string AppointEndTime, string IsPass)
       {
           string sql = "select count(*) from GP_Teachers_Appoint_Information where training_base_code like '%" + TrainingBaseCode+"%'";
           if (!string.IsNullOrEmpty(RealName))
           {
               sql += "and teachers_real_name like '%" + RealName + "%'";
           }
           if (!string.IsNullOrEmpty(ProfessionalBaseName))
           {
               sql += "and professional_base_name = '" + ProfessionalBaseName + "'";
           }
           if (!string.IsNullOrEmpty(DeptName))
           {
               sql += "and dept_name like '" + DeptName + "%'";
           }

           if (!string.IsNullOrEmpty(AppointBeginTime))
           {
               sql += "and appoint_begin_time = '" + AppointBeginTime + "'";
           }
           if (!string.IsNullOrEmpty(AppointEndTime))
           {
               sql += "and appoint_end_time = '" + AppointEndTime + "'";
           }
           if (!string.IsNullOrEmpty(IsPass))
           {
               sql += "and is_pass like '%" + IsPass + "%'";
           }

           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion


       #region UpdateByManager(TeachersAppointInformationModel model)
       public bool UpdateByManager(TeachersAppointInformationModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_Teachers_Appoint_Information set ");
           strSql.Append("id=@id,");
           strSql.Append("is_pass=@is_pass");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50),
					new SqlParameter("@is_pass", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.id;
           parameters[1].Value = model.is_pass;

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

       #region UpdateIsReceive(string  id,string isReceive)
       public bool UpdateIsReceive(string id, string isReceive)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_Teachers_Appoint_Information set ");
           strSql.Append("id=@id,");
           strSql.Append("IsReceive=@IsReceive");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50),
					new SqlParameter("@IsReceive", SqlDbType.NVarChar,50)};
           parameters[0].Value = id;
           parameters[1].Value = isReceive;

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
