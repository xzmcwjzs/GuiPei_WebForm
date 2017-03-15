using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
   public class LoginDAL
    {
        SqlHelper db = new SqlHelper();
        #region GetDataTable(LoginModel model)
        public DataTable GetDataTable(LoginModel model)
        {
            string sql = string.Format("select * from GP_Login where name=@name and password=@password");
            SqlParameter[] prams = { db.MakeInParam("@name",SqlDbType.NVarChar,50,model.name),
                                  db.MakeInParam("@password",SqlDbType.NVarChar,50,model.password)};
            DataTable dt = db.RunDataTable(sql, prams);
            return dt;
        }
        #endregion
        #region  UpdatePassword(string teachers_name, string teachers_password)
        public int UpdatePassword(string name, string password)
        {
            string sql = string.Format("update GP_Login set password=@password where name=@name");
            SqlParameter[] prams = { db.MakeInParam("@name",SqlDbType.NVarChar,50,name),
                                  db.MakeInParam("@password",SqlDbType.NVarChar,50,password)};
            int n = db.RunExecuteNonQuery(sql, prams);
            return n;
        }
        #endregion


        #region getTeachersNameList(string training_base_code,string professional_base_code, string type)
        public List<Model.LoginModel> getTeachersNameList(string training_base_code, string professional_base_code, string type)
        {
            List<Model.LoginModel> list = null;

            string sql = string.Format("select * from GP_Login where training_base_code=@training_base_code and professional_base_code=@professional_base_code and type like @type");
            SqlParameter[] prams = { db.MakeInParam("@training_base_code", SqlDbType.NVarChar, 50, training_base_code),
                                   db.MakeInParam("@professional_base_code", SqlDbType.NVarChar, 50, professional_base_code),
                                   db.MakeInParam("@type", SqlDbType.NVarChar, 50, "%"+type+"%")};

            DataTable dt = db.RunDataTable(sql, prams);
            if (dt.Rows.Count > 0)
            {
                list = new List<LoginModel>();
                LoginModel model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new LoginModel();
                    model.name = dr["name"].ToString();
                    model.real_name = dr["real_name"].ToString();
                    model.training_base_code = dr["training_base_code"].ToString();
                    model.training_base_name = dr["training_base_name"].ToString();
                    model.professional_base_code = dr["professional_base_code"].ToString();
                    model.professional_base_name = dr["professional_base_name"].ToString();
                    model.dept_code = dr["dept_code"].ToString();
                    model.dept_name = dr["dept_name"].ToString();

                    list.Add(model);
                }
            }
           return list;

        }
        #endregion


        #region getTeachersName(string training_base_code,string professional_base_code)
        public List<Model.LoginModel> getTeachersName(string training_base_code, string professional_base_code, string type,string real_name)
        {
            List<Model.LoginModel> list = new List<LoginModel>();

            string sql = string.Format("select * from GP_Login where training_base_code=@training_base_code and professional_base_code=@professional_base_code and type=@type and real_name=@real_name");
            SqlParameter[] prams = { db.MakeInParam("@training_base_code", SqlDbType.NVarChar, 50, training_base_code),
                                   db.MakeInParam("@professional_base_code", SqlDbType.NVarChar, 50, professional_base_code),
                                   db.MakeInParam("@type", SqlDbType.NVarChar, 50, type),
                                    db.MakeInParam("@real_name", SqlDbType.NVarChar, 50, real_name)};

            DataTable dt = db.RunDataTable(sql, prams);
            foreach (DataRow dr in dt.Rows)
            {
                Model.LoginModel model = new LoginModel();
                model.name = dr["name"].ToString();
                model.real_name = dr["real_name"].ToString();
                model.training_base_code = dr["training_base_code"].ToString();
                model.training_base_name = dr["training_base_name"].ToString();
                model.professional_base_code = dr["professional_base_code"].ToString();
                model.professional_base_name = dr["professional_base_name"].ToString();
                model.dept_code = dr["dept_code"].ToString();
                model.dept_name = dr["dept_name"].ToString();

                list.Add(model);
            }

            return list;

        }
        #endregion

        #region GetTeachersDtByDeptCode(string training_base_code, string professional_base_code,string dept_code, string type)
        public DataTable GetTeachersDtByDeptCode(string training_base_code, string professional_base_code, string dept_code, string type)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,name,password,real_name,training_base_name,training_base_code,professional_base_name,professional_base_code,dept_name,dept_code,type,LoginState,RegisterDate from GP_Login ");
            strSql.Append(" where dept_code=@dept_code and type like @type and training_base_code=@training_base_code and professional_base_code=@professional_base_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@dept_code", SqlDbType.NVarChar,50),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_code", SqlDbType.NVarChar,50)			};
            parameters[0].Value = dept_code;
            parameters[1].Value = "%" + type + "%";
            parameters[2].Value = training_base_code;
            parameters[3].Value = professional_base_code;
           
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
        public LoginModel DataRowToModel(DataRow row)
        {
            LoginModel model = new LoginModel();
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
                if (row["password"] != null)
                {
                    model.password = row["password"].ToString();
                }
                if (row["real_name"] != null)
                {
                    model.real_name = row["real_name"].ToString();
                }
                if (row["training_base_name"] != null)
                {
                    model.training_base_name = row["training_base_name"].ToString();
                }
                if (row["training_base_code"] != null)
                {
                    model.training_base_code = row["training_base_code"].ToString();
                }
                if (row["professional_base_name"] != null)
                {
                    model.professional_base_name = row["professional_base_name"].ToString();
                }
                if (row["professional_base_code"] != null)
                {
                    model.professional_base_code = row["professional_base_code"].ToString();
                }
                if (row["dept_name"] != null)
                {
                    model.dept_name = row["dept_name"].ToString();
                }
                if (row["dept_code"] != null)
                {
                    model.dept_code = row["dept_code"].ToString();
                }
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
                if (row["LoginState"] != null)
                {
                    model.LoginState = row["LoginState"].ToString();
                }
                if (row["RegisterDate"] != null)
                {
                    model.RegisterDate = row["RegisterDate"].ToString();
                }
            }
            return model;
        } 
        #endregion

        #region GetTeachersListByDeptCode( string training_base_code, string professional_base_code,string dept_code, string type)
        public List<LoginModel> GetTeachersListByDeptCode(string training_base_code, string professional_base_code, string dept_code, string type)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,name,password,real_name,training_base_name,training_base_code,professional_base_name,professional_base_code,dept_name,dept_code,type,LoginState,RegisterDate from GP_Login ");
            strSql.Append(" where dept_code=@dept_code and type like @type and training_base_code=@training_base_code and professional_base_code=@professional_base_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@dept_code", SqlDbType.NVarChar,50),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_code", SqlDbType.NVarChar,50)			};
            parameters[0].Value = dept_code;
            parameters[1].Value = "%"+type+"%";
            parameters[2].Value = training_base_code;
            parameters[3].Value = professional_base_code;

            DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
            List<LoginModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<LoginModel>();
                LoginModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new LoginModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        } 
        #endregion


        #region Add(LoginModel model)
        public bool Add(LoginModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GP_Login(");
            strSql.Append("id,name,password,real_name,training_base_name,training_base_code,professional_base_name,professional_base_code,dept_name,dept_code,type,LoginState,RegisterDate)");
            strSql.Append(" values (");
            strSql.Append("@id,@name,@password,@real_name,@training_base_name,@training_base_code,@professional_base_name,@professional_base_code,@dept_name,@dept_code,@type,@LoginState,@RegisterDate)");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.NVarChar,50),
                    new SqlParameter("@name", SqlDbType.NVarChar,50),
                    new SqlParameter("@password", SqlDbType.NVarChar,50),
                    new SqlParameter("@real_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@training_base_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@training_base_code", SqlDbType.NVarChar,50),
                    new SqlParameter("@professional_base_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@professional_base_code", SqlDbType.NVarChar,50),
                    new SqlParameter("@dept_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@dept_code", SqlDbType.NVarChar,50),
                    new SqlParameter("@type", SqlDbType.NVarChar,50),
                    new SqlParameter("@LoginState", SqlDbType.NVarChar,50),
                    new SqlParameter("@RegisterDate", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.name;
            parameters[2].Value = model.password;
            parameters[3].Value = model.real_name;
            parameters[4].Value = model.training_base_name;
            parameters[5].Value = model.training_base_code;
            parameters[6].Value = model.professional_base_name;
            parameters[7].Value = model.professional_base_code;
            parameters[8].Value = model.dept_name;
            parameters[9].Value = model.dept_code;
            parameters[10].Value = model.type;
            parameters[11].Value = model.LoginState;
            parameters[12].Value = model.RegisterDate;

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

        #region GetModelByName(string name)
        public LoginModel GetModelByName(string name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,password,real_name,training_base_name,training_base_code,professional_base_name,professional_base_code,dept_name,dept_code,type,LoginState,RegisterDate from GP_Login ");
            strSql.Append(" where name=@name ");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50)			};
            parameters[0].Value = name;

            LoginModel model = new LoginModel();
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

        #region 分页
        public List<Model.LoginModel> GetPagedList(string TrainingBaseCode, string RealName,
            string Type, string RegisterDate, 
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_Login where training_base_code like '%" + TrainingBaseCode + "%'";

            if (!string.IsNullOrEmpty(RealName))
            {
                sql += "and real_name = '" + RealName + "'";
            }
            if (!string.IsNullOrEmpty(Type))
            {
                sql += "and type like '%" + Type + "%'";
            }
            if (!string.IsNullOrEmpty(RegisterDate))
            {
                sql += "and RegisterDate = '" + RegisterDate + "'";
            }
            
            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<LoginModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<LoginModel>();
                LoginModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new LoginModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int GetRecordCount(string TrainingBaseCode, string RealName,
            string Type, string RegisterDate)
        {
            string sql = "select count(*) from GP_Login where training_base_code like '%" + TrainingBaseCode + "%'";
            if (!string.IsNullOrEmpty(RealName))
            {
                sql += "and real_name = '" + RealName + "'";
            }
            if (!string.IsNullOrEmpty(Type))
            {
                sql += "and type like '%" + Type + "%'";
            }
            if (!string.IsNullOrEmpty(RegisterDate))
            {
                sql += "and RegisterDate = '" + RegisterDate + "'";
            }
            return Convert.ToInt32(db.RunExecuteScalar(sql));
        }
        #endregion


        #region UpdateLoginState(LoginModel model)
        public bool UpdateLoginState(LoginModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GP_Login set ");
            strSql.Append("id=@id,");
            strSql.Append("LoginState=@LoginState");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50),
					new SqlParameter("@LoginState", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.LoginState;

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

        #region GetPassword(string name, string real_name)
        public DataTable GetPassword(string name, string real_name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 password from GP_Login ");
            strSql.Append(" where name=@name and real_name=@real_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@real_name", SqlDbType.NVarChar,50)			};
            parameters[0].Value = name;
            parameters[1].Value = real_name;

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
