using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;
using Model;

namespace DAL
{
   public class DiseaseRegister2DAL
    {
       SqlHelper db = new SqlHelper();
       #region bool Insert(DiseaseRegister2Model model)
       public bool Insert(DiseaseRegister2Model model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_Disease_Register2(");
           strSql.Append("id,students_name,students_real_name,training_base_name,professional_base_name,dept_name,disease_name,required_num,real_num,master_degree,patient_name,case_num,main_diagnosis,secondary_diagnosis,is_charge,is_rescue,cure_measure,visit_date,comment,writor,register_date,training_base_code,professional_base_code,dept_code,teacher_check,kzr_check,base_check,manage_check,condition,TeacherId,TeacherName)");
           strSql.Append(" values (");
           strSql.Append("@id,@students_name,@students_real_name,@training_base_name,@professional_base_name,@dept_name,@disease_name,@required_num,@real_num,@master_degree,@patient_name,@case_num,@main_diagnosis,@secondary_diagnosis,@is_charge,@is_rescue,@cure_measure,@visit_date,@comment,@writor,@register_date,@training_base_code,@professional_base_code,@dept_code,@teacher_check,@kzr_check,@base_check,@manage_check,@condition,@TeacherId,@TeacherName)");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50),
					new SqlParameter("@students_name", SqlDbType.NVarChar,50),
					new SqlParameter("@students_real_name", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@dept_name", SqlDbType.NVarChar,500),
					new SqlParameter("@disease_name", SqlDbType.NVarChar,500),
					new SqlParameter("@required_num", SqlDbType.NVarChar,50),
					new SqlParameter("@real_num", SqlDbType.NVarChar,50),
					new SqlParameter("@master_degree", SqlDbType.NVarChar,50),
					new SqlParameter("@patient_name", SqlDbType.NVarChar,50),
					new SqlParameter("@case_num", SqlDbType.NVarChar,50),
					new SqlParameter("@main_diagnosis", SqlDbType.NVarChar,1000),
					new SqlParameter("@secondary_diagnosis", SqlDbType.NVarChar,1000),
					new SqlParameter("@is_charge", SqlDbType.NVarChar,50),
					new SqlParameter("@is_rescue", SqlDbType.NVarChar,50),
					new SqlParameter("@cure_measure", SqlDbType.NVarChar,1000),
					new SqlParameter("@visit_date", SqlDbType.NVarChar,50),
					new SqlParameter("@comment", SqlDbType.NVarChar,1000),
					new SqlParameter("@writor", SqlDbType.NVarChar,50),
					new SqlParameter("@register_date", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@dept_code", SqlDbType.NVarChar,50),
					new SqlParameter("@teacher_check", SqlDbType.NVarChar,50),
					new SqlParameter("@kzr_check", SqlDbType.NVarChar,50),
					new SqlParameter("@base_check", SqlDbType.NVarChar,50),
					new SqlParameter("@manage_check", SqlDbType.NVarChar,50),
                                       new SqlParameter("@condition",SqlDbType.NVarChar,50),
                                       new SqlParameter("@TeacherId",SqlDbType.NVarChar,50),
                                       new SqlParameter("@TeacherName",SqlDbType.NVarChar,50)};
           parameters[0].Value = model.id;
           parameters[1].Value = model.students_name;
           parameters[2].Value = model.students_real_name;
           parameters[3].Value = model.training_base_name;
           parameters[4].Value = model.professional_base_name;
           parameters[5].Value = model.dept_name;
           parameters[6].Value = model.disease_name;
           parameters[7].Value = model.required_num;
           parameters[8].Value = model.real_num;
           parameters[9].Value = model.master_degree;
           parameters[10].Value = model.patient_name;
           parameters[11].Value = model.case_num;
           parameters[12].Value = model.main_diagnosis;
           parameters[13].Value = model.secondary_diagnosis;
           parameters[14].Value = model.is_charge;
           parameters[15].Value = model.is_rescue;
           parameters[16].Value = model.cure_measure;
           parameters[17].Value = model.visit_date;
           parameters[18].Value = model.comment;
           parameters[19].Value = model.writor;
           parameters[20].Value = model.register_date;
           parameters[21].Value = model.training_base_code;
           parameters[22].Value = model.professional_base_code;
           parameters[23].Value = model.dept_code;
           parameters[24].Value = model.teacher_check;
           parameters[25].Value = model.kzr_check;
           parameters[26].Value = model.base_check;
           parameters[27].Value = model.manage_check;
           parameters[28].Value = model.condition;
           parameters[29].Value = model.TeacherId;
           parameters[30].Value = model.TeacherName;

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
       public DiseaseRegister2Model DataRowToModel(DataRow row)
       {
           DiseaseRegister2Model model = new DiseaseRegister2Model();
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
               if (row["training_base_name"] != null)
               {
                   model.training_base_name = row["training_base_name"].ToString();
               }
               if (row["professional_base_name"] != null)
               {
                   model.professional_base_name = row["professional_base_name"].ToString();
               }
               if (row["dept_name"] != null)
               {
                   model.dept_name = row["dept_name"].ToString();
               }
               if (row["disease_name"] != null)
               {
                   model.disease_name = row["disease_name"].ToString();
               }
               if (row["required_num"] != null)
               {
                   model.required_num = row["required_num"].ToString();
               }
               if (row["real_num"] != null)
               {
                   model.real_num = row["real_num"].ToString();
               }
               if (row["master_degree"] != null)
               {
                   model.master_degree = row["master_degree"].ToString();
               }
               if (row["patient_name"] != null)
               {
                   model.patient_name = row["patient_name"].ToString();
               }
               if (row["case_num"] != null)
               {
                   model.case_num = row["case_num"].ToString();
               }
               if (row["main_diagnosis"] != null)
               {
                   model.main_diagnosis = row["main_diagnosis"].ToString();
               }
               if (row["secondary_diagnosis"] != null)
               {
                   model.secondary_diagnosis = row["secondary_diagnosis"].ToString();
               }
               if (row["is_charge"] != null)
               {
                   model.is_charge = row["is_charge"].ToString();
               }
               if (row["is_rescue"] != null)
               {
                   model.is_rescue = row["is_rescue"].ToString();
               }
               if (row["cure_measure"] != null)
               {
                   model.cure_measure = row["cure_measure"].ToString();
               }
               if (row["visit_date"] != null)
               {
                   model.visit_date = row["visit_date"].ToString();
               }
               if (row["comment"] != null)
               {
                   model.comment = row["comment"].ToString();
               }
               if (row["writor"] != null)
               {
                   model.writor = row["writor"].ToString();
               }
               if (row["register_date"] != null)
               {
                   model.register_date = row["register_date"].ToString();
               }
               if (row["training_base_code"] != null)
               {
                   model.training_base_code = row["training_base_code"].ToString();
               }
               if (row["professional_base_code"] != null)
               {
                   model.professional_base_code = row["professional_base_code"].ToString();
               }
               if (row["dept_code"] != null)
               {
                   model.dept_code = row["dept_code"].ToString();
               }
               if (row["teacher_check"] != null)
               {
                   model.teacher_check = row["teacher_check"].ToString();
               }
               if (row["kzr_check"] != null)
               {
                   model.kzr_check = row["kzr_check"].ToString();
               }
               if (row["base_check"] != null)
               {
                   model.base_check = row["base_check"].ToString();
               }
               if (row["manage_check"] != null)
               {
                   model.manage_check = row["manage_check"].ToString();
               }
               if (row["condition"] != null)
               {
                   model.condition = row["condition"].ToString();
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

       #region 分页
       public List<Model.DiseaseRegister2Model> GetPagedList(string students_name, string training_base_code, string dept_name, string disease_name, string required_num, string master_degree,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by register_date desc) as num,* from GP_Disease_Register2 where students_name='" + students_name + "' and training_base_code='" + training_base_code + "'";

           if (!string.IsNullOrEmpty(dept_name))
           {
               sql += "and dept_name like '%" + dept_name + "%'";
           }
           if (!string.IsNullOrEmpty(disease_name))
           {
               sql += "and disease_name like '%" + disease_name + "%'";
           }
           if (!string.IsNullOrEmpty(required_num))
           {
               sql += "and required_num ='" + required_num + "'";
           }
           if (!string.IsNullOrEmpty(master_degree))
           {
               sql += "and master_degree like '%" + master_degree + "%'";
           }
            sql += ")as t where t.num>=@start and t.num<=@end";
           
           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<DiseaseRegister2Model> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<DiseaseRegister2Model>();
               DiseaseRegister2Model model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new DiseaseRegister2Model();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int GetRecordCount(string name, string training_base_code, string dept_name,string disease_name, string required_num, string master_degree)
       {
           string sql = "select count(*) from GP_Disease_Register2 where training_base_code='" + training_base_code
               + "' and students_name='" + name + "'";
           if (!string.IsNullOrEmpty(dept_name))
           {
               sql += "and dept_name like '%" + dept_name + "%'";
           }
           if (!string.IsNullOrEmpty(disease_name))
           {
               sql += "and disease_name like '%" + disease_name + "%'";
           } 
           if (!string.IsNullOrEmpty(required_num))
           {
               sql += "and required_num ='" + required_num + "'";
           } 
           if (!string.IsNullOrEmpty(master_degree))
           {
               sql += "and master_degree like '%" + master_degree + "%'";
           }
           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion

       #region GetModelById(string id)
       public DiseaseRegister2Model GetModelById(string id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select id,students_name,students_real_name,training_base_name,professional_base_name,dept_name,disease_name,required_num,real_num,master_degree,patient_name,case_num,main_diagnosis,secondary_diagnosis,is_charge,is_rescue,cure_measure,visit_date,comment,writor,register_date,training_base_code,professional_base_code,dept_code,teacher_check,kzr_check,base_check,manage_check,condition,TeacherId,TeacherName from GP_Disease_Register2 ");
			strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50)			};
           parameters[0].Value = id;

           DiseaseRegister2Model model = new DiseaseRegister2Model();
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

       #region Update(DiseaseRegister2Model model,string id)
       public bool Update(DiseaseRegister2Model model,string id)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_Disease_Register2 set ");
           strSql.Append("disease_name=@disease_name,");
           strSql.Append("patient_name=@patient_name,");
           strSql.Append("case_num=@case_num,");
           strSql.Append("main_diagnosis=@main_diagnosis,");
           strSql.Append("secondary_diagnosis=@secondary_diagnosis,");
           strSql.Append("is_charge=@is_charge,");
           strSql.Append("is_rescue=@is_rescue,");
           strSql.Append("cure_measure=@cure_measure,");
           strSql.Append("visit_date=@visit_date,");
           strSql.Append("comment=@comment,");
          
           strSql.Append("condition=@condition");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@disease_name", SqlDbType.NVarChar,500),
					
					new SqlParameter("@patient_name", SqlDbType.NVarChar,50),
					new SqlParameter("@case_num", SqlDbType.NVarChar,50),
					new SqlParameter("@main_diagnosis", SqlDbType.NVarChar,1000),
					new SqlParameter("@secondary_diagnosis", SqlDbType.NVarChar,1000),
					new SqlParameter("@is_charge", SqlDbType.NVarChar,50),
					new SqlParameter("@is_rescue", SqlDbType.NVarChar,50),
					new SqlParameter("@cure_measure", SqlDbType.NVarChar,1000),
					new SqlParameter("@visit_date", SqlDbType.NVarChar,50),
					new SqlParameter("@comment", SqlDbType.NVarChar,1000),
					
                    new SqlParameter("@condition",SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.disease_name;
          
           parameters[1].Value = model.patient_name;
           parameters[2].Value = model.case_num;
           parameters[3].Value = model.main_diagnosis;
           parameters[4].Value = model.secondary_diagnosis;
           parameters[5].Value = model.is_charge;
           parameters[6].Value = model.is_rescue;
           parameters[7].Value = model.cure_measure;
           parameters[8].Value = model.visit_date;
           parameters[9].Value = model.comment;
           
           parameters[10].Value = model.condition;
           parameters[11].Value = id;

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
       public List<Model.DiseaseRegister2Model> CommonGetPagedList(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
           string DiseaseName, string RequiredNum, string MasterDegree,
       int start, int end)
       {
           string sql = "select * from (select row_number() over(order by register_date desc) as num,* from GP_Disease_Register2 where training_base_code like '%" + TrainingBaseCode + "%'";
           if (!string.IsNullOrEmpty(StudentsRealName))
           {
               sql += "and students_real_name like '%" + StudentsRealName + "%'";
           }
           if (!string.IsNullOrEmpty(ProfessionalBaseCode))
           {
               sql += "and professional_base_code like '%" + ProfessionalBaseCode + "%'";
           }
           if (!string.IsNullOrEmpty(DeptCode))
           {
               sql += "and dept_code like '%" + DeptCode + "%'";
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
               sql += "and dept_name like '%" + DeptName + "%'";
           }
           if (!string.IsNullOrEmpty(TeachersRealName))
           {
               sql += "and TeacherName like '%" + TeachersRealName + "%'";
           }
           if (!string.IsNullOrEmpty(DiseaseName))
           {
               sql += "and disease_name like '%" + DiseaseName + "%'";
           }
           if (!string.IsNullOrEmpty(RequiredNum))
           {
               sql += "and required_num ='" + RequiredNum + "'";
           }
           if (!string.IsNullOrEmpty(MasterDegree))
           {
               sql += "and master_degree like '%" + MasterDegree + "%'";
           }
           sql += ")as t where t.num>=@start and t.num<=@end";


           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           DataTable dt = db.RunDataTable(sql, pars);
           List<DiseaseRegister2Model> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<DiseaseRegister2Model>();
               DiseaseRegister2Model model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new DiseaseRegister2Model();
                   model = DataRowToModel(row);
                   list.Add(model);
               }
           }
           return list;
       }


       public int CommonGetRecordCount(string StudentsRealName, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string TeachersName,string ProfessionalBaseName,string DeptName,string TeachersRealName,
           string DiseaseName, string RequiredNum, string MasterDegree)
       {
           string sql = "select count(*) from GP_Disease_Register2 where training_base_code like '%" + TrainingBaseCode + "%'";
           if (!string.IsNullOrEmpty(StudentsRealName))
           {
               sql += "and students_real_name like '%" + StudentsRealName + "%'";
           }
           if (!string.IsNullOrEmpty(ProfessionalBaseCode))
           {
               sql += "and professional_base_code like '%" + ProfessionalBaseCode + "%'";
           }
           if (!string.IsNullOrEmpty(DeptCode))
           {
               sql += "and dept_code like '%" + DeptCode + "%'";
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
               sql += "and dept_name like '%" + DeptName + "%'";
           }
           if (!string.IsNullOrEmpty(TeachersRealName))
           {
               sql += "and TeacherName like '%" + TeachersRealName + "%'";
           }
           if (!string.IsNullOrEmpty(DiseaseName))
           {
               sql += "and disease_name like '%" + DiseaseName + "%'";
           }
           if (!string.IsNullOrEmpty(RequiredNum))
           {
               sql += "and required_num ='" + RequiredNum + "'";
           }
           if (!string.IsNullOrEmpty(MasterDegree))
           {
               sql += "and master_degree like '%" + MasterDegree + "%'";
           }

           return Convert.ToInt32(db.RunExecuteScalar(sql));
       }
       #endregion

       #region UpdateCheckByTeacher(DiseaseRegister2Model model)
       public bool UpdateCheckByTeacher(DiseaseRegister2Model model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update GP_Disease_Register2 set ");
           strSql.Append("teacher_check=@teacher_check");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@teacher_check", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.teacher_check;
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
