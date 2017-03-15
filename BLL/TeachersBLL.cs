using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;

namespace BLL
{
   public class TeachersBLL
    {
        TeachersDAL teachersDAL = new TeachersDAL();
        public DataTable GetDataTable(TeachersModel model)
        {

            return teachersDAL.GetDataTable(model);
        }
        public int UpdatePassword(string teachers_name, string teachers_password)
        {

            return teachersDAL.UpdatePassword(teachers_name, teachers_password);

        }
        public List<Model.TeachersModel> getTeachersNameList(string training_base_code, string professional_base_code)
        {

            return teachersDAL.getTeachersNameList(training_base_code,professional_base_code);

        }
    }
}
