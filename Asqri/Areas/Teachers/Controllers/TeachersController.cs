using Asqri.ViewModels;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DominClass;
namespace Asqri.Areas.Teachers.Controllers
{
    public class TeachersController : Controller
    {
        TeacherViewModel model = new TeacherViewModel();
        TeacherRepository blteacher = new TeacherRepository();
        // GET: Teachers/Teachers
        public ActionResult Index()
        {
            model.Teachers = blteacher.Select();
            return View(model);
        }
        public ActionResult Detils(int id)
        {
            model.Teacher = blteacher.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditTeachers(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacher.Enabled = true;

                if (blteacher.UpdateTeacher(teacher))
                {
                    return MessageBox.Show("معلم تایید شد", MessageType.Success);
            }
            else
            {

                return MessageBox.Show("معلم تایید نشد", MessageType.Error);
            }
        }
            else
            {
                //مقدار ورودی اشتباه
                return MessageBox.Show(ModelState.GetErrors(), MessageType.Warning);
            }
        }
        [HttpPost]
        public ActionResult falseTeachers(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacher.Enabled = false;

                if (blteacher.UpdateTeacher(teacher))
                {
                    return MessageBox.Show("ثبت شد", MessageType.Success);
                }
                else
                {

                    return MessageBox.Show("ثبت نشد", MessageType.Error);
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