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
   public class Marketer
    {
        public Marketer ()
        {

        }
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "نام کاربری خود را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام کاربری ")]
        [Display(Name = "نام کاربری ")]
        public string Username { get; set; }
        [Required(ErrorMessage = "نام خود را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام ")]
        [Display(Name = "نام ")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "نام خانوادگی خود را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام خانوادگی ")]
        [Display(Name = "نام خانوادگی ")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public string Lname { get; set; }
        [Required(ErrorMessage = "ایمیل خود را وارد کنید")]
        [Display(Name = "ایمیل ")]
        [DisplayName("ایمیل ")]
        [RegularExpression(@"^[_A-Za-z0-9-\+]+(\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\.[A-Za-z0-9-]+)*(\.[A-Za-z]{2,4})$", ErrorMessage = "ایمیل را بدرستی وارد کنید")]
        public string Email { get; set; }
        [DisplayName("شماره موبایل")]
        [Display(Name = "شماره موبایل")]
        [RegularExpression(@"^0?9[123]\d{8}$", ErrorMessage = "شماره موبایل را بدرستی وارد کنید")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public string Mobile { get; set; }
        [DisplayName("جنسیت ")]
        [Display(Name = "جنسیت ")]
        public string Gender { get; set; }
        public string Intresting { get; set; }
        [DisplayName("روزمه ")]
        [Display(Name = "روزمه ")]
        public string Files { get; set; }
    }
}
