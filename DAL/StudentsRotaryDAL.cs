using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public class StudentsRotaryDAL
    {
       SqlHelper db = new SqlHelper();
       #region InsertStudentsRotary(StudentsRotaryModel model)
       public bool InsertStudentsRotary(StudentsRotaryModel model) {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_Students_Rotary(");
           strSql.Append("id,name,real_name,rotary_begin_time,rotary_end_time,training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name,instructor,instructor_tag,register_date,writor,outdept_status,outdept_application,questionnaire_status)");
           strSql.Append(" values (");
           strSql.Append("@id,@name,@real_name,@rotary_begin_time,@rotary_end_time,@training_base_code,@training_base_name,@professional_base_code,@professional_base_name,@rotary_dept_code,@rotary_dept_name,@instructor,@instructor_tag,@register_date,@writor,@outdept_status,@outdept_application,@questionnaire_status)");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@real_name", SqlDbType.NVarChar,50),
					new SqlParameter("@rotary_begin_time", SqlDbType.NVarChar,50),
					new SqlParameter("@rotary_end_time", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@rotary_dept_code", SqlDbType.NVarChar,50),
					new SqlParameter("@rotary_dept_name", SqlDbType.NVarChar,500),
					new SqlParameter("@instructor", SqlDbType.NVarChar,50),
                    new SqlParameter("@instructor_tag",SqlDbType.NVarChar,50),
					new SqlParameter("@register_date", SqlDbType.Date,50),
					new SqlParameter("@writor", SqlDbType.NVarChar,50),
                    new SqlParameter("@outdept_status", SqlDbType.NVarChar,50),
                    new SqlParameter("@outdept_application",SqlDbType.NVarChar,50),
                    new SqlParameter("@questionnaire_status",SqlDbType.NVarChar,50)};

           parameters[0].Value = model.id;
           parameters[1].Value = model.name;
           parameters[2].Value = model.real_name;
           parameters[3].Value = model.rotary_begin_time;
           parameters[4].Value = model.rotary_end_time;
           parameters[5].Value = model.training_base_code;
           parameters[6].Value = model.training_base_name;
           parameters[7].Value = model.professional_base_code;
           parameters[8].Value = model.professional_base_name;
           parameters[9].Value = model.rotary_dept_code;
           parameters[10].Value = model.rotary_dept_name;
           parameters[11].Value = model.instructor;
           parameters[12].Value = model.instructor_tag;
           parameters[13].Value = model.register_date;
           parameters[14].Value = model.writor;
           parameters[15].Value = model.outdept_status;
           parameters[16].Value = model.outdept_application;
           parameters[17].Value = model.questionnaire_status;

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

       #region  getRotaryTimeList(string name,string training_base_code,string professional_base_code)
       public List<Model.StudentsRotaryModel> getRotaryTimeList(string name,string training_base_code,string professional_base_code)
       {
           List<Model.StudentsRotaryModel> list = new List<StudentsRotaryModel>();

           string sql = string.Format("select top 1 * from GP_Students_Rotary where name=@name and training_base_code=@training_base_code and professional_base_code=@professional_base_code order by register_date desc ");

           SqlParameter[] prams = { db.MakeInParam("@name", SqlDbType.NVarChar, 50, name),
                                  db.MakeInParam("@training_base_code", SqlDbType.NVarChar, 50, training_base_code),
                                 db.MakeInParam("@professional_base_code", SqlDbType.NVarChar, 50, professional_base_code)
                                  };

           DataTable dt = db.RunDataTable(sql, prams);
           foreach (DataRow dr in dt.Rows)
           {
               Model.StudentsRotaryModel model = new StudentsRotaryModel();
               model.rotary_begin_time =dr["rotary_begin_time"].ToString();
               model.rotary_end_time =dr["rotary_end_time"].ToString();
               model.register_date =dr["register_date"].ToString();

               list.Add(model);
           }

           return list;


       }
       #endregion

       #region GetPagedList(string students_name,string training_base_code, int pageIndex, int pageSize, out int rowCount, out int pageCount)
       /// <summary>
       /// 获得分页数据并输出总行数和总页数
       /// </summary>
       /// <param name="pageIndex"></param>
       /// <param name="pageSize"></param>
       /// <param name="rowCount"></param>
       /// <param name="pageCount"></param>
       /// <returns></returns>
       public List<Model.StudentsRotaryModel> GetPagedList(string students_name,string training_base_code, 
          string rotary_dept,string instructor,string rotary_begin_time,string rotary_end_time,
           int pageIndex, int pageSize, out int rowCount, out int pageCount)
       {

           List<Model.StudentsRotaryModel> list = null;
           DataTable dt=new DataTable();

           if (!string.IsNullOrEmpty(rotary_dept) && string.IsNullOrEmpty(instructor) && string.IsNullOrEmpty(rotary_begin_time) && string.IsNullOrEmpty(rotary_end_time))
           {
               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
              "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
              "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code + 
              "'and rotary_dept_code='" + rotary_dept + "'"
               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);
           }
           else if (string.IsNullOrEmpty(rotary_dept) && !string.IsNullOrEmpty(instructor) && string.IsNullOrEmpty(rotary_begin_time) && string.IsNullOrEmpty(rotary_end_time))
           {
               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
              "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
              "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code +
              "'and instructor like '%" + instructor + "%'"
               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);
           
           }
           else if (string.IsNullOrEmpty(rotary_dept) && string.IsNullOrEmpty(instructor) && !string.IsNullOrEmpty(rotary_begin_time) && string.IsNullOrEmpty(rotary_end_time))
           {
               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
              "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
              "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code +
              "'and rotary_begin_time>='" + rotary_begin_time + "'"
               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

           }
           else if (string.IsNullOrEmpty(rotary_dept) && string.IsNullOrEmpty(instructor) && string.IsNullOrEmpty(rotary_begin_time) && !string.IsNullOrEmpty(rotary_end_time))
           {
               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
              "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
              "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code +
              "'and rotary_end_time<='" + rotary_end_time + "'"
               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

           }
           else if (!string.IsNullOrEmpty(rotary_dept) && !string.IsNullOrEmpty(instructor) && string.IsNullOrEmpty(rotary_begin_time) && string.IsNullOrEmpty(rotary_end_time))
           {
               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
              "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
              "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code +
              "'and rotary_dept_code='" + rotary_dept + "'and instructor like '%"+instructor+"%'"
               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

           }
           else if (!string.IsNullOrEmpty(rotary_dept) && string.IsNullOrEmpty(instructor) && !string.IsNullOrEmpty(rotary_begin_time) && string.IsNullOrEmpty(rotary_end_time))
           {
               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
              "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
              "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code +
              "'and rotary_dept_code='" + rotary_dept + "'and rotary_begin_time>='" + rotary_begin_time + "'"
               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

           }
           else if (!string.IsNullOrEmpty(rotary_dept) && string.IsNullOrEmpty(instructor) && string.IsNullOrEmpty(rotary_begin_time) && !string.IsNullOrEmpty(rotary_end_time))
           {
               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
              "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
              "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code +
              "'and rotary_dept_code='" + rotary_dept + "'and rotary_end_time<='" + rotary_end_time + "'"
               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

           }
           else if (string.IsNullOrEmpty(rotary_dept) && !string.IsNullOrEmpty(instructor) && !string.IsNullOrEmpty(rotary_begin_time) && string.IsNullOrEmpty(rotary_end_time))
           {
               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
              "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
              "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code +
              "'and instructor like '%" + instructor + "%'and rotary_begin_time>='" + rotary_begin_time + "'"
               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

           }
           else if (string.IsNullOrEmpty(rotary_dept) && !string.IsNullOrEmpty(instructor) && string.IsNullOrEmpty(rotary_begin_time) && !string.IsNullOrEmpty(rotary_end_time))
           {
               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
              "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
              "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code +
              "'and instructor like '%" + instructor + "%'and rotary_end_time<='" + rotary_end_time + "'"
               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

           }
               //rotary_begin_time  rotary_end_time/ok
           else if (string.IsNullOrEmpty(rotary_dept) && string.IsNullOrEmpty(instructor) && !string.IsNullOrEmpty(rotary_begin_time) && !string.IsNullOrEmpty(rotary_end_time))
           {
               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
              "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
              "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code +
              "'and (rotary_begin_time>='" + rotary_begin_time + "'and rotary_begin_time<='" + rotary_end_time + "') or (rotary_end_time<='"+rotary_end_time+"'and rotary_end_time>='"+rotary_begin_time+"')"
               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

           }
           //rotary_dept_code  instructor  rotary_begin_time/ok
           else if (!string.IsNullOrEmpty(rotary_dept) && !string.IsNullOrEmpty(instructor) && !string.IsNullOrEmpty(rotary_begin_time) && string.IsNullOrEmpty(rotary_end_time))
           {
               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
              "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
              "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code +
              "'and rotary_dept_code='" + rotary_dept + "'and instructor like '%" + instructor + "%' and rotary_begin_time>='"+rotary_begin_time+"'"
               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

           }
           //rotary_dept_code  instructor  rotary_end_time/ok
           else if (!string.IsNullOrEmpty(rotary_dept) && !string.IsNullOrEmpty(instructor) && string.IsNullOrEmpty(rotary_begin_time) && !string.IsNullOrEmpty(rotary_end_time))
           {
               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
              "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
              "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code +
              "'and rotary_dept_code='" + rotary_dept + "'and instructor like '%" + instructor + "%' and rotary_end_time<='" + rotary_end_time + "'"
               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

           }
           //rotary_dept_code  rotary_begin_time  rotary_begin_time/ok
           else if (!string.IsNullOrEmpty(rotary_dept) && string.IsNullOrEmpty(instructor) && !string.IsNullOrEmpty(rotary_begin_time) && !string.IsNullOrEmpty(rotary_end_time))
           {
               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
              "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
              "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code +
              "'and rotary_dept_code='"+rotary_dept+"'and ((rotary_begin_time>='" + rotary_begin_time + "'and rotary_begin_time<='" + rotary_end_time + "') or (rotary_end_time<='" + rotary_end_time + "'and rotary_end_time>='" + rotary_begin_time + "'))"
               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

           }
           else if (string.IsNullOrEmpty(rotary_dept) && !string.IsNullOrEmpty(instructor) && !string.IsNullOrEmpty(rotary_begin_time) && !string.IsNullOrEmpty(rotary_end_time))
           {
               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
              "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
              "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code +
              "'and instructor like '%" + instructor + "%' and ((rotary_begin_time>='" + rotary_begin_time + "'and rotary_begin_time<='" + rotary_end_time + "') or (rotary_end_time<='" + rotary_end_time + "'and rotary_end_time>='" + rotary_begin_time + "'))"
               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

           }
           else if (!string.IsNullOrEmpty(rotary_dept) && !string.IsNullOrEmpty(instructor) && !string.IsNullOrEmpty(rotary_begin_time) && !string.IsNullOrEmpty(rotary_end_time))
           {
               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
              "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
              "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code +
              "'and rotary_dept_code='"+rotary_dept+"' and instructor like '%" + instructor + "%' and ((rotary_begin_time>='" + rotary_begin_time + "'and rotary_begin_time<='" + rotary_end_time + "') or (rotary_end_time<='" + rotary_end_time + "'and rotary_end_time>='" + rotary_begin_time + "'))"
               , "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

           }

          else {

               dt = db.RunPagedDataPro("GetPageList", "id,name,real_name,rotary_begin_time,rotary_end_time," +
               "training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name," +
               "instructor,instructor_tag,writor,register_date,outdept_status,outdept_application,questionnaire_status", "GP_Students_Rotary", "name='" + students_name + "' and training_base_code='" + training_base_code
               + "'", "register_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);
             }
           

           //将数据表转为泛型集合
           if (dt.Rows.Count > 0)
           {
               list = new List<StudentsRotaryModel>();
               Model.StudentsRotaryModel model = null;//声明实体对象
               foreach (DataRow dr in dt.Rows)
               {
                   model = new Model.StudentsRotaryModel();
                   model.id = dr["id"].ToString();
                   model.name = dr["name"].ToString();
                   model.real_name = dr["real_name"].ToString();

                   model.rotary_begin_time = dr["rotary_begin_time"].ToString();
                   model.rotary_end_time = dr["rotary_end_time"].ToString();

                   model.training_base_code = dr["training_base_code"].ToString();
                   model.training_base_name = dr["training_base_name"].ToString();
                  
                   model.professional_base_code = dr["professional_base_code"].ToString();
                   model.professional_base_name = dr["professional_base_name"].ToString();

                   model.rotary_dept_code = dr["rotary_dept_code"].ToString();
                   model.rotary_dept_name = dr["rotary_dept_name"].ToString();
                   model.instructor = dr["instructor"].ToString();
                   model.instructor_tag = dr["instructor_tag"].ToString();
                   model.writor = dr["writor"].ToString();
                   model.register_date = dr["register_date"].ToString();
                   model.outdept_status = dr["outdept_status"].ToString();
                   model.outdept_application = dr["outdept_application"].ToString();
                   model.questionnaire_status = dr["questionnaire_status"].ToString();
                   list.Add(model);
               }
           }
           return list;
       }
       #endregion

       #region  Model.StudentsRotaryModel GetModelById(string id)
       public Model.StudentsRotaryModel GetModelById(string id) {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select id,name,real_name,rotary_begin_time,rotary_end_time,training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name,instructor,instructor_tag,outdept_status,questionnaire_status,outdept_application,register_date,writor from GP_Students_Rotary ");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50)			};
           parameters[0].Value = id;

           Model.StudentsRotaryModel model= new Model.StudentsRotaryModel();
           DataSet ds = db.RunDataSet(strSql.ToString(), parameters,"tbName");
           if (ds.Tables[0].Rows.Count > 0)
           {
               return DataRowToModel(ds.Tables[0].Rows[0]);
           }
           else
           {
               return null;
           }
       }
       public Model.StudentsRotaryModel DataRowToModel(DataRow row)
       {
           Model.StudentsRotaryModel model = new Model.StudentsRotaryModel();
           if (row != null)
           {
               if (row["id"] != null)
               {
                   model.id = row["id"].ToString();
               }
               if (row["name"] != null)
               {
                   model.name = row["name"].ToString();
               }
               if (row["real_name"] != null)
               {
                   model.real_name = row["real_name"].ToString();
               }
               if (row["rotary_begin_time"] != null)
               {
                   model.rotary_begin_time = row["rotary_begin_time"].ToString();
               }
               if (row["rotary_end_time"] != null)
               {
                   model.rotary_end_time = row["rotary_end_time"].ToString();
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
               if (row["rotary_dept_code"] != null)
               {
                   model.rotary_dept_code = row["rotary_dept_code"].ToString();
               }
               if (row["rotary_dept_name"] != null)
               {
                   model.rotary_dept_name = row["rotary_dept_name"].ToString();
               }
               if (row["instructor"] != null)
               {
                   model.instructor = row["instructor"].ToString();
               }
               if (row["instructor_tag"] != null)
               {
                   model.instructor_tag = row["instructor_tag"].ToString();
               }
               if (row["register_date"] != null)
               {
                   model.register_date = row["register_date"].ToString();
               }
               if (row["writor"] != null)
               {
                   model.writor = row["writor"].ToString();
               }
               if (row["outdept_status"] != null)
               {
                   model.outdept_status = row["outdept_status"].ToString();
               }
               if (row["outdept_application"] != null)
               {
                   model.outdept_application = row["outdept_application"].ToString();
               }
               if (row["questionnaire_status"] != null)
               {
                   model.questionnaire_status = row["questionnaire_status"].ToString();
               }
           }
           return model;
       }

       #endregion

       #region  UpdateRotary(Model.StudentsRotaryModel model)

       public bool UpdateRotary(Model.StudentsRotaryModel model,string id)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_Students_Rotary set ");
           strSql.Append("rotary_begin_time=@rotary_begin_time,");
           strSql.Append("rotary_end_time=@rotary_end_time,");
           strSql.Append("rotary_dept_code=@rotary_dept_code,");
           strSql.Append("rotary_dept_name=@rotary_dept_name,");
           strSql.Append("instructor=@instructor,");
           strSql.Append("instructor_tag=@instructor_tag,");
           strSql.Append("writor=@writor");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@rotary_begin_time", SqlDbType.NVarChar,50),
					new SqlParameter("@rotary_end_time", SqlDbType.NVarChar,50),
					new SqlParameter("@rotary_dept_code", SqlDbType.NVarChar,50),
					new SqlParameter("@rotary_dept_name", SqlDbType.NVarChar,500),
					new SqlParameter("@instructor", SqlDbType.NVarChar,50),
                    new SqlParameter("@instructor_tag", SqlDbType.NVarChar,50),
					new SqlParameter("@writor", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.NVarChar,50)};
         
           parameters[0].Value = model.rotary_begin_time;
           parameters[1].Value = model.rotary_end_time;
           parameters[2].Value = model.rotary_dept_code;
           parameters[3].Value = model.rotary_dept_name;
           parameters[4].Value = model.instructor;
           parameters[5].Value = model.instructor_tag;
           parameters[6].Value = model.writor;
           parameters[7].Value = id;

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

       #region  UpdateQuestStatus(string status)
       public bool UpdateQuestStatus(string status,string id)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_Students_Rotary set ");
           strSql.Append("questionnaire_status=@questionnaire_status");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@questionnaire_status", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.NVarChar,50)};
           parameters[0].Value = status;
           parameters[1].Value = id;

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

       #region  GetApplication(string id)
       public string  GetApplication(string id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select outdept_application from GP_Students_Rotary ");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50)};
           parameters[0].Value = id;
           DataTable dt = new DataTable();
           dt = db.RunDataTable(strSql.ToString(),parameters);

           if (dt.Rows.Count > 0)
           {
               return dt.Rows[0][0].ToString();
           }
           else
           {
               return null;
           }
       }
       #endregion
       #region
       public bool UpdateApplication(string appli,string id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_Students_Rotary set ");
           strSql.Append("outdept_application=@outdept_application");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@outdept_application", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.NVarChar,50)};
           parameters[0].Value =appli;
           parameters[1].Value = id;

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

       #region  GetQuestionnaire(string id)
       public string GetQuestionnaire(string id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select questionnaire_status from GP_Students_Rotary ");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50)};
           parameters[0].Value = id;
           DataTable dt = new DataTable();
           dt = db.RunDataTable(strSql.ToString(), parameters);

           if (dt.Rows.Count > 0)
           {
               return dt.Rows[0][0].ToString();
           }
           else
           {
               return null;
           }
       }
       #endregion

       #region GetDtByNT(string name, string training_base_code)
       public DataTable GetDtByNT(string name, string training_base_code)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  id,name,real_name,rotary_begin_time,rotary_end_time,training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name,instructor,instructor_tag,register_date,writor,outdept_status,outdept_application,questionnaire_status from GP_Students_Rotary ");
           strSql.Append(" where name=@name and training_base_code=@training_base_code ");
           SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_code", SqlDbType.NVarChar,50)			};
           parameters[0].Value = name;
           parameters[1].Value = training_base_code;

           DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
           return dt;
       } 
       #endregion


       #region UpdateOutdeptStatusByT(StudentsRotaryModel model)
       public bool UpdateOutdeptStatusByT(string status,string id)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_Students_Rotary set ");
           strSql.Append("outdept_status=@outdept_status");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@outdept_status", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.NVarChar,50)};
           parameters[0].Value = status;
           parameters[1].Value = id;

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
