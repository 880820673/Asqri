using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asqri.ViewModels;
using DominClass;
using DataLayer;
using Asqri.Helpers.Filters;
using System.IO;

namespace Asqri.Areas.Class.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class/Class
        GroupRepository blGroup = new GroupRepository();
        ClassViewModels model = new ClassViewModels();
        DorehRepository bldoreh = new DorehRepository();
        TeacherRepository blteacher = new TeacherRepository();
        public ActionResult Index()
        {
            model.Dorehs = bldoreh.Select();
            return View(model);
        }
        public ActionResult Groups()
        {
           
            model.Groups = blGroup.Select().ToList();
            return View(model);
        }

        /// <summary>
        /// گروه بندی
        /// </summary>
  
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteGroup(int id)
        {
            if (blGroup.Delete(id))
            {
                ViewData["id"] = "Group_ParentId";
                ViewData["name"] = "Group.ParentId";
                return Json(new JsonData()
                {
                    Script = MessageBox.Show("با موفقیت حذف شد", MessageType.Success).Script,
                    Success = true,
                    Html = this.RenderPartialToString("_GroupList", blGroup.Select().ToList())
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
        public ActionResult AddGroup(Group group)
        {
            if (ModelState.IsValid)
            {
                if (blGroup.Add(group))
                {
                    ViewData["id"] = "Group_ParentId";
                    ViewData["name"] = "Group.ParentId";
                    //موفق
                    return Json(new JsonData()
                    {
                        Script = MessageBox.Show("با موفقیت ثبت شد", MessageType.Success).Script,
                        Success = true,
                        Html = this.RenderPartialToString("_GroupList", blGroup.Select().ToList())
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
        public ActionResult EditGroup(Group group)
        {
            if (ModelState.IsValid && group.Id != 0)
            {
                if (blGroup.Update(group))
                {
                    ViewData["id"] = "Group_ParentId";
                    ViewData["name"] = "Group.ParentId";
                    //موفق
                    return Json(new JsonData()
                    {
                        Script = MessageBox.Show("با موفقیت ویرایش شد", MessageType.Success).Script,
                        Success = true,
                        Html = this.RenderPartialToString("_GroupList", blGroup.Select().ToList())
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
        /// </summary>
        [HttpGet]
        public ActionResult AddClass()
        {
            

            model.Groups = blGroup.Select();
            model.Dorehs = bldoreh.Select();
            model.Teachers = blteacher.Where(p =>p.Enabled== true).ToList();
            return View(model);
        }
        [AjaxOnly]
        [HttpPost]
        public ActionResult AddClass(Doreh doreh, HttpPostedFileBase UploadImage)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    string path = Path.Combine(Server.MapPath("~/File/UploadImages"),
                       Path.GetFileName(UploadImage.FileName));
                    UploadImage.SaveAs(path);
                    doreh.ImageDoreh = UploadImage.FileName;
                    if (bldoreh.Add(doreh))
                    {
                        return MessageBox.Show("دوره  با موفقیت ثبت شد", MessageType.Success);
                    }
                    else
                    {
                        return MessageBox.Show("دوره ثبت نشد", MessageType.Error);
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
        [HttpGet]
        public ActionResult EditClass(int ID)
        {


            model.Groups = blGroup.Select();
            model.Doreh = bldoreh.Find(ID);
            model.Teachers = blteacher.Where(p => p.Enabled == true).ToList();
            return View(model);
        }
        [HttpPost]
        [AjaxOnly]
        public ActionResult EditClass(Doreh doreh, HttpPostedFileBase UploadImage)
        {

            if (ModelState.IsValid)
            {
                string imagePath = null;
                if (UploadImage != null)
                {
                    imagePath = UploadImage.FileName;
                    //UploadImage.InputStream.ResizeImageByWidth(500, Server.MapPath("~") + "Files\\UploadImages\\" + imagePath, Utilty.ImageComperssion.Normal);
                }

                if (bldoreh.Update(doreh, imagePath))
                {
                    return MessageBox.Show("دروره با موفقیت ویرایش شد", MessageType.Success);
                }
                else
                {
                    if (imagePath != null)
                    {
                        System.IO.File.Delete(Server.MapPath("~") + "Files\\UploadImages\\" + imagePath);
                    }
                    return MessageBox.Show("دروره ویرایش نشد", MessageType.Error);
                }
            }
            else
            {
                //مقدار ورودی اشتباه
                return MessageBox.Show(ModelState.GetErrors(), MessageType.Warning);
            }
        }
        public ActionResult DeleteClass(int id)
        {

            bldoreh.Delete(id);
            model.Dorehs = bldoreh.Select();
            return View("index", model);

        }

    }
}