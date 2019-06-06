using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using weather.until;

namespace weather.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        //GET
        public ActionResult WeatherForJson()
        {
            string response = HttpWebResponseUtility.Get("https://www.tianqiapi.com/api?version=v1&cityid=101010100");
            //此时response的字符串有很多\，这是C#自动转义的，不用处理
            //string s = response.Replace(@"\","");
            JObject jb = (JObject)JsonConvert.DeserializeObject(response);
            string city = jb["cityid"].ToString();//这里是尝试使用json的序列化效果
            //return Json(jb, JsonRequestBehavior.AllowGet);
            //return Content(response);//页面返回json字符串
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult WeatherForJson(string city)
        {
            //HttpWebResponseUtility response = new HttpWebResponseUtility();
            //IDictionary<string,string> param = new Dictionary<string,string>();
            //param.Add("version", "v1");
            //param.Add("cityid", "101010100");
            //string  response =HttpWebResponseUtility.CreatePostHttpResponse("https://www.tianqiapi.com/api",param,null,null, Encoding.UTF8, null);
            string response = HttpWebResponseUtility.Post("https://www.tianqiapi.com/api", "version=v1&cityid=101010500", null);
            //Response.Write(response);
            return Content(response);
        }
    }
}