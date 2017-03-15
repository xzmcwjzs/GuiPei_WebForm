using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class InDeptFellingDAL
    {

        SqlHelper db = new SqlHelper();
        #region GetModelById(string id) 
        public Model.InDeptFellingModel GetModelById(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,name,real_name,training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name,indept_felling,register_date,writor,teacher_status,kzr_status,base_status,manager_status,TeacherId,TeacherName from GP_InDept_Felling ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50)			};
            parameters[0].Value = id;

            InDeptFellingModel model = new InDeptFellingModel();
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
        #endregion
        #region DataRowToModel(DataRow row)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.InDeptFellingModel DataRowToModel(DataRow row)
        {
            Model.InDeptFellingModel model = new Model.InDeptFellingModel();
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
                if (row["indept_felling"] != null)
                {
                    model.indept_felling = row["indept_felling"].ToString();
                }
                if (row["register_date"] != null)
                {
                    model.register_date = row["register_date"].ToString();
                }
                if (row["writor"] != null)
                {
                    model.writor = row["writor"].ToString();
                }
                if (row["teacher_status"] != null)
                {
                    model.teacher_status = row["teacher_status"].ToString();
                }
                if (row["kzr_status"] != null)
                {
                    model.kzr_status = row["kzr_status"].ToString();
                }
                if (row["base_status"] != null)
                {
                    model.base_status = row["base_status"].ToString();
                }
                if (row["manager_status"] != null)
                {
                    model.manager_status = row["manager_status"].ToString();
                }
                if (row["TeacherId"] != null)
                {
                    model.TeacherId = row["TeacherId"].ToString();
                }
                if (row["TeacherName"] != null)
                {
                    model.TeacherName = row["TeacherName"].ToString();
                }
            }
            return model;
        } 
        #endregion

        #region InsertDeptFelling(InDeptFellingModel model)
        public bool InsertDeptFelling(InDeptFellingModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GP_InDept_Felling(");
            strSql.Append("id,name,real_name,training_base_code,training_base_name,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name,indept_felling,register_date,writor,teacher_status,kzr_status,base_status,manager_status,TeacherId,TeacherName)");
            strSql.Append(" values (");
            strSql.Append("@id,@name,@real_name,@training_base_code,@training_base_name,@professional_base_code,@professional_base_name,@rotary_dept_code,@rotary_dept_name,@indept_felling,@register_date,@writor,@teacher_status,@kzr_status,@base_status,@manager_status,@TeacherId,@TeacherName)");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@real_name", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@rotary_dept_code", SqlDbType.NVarChar,50),
					new SqlParameter("@rotary_dept_name", SqlDbType.NVarChar,50),
					new SqlParameter("@indept_felling", SqlDbType.NVarChar,1000),
					new SqlParameter("@register_date", SqlDbType.NVarChar,50),
					new SqlParameter("@writor", SqlDbType.NVarChar,50),
					new SqlParameter("@teacher_status", SqlDbType.NVarChar,50),
					new SqlParameter("@kzr_status", SqlDbType.NVarChar,50),
					new SqlParameter("@base_status", SqlDbType.NVarChar,50),
					new SqlParameter("@manager_status", SqlDbType.NVarChar,50),
                                        new SqlParameter("@TeacherId", SqlDbType.NVarChar,50),
                                        new SqlParameter("@TeacherName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.name;
            parameters[2].Value = model.real_name;
            parameters[3].Value = model.training_base_code;
            parameters[4].Value = model.training_base_name;
            parameters[5].Value = model.professional_base_code;
            parameters[6].Value = model.professional_base_name;
            parameters[7].Value = model.rotary_dept_code;
            parameters[8].Value = model.rotary_dept_name;
            parameters[9].Value = model.indept_felling;
            parameters[10].Value = model.register_date;
            parameters[11].Value = model.writor;
            parameters[12].Value = model.teacher_status;
            parameters[13].Value = model.kzr_status;
            parameters[14].Value = model.base_status;
            parameters[15].Value = model.manager_status;
            parameters[16].Value = model.TeacherId;
            parameters[17].Value = model.TeacherName;


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

        #region UpdateDeptFelling(Model.InDeptFellingModel model, string id)
        public bool UpdateDeptFelling(InDeptFellingModel model, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GP_InDept_Felling set ");
            strSql.Append("rotary_dept_code=@rotary_dept_code,");
            strSql.Append("rotary_dept_name=@rotary_dept_name,");
            strSql.Append("indept_felling=@indept_felling,");
            strSql.Append("writor=@writor,");
            strSql.Append("register_date=@register_date,");
            strSql.Append("TeacherId=@TeacherId,");
            strSql.Append("TeacherName=@TeacherName");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@rotary_dept_code", SqlDbType.NVarChar,50),
					new SqlParameter("@rotary_dept_name", SqlDbType.NVarChar,50),
					new SqlParameter("@indept_felling", SqlDbType.NVarChar,1000),
					new SqlParameter("@writor", SqlDbType.NVarChar,50),
                    new SqlParameter("@register_date", SqlDbType.NVarChar,50),
                    new SqlParameter("@TeacherId", SqlDbType.NVarChar,50),
                    new SqlParameter("@TeacherName", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.NVarChar,50)
                                        };

            parameters[0].Value = model.rotary_dept_code;
            parameters[1].Value = model.rotary_dept_name;
            parameters[2].Value = model.indept_felling;

            parameters[3].Value = model.writor;
            parameters[4].Value = model.register_date;
            parameters[5].Value = model.TeacherId; parameters[6].Value = model.TeacherName;
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

        #region 分页
        public List<Model.InDeptFellingModel> GetPagedList(string students_name, string training_base_code, string rotary_dept,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by register_date desc) as num,* from GP_InDept_Felling where name='" + students_name + "' and training_base_code='" + training_base_code + "'";

            if (!string.IsNullOrEmpty(rotary_dept))
            {
                sql += "and rotary_dept_name like '%" + rotary_dept + "%')as t where t.num>=@start and t.num<=@end";
            }
            else
            {
                sql += ")as t where t.num>=@start and t.num<=@end";
            }

            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<InDeptFellingModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<InDeptFellingModel>();
                InDeptFellingModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new InDeptFellingModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int GetRecordCount(string name, string training_base_code, string rotary_dept)
        {
            string sql = "select count(*) from GP_InDept_Felling where training_base_code='" + training_base_code
                + "' and name='" + name + "'";
            if (!string.IsNullOrEmpty(rotary_dept))
            {
                sql += "and rotary_dept_name like '%" + rotary_dept + "%'";
            }
            return Convert.ToInt32(db.RunExecuteScalar(sql));
        } 
        #endregion
        #region Common分页
        public List<Model.InDeptFellingModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName,string TeachersRealName,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by register_date desc) as num,* from GP_InDept_Felling where training_base_code like '%" + TrainingBaseCode + "%'";
            if (!string.IsNullOrEmpty(StudentsRealName))
            {
                sql += "and real_name like '%" + StudentsRealName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseCode))
            {
                sql += "and professional_base_code like '%" + ProfessionalBaseCode + "%'";
            }
            if (!string.IsNullOrEmpty(DeptCode))
            {
                sql += "and rotary_dept_code like '%" + DeptCode + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersName))
            {
                sql += "and TeacherId like '%" + TeachersName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseName))
            {
                sql += "and professional_base_name like '%" + ProfessionalBaseName + "%'";
            }
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and rotary_dept_name like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersRealName))
            {
                sql += "and TeacherName like '%" + TeachersRealName + "%'";
            }
            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<InDeptFellingModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<InDeptFellingModel>();
                InDeptFellingModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new InDeptFellingModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName)
        {
            string sql = "select count(*) from GP_InDept_Felling where training_base_code like '%" + TrainingBaseCode + "%'";
            if (!string.IsNullOrEmpty(StudentsRealName))
            {
                sql += "and real_name like '%" + StudentsRealName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseCode))
            {
                sql += "and professional_base_code like '%" + ProfessionalBaseCode + "%'";
            }
            if (!string.IsNullOrEmpty(DeptCode))
            {
                sql += "and rotary_dept_code like '%" + DeptCode + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersName))
            {
                sql += "and TeacherId like '%" + TeachersName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseName))
            {
                sql += "and professional_base_name like '%" + ProfessionalBaseName + "%'";
            }
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and rotary_dept_name like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(TeachersRealName))
            {
                sql += "and TeacherName like '%" + TeachersRealName + "%'";
            }
            return Convert.ToInt32(db.RunExecuteScalar(sql));
        }
        #endregion
        #region UpdateCheckByTeacher(InDeptFellingModel model)
        public bool UpdateCheckByTeacher(InDeptFellingModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GP_InDept_Felling set ");
            strSql.Append("teacher_status=@teacher_status");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@teacher_status", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.teacher_status;
            parameters[1].Value = model.id;

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
