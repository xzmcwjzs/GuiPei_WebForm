using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace BLL
{
   public class LoginBLL
    {

       LoginDAL loginDAL = new LoginDAL();
        public DataTable GetDataTable(LoginModel model)
        {

            return loginDAL.GetDataTable(model);
        }
        public int UpdatePassword(string name, string password)
        {

            return loginDAL.UpdatePassword(name, password);

        }

        public List<Model.LoginModel> getTeachersNameList(string training_base_code, string professional_base_code, string type)
        {

            return loginDAL.getTeachersNameList(training_base_code, professional_base_code, type);

        }

        public List<Model.LoginModel> getTeachersName(string training_base_code, string professional_base_code, string type, string real_name)
        {
            return loginDAL.getTeachersName(training_base_code, professional_base_code, type,real_name);
        }

        public DataTable GetTeachersDtByDeptCode(string training_base_code, string professional_base_code, string dept_code, string type)
        {
            return loginDAL.GetTeachersDtByDeptCode(training_base_code, professional_base_code, dept_code, type);
        }

        public List<LoginModel> GetTeachersListByDeptCode(string training_base_code, string professional_base_code, string dept_code, string type)
        {
            return loginDAL.GetTeachersListByDeptCode(training_base_code, professional_base_code, dept_code, type);
        }

        public bool Add(LoginModel model)
        {
            return loginDAL.Add(model);
        }

        public bool checkName(string name)
        {
            return loginDAL.GetModelByName(name) == null ? true : false;
        }


        #region 分页
        public List<Model.LoginModel> GetPagedList(string TrainingBaseCode, string RealName,
            string Type, string RegisterDate,
        int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<LoginModel> list = loginDAL.GetPagedList(TrainingBaseCode, RealName, Type, RegisterDate, start, end);
            return list;
        }

        public int GetPageCount(int pageSize, string TrainingBaseCode, string RealName,
            string Type, string RegisterDate)
        {
            int recordCount = loginDAL.GetRecordCount(TrainingBaseCode, RealName, Type, RegisterDate);
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public int GetRecordCount(string TrainingBaseCode, string RealName,
            string Type, string RegisterDate)
        {
            return loginDAL.GetRecordCount(TrainingBaseCode, RealName, Type, RegisterDate);
        }
        #endregion

        public bool UpdateLoginState(LoginModel model)
        {

            return loginDAL.UpdateLoginState(model);
        }

        public string  GetPassword(string name, string real_name)
        {
            DataTable dt = loginDAL.GetPassword(name, real_name);
            return dt==null?"-1": dt.Rows[0][0].ToString();
        }
    }
}
