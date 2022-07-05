using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asqri.ViewModels;
using DataLayer;
using DominClass;
using Asqri.Helpers.Filters;
using System.IO;
namespace Asqri.Controllers
{
    public class MarketerController : Controller
    {
        // GET: Marketer
        MarketerViewModels m = new MarketerViewModels();
        MarketerRepository blm = new MarketerRepository();
        UsersRepository bluser = new UsersRepository();
        
        // GET: Teacher
        [HttpGet]
        public ActionResult RegisterMarketer()
        {
            m.Marketers = blm.Select();
            return View(m);
        }
        [AjaxOnly]
        [HttpPost]
        [Route("api/Files/UploadImages")]
        public ActionResult RegisterMarketer(Marketer marketer,Users user, HttpPostedFileBase UploadImage)
        {
            if (UploadImage != null && UploadImage.ContentLength > 0)
                try
                {

                    if (ModelState.IsValid)
                    {
                        string path = Path.Combine(Server.MapPath("~/File/UploadImages"),
                           Path.GetFileName(UploadImage.FileName));
                        UploadImage.SaveAs(path);
                        marketer.Files = UploadImage.FileName;

                        if (bluser.Exist2(marketer.Username))
                        {
                            return MessageBox.Show("با این نام کاربری قبلا در سایت ثبت شده است ", MessageType.Warning);
                        }
                        else
                        {
                            user.Username = marketer.Username;
                            user.ConfirmPassword = user.Password;
                            user.Stdus = "marketer";
                            if (blm.Add(marketer))
                            {
                                if (bluser.Add(user))
                                {
                                    return MessageBox.Show(" ثبت نام با موفقیت بود", MessageType.Success);
                                }
                                else
                                {
                                    return MessageBox.Show(" ثبت نشد", MessageType.Error);
                                }

                            }
                            else
                            {
                                System.IO.File.Delete(path);
                                return MessageBox.Show(" ثبت نشد", MessageType.Error);
                            }
                        }
                        //UploadImage4

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
                return MessageBox.Show("ثبت نام نا موفق می یاشد", MessageType.Error);
            }


        }
    }
}