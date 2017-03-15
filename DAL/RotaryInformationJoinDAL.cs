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
   public class RotaryInformationJoinDAL
    {
       SqlHelper db = new SqlHelper();

        #region 分页
       public List<Model.RotaryInformationJoinModel> GetPagedList(string training_base_code, string dept_code, string teachers_name,
             string name, string sex,  string high_education, string identity_type, string send_unit, string collaborative_unit, string training_time, string plan_training_time,string rotary_begin_time,string rotary_end_time,string outdept_status,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by TrainingTime desc,RotaryBeginTime asc) as num,* from RotaryInformationJoin where  TrainingBaseCode='" + training_base_code + "' and DeptCode='" + dept_code + "' and TeachersName='" + teachers_name + "'";

            if (!string.IsNullOrEmpty(name))
            {
                sql += "and Name = '" + name + "'";
            }
            if (!string.IsNullOrEmpty(sex))
            {
                sql += "and Sex = '" + sex + "'";
            }
            if (!string.IsNullOrEmpty(high_education))
            {
                sql += "and HighEducation = '" + high_education + "'";
            }
            if (!string.IsNullOrEmpty(identity_type))
            {
                sql += "and IdentityType = '" + identity_type + "'";
            }
            if (!string.IsNullOrEmpty(send_unit))
            {
                sql += "and SendUnit like '%" + send_unit + "%'";
            }
            if (!string.IsNullOrEmpty(collaborative_unit))
            {
                sql += "and CollaborativeUnit like '%" + collaborative_unit + "%'";
            }
            if (!string.IsNullOrEmpty(training_time))
            {
                sql += "and TrainingTime like '%" + training_time + "%'";
            }
            if (!string.IsNullOrEmpty(plan_training_time))
            {
                sql += "and PlanTrainingTime like '%" + plan_training_time + "%'";
            }

            if (!string.IsNullOrEmpty(rotary_begin_time))
            {
                sql += "and RotaryBeginTime = '" + rotary_begin_time + "'";
            }
            if (!string.IsNullOrEmpty(rotary_end_time))
            {
                sql += "and RotaryEndTime = '" + rotary_end_time + "'";
            }
            if (!string.IsNullOrEmpty(outdept_status))
            {
                sql += "and OutdeptStatus = '" + outdept_status + "'";
            }

            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<RotaryInformationJoinModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<RotaryInformationJoinModel>();
                Model.RotaryInformationJoinModel model = null;//声明实体对象
                foreach (DataRow dr in dt.Rows)
                {
                    model = new RotaryInformationJoinModel();
                    model = DataRowToModel(dr);
                    list.Add(model);
                }
            }
            return list;
        }


       public int GetRecordCount(string training_base_code, string dept_code, string teachers_name,
            string name, string sex, string high_education, string identity_type, string send_unit, string collaborative_unit, string training_time, string plan_training_time, string rotary_begin_time, string rotary_end_time, string outdept_status)
        {
            string sql = "select COUNT(*) from RotaryInformationJoin where TrainingBaseCode='" + training_base_code
                + "' and DeptCode='" + dept_code + "' and TeachersName='" + teachers_name + "'";
            if (!string.IsNullOrEmpty(name))
            {
                sql += "and Name = '" + name + "'";
            }
            if (!string.IsNullOrEmpty(sex))
            {
                sql += "and Sex = '" + sex + "'";
            }
            
            if (!string.IsNullOrEmpty(high_education))
            {
                sql += "and HighEducation = '" + high_education + "'";
            }
            
            if (!string.IsNullOrEmpty(identity_type))
            {
                sql += "and IdentityType = '" + identity_type + "'";
            }
            if (!string.IsNullOrEmpty(send_unit))
            {
                sql += "and SendUnit like '%" + send_unit + "%'";
            }
            if (!string.IsNullOrEmpty(collaborative_unit))
            {
                sql += "and CollaborativeUnit like '%" + collaborative_unit + "%'";
            }
            if (!string.IsNullOrEmpty(training_time))
            {
                sql += "and TrainingTime like '%" + training_time + "%'";
            }
            if (!string.IsNullOrEmpty(plan_training_time))
            {
                sql += "and PlanTrainingTime like '%" + plan_training_time + "%'";
            }

            if (!string.IsNullOrEmpty(rotary_begin_time))
            {
                sql += "and RotaryBeginTime = '" + rotary_begin_time + "'";
            }
            if (!string.IsNullOrEmpty(rotary_end_time))
            {
                sql += "and RotaryEndTime = '" + rotary_end_time + "'";
            }
            if (!string.IsNullOrEmpty(outdept_status))
            {
                sql += "and OutdeptStatus = '" + outdept_status + "'";
            }
            int count = Convert.ToInt32(db.RunExecuteScalar(sql));
            return count;
        }
        #endregion


        #region DataRowToModel(DataRow row)
        public RotaryInformationJoinModel DataRowToModel(DataRow row)
        {
            RotaryInformationJoinModel model = new RotaryInformationJoinModel();
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
                if (row["RotaryBeginTime"] != null)
                {
                    model.RotaryBeginTime = row["RotaryBeginTime"].ToString();
                }
                if (row["RotaryEndTime"] != null)
                {
                    model.RotaryEndTime = row["RotaryEndTime"].ToString();
                }
                if (row["RotaryDays"] != null)
                {
                    model.RotaryDays = row["RotaryDays"].ToString();
                }
                if (row["RotaryOrder"] != null && row["RotaryOrder"].ToString() != "")
                {
                    model.RotaryOrder = int.Parse(row["RotaryOrder"].ToString());
                }
                if (row["TeachersName"] != null)
                {
                    model.TeachersName = row["TeachersName"].ToString();
                }
                if (row["TeachersRealName"] != null)
                {
                    model.TeachersRealName = row["TeachersRealName"].ToString();
                }
                if (row["OutdeptStatus"] != null)
                {
                    model.OutdeptStatus = row["OutdeptStatus"].ToString();
                }
                if (row["OutdeptApplication"] != null)
                {
                    model.OutdeptApplication = row["OutdeptApplication"].ToString();
                }
                if (row["QuestionnaireStatus"] != null)
                {
                    model.QuestionnaireStatus = row["QuestionnaireStatus"].ToString();
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
                if (row["InfoName"] != null)
                {
                    model.InfoName = row["InfoName"].ToString();
                }
                if (row["InfoRealName"] != null)
                {
                    model.InfoRealName = row["InfoRealName"].ToString();
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
                if (row["HighEducation"] != null)
                {
                    model.HighEducation = row["HighEducation"].ToString();
                }
                if (row["HighSchool"] != null)
                {
                    model.HighSchool = row["HighSchool"].ToString();
                }
                if (row["GraduationTime"] != null)
                {
                    model.GraduationTime = row["GraduationTime"].ToString();
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
                if (row["InfoTrainingBaseCode"] != null)
                {
                    model.InfoTrainingBaseCode = row["InfoTrainingBaseCode"].ToString();
                }
                if (row["InfoTrainingBaseName"] != null)
                {
                    model.InfoTrainingBaseName = row["InfoTrainingBaseName"].ToString();
                }
                if (row["CollaborativeUnit"] != null)
                {
                    model.CollaborativeUnit = row["CollaborativeUnit"].ToString();
                }
                if (row["InfoProfessionalBaseCode"] != null)
                {
                    model.InfoProfessionalBaseCode = row["InfoProfessionalBaseCode"].ToString();
                }
                if (row["InfoProfessionalBaseName"] != null)
                {
                    model.InfoProfessionalBaseName = row["InfoProfessionalBaseName"].ToString();
                }
                if (row["TrainingTime"] != null)
                {
                    model.TrainingTime = row["TrainingTime"].ToString();
                }
                if (row["PlanTrainingTime"] != null)
                {
                    model.PlanTrainingTime = row["PlanTrainingTime"].ToString();
                }
                if (row["InfoTag1"] != null)
                {
                    model.InfoTag1 = row["InfoTag1"].ToString();
                }
                if (row["InfoTag2"] != null)
                {
                    model.InfoTag2 = row["InfoTag2"].ToString();
                }
                if (row["InfoTag3"] != null)
                {
                    model.InfoTag3 = row["InfoTag3"].ToString();
                }
                if (row["TrainingBaseProvinceCode"] != null)
                {
                    model.TrainingBaseProvinceCode = row["TrainingBaseProvinceCode"].ToString();
                }
                if (row["TrainingBaseProvinceName"] != null)
                {
                    model.TrainingBaseProvinceName = row["TrainingBaseProvinceName"].ToString();
                }
            }
            return model;
        } 
        #endregion


        #region GetModelById
        public Model.RotaryInformationJoinModel GetModelById(string Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from RotaryInformationJoin ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,50)};

            parameters[0].Value = Id;


            Model.RotaryInformationJoinModel model = new Model.RotaryInformationJoinModel();
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

        #region Common分页
        public List<Model.RotaryInformationJoinModel> CommonGetPagedList(string TrainingBaseCode, string ProfessionalBaseCode,
            string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
            string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime,
            string DeptName, string ProfessionalBaseName, string TeachersRealName,
            string RotaryBeginTime, string RotaryEndTime, string OutdeptStatus,
        int start, int end)
        {
            string sql = "select * from (select row_number() over(order by TrainingTime desc,RotaryBeginTime asc) as num,* from RotaryInformationJoin where TrainingBaseCode like '%" + TrainingBaseCode + "%'";

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
                sql += "and TeachersRealName like '%" + TeachersRealName + "%'";
            }
            if (!string.IsNullOrEmpty(RotaryBeginTime))
            {
                sql += "and RotaryBeginTime = '" + RotaryBeginTime + "'";
            }
            if (!string.IsNullOrEmpty(RotaryEndTime))
            {
                sql += "and RotaryEndTime = '" + RotaryEndTime + "'";
            }
            if (!string.IsNullOrEmpty(OutdeptStatus))
            {
                sql += "and OutdeptStatus = '" + OutdeptStatus + "'";
            }
            sql += ")as t where t.num>=@start and t.num<=@end";


            SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = db.RunDataTable(sql, pars);
            List<RotaryInformationJoinModel> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<RotaryInformationJoinModel>();
                RotaryInformationJoinModel model = null;
                foreach (DataRow row in dt.Rows)
                {
                    model = new RotaryInformationJoinModel();
                    model = DataRowToModel(row);
                    list.Add(model);
                }
            }
            return list;
        }


        public int CommonGetRecordCount(string TrainingBaseCode, string ProfessionalBaseCode,
            string StudentsRealName, string Sex, string MinZu, string HighEducation, string HighSchool,
            string IdentityType, string SendUnit, string CollaborativeUnit, string TrainingTime, string PlanTrainingTime,
            string DeptName, string ProfessionalBaseName, string TeachersRealName,
            string RotaryBeginTime, string RotaryEndTime, string OutdeptStatus)
        {
            string sql = "select count(*) from RotaryInformationJoin where TrainingBaseCode like '%" + TrainingBaseCode + "%'";
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
                sql += "and TeachersRealName like '%" + TeachersRealName + "%'";
            }
            if (!string.IsNullOrEmpty(RotaryBeginTime))
            {
                sql += "and RotaryBeginTime = '" + RotaryBeginTime + "'";
            }
            if (!string.IsNullOrEmpty(RotaryEndTime))
            {
                sql += "and RotaryEndTime = '" + RotaryEndTime + "'";
            }
            if (!string.IsNullOrEmpty(OutdeptStatus))
            {
                sql += "and OutdeptStatus = '" + OutdeptStatus + "'";
            }
            return Convert.ToInt32(db.RunExecuteScalar(sql));
        }
        #endregion
    }
}
