using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.Demo.Client.GetService;
using WCF.Demo.Client.AddService;
using WCF.Demo.Client.RemoveService;
using WCF.Demo.Client.SaveService;
using WCF.Demo.Client.SearchService;
using System.Net;
//using WCF.Demo.Client.Models;

namespace WCF.Demo.Client.Controllers
{
    public class DemoController : Controller
    {
        //Models.User u = new Models.User();
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }

        //获取列表
        public ActionResult Get()
        {
            GetClient getClient = new GetClient();
            var user=getClient.DoWork();
            
            return View(user);
        }

        //添加
        public ActionResult Add()
        {

            return View();
        }
        //添加
        [HttpPost]
        public ActionResult Add(AddService.User user)
        {
            AddClient addClient = new AddClient();
            user.SubmitTime = DateTime.Now;
            addClient.DoWork(user);
            return RedirectToAction("Get");
        }

        //详情
        public ActionResult Search(int? userid)
        {

            if(userid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchClient searchClient = new SearchClient();
            SearchService.User user = searchClient.DoWork((int)userid);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //更新
        public ActionResult Save(int? userid)
        {
            if (userid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchClient searchClient = new SearchClient();
            SearchService.User user = searchClient.DoWork((int)userid);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Save(SaveService.User user)
        {
            SaveClient saveClient = new SaveClient();
            user.SubmitTime = DateTime.Now;
            saveClient.DoWork(user);
            return RedirectToAction("Get");
        }

        //删除
        public ActionResult Remove(int? userid)
        {
            if (userid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchClient searchClient = new SearchClient();
            SearchService.User user = searchClient.DoWork((int)userid);
           
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //确认删除
        [HttpPost, ActionName("Remove")]
        public ActionResult RemoveConfirm(int userid)
        {
            RemoveClient removeClient = new RemoveClient();
            removeClient.DoWork(userid);
            return RedirectToAction("Get");
        }
    }
}