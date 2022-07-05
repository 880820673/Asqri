using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Asqri.Models.EntityModels
{
    public class TeacherMetaData
    {
        [ScaffoldColumn(false)]
        [Bindable(false)]

        [Display(Name = "نام")]
        [DisplayName("نام")]
        [Required(ErrorMessage = "نام خود را وارد کنید", AllowEmptyStrings = false)]
        [StringLength(50,ErrorMessage ="حداکثر تعداد حروف وارده پنجاه حرف است")]
        public string Fname { get; set; }
        [Display(Name ="نام خانوادگی")]
        [DisplayName("نام خانوادگی")]
        [Required (ErrorMessage ="نام خانوادگی را وارد کنید",AllowEmptyStrings =false)]
        [StringLength(50, ErrorMessage = "حداکثر تعداد حروف وارده پنجاه حرف است")]
        public string Lname { get; set; }
        [Display(Name ="نام کاربری")]
        [DisplayName("نام کاربری")]
        [Required (ErrorMessage ="نام کاربری را وارد کنید",AllowEmptyStrings =false)]
        [StringLength(50, ErrorMessage = "حداکثر تعداد حروف وارده پنجاه حرف است")]
        public string Username { get; set; }
        [Display(Name ="پسورد")]
        [DisplayName("پسورد")]
        [Required(ErrorMessage ="لطفا پسورد را وارد کنید",AllowEmptyStrings =false)]
        public int Password { get; set; }
        [Display(Name ="ایمیل")]
        [DisplayName("ایمیل")]
        [Required(ErrorMessage ="لطفا ایمیل را وارد کنید",AllowEmptyStrings =false)]
        public string Email { get; set; }
        [Display(Name ="شماره موبایل")]
        [DisplayName("شماره موبایل")]
        [Required(ErrorMessage ="شماره موبایل را وارد کنید",AllowEmptyStrings =false)]
        public int Mobile { get; set; }
        [Display(Name ="شماره تلگرام")]
        [DisplayName("شماره تلگرام")]
        [Required(ErrorMessage ="لطفا شماره ای که دارای حساب تلگرامی است را وارد کنید",AllowEmptyStrings =false)]
        public int Tlegram { get; set; }
        [Display(Name ="شماره تلفن ثابت")]
        [DisplayName("شماره تلفن ثابت")]
        [Required(ErrorMessage ="شماره تلفن ثابت را وارد کنید",AllowEmptyStrings =false)]
        public int Phone { get; set; }
        [Display(Name ="در چه زمینه درسی مایل به همکاری با هستید :")]
        [DisplayName("در چه زمینه درسی مایل به همکاری با ما هستید :")]
        [Required(ErrorMessage ="لطفا فیلد را پر کنید",AllowEmptyStrings =false)]
        public string Intresting { get; set; }
        [Display(Name ="")]
        [DisplayName("")]
        [Required(ErrorMessage ="",AllowEmptyStrings =false)]
        public int Gender { get; set; }
        [Display(Name = "عکس ")]
        [DisplayName("عکس")]
        [Required(ErrorMessage = "", AllowEmptyStrings = false)]
        public string Image { get; set; }
        [Display(Name = "تصویر مصدق کارت ملی")]
        [DisplayName("تصویر مصدق کارت ملی")]
        [Required(ErrorMessage = "", AllowEmptyStrings = false)]
        public string NationalImage { get; set; }
        [Display(Name = "تصویر مصدق  مدرک تحصیلی")]
        [DisplayName("تصویر مصدق مدرک تحصیلی")]
        [Required(ErrorMessage = "", AllowEmptyStrings = false)]
        public string DegreeImage { get; set; }
        [Display(Name = "تصویر مصدق رزومه")]
        [DisplayName("تصویر مصدق رزومه")]
        [Required(ErrorMessage = "", AllowEmptyStrings = false)]
        public string RozomeImage { get; set; }
    }
}