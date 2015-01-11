using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSharp.Demo.Web.Areas.Admin.Controllers
{
    public class OrganizationsController : Controller
    {
        #region Ajax功能

        #region 获取数据

        public ActionResult NodeData()
        {
            List<object> nodes = new List<object>()
            {
                new
                {
                    id = 1,
                    text = "公司一",
                    children = new List<object>()
                    {
                        new { id = 3, text = "财务部" },
                        new { id = 4, text = "人事部" }
                    }
                },
                new { id = 2, text = "公司二" }
            };
            return Json(nodes, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 验证数据

        #endregion

        #region 功能方法

        #endregion

        #endregion

        #region 视图功能

        public ActionResult Index()
        {
            return View();
        }

        #endregion

    }
}