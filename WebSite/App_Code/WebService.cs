using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;


/// <summary>
/// WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]

    public string getProvince()
    {
        BLL.ProvinceBLL provinceBLL = new BLL.ProvinceBLL();

        List<Model.ProvinceModel> list = provinceBLL.getListModel();

        //return list;
        JavaScriptSerializer jss = new JavaScriptSerializer();
        string json = jss.Serialize(list);
        return json;
        //在这边拼接json数据，返回
    }
    
}
