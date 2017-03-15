using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
   public class PublishArticalRecordsDAL
    {
        SqlHelper db = new SqlHelper();
        #region Add(PublishArticalRecordsModel model)
        public bool Add(PublishArticalRecordsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GP_PublishArticalRecords(");
            strSql.Append("Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,TeacherId,TeacherName,Comment,ArticalTitle,ArticalCategory,PublishJournal,Author,PublishDate)");
            strSql.Append(" values (");
            strSql.Append("@Id,@StudentsRealName,@StudentsName,@TrainingBaseCode,@TrainingBaseName,@ProfessionalBaseCode,@ProfessionalBaseName,@DeptCode,@DeptName,@RegisterDate,@Writor,@TeacherCheck,@KzrCheck,@BaseCheck,@ManagerCheck,@TeacherId,@TeacherName,@Comment,@ArticalTitle,@ArticalCategory,@PublishJournal,@Author,@PublishDate)");
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
					new SqlParameter("@Comment", SqlDbType.NVarChar,1000),
					new SqlParameter("@ArticalTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@ArticalCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@PublishJournal", SqlDbType.NVarChar,50),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@PublishDate", SqlDbType.NVarChar,50)};
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
            parameters[17].Value = model.Comment;
            parameters[18].Value = model.ArticalTitle;
            parameters[19].Value = model.ArticalCategory;
            parameters[20].Value = model.PublishJournal;
            parameters[21].Value = model.Author;
            parameters[22].Value = model.PublishDate;

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

        #region GetListById(string Id)
        public List<PublishArticalRecordsModel> GetListById(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,StudentsRealName,StudentsName,TrainingBaseCode,TrainingBaseName,ProfessionalBaseCode,ProfessionalBaseName,DeptCode,DeptName,RegisterDate,Writor,TeacherCheck,KzrCheck,BaseCheck,ManagerCheck,TeacherId,TeacherName,Comment,ArticalTitle,ArticalCategory,PublishJournal,Author,PublishDate from GP_PublishArticalRecords ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50)			};
            parameters[0].Value = Id;

            DataTable dt = db.RunDataTable(strSql.ToString(), parameters);
            List<PublishArticalRecordsModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<PublishArticalRecordsModel>();
                PublishArticalRecordsModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new PublishArticalRecordsModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        } 
        #endregion

        #region Update(PublishArticalRecordsModel model)
        public bool Update(PublishArticalRecordsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GP_PublishArticalRecords set ");
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
            strSql.Append("Comment=@Comment,");
            strSql.Append("ArticalTitle=@ArticalTitle,");
            strSql.Append("ArticalCategory=@ArticalCategory,");
            strSql.Append("PublishJournal=@PublishJournal,");
            strSql.Append("Author=@Author,");
            strSql.Append("PublishDate=@PublishDate");
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
					new SqlParameter("@Comment", SqlDbType.NVarChar,1000),
					new SqlParameter("@ArticalTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@ArticalCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@PublishJournal", SqlDbType.NVarChar,50),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@PublishDate", SqlDbType.NVarChar,50),
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
            parameters[12].Value = model.Comment;
            parameters[13].Value = model.ArticalTitle;
            parameters[14].Value = model.ArticalCategory;
            parameters[15].Value = model.PublishJournal;
            parameters[16].Value = model.Author;
            parameters[17].Value = model.PublishDate;
            parameters[18].Value = model.Id;

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
        public PublishArticalRecordsModel DataRowToModel(DataRow row)
        {
            PublishArticalRecordsModel model = new PublishArticalRecordsModel();
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
                if (row["Comment"] != null)
                {
                    model.Comment = row["Comment"].ToString();
                }
                if (row["ArticalTitle"] != null)
                {
                    model.ArticalTitle = row["ArticalTitle"].ToString();
                }
                if (row["ArticalCategory"] != null)
                {
                    model.ArticalCategory = row["ArticalCategory"].ToString();
                }
                if (row["PublishJournal"] != null)
                {
                    model.PublishJournal = row["PublishJournal"].ToString();
                }
                if (row["Author"] != null)
                {
                    model.Author = row["Author"].ToString();
                }
                if (row["PublishDate"] != null)
                {
                    model.PublishDate = row["PublishDate"].ToString();
                }
            }
            return model;
        } 
        #endregion
        #region 分页
        public List<Model.PublishArticalRecordsModel> GetPagedList(string StudentsName, string TrainingBaseCode, string DeptName,
            string ArticalTitle, string ArticalCategory, string Author,string PublishDate,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_PublishArticalRecords where StudentsName='" + StudentsName + "' and TrainingBaseCode='" + TrainingBaseCode + "'";

            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and DeptName like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(ArticalTitle))
            {
                sql += "and ArticalTitle like '%" + ArticalTitle + "%'";
            }
            if (!string.IsNullOrEmpty(ArticalCategory))
            {
                sql += "and ArticalCategory ='" + ArticalCategory + "'";
            }
            if (!string.IsNullOrEmpty(Author))
            {
                sql += "and Author='" + Author + "'";
            }
            if (!string.IsNullOrEmpty(PublishDate))
            {
                sql += "and PublishDate like '%" + PublishDate + "%'";
            }
            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<PublishArticalRecordsModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<PublishArticalRecordsModel>();
                PublishArticalRecordsModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new PublishArticalRecordsModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int GetRecordCount(string StudentsName, string TrainingBaseCode, string DeptName,
            string ArticalTitle, string ArticalCategory, string Author, string PublishDate)
        {
            string sql = "select count(*) from GP_PublishArticalRecords where TrainingBaseCode='" + TrainingBaseCode
                + "' and StudentsName='" + StudentsName + "'";
            if (!string.IsNullOrEmpty(DeptName))
            {
                sql += "and DeptName like '%" + DeptName + "%'";
            }
            if (!string.IsNullOrEmpty(ArticalTitle))
            {
                sql += "and ArticalTitle like '%" + ArticalTitle + "%'";
            }
            if (!string.IsNullOrEmpty(ArticalCategory))
            {
                sql += "and ArticalCategory ='" + ArticalCategory + "'";
            }
            if (!string.IsNullOrEmpty(Author))
            {
                sql += "and Author='" + Author + "'";
            }
            if (!string.IsNullOrEmpty(PublishDate))
            {
                sql += "and PublishDate like '%" + PublishDate + "%'";
            }

            return Convert.ToInt32(db.RunExecuteScalar(sql));
        }
        #endregion

        #region Common分页
        public List<Model.PublishArticalRecordsModel> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string ArticalTitle, string ArticalCategory, string Author, string PublishDate,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by RegisterDate desc) as num,* from GP_PublishArticalRecords where  TrainingBaseCode like '%" + TrainingBaseCode + "%'";

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
            if (!string.IsNullOrEmpty(ArticalTitle))
            {
                sql += "and ArticalTitle like '%" + ArticalTitle + "%'";
            }
            if (!string.IsNullOrEmpty(ArticalCategory))
            {
                sql += "and ArticalCategory ='" + ArticalCategory + "'";
            }
            if (!string.IsNullOrEmpty(Author))
            {
                sql += "and Author='" + Author + "'";
            }
            if (!string.IsNullOrEmpty(PublishDate))
            {
                sql += "and PublishDate like '%" + PublishDate + "%'";
            }
            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<PublishArticalRecordsModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<PublishArticalRecordsModel>();
                PublishArticalRecordsModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new PublishArticalRecordsModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName, string ProfessionalBaseName, string DeptName, string TeachersRealName,
            string ArticalTitle, string ArticalCategory, string Author, string PublishDate)
        {
            string sql = "select count(*) from GP_PublishArticalRecords where TrainingBaseCode like '%" + TrainingBaseCode + "%'";
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
            if (!string.IsNullOrEmpty(ArticalTitle))
            {
                sql += "and ArticalTitle like '%" + ArticalTitle + "%'";
            }
            if (!string.IsNullOrEmpty(ArticalCategory))
            {
                sql += "and ArticalCategory ='" + ArticalCategory + "'";
            }
            if (!string.IsNullOrEmpty(Author))
            {
                sql += "and Author='" + Author + "'";
            }
            if (!string.IsNullOrEmpty(PublishDate))
            {
                sql += "and PublishDate like '%" + PublishDate + "%'";
            }

            return Convert.ToInt32(db.RunExecuteScalar(sql));
        }
        #endregion

        #region UpdateCheckByTeacher(PublishArticalRecordsModel model)
        public bool UpdateCheckByTeacher(PublishArticalRecordsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GP_PublishArticalRecords set ");
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
    }
}
