using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
   public class ProfessionalBaseBLL
    {
       ProfessionalBaseDAL professionalBaseDAL = new ProfessionalBaseDAL();
        public List<Model.ProfessionalBaseModel> getListModel()
        {
            return professionalBaseDAL.getListModel();

        }
    }
}
