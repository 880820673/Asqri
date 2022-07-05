using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominClass
{
    public class Student
    {
        public Student()
        {

        }
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "نام خود را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام ")]
        [Display(Name = "نام ")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public string Name { get; set; }
        [Required(ErrorMessage = " نام خانوادگی خود را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName(" نام خانوادگی")]
        [Display(Name = " نام خانوادگی")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "نام پدر خود را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName(" نام پدر ")]
        [Display(Name = "نام پدر ")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public string Father { get; set; }
        [Required(ErrorMessage = "کد ملی خود را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName(" کدملی ")]
        [Display(Name = "کد ملی  ")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public string Code { get; set; }
        [Required(ErrorMessage = "ایمیل خود را وارد کنید")]
        [Display(Name = "ایمیل ")]
        [DisplayName("ایمیل ")]
        [RegularExpression(@"^[_A-Za-z0-9-\+]+(\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\.[A-Za-z0-9-]+)*(\.[A-Za-z]{2,4})$", ErrorMessage = "ایمیل را بدرستی وارد کنید")]
        public string Email { get; set; }
        [Required(ErrorMessage = "نام کاربری خود را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام کاربری ")]
        [Display(Name = "نام کاربری ")]
        public string Username { get; set; }


        [DisplayName("مقطع تحصیلی ")]
        [Display(Name = "مقطع تحصیلی ")]
        public string Magth { get; set; }

        [Required(ErrorMessage = "رشته تحصیلی خود را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("رشته تحصیلی تحصیلی ")]
        [Display(Name = "رشته تحصیلی تحصیلی ")]
        public string Reshth { get; set; }
        [DisplayName("آخرین معدل ")]
        [Display(Name = "آخرین معدل ")]
        [Required(ErrorMessage = "آخرین معدل خود را وارد کنید", AllowEmptyStrings = false)]
        public string Avrge { get; set; }
        [DisplayName("جنسیت ")]
        [Display(Name = "جنسیت ")]
        public string Gender { get; set; }
        [DisplayName("شماره موبایل")]
        [Display(Name = "شماره موبایل")]
        [RegularExpression(@"^0?9[123]\d{8}$", ErrorMessage = "شماره موبایل را بدرستی وارد کنید")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public string Mobile { get; set; }
        [DisplayName("آدرس ")]
        [Display(Name = "آدرس ")]
        public string Adress { get; set; }
        [DisplayName("تصویر صفحه نخست شناسنامه ")]
        [Display(Name = "تصویر صفحه نخست شناسنامه ")]
        public string ShenasnameImage { get; set; }
        [DisplayName("تصویر کارت ملی ")]
        [Display(Name = "تصویر کارت ملی ")]
        public string NationalImage { get; set; }
        [DisplayName("تصویر 3*4 دانش آموز ")]
        [Display(Name = "تصویر 3*4 دانش آموز")]
        public string StudentImage { get; set; }
    }
}
