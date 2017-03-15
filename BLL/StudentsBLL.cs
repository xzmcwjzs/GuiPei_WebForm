using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Data;


namespace BLL
{
   public class StudentsBLL
    {
       StudentsDAL studentsDAL = new StudentsDAL();
        public DataTable GetDataTable(StudentsModel model)
        {

            return studentsDAL.GetDataTable(model);
        }
        public int UpdatePassword(string students_name, string students_password)
        {

            return studentsDAL.UpdatePassword(students_name, students_password);

        }
    }
}
