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
   public  class QuestionnaireDAL
    {
       SqlHelper db = new SqlHelper();
       #region InsertQuestionnaire(Model.QuestionnaireModel model)
       public bool InsertQuestionnaire(Model.QuestionnaireModel model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into GP_Questionnaire(");
           strSql.Append("id,training_base_name,training_base_code,professional_base_name,professional_base_code,rotary_dept_name,rotary_dept_code,instructor,one,two,three,four,five,six,seven,eight,nine,ten,eleven,twelve,thirteen,advice,register_date,writor)");
           strSql.Append(" values (");
           strSql.Append("@id,@training_base_name,@training_base_code,@professional_base_name,@professional_base_code,@rotary_dept_name,@rotary_dept_code,@instructor,@one,@two,@three,@four,@five,@six,@seven,@eight,@nine,@ten,@eleven,@twelve,@thirteen,@advice,@register_date,@writor)");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@training_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_name", SqlDbType.NVarChar,50),
					new SqlParameter("@professional_base_code", SqlDbType.NVarChar,50),
					new SqlParameter("@rotary_dept_name", SqlDbType.NVarChar,100),
					new SqlParameter("@rotary_dept_code", SqlDbType.NVarChar,50),
					new SqlParameter("@instructor", SqlDbType.NVarChar,50),
					new SqlParameter("@one", SqlDbType.NVarChar,10),
					new SqlParameter("@two", SqlDbType.NVarChar,10),
					new SqlParameter("@three", SqlDbType.NVarChar,10),
					new SqlParameter("@four", SqlDbType.NVarChar,10),
					new SqlParameter("@five", SqlDbType.NVarChar,10),
					new SqlParameter("@six", SqlDbType.NVarChar,10),
					new SqlParameter("@seven", SqlDbType.NVarChar,10),
					new SqlParameter("@eight", SqlDbType.NVarChar,10),
					new SqlParameter("@nine", SqlDbType.NVarChar,10),
					new SqlParameter("@ten", SqlDbType.NVarChar,10),
					new SqlParameter("@eleven", SqlDbType.NVarChar,10),
					new SqlParameter("@twelve", SqlDbType.NVarChar,10),
					new SqlParameter("@thirteen", SqlDbType.NVarChar,10),
					new SqlParameter("@advice", SqlDbType.NVarChar,500),
					new SqlParameter("@register_date", SqlDbType.NVarChar,50),
					new SqlParameter("@writor", SqlDbType.NVarChar,50)};
           parameters[0].Value = model.id;
           parameters[1].Value = model.training_base_name;
           parameters[2].Value = model.training_base_code;
           parameters[3].Value = model.professional_base_name;
           parameters[4].Value = model.professional_base_code;
           parameters[5].Value = model.rotary_dept_name;
           parameters[6].Value = model.rotary_dept_code;
           parameters[7].Value = model.instructor;
           parameters[8].Value = model.one;
           parameters[9].Value = model.two;
           parameters[10].Value = model.three;
           parameters[11].Value = model.four;
           parameters[12].Value = model.five;
           parameters[13].Value = model.six;
           parameters[14].Value = model.seven;
           parameters[15].Value = model.eight;
           parameters[16].Value = model.nine;
           parameters[17].Value = model.ten;
           parameters[18].Value = model.eleven;
           parameters[19].Value = model.twelve;
           parameters[20].Value = model.thirteen;
           parameters[21].Value = model.advice;
           parameters[22].Value = model.register_date;
           parameters[23].Value = model.writor;

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
       
       /// <summary>
       /// 分页list
       /// </summary>
       /// <param name="start"></param>
       /// <param name="end"></param>
       /// <returns></returns>
       #region GetPageAdviceList
       public List<QuestionnaireModel> GetPageAdviceList(int start, int end, string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string RealName)
       {
           string sql = "select * from (select row_number() over(order by register_date) as num,* from GP_Questionnaire where training_base_code=@TrainingBaseCode and professional_base_code=@ProfessionalBaseCode and rotary_dept_code=@DeptCode and instructor=@RealName) as t where t.num>=@start and t.num<=@end";
           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int),
                                 new SqlParameter("@TrainingBaseCode",SqlDbType.NVarChar,50),
                                 new SqlParameter("@ProfessionalBaseCode",SqlDbType.NVarChar,50),
                                 new SqlParameter("@DeptCode",SqlDbType.NVarChar,50),
                                 new SqlParameter("@RealName",SqlDbType.NVarChar,50)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           pars[2].Value = TrainingBaseCode;
           pars[3].Value = ProfessionalBaseCode;
           pars[4].Value = DeptCode;
           pars[5].Value = RealName;

           DataTable dt = db.RunDataTable(sql,pars);
           List<QuestionnaireModel> list = null;
           if (dt.Rows.Count > 0) {
               list = new List<QuestionnaireModel>();
               QuestionnaireModel model = null;
               foreach(DataRow row in dt.Rows){
                   model = new QuestionnaireModel();
                   LoadEntity(row, model);
                   list.Add(model);
               }
           }
           return list;
       } 
       #endregion

       /// <summary>
       /// row转model
       /// </summary>
       /// <param name="row"></param>
       /// <param name="model"></param>
       #region  LoadEntity(DataRow row,QuestionnaireModel model)
       private void LoadEntity(DataRow row,QuestionnaireModel model) {
           if (row["id"] != null)
           {
               model.id = row["id"].ToString();
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
           if (row["rotary_dept_name"] != null)
           {
               model.rotary_dept_name = row["rotary_dept_name"].ToString();
           }
           if (row["rotary_dept_code"] != null)
           {
               model.rotary_dept_code = row["rotary_dept_code"].ToString();
           }
           if (row["instructor"] != null)
           {
               model.instructor = row["instructor"].ToString();
           }
           if (row["one"] != null)
           {
               model.one = row["one"].ToString();
           }
           if (row["two"] != null)
           {
               model.two = row["two"].ToString();
           }
           if (row["three"] != null)
           {
               model.three = row["three"].ToString();
           }
           if (row["four"] != null)
           {
               model.four = row["four"].ToString();
           }
           if (row["five"] != null)
           {
               model.five = row["five"].ToString();
           }
           if (row["six"] != null)
           {
               model.six = row["six"].ToString();
           }
           if (row["seven"] != null)
           {
               model.seven = row["seven"].ToString();
           }
           if (row["eight"] != null)
           {
               model.eight = row["eight"].ToString();
           }
           if (row["nine"] != null)
           {
               model.nine = row["nine"].ToString();
           }
           if (row["ten"] != null)
           {
               model.ten = row["ten"].ToString();
           }
           if (row["eleven"] != null)
           {
               model.eleven = row["eleven"].ToString();
           }
           if (row["twelve"] != null)
           {
               model.twelve = row["twelve"].ToString();
           }
           if (row["thirteen"] != null)
           {
               model.thirteen = row["thirteen"].ToString();
           }
           if (row["advice"] != null)
           {
               model.advice = row["advice"].ToString();
           }
           if (row["register_date"] != null)
           {
               model.register_date = row["register_date"].ToString();
           }
           if (row["writor"] != null)
           {
               model.writor = row["writor"].ToString();
           }
       }
#endregion

       /// <summary>
       /// 获取总的记录数
       /// </summary>
       /// <returns></returns>
       #region GetRecordCount
       public int GetRecordCount(string TrainingBaseCode, string ProfessionalBaseCode, string DeptCode, string RealName)
       {
           string sql = "select count(*) from GP_Questionnaire where training_base_code=@TrainingBaseCode and professional_base_code=@ProfessionalBaseCode and rotary_dept_code=@DeptCode and instructor=@RealName";
           SqlParameter[] pars = { 
                                 
                                 new SqlParameter("@TrainingBaseCode",SqlDbType.NVarChar,50),
                                 new SqlParameter("@ProfessionalBaseCode",SqlDbType.NVarChar,50),
                                 new SqlParameter("@DeptCode",SqlDbType.NVarChar,50),
                                 new SqlParameter("@RealName",SqlDbType.NVarChar,50)
                                 };
           
           pars[0].Value = TrainingBaseCode;
           pars[1].Value = ProfessionalBaseCode;
           pars[2].Value = DeptCode;
           pars[3].Value = RealName;
           return Convert.ToInt32(db.RunExecuteScalar(sql,pars));
       } 
       #endregion

        #region 管理员的问卷调查
       public List<QuestionnaireModel> GetPageAdviceListM(int start, int end, string TrainingBaseCode)
       {
           string sql = "select * from (select row_number() over(order by register_date) as num,* from GP_Questionnaire where training_base_code like @TrainingBaseCode) as t where t.num>=@start and t.num<=@end";
           SqlParameter[] pars = { 
                                 new SqlParameter("@start",SqlDbType.Int),
                                 new SqlParameter("@end",SqlDbType.Int),
                                 new SqlParameter("@TrainingBaseCode",SqlDbType.NVarChar,50)
                                 };
           pars[0].Value = start;
           pars[1].Value = end;
           pars[2].Value ='%'+TrainingBaseCode+'%';
            

           DataTable dt = db.RunDataTable(sql, pars);
           List<QuestionnaireModel> list = null;
           if (dt.Rows.Count > 0)
           {
               list = new List<QuestionnaireModel>();
               QuestionnaireModel model = null;
               foreach (DataRow row in dt.Rows)
               {
                   model = new QuestionnaireModel();
                   LoadEntity(row, model);
                   list.Add(model);
               }
           }
           return list;
       }
       
       public int GetRecordCountM(string TrainingBaseCode)
       {
           string sql = "select count(*) from GP_Questionnaire where training_base_code like @TrainingBaseCode";
           SqlParameter[] pars = {  
                                 new SqlParameter("@TrainingBaseCode",SqlDbType.NVarChar,50) 
                                 };

           pars[0].Value ='%'+ TrainingBaseCode+'%';
            
           return Convert.ToInt32(db.RunExecuteScalar(sql, pars));
       }
       #endregion

         

    }
}
