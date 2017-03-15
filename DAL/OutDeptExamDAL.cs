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
    public class OutDeptExamDAL
    {
        SqlHelper db = new SqlHelper();
        #region Insert
        public bool Insert(Model.OutDeptExamModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into GP_OutDept_Exam(");
			strSql.Append("id,students_name,students_real_name,sex,training_base_code,training_base_name,high_education,high_education_time,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name,rotary_begin_time,rotary_end_time,instructor,instructor_tag,kqqk,gztd,ydyf,llsp,zdzx,blsx,clbrnl,sjcznl,czjn,zdsp,djnl,total_score,instructor_date,is_pass,dept_manager,dept_manager_date)");
			strSql.Append(" values (");
			strSql.Append("@id,@students_name,@students_real_name,@sex,@training_base_code,@training_base_name,@high_education,@high_education_time,@professional_base_code,@professional_base_name,@rotary_dept_code,@rotary_dept_name,@rotary_begin_time,@rotary_end_time,@instructor,@instructor_tag,@kqqk,@gztd,@ydyf,@llsp,@zdzx,@blsx,@clbrnl,@sjcznl,@czjn,@zdsp,@djnl,@total_score,@instructor_date,@is_pass,@dept_manager,@dept_manager_date)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50),
					new SqlParameter("@students_name", SqlDbType.NVarChar,50),
					new SqlParameter("@students_real_name", SqlDbType.NVarChar,50),
					new SqlParameter("@sex", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@high_education", SqlDbType.NVarChar,50),
					new SqlParameter("@high_education_time", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@rotary_dept_code", SqlDbType.NVarChar,50),
					new SqlParameter("@rotary_dept_name", SqlDbType.NVarChar,50),
					new SqlParameter("@rotary_begin_time", SqlDbType.NVarChar,50),
					new SqlParameter("@rotary_end_time", SqlDbType.NVarChar,50),
					new SqlParameter("@instructor", SqlDbType.NVarChar,50),
					new SqlParameter("@instructor_tag", SqlDbType.NVarChar,50),
					new SqlParameter("@kqqk", SqlDbType.NVarChar,10),
					new SqlParameter("@gztd", SqlDbType.NVarChar,10),
					new SqlParameter("@ydyf", SqlDbType.NVarChar,10),
					new SqlParameter("@llsp", SqlDbType.NVarChar,10),
					new SqlParameter("@zdzx", SqlDbType.NVarChar,10),
					new SqlParameter("@blsx", SqlDbType.NVarChar,10),
					new SqlParameter("@clbrnl", SqlDbType.NVarChar,10),
					new SqlParameter("@sjcznl", SqlDbType.NVarChar,10),
					new SqlParameter("@czjn", SqlDbType.NVarChar,10),
					new SqlParameter("@zdsp", SqlDbType.NVarChar,10),
					new SqlParameter("@djnl", SqlDbType.NVarChar,10),
					new SqlParameter("@total_score", SqlDbType.NVarChar,10),
					new SqlParameter("@instructor_date", SqlDbType.NVarChar,50),
					new SqlParameter("@is_pass", SqlDbType.NVarChar,10),
					new SqlParameter("@dept_manager", SqlDbType.NVarChar,50),
					new SqlParameter("@dept_manager_date", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.students_name;
			parameters[2].Value = model.students_real_name;
			parameters[3].Value = model.sex;
			parameters[4].Value = model.training_base_code;
			parameters[5].Value = model.training_base_name;
			parameters[6].Value = model.high_education;
			parameters[7].Value = model.high_education_time;
			parameters[8].Value = model.professional_base_code;
			parameters[9].Value = model.professional_base_name;
			parameters[10].Value = model.rotary_dept_code;
			parameters[11].Value = model.rotary_dept_name;
			parameters[12].Value = model.rotary_begin_time;
			parameters[13].Value = model.rotary_end_time;
			parameters[14].Value = model.instructor;
			parameters[15].Value = model.instructor_tag;
			parameters[16].Value = model.kqqk;
			parameters[17].Value = model.gztd;
			parameters[18].Value = model.ydyf;
			parameters[19].Value = model.llsp;
			parameters[20].Value = model.zdzx;
			parameters[21].Value = model.blsx;
			parameters[22].Value = model.clbrnl;
			parameters[23].Value = model.sjcznl;
			parameters[24].Value = model.czjn;
			parameters[25].Value = model.zdsp;
			parameters[26].Value = model.djnl;
			parameters[27].Value = model.total_score;
			parameters[28].Value = model.instructor_date;
			parameters[29].Value = model.is_pass;
			parameters[30].Value = model.dept_manager;
			parameters[31].Value = model.dept_manager_date;

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

        #region SelectRotaryTimeModel

        public Model.OutDeptExamModel SelectRotaryTimeModel(string students_name, string training_base_code, string rotary_dept_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from GP_OutDept_Exam ");
            strSql.Append(" where rotary_dept_code=@rotary_dept_code and students_name=@students_name and training_base_code=@training_base_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@rotary_dept_code", SqlDbType.NVarChar,50),
					new SqlParameter("@students_name", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_code", SqlDbType.NVarChar,50)			};
            parameters[0].Value = rotary_dept_code;
            parameters[1].Value = students_name;
            parameters[2].Value = training_base_code;

            OutDeptExamModel model = new OutDeptExamModel();
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

        #region GetListExam
        public DataTable GetListExam(string training_base_code, string rotary_dept_code, string instructor, string instructor_tag, string students_name, string rotary_begin_time, string rotary_end_time, string total_score, string is_pass, int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {//students_name,rotary_begin_time,rotary_end_time,total_score,is_pass,
            //+ "and rotary_begin_time like isnull('%" + rotary_begin_time + "%',rotary_begin_time) and rotary_end_time like isnull('%" + rotary_end_time + "%',rotary_end_time)"
            //if (students_name == string.Empty || students_name == "") students_name = null;
            //if (rotary_begin_time == string.Empty || rotary_begin_time == "") rotary_begin_time = null;
            //if (rotary_end_time == string.Empty || rotary_end_time == "") rotary_end_time = null;
            //if (total_score == string.Empty || total_score == "") total_score = null;
            //if (is_pass == string.Empty || is_pass == "") is_pass = null;
            
            string  sq ="training_base_code='" + training_base_code
                + "' and rotary_dept_code='" + rotary_dept_code + "' and instructor='" + instructor + "' and instructor_tag='" + instructor_tag+"'";
            if (!string.IsNullOrEmpty(students_name)) {
                sq += "and students_real_name like '%"+students_name+"%'";
            }
            if (!string.IsNullOrEmpty(rotary_begin_time))
            {
                sq += "and rotary_begin_time >='"+rotary_begin_time+"'";
            }
            if (!string.IsNullOrEmpty(rotary_end_time))
            {
                sq += "and rotary_end_time <='" + rotary_end_time + "'";
            }
            if (!string.IsNullOrEmpty(total_score)) {
                sq += "and total_score='" + total_score + "'";
            }
            if (!string.IsNullOrEmpty(is_pass))
            {
                sq += "and is_pass like '%" + is_pass + "%'";
            }
            DataTable dt = db.RunPagedDataPro("GetPageList", "id,students_name,students_real_name,sex,training_base_code,training_base_name,high_education,high_education_time,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name,rotary_begin_time,rotary_end_time,instructor,instructor_tag,kqqk,gztd,ydyf,llsp,zdzx,blsx,clbrnl,sjcznl,czjn,zdsp,djnl,total_score,instructor_date,is_pass,dept_manager,dept_manager_date",
                "GP_OutDept_Exam",sq, "instructor_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);

            //DataTable dt = db.RunPagedDataPro("GetPageList", "id,students_name,students_real_name,sex,training_base_code,training_base_name,high_education,high_education_time,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name,rotary_begin_time,rotary_end_time,instructor,instructor_tag,kqqk,gztd,ydyf,llsp,zdzx,blsx,clbrnl,sjcznl,czjn,zdsp,djnl,total_score,instructor_date,is_pass,dept_manager,dept_manager_date",
            //    "GP_OutDept_Exam", "training_base_code='" + training_base_code
            //    + "' and rotary_dept_code='" + rotary_dept_code + "' and instructor='" + instructor + "' and instructor_tag='" + instructor_tag
            //    + "' and students_real_name like ISNULL('%" + students_name + "%',students_real_name)"
            //    + "and total_score=isnull('"+total_score+"',total_score) and is_pass like isnull('%" + is_pass + "%',is_pass)"
            //   , "instructor_date desc", "id", pageIndex, pageSize, out rowCount, out pageCount);
            return dt;

		}
        public OutDeptExamModel DataRowToModel2(DataRow row)
        {
            OutDeptExamModel model = new OutDeptExamModel();
            if (row != null)
            {
                if (row["id"] != null)
                {
                    model.id = row["id"].ToString();
                }
                if (row["students_name"] != null)
                {
                    model.students_name = row["students_name"].ToString();
                }
                if (row["students_real_name"] != null)
                {
                    model.students_real_name = row["students_real_name"].ToString();
                }
                if (row["sex"] != null)
                {
                    model.sex = row["sex"].ToString();
                }
                if (row["training_base_code"] != null)
                {
                    model.training_base_code = row["training_base_code"].ToString();
                }
                if (row["training_base_name"] != null)
                {
                    model.training_base_name = row["training_base_name"].ToString();
                }
                if (row["high_education"] != null)
                {
                    model.high_education = row["high_education"].ToString();
                }
                if (row["high_education_time"] != null)
                {
                    model.high_education_time = row["high_education_time"].ToString();
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
                if (row["rotary_begin_time"] != null)
                {
                    model.rotary_begin_time = row["rotary_begin_time"].ToString();
                }
                if (row["rotary_end_time"] != null)
                {
                    model.rotary_end_time = row["rotary_end_time"].ToString();
                }
                if (row["instructor"] != null)
                {
                    model.instructor = row["instructor"].ToString();
                }
                if (row["instructor_tag"] != null)
                {
                    model.instructor_tag = row["instructor_tag"].ToString();
                }
                if (row["kqqk"] != null)
                {
                    model.kqqk = row["kqqk"].ToString();
                }
                if (row["gztd"] != null)
                {
                    model.gztd = row["gztd"].ToString();
                }
                if (row["ydyf"] != null)
                {
                    model.ydyf = row["ydyf"].ToString();
                }
                if (row["llsp"] != null)
                {
                    model.llsp = row["llsp"].ToString();
                }
                if (row["zdzx"] != null)
                {
                    model.zdzx = row["zdzx"].ToString();
                }
                if (row["blsx"] != null)
                {
                    model.blsx = row["blsx"].ToString();
                }
                if (row["clbrnl"] != null)
                {
                    model.clbrnl = row["clbrnl"].ToString();
                }
                if (row["sjcznl"] != null)
                {
                    model.sjcznl = row["sjcznl"].ToString();
                }
                if (row["czjn"] != null)
                {
                    model.czjn = row["czjn"].ToString();
                }
                if (row["zdsp"] != null)
                {
                    model.zdsp = row["zdsp"].ToString();
                }
                if (row["djnl"] != null)
                {
                    model.djnl = row["djnl"].ToString();
                }
                if (row["total_score"] != null)
                {
                    model.total_score = row["total_score"].ToString();
                }
                if (row["instructor_date"] != null)
                {
                    model.instructor_date = row["instructor_date"].ToString();
                }
                if (row["is_pass"] != null)
                {
                    model.is_pass = row["is_pass"].ToString();
                }
                if (row["dept_manager"] != null)
                {
                    model.dept_manager = row["dept_manager"].ToString();
                }
                if (row["dept_manager_date"] != null)
                {
                    model.dept_manager_date = row["dept_manager_date"].ToString();
                }
            }
            return model;
        }
        #endregion

        #region SelectById
        public OutDeptExamModel SelectById(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,students_name,students_real_name,sex,training_base_code,training_base_name,high_education,high_education_time,professional_base_code,professional_base_name,rotary_dept_code,rotary_dept_name,rotary_begin_time,rotary_end_time,instructor,instructor_tag,kqqk,gztd,ydyf,llsp,zdzx,blsx,clbrnl,sjcznl,czjn,zdsp,djnl,total_score,instructor_date,is_pass,dept_manager,dept_manager_date from GP_OutDept_Exam ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50)	};
            parameters[0].Value = id;

            OutDeptExamModel model = new OutDeptExamModel();
            DataSet ds = db.RunDataSet(strSql.ToString(), parameters,"tbName");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel2(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region UpdateById
        public bool UpdateById(OutDeptExamModel model,string id)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GP_OutDept_Exam set ");
            strSql.Append("kqqk=@kqqk,");
            strSql.Append("gztd=@gztd,");
            strSql.Append("ydyf=@ydyf,");
            strSql.Append("llsp=@llsp,");
            strSql.Append("zdzx=@zdzx,");
            strSql.Append("blsx=@blsx,");
            strSql.Append("clbrnl=@clbrnl,");
            strSql.Append("sjcznl=@sjcznl,");
            strSql.Append("czjn=@czjn,");
            strSql.Append("zdsp=@zdsp,");
            strSql.Append("djnl=@djnl,");
            strSql.Append("total_score=@total_score,");
            strSql.Append("instructor_date=@instructor_date,");
            strSql.Append("is_pass=@is_pass,");
            strSql.Append("dept_manager=@dept_manager,");
            strSql.Append("dept_manager_date=@dept_manager_date");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@kqqk", SqlDbType.NVarChar,10),
					new SqlParameter("@gztd", SqlDbType.NVarChar,10),
					new SqlParameter("@ydyf", SqlDbType.NVarChar,10),
					new SqlParameter("@llsp", SqlDbType.NVarChar,10),
					new SqlParameter("@zdzx", SqlDbType.NVarChar,10),
					new SqlParameter("@blsx", SqlDbType.NVarChar,10),
					new SqlParameter("@clbrnl", SqlDbType.NVarChar,10),
					new SqlParameter("@sjcznl", SqlDbType.NVarChar,10),
					new SqlParameter("@czjn", SqlDbType.NVarChar,10),
					new SqlParameter("@zdsp", SqlDbType.NVarChar,10),
					new SqlParameter("@djnl", SqlDbType.NVarChar,10),
					new SqlParameter("@total_score", SqlDbType.NVarChar,10),
					new SqlParameter("@instructor_date", SqlDbType.NVarChar,50),
					new SqlParameter("@is_pass", SqlDbType.NVarChar,10),
					new SqlParameter("@dept_manager", SqlDbType.NVarChar,50),
					new SqlParameter("@dept_manager_date", SqlDbType.NVarChar,10),
					new SqlParameter("@id", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.kqqk;
            parameters[1].Value = model.gztd;
            parameters[2].Value = model.ydyf;
            parameters[3].Value = model.llsp;
            parameters[4].Value = model.zdzx;
            parameters[5].Value = model.blsx;
            parameters[6].Value = model.clbrnl;
            parameters[7].Value = model.sjcznl;
            parameters[8].Value = model.czjn;
            parameters[9].Value = model.zdsp;
            parameters[10].Value = model.djnl;
            parameters[11].Value = model.total_score;
            parameters[12].Value = model.instructor_date;
            parameters[13].Value = model.is_pass;
            parameters[14].Value = model.dept_manager;
            parameters[15].Value = model.dept_manager_date;
            parameters[16].Value = id;

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

        #region DataRowToModel(DataRow row)
        public OutDeptExamModel DataRowToModel(DataRow row)
        {
            OutDeptExamModel model = new OutDeptExamModel();
            if (row != null)
            {
                if (row["id"] != null)
                {
                    model.id = row["id"].ToString();
                }
                if (row["students_name"] != null)
                {
                    model.students_name = row["students_name"].ToString();
                }
                if (row["students_real_name"] != null)
                {
                    model.students_real_name = row["students_real_name"].ToString();
                }
                if (row["sex"] != null)
                {
                    model.sex = row["sex"].ToString();
                }
                if (row["training_base_code"] != null)
                {
                    model.training_base_code = row["training_base_code"].ToString();
                }
                if (row["training_base_name"] != null)
                {
                    model.training_base_name = row["training_base_name"].ToString();
                }
                if (row["high_education"] != null)
                {
                    model.high_education = row["high_education"].ToString();
                }
                if (row["high_education_time"] != null)
                {
                    model.high_education_time = row["high_education_time"].ToString();
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
                if (row["rotary_begin_time"] != null)
                {
                    model.rotary_begin_time = row["rotary_begin_time"].ToString();
                }
                if (row["rotary_end_time"] != null)
                {
                    model.rotary_end_time = row["rotary_end_time"].ToString();
                }
                if (row["instructor"] != null)
                {
                    model.instructor = row["instructor"].ToString();
                }
                if (row["instructor_tag"] != null)
                {
                    model.instructor_tag = row["instructor_tag"].ToString();
                }
                if (row["kqqk"] != null)
                {
                    model.kqqk = row["kqqk"].ToString();
                }
                if (row["gztd"] != null)
                {
                    model.gztd = row["gztd"].ToString();
                }
                if (row["ydyf"] != null)
                {
                    model.ydyf = row["ydyf"].ToString();
                }
                if (row["llsp"] != null)
                {
                    model.llsp = row["llsp"].ToString();
                }
                if (row["zdzx"] != null)
                {
                    model.zdzx = row["zdzx"].ToString();
                }
                if (row["blsx"] != null)
                {
                    model.blsx = row["blsx"].ToString();
                }
                if (row["clbrnl"] != null)
                {
                    model.clbrnl = row["clbrnl"].ToString();
                }
                if (row["sjcznl"] != null)
                {
                    model.sjcznl = row["sjcznl"].ToString();
                }
                if (row["czjn"] != null)
                {
                    model.czjn = row["czjn"].ToString();
                }
                if (row["zdsp"] != null)
                {
                    model.zdsp = row["zdsp"].ToString();
                }
                if (row["djnl"] != null)
                {
                    model.djnl = row["djnl"].ToString();
                }
                if (row["total_score"] != null)
                {
                    model.total_score = row["total_score"].ToString();
                }
                if (row["instructor_date"] != null)
                {
                    model.instructor_date = row["instructor_date"].ToString();
                }
                if (row["is_pass"] != null)
                {
                    model.is_pass = row["is_pass"].ToString();
                }
                if (row["dept_manager"] != null)
                {
                    model.dept_manager = row["dept_manager"].ToString();
                }
                if (row["dept_manager_date"] != null)
                {
                    model.dept_manager_date = row["dept_manager_date"].ToString();
                }
            }
            return model;
        } 
        #endregion

        #region Common分页
        public List<Model.OutDeptExamModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string RotaryBeginTime, string RotaryEndTime, string TotalScore, string IsPass,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by dept_manager_date desc) as num,* from GP_OutDept_Exam where training_base_code like '%" + TrainingBaseCode + "%'";

            if (!string.IsNullOrEmpty(StudentsRealName))
            {
                sql += "and students_real_name like '%" + StudentsRealName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseCode))
            {
                sql += "and professional_base_code like '%" + ProfessionalBaseCode + "%'";
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
                sql += "and instructor like '%" + TeachersRealName + "%'";
            }
            if (!string.IsNullOrEmpty(RotaryBeginTime))
            {
                sql += "and rotary_begin_time = '" + RotaryBeginTime + "'";
            }
            if (!string.IsNullOrEmpty(RotaryEndTime))
            {
                sql += "and rotary_end_time = '" + RotaryEndTime + "'";
            }
            if (!string.IsNullOrEmpty(TotalScore))
            {
                sql += "and total_score = '" + TotalScore + "'";
            }
            if (!string.IsNullOrEmpty(IsPass))
            {
                sql += "and is_pass = '" + IsPass + "'";
            }
            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<OutDeptExamModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<OutDeptExamModel>();
                OutDeptExamModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new OutDeptExamModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string RotaryBeginTime, string RotaryEndTime, string TotalScore, string IsPass)
        {
            string sql = "select count(*) from GP_OutDept_Exam where training_base_code like '%" + TrainingBaseCode + "%'";
            if (!string.IsNullOrEmpty(StudentsRealName))
            {
                sql += "and students_real_name like '%" + StudentsRealName + "%'";
            }
            if (!string.IsNullOrEmpty(ProfessionalBaseCode))
            {
                sql += "and professional_base_code like '%" + ProfessionalBaseCode + "%'";
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
                sql += "and instructor like '%" + TeachersRealName + "%'";
            }
            if (!string.IsNullOrEmpty(RotaryBeginTime))
            {
                sql += "and rotary_begin_time = '" + RotaryBeginTime + "'";
            }
            if (!string.IsNullOrEmpty(RotaryEndTime))
            {
                sql += "and rotary_end_time = '" + RotaryEndTime + "'";
            }
            if (!string.IsNullOrEmpty(TotalScore))
            {
                sql += "and total_score = '" + TotalScore + "'";
            }
            if (!string.IsNullOrEmpty(IsPass))
            {
                sql += "and is_pass = '" + IsPass + "'";
            }

            return Convert.ToInt32(db.RunExecuteScalar(sql));
        }
        #endregion
    }
}
