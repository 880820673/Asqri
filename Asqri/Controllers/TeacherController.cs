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
    public class TeacherController : Controller
    {

        TeacherViewModel t = new TeacherViewModel();
        TeacherRepository blt = new TeacherRepository();
        UsersRepository bluser = new UsersRepository();
        // GET: Teacher
        [HttpGet]
        public ActionResult RegisterTeacher()
        {
            t.Teachers = blt.Select();
            t.Users = bluser.Select();
            return View(t);
        }
        [AjaxOnly]
        [HttpPost]
        [Route("api/Files/UploadImages")]
        public ActionResult RegisterTeacher(Teacher teacher, Users user, HttpPostedFileBase UploadImage, HttpPostedFileBase UploadImage2, HttpPostedFileBase UploadImage3, HttpPostedFileBase UploadImage4)
        {
            if (UploadImage != null && UploadImage.ContentLength > 0 && UploadImage2 != null && UploadImage2.ContentLength > 0 && UploadImage3 != null && UploadImage3.ContentLength > 0 && UploadImage4 != null && UploadImage4.ContentLength > 0)
                try
                {

                    if (ModelState.IsValid)
                    {
                        string path = Path.Combine(Server.MapPath("~/File/UploadImages"),
                           Path.GetFileName(UploadImage.FileName));
                        UploadImage.SaveAs(path);
                        teacher.Image = UploadImage.FileName;
                        //UploadImage2
                        string path2 = Path.Combine(Server.MapPath("~/File/UploadImages"),
                        Path.GetFileName(UploadImage2.FileName));
                        UploadImage2.SaveAs(path2);
                        teacher.NationalImage = UploadImage2.FileName;
                        //UploadImage3
                        string path3 = Path.Combine(Server.MapPath("~/File/UploadImages"),
                       Path.GetFileName(UploadImage3.FileName));
                        UploadImage3.SaveAs(path3);
                        teacher.DegreeImage = UploadImage3.FileName;
                        //UploadImage4
                        string path4 = Path.Combine(Server.MapPath("~/File/UploadImages"),
                       Path.GetFileName(UploadImage4.FileName));
                        UploadImage3.SaveAs(path4);
                        teacher.RozomeImage = UploadImage4.FileName;
                        if (bluser.Exist2(teacher.Username))
                        {
                            return MessageBox.Show("با این نام کاربری قبلا در سایت ثبت شده است ", MessageType.Warning);
                        }
                        else
                        {
                            user.Username = teacher.Username;
                            user.Stdus = "teacher";
                            teacher.Enabled = false;
                            if (blt.Add(teacher))
                            {
                                if (bluser.Add(user))
                                {
                                    return MessageBox.Show("دانش آموز  با موفقیت ثبت شد", MessageType.Success);
                                }
                                else
                                {
                                    return MessageBox.Show("دانش آموز ثبت نشد", MessageType.Error);
                                }

                            }
                            else
                            {
                                System.IO.File.Delete(path);
                                return MessageBox.Show("دانش آموز ثبت نشد", MessageType.Error);
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
                return MessageBox.Show("مدرس ثبت نشد", MessageType.Error);
            }




        }
        [AjaxOnly]
        [HttpPost]
        [Route("api/Files/UploadImages")]
        public ActionResult UpdateTeacher(Teacher teacher, Users user, HttpPostedFileBase UploadImage, HttpPostedFileBase UploadImage2, HttpPostedFileBase UploadImage3, HttpPostedFileBase UploadImage4)
        {
            if (UploadImage != null && UploadImage.ContentLength > 0 && UploadImage2 != null && UploadImage2.ContentLength > 0 && UploadImage3 != null && UploadImage3.ContentLength > 0 && UploadImage4 != null && UploadImage4.ContentLength > 0)
                try
                {

                    if (ModelState.IsValid)
                    {
                        string path = Path.Combine(Server.MapPath("~/File/UploadImages"),
                           Path.GetFileName(UploadImage.FileName));
                        UploadImage.SaveAs(path);
                        teacher.Image = UploadImage.FileName;
                       string imagePath= UploadImage.FileName;
                        //UploadImage2
                        string path2 = Path.Combine(Server.MapPath("~/File/UploadImages"),
                        Path.GetFileName(UploadImage2.FileName));
                        UploadImage2.SaveAs(path2);
                        teacher.NationalImage = UploadImage2.FileName;
                        string imagePath2 = UploadImage2.FileName;
                        //UploadImage3
                        string path3 = Path.Combine(Server.MapPath("~/File/UploadImages"),
                       Path.GetFileName(UploadImage3.FileName));
                        UploadImage3.SaveAs(path3);
                        teacher.DegreeImage = UploadImage3.FileName;
                        string imagePath3 = UploadImage3.FileName;
                        //UploadImage4
                        string path4 = Path.Combine(Server.MapPath("~/File/UploadImages"),
                       Path.GetFileName(UploadImage4.FileName));
                        UploadImage3.SaveAs(path4);
                        teacher.RozomeImage = UploadImage4.FileName;
                        string imagePath4 = UploadImage4.FileName;
                        if (bluser.Exist2(teacher.Username))
                        {
                            return MessageBox.Show("با این نام کاربری قبلا در سایت ثبت شده است ", MessageType.Warning);
                        }
                        else
                        {
                            user.Username = teacher.Username;
                            user.Stdus = "teacher";
                            teacher.Enabled = false;
                            if (blt.Update(teacher, imagePath, imagePath2, imagePath3, imagePath4))
                            {
                                if (bluser.Update(user))
                                {
                                    return MessageBox.Show("مدرس  با موفقیت ثبت شد", MessageType.Success);
                                }
                                else
                                {
                                    return MessageBox.Show("مدرس ثبت نشد", MessageType.Error);
                                }

                            }
                            else
                            {
                                System.IO.File.Delete(path);
                                return MessageBox.Show("مدرس ثبت نشد", MessageType.Error);
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
                return MessageBox.Show("مدرس ثبت نشد", MessageType.Error);
            }




        }
        [HttpGet]
        public ActionResult AllTeacher()
        {
            t.Teachers = blt.Select();

            return View(t);
        }

        [HttpGet]
        public ActionResult DetilsTeacher(int id)
        {
            t.Teacher = blt.Find(id);

            return View(t);
        }
        [HttpGet]
        public ActionResult ProfileTeacher(int id)
        {

            foreach (var item in blt.Select().Where(m => m.Id == id))
            {

                t.User = bluser.FindUser(item.Username);

            }
            t.Teacher = blt.Find(id);
            return View(t);


        }
    }
}