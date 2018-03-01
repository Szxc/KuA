//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using MongoDB;
//using MongoDbDemo;
//using MongoDB.Driver;
//using MongoDB.Bson;
//using DAL.Entity;
//using DAL;
//using MongoDB.Driver.Builders;
//using System.Diagnostics;

//namespace MongoDbDemo.Controllers
//{
//    public class HomeController : Controller
//    {
//        //  
//        // GET: /Home/  

//        public ActionResult Index()
//        {
//            return Content("MongoDbDemo");
//        }

//        #region INSERT
//        /// <summary>  
//        /// 添加用户  
//        /// </summary>  
//        /// <returns></returns>  
//        public ActionResult Ruser()
//        {
//            try
//            {
//                string name = Request["name"];
//                string age = Request["age"];
//                User user1 = new User { Uname = name, Age = age };
//                MongoDbHelper mh = new MongoDbHelper("127.0.0.1", "1000");
//                if (mh.Insert<User>(user1))
//                {
//                    return Json(new { success = "true" });
//                }
//            }
//            catch (Exception)
//            {
//                return Json(new { success = "filled" });
//                throw;
//            }
//            return Json(new { success = "filled" });
//        }
//        #endregion

//        #region SELECT
//        /// <summary>  
//        /// 查询一个集合中的所有数据  
//        /// </summary>  
//        /// <returns></returns>  
//        public ActionResult Seluser()
//        {
//            MongoDbHelper mh = new MongoDbHelper("127.0.0.1", "1000");
//            List<User> users = mh.FindAll<User>();
//            return Json(new { success = "true" });
//        }

//        /// <summary>  
//        /// 按条件查询一条数据  
//        /// </summary>  
//        /// <returns></returns>  
//        public ActionResult SelOne()
//        {
//            string name = Request["name"];
//            string age = Request["age"];
//            MongoDbHelper mh = new MongoDbHelper("127.0.0.1", "1000");
//            User users = mh.FindOne<User>(Query.And(Query.EQ("Uname", name), Query.EQ("Age", age)));
//            return Json(new { success = "true", users = users });
//        }

//        /// <summary>  
//        /// 分页查询  
//        /// </summary>  
//        /// <returns></returns>  
//        public ActionResult SelPage()
//        {
//            int pageindex = int.Parse(Request["pageindex"]);//页索引  
//            int pagesize = int.Parse(Request["pagesize"]);//行数  
//            MongoDbHelper mh = new MongoDbHelper("127.0.0.1", "1000");
//            Stopwatch sw1 = new Stopwatch();
//            sw1.Start();
//            List<User> users = mh.Find<User>(null, pageindex, pagesize, null);
//            return Json(new { success = "true", users = users });
//        }
//        #endregion

//        #region UPDATE
//        /// <summary>  
//        /// 修改信息  
//        /// </summary>  
//        /// <returns></returns>  
//        public ActionResult upduser()
//        {
//            MongoDbHelper mh = new MongoDbHelper("127.0.0.1", "1000");
//            if (mh.Update<User>(Query.EQ("Uname", "阿斯达"), Update.Set("Uname", "阿斯达s"), "User"))
//            {
//                return Json(new { success = "true" });
//            }
//            else
//            {
//                return Json(new { success = "fales" });
//            }

//        }
//        #endregion

//        #region DELETE
//        /// <summary>  
//        /// 删除消息  
//        /// </summary>  
//        /// <returns></returns>  
//        public ActionResult deluser()
//        {
//            MongoDbHelper mh = new MongoDbHelper("127.0.0.1", "1000");
//            if (mh.Remove<User>(Query.EQ("Uname", "阿斯达s")))
//            {
//                return Json(new { success = "true" });
//            }
//            else
//            {
//                return Json(new { success = "fales" });
//            }
//        }
//        #endregion
//    }
//}