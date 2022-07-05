using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DominClass
{
   public class Teacher
    {
        public Teacher()
        {

        }
      
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int Id { get; set; }
        [Display(Name = "نام")]
        [DisplayName("نام")]
        [Required(ErrorMessage = "نام  را وارد کنید", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "حداکثر تعداد حروف وارده پنجاه حرف است")]
        public string Fname { get; set; }
        [Display(Name = "نام خانوادگی")]
        [DisplayName("نام خانوادگی")]
        [Required(ErrorMessage = "نام خانوادگی را وارد کنید", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "حداکثر تعداد حروف وارده پنجاه حرف است")]
        public string Lname { get; set; }
        [Display(Name = "نام کاربری")]
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "نام کاربری را وارد کنید", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "حداکثر تعداد حروف وارده پنجاه حرف است")]
        public string Username { get; set; }
  
        [Display(Name = "ایمیل")]
        [DisplayName("ایمیل")]
        [Required(ErrorMessage = "ایمیل  را وارد کنید", AllowEmptyStrings = false)]
        [RegularExpression(@"^[_A-Za-z0-9-\+]+(\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\.[A-Za-z0-9-]+)*(\.[A-Za-z]{2,4})$", ErrorMessage = "ایمیل را بدرستی وارد کنید")]
        public string Email { get; set; }
        [Display(Name = "شماره موبایل")]
        [DisplayName("شماره موبایل")]
        [RegularExpression(@"^0?9[123]\d{8}$", ErrorMessage = "شماره موبایل را بدرستی وارد کنید")]
        public string Mobile { get; set; }
        [Display(Name = "شماره تلگرام")]
        [DisplayName("شماره تلگرام")]
        [Required(ErrorMessage = "نام محصول را وارد کنید", AllowEmptyStrings = false)]
        [RegularExpression(@"^0?9[123]\d{8}$", ErrorMessage = "شماره موبایل را بدرستی وارد کنید")]
        public string Tlegram { get; set; }
   
        [Display(Name = "در چه زمینه درسی مایل به همکاری با هستید :")]
        [DisplayName("در چه زمینه درسی مایل به همکاری با ما هستید :")]
   
        public string Intresting { get; set; }
        [Display(Name = "جنسیت")]
        [DisplayName("جنسیت")]
        [Required(ErrorMessage = "جنسیت را انتخاب کنید", AllowEmptyStrings = false)]
        public string Gender { get; set; }
        [Display(Name = "عکس ")]
        [DisplayName("عکس")]

        public string Image { get; set; }
        [Display(Name = "تصویر مصدق کارت ملی")]
        [DisplayName("تصویر مصدق کارت ملی")]
       
        public string NationalImage { get; set; }
        [Display(Name = "تصویر مصدق  مدرک تحصیلی")]
        [DisplayName("تصویر مصدق مدرک تحصیلی")]

        public string DegreeImage { get; set; }
        [Display(Name = "تصویر مصدق رزومه")]
        [DisplayName("تصویر مصدق رزومه")]
 
        public string RozomeImage { get; set; }
        public bool Enabled { get; set; }
    }
}
