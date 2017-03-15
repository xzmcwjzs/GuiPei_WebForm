using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
  public class ReleaseNewsBLL
    {
      ReleaseNewsDAL releaseNewsDAL = new ReleaseNewsDAL();

      public bool Add(ReleaseNewsModel model)
      {
          return releaseNewsDAL.Add(model);
      }

      public List<ReleaseNewsModel> GetListById(string Id)
      {
          return releaseNewsDAL.GetListById(Id);
      }

      #region 分页
      public List<Model.ReleaseNewsModel> GetPagedList(string ManagersName, string TrainingBaseCode,
           string NewsTitle, string RegisteDate,string Type,
      int pageIndex, int pageSize)
      {
          int start = (pageIndex - 1) * pageSize + 1;
          int end = pageIndex * pageSize;
          List<ReleaseNewsModel> list = releaseNewsDAL.GetPagedList(ManagersName, TrainingBaseCode, NewsTitle, RegisteDate,Type,  start, end);
          return list;
      }

      public int GetPageCount(int pageSize, string ManagersName, string TrainingBaseCode,
           string NewsTitle, string RegisteDate, string Type)
      {
          int recordCount = releaseNewsDAL.GetRecordCount(ManagersName, TrainingBaseCode, NewsTitle, RegisteDate,Type);
          int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
          return pageCount;
      }
      public int GetRecordCount(string ManagersName, string TrainingBaseCode,
           string NewsTitle, string RegisteDate, string Type)
      {
          return releaseNewsDAL.GetRecordCount(ManagersName, TrainingBaseCode, NewsTitle, RegisteDate,Type);
      }
      #endregion

      public bool Update(ReleaseNewsModel model)
      {

          return releaseNewsDAL.Update(model);
      }


    }
}
