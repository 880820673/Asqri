using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DominClass;
using DataLayer;
using Asqri.ViewModels;
using System.IO;
using Asqri.Helpers.Filters;

namespace Asqri.Areas.SlidShow.Controllers
{
    public class SlideController : Controller
    {
        // GET: SlidShow/Slide
        SlidRepository blslid = new SlidRepository();
        SlidViewModels slidview = new SlidViewModels();

        public ActionResult Index()
        {
            slidview.Slids = blslid.Select();
            return View(slidview);
        }
        [HttpGet]
        public ActionResult AddSlid()
        {

            slidview.Slids = blslid.Select();
            return View(slidview);
        }
        [HttpPost]
        public ActionResult AddSlid(Slid slid, HttpPostedFileBase UploadImage)
        {

            if (UploadImage != null && UploadImage.ContentLength > 0 )
                try
                {

                    if (ModelState.IsValid)
                    {
                        string path = Path.Combine(Server.MapPath("~/File/UploadImages"),
                           Path.GetFileName(UploadImage.FileName));
                        UploadImage.SaveAs(path);
                        slid.File = UploadImage.FileName;
                                if (blslid.Add(slid))
                                {
                                    return MessageBox.Show("تصویر  با موفقیت ثبت شد", MessageType.Success);
                                }
                                else
                                {
                                    return MessageBox.Show("تصویر ثبت نشد", MessageType.Error);
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
            else
            {
                return MessageBox.Show("تصویر ثبت نشد", MessageType.Error);
            }
        }
        public ActionResult DeleteSlid(int id)
        {

            blslid.Delete(id);
            slidview.Slids = blslid.Select();
            return View("index", slidview);

        }
        [HttpGet]
        public ActionResult EditSlid(int id)
        {
            var model = new SlidViewModels();

            model.Slid = blslid.Find(id);
            return View(model);
        }
        [AjaxOnly]
        [HttpPost]
        public ActionResult EditSlid(Slid slid, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
            {
                string imagePath = null;
                if (UploadImage != null)
                {
                    imagePath = UploadImage.FileName;
                    //UploadImage.InputStream.ResizeImageByWidth(500, Server.MapPath("~") + "Files\\UploadImages\\" + imagePath, Utilty.ImageComperssion.Normal);
                }

                if (blslid.Update(slid, imagePath))
                {
                    return MessageBox.Show("اسلایدشو با موفقیت ویرایش شد", MessageType.Success);
                }
                else
                {
                    if (imagePath != null)
                    {
                        System.IO.File.Delete(Server.MapPath("~") + "Files\\UploadImages\\" + imagePath);
                    }
                    return MessageBox.Show("اسلایدشو ویرایش نشد", MessageType.Error);
                }
            }
            else
            {
                //مقدار ورودی اشتباه
                return MessageBox.Show(ModelState.GetErrors(), MessageType.Warning);
            }
        }
    }
}