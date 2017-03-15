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
    public class TrainingBaseBLL
    {
        TrainingBaseDAL trainingBaseDAL = new TrainingBaseDAL();
        public List<Model.TrainingBaseModel> getProvinceNameListModel()
        {
            return trainingBaseDAL.getProvinceNameListModel();

        }
        public List<Model.TrainingBaseModel> getHospitalNameListModel(string province_code) {
            return trainingBaseDAL.getHospitalNameListModel(province_code);
        }

        public DataTable GetDt()
        {
            return trainingBaseDAL.GetDt();
        }
      
    }
}
