using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asqri.ViewModels;
using DataLayer;
using Asqri.Helpers.Filters;
using DominClass;
namespace Asqri.Controllers
{
    public class HomeController : Controller
    {
        HomeViewModels model = new HomeViewModels();
        SlidRepository blslid = new SlidRepository();
        NewsRepository blnews = new NewsRepository();
        NazarRepository blNazar = new NazarRepository();
        DorehRepository bldoreh = new DorehRepository();
        GroupRepository blgroup = new GroupRepository();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            model.Slids = blslid.Select();
            model.News = blnews.Select();
            model.Nazars = blNazar.Select().Where(m=>m.Enabled==true);
            model.Dorehs = bldoreh.Select();
            model.Groups = blgroup.Select().Where(p=>p.ParentId==null);
            return View(model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ShowNews(int id)
        {
            model.news = blnews.Find(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult Showcourse(int id)
        {
            model.Doreh = bldoreh.Find(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult ShowAllcourse(int id)
        {
            model.Dorehs = bldoreh.Select().Where(p => p.GroupId == id);
            return View(model);
        }
    
           [HttpGet]
        public ActionResult About()
        {
           
            return View();
        }
        [AjaxOnly]
        [HttpPost]
        public ActionResult AddNazar(Nazar nazar)
        {
            try
            {
                nazar.Times = DateTime.Now;
                nazar.Enabled = false;
                if (ModelState.IsValid)
                {
                  
                        if (blNazar.Add(nazar))
                        {
                                return MessageBox.Show("نظر شما   با موفقیت ثبت شد", MessageType.Success);
                         }
                        else
                        {
                           
                            return MessageBox.Show("نظر شما ثبت نشد", MessageType.Error);
                        }

                }
                else
                {
                    //مقدار ورودی اشتباه
                    return MessageBox.Show(ModelState.GetErrors(), MessageType.Warning);
                }
            }
            catch (Exception ex)
            {
                return MessageBox.Show(ex.Message.ToString(), MessageType.Warning);
            }
        }


    }
}