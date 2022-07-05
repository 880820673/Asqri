using Asqri.ViewModels;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asqri.Helpers.Filters;
using System.IO;
using DominClass;
namespace Asqri.Controllers
{
    public class StudentController : Controller
    {
        StudentViewModel st = new StudentViewModel();
        StudentRepository bls = new StudentRepository();
        UsersRepository bluser = new UsersRepository();
        // GET: Student
        [HttpGet]
        public ActionResult RegisterStudent()
        {
            st.Students = bls.Select();
            return View(st);
        }
        [AjaxOnly]
        [HttpPost]
        [Route("api/Files/UploadImages")]
        public ActionResult RegisterStudent(Student student,Users user ,HttpPostedFileBase UploadImage, HttpPostedFileBase UploadImage2, HttpPostedFileBase UploadImage3)
        {
            if (UploadImage != null && UploadImage.ContentLength > 0 && UploadImage2 != null && UploadImage2.ContentLength > 0 && UploadImage3 != null && UploadImage3.ContentLength > 0)
                try
                {

                    if (ModelState.IsValid)
                    {
                        string path = Path.Combine(Server.MapPath("~/File/UploadImages"),
                           Path.GetFileName(UploadImage.FileName));
                        UploadImage.SaveAs(path);
                        student.ShenasnameImage = UploadImage.FileName;
                        //UploadImage2
                        string path2 = Path.Combine(Server.MapPath("~/File/UploadImages"),
                        Path.GetFileName(UploadImage2.FileName));
                        UploadImage2.SaveAs(path2);
                        student.NationalImage = UploadImage2.FileName;
                        //UploadImage3
                        string path3 = Path.Combine(Server.MapPath("~/File/UploadImages"),
                       Path.GetFileName(UploadImage3.FileName));
                        UploadImage3.SaveAs(path3);
                        student.StudentImage = UploadImage3.FileName;
                        if (bluser.Exist2(student.Username))
                        {
                            return MessageBox.Show("با این نام کاربری قبلا در سایت ثبت شده است ", MessageType.Warning);
                        }
                        else
                        {
                            user.Username = student.Username;
                            user.Stdus = "student";
                            if (bls.Add(student))
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
                return MessageBox.Show("دانش آموز ثبت نشد", MessageType.Error);
            }


        }
 
}
}