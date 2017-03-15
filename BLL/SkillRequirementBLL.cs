using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
  public  class SkillRequirementBLL
    {

      SkillRequirementDAL skillRequirementDAL = new SkillRequirementDAL();
      public List<SkillRequirementModel> GetList(string DeptCode)
      {
          return skillRequirementDAL.GetList(DeptCode);
      }

    }
}
