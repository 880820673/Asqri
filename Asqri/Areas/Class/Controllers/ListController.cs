using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asqri.ViewModels;
using DominClass;
using DataLayer;
using Asqri.Helpers.Filters;

namespace Asqri.Areas.Class.Controllers
{
    public class ListController : Controller
    {
        ClassViewModels model = new ClassViewModels();
        ListtRepository blListt = new ListtRepository();
        // GET: Class/List
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult list()
        {

            model.Listts = blListt.Select().ToList();
            return View(model);
        }

        /// <summary>
        /// گروه بندی
        /// </summary>

        [HttpPost]
        [AjaxOnly]
        public ActionResult Deletelist(int id)
        {
            if (blListt.Delete(id))
            {
                ViewData["id"] = "Listt_ParentId";
                ViewData["name"] = "Listt.ParentId";
                return Json(new JsonData()
                {
                    Script = MessageBox.Show("با موفقیت حذف شد", MessageType.Success).Script,
                    Success = true,
                    Html = this.RenderPartialToString("_ListtList", blListt.Select().ToList())
                });
            }
            else
            {
                return Json(new JsonData
                {
                    Script = MessageBox.Show("حذف نشد", MessageType.Error).Script,
                    Success = false,
                    Html = ""
                });
            }
        }
        [HttpPost]
        [AjaxOnly]
        public ActionResult Addlist(Listt group)
        {
            if (ModelState.IsValid)
            {
                if (blListt.Add(group))
                {
                    ViewData["id"] = "Listt_ParentId";
                    ViewData["name"] = "Listt.ParentId";
                    //موفق
                    return Json(new JsonData()
                    {
                        Script = MessageBox.Show("با موفقیت ثبت شد", MessageType.Success).Script,
                        Success = true,
                        Html = this.RenderPartialToString("_GroupList", blListt.Select().ToList())
                    });
                }
                else
                {
                    //نا موفق
                    return Json(new JsonData
                    {
                        Script = MessageBox.Show("ثبت نشد", MessageType.Error).Script,
                        Success = false,
                        Html = ""
                    });
                }
            }
            else
            {
                //خطا مقداری
                return Json(new JsonData
                {
                    Script = MessageBox.Show(ModelState.GetErrors(), MessageType.Warning).Script,
                    Success = false,
                    Html = ""
                });
            }
        }
        [HttpPost]
        [AjaxOnly]
        public ActionResult Editlist(Listt group)
        {
            if (ModelState.IsValid && group.Id != 0)
            {
                if (blListt.Update(group))
                {
                    ViewData["id"] = "Listt_ParentId";
                    ViewData["name"] = "Listt.ParentId";
                    //موفق
                    return Json(new JsonData()
                    {
                        Script = MessageBox.Show("با موفقیت ویرایش شد", MessageType.Success).Script,
                        Success = true,
                        Html = this.RenderPartialToString("_GroupList", blListt.Select().ToList())
                    });
                }
                else
                {
                    //نا موفق
                    return Json(new JsonData
                    {
                        Script = MessageBox.Show("ویرایش نشد", MessageType.Error).Script,
                        Success = false,
                        Html = ""
                    });
                }
            }
            else
            {
                //خطا مقداری
                return Json(new JsonData
                {
                    Script = MessageBox.Show(ModelState.GetErrors(), MessageType.Warning).Script,
                    Success = false,
                    Html = ""
                });
            }
        }

        public class JsonData
        {
            public string Script { get; set; }
            public string Html { get; set; }
            public bool Success { get; set; }
        }
        /// <summary>
        /// گروه بندی
    }
}