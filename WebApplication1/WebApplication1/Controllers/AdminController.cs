using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        dbemarketingEntities db = new dbemarketingEntities();
        // GET: Admin
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult login(tbl_admin avm)
        {
            tbl_admin ad = db.tbl_admin.Where(x => x.ad_username == avm.ad_username && x.ad_password == avm.ad_password).SingleOrDefault();
            if (ad!=null)
            {

                Session["ad_id"] = ad.ad_id.ToString();
                return RedirectToAction("Create");

            }
            else
            {
                ViewBag.error = "Invalid username or password";
                
            }

            return View();
        }


        public ActionResult Create()
        {
            if ( Session["ad_id"]==null)
            {
                return RedirectToAction("login");
            }
            return View();
        }


    }
}