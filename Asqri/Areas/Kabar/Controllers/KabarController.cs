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

namespace Asqri.Areas.Kabar.Controllers
{
    public class KabarController : Controller
    {
        NewsRepository blnews = new NewsRepository();
        NewsViewModels Models = new NewsViewModels();
        // GET: Kabar/Kabar
        public ActionResult Index()
        {
            Models.News = blnews.Select();
            return View(Models);
        }
        [HttpGet]
        public ActionResult AddNews()
        {
            Models.News = blnews.Select();
            return View(Models);
        }

        [HttpPost]
        public ActionResult AddNews(News news, HttpPostedFileBase UploadImage)
        {
            try
            {

                if (UploadImage != null && UploadImage.ContentLength > 0)
                {
                    if (ModelState.IsValid)
                    {
                        string path = Path.Combine(Server.MapPath("~/File/UploadImages"),
                         Path.GetFileName(UploadImage.FileName));
                        UploadImage.SaveAs(path);
                        news.Image = UploadImage.FileName;
                        news.times = DateTime.Now;
                        if (blnews.Add(news))
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
                else
                {
                    return MessageBox.Show("تصویر ثبت نشد", MessageType.Error);
                }
            }
            catch (Exception ex)
            {
                return MessageBox.Show(ex.Message.ToString(), MessageType.Warning);
            }

        }
        public ActionResult DeleteNews(int id)
        {

            blnews.Delete(id);
            Models.News = blnews.Select();
            return View("index", Models);

        }
        [HttpGet]
        public ActionResult EditNews(int id)
        {
          

            Models.news = blnews.Find(id);
            return View(Models);
        }
        [AjaxOnly]
        [HttpPost]
        public ActionResult EditNews(News news, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
            {
                string imagePath = null;
                if (UploadImage != null)
                {
                    imagePath = UploadImage.FileName;
                    //UploadImage.InputStream.ResizeImageByWidth(500, Server.MapPath("~") + "Files\\UploadImages\\" + imagePath, Utilty.ImageComperssion.Normal);
                }
                news.times = DateTime.Now;
                if (blnews.Update(news, imagePath))
                {
                    return MessageBox.Show("خبر با موفقیت ویرایش شد", MessageType.Success);
                }
                else
                {
                    if (imagePath != null)
                    {
                        System.IO.File.Delete(Server.MapPath("~") + "Files\\UploadImages\\" + imagePath);
                    }
                    return MessageBox.Show("خبر ویرایش نشد", MessageType.Error);
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