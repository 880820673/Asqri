using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace DominClass
{
  public  class Doreh
    {
        public Doreh()
        {

        }
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int ID { get; set; }
        [Display(Name = "نام دوره")]
        [DisplayName("نام دوره")]
        [MaxLength (50)]
        public string DorehName { get; set; }
        [Display(Name = "نام گروه درسی")]
        [DisplayName("نام گروه درسی")]
        public int GroupId { get; set; }
        [Display(Name = "تیتر دوره")]
        [DisplayName("تیتر دوره")]
        public string TitrDoreh { get; set; }
        [Display(Name = "شرح دوره")]
        [DisplayName("شرح دوره")]
        [AllowHtml]
        [DataType(DataType.Html, ErrorMessage = "فرمت متن نا معتبر است")]
        public string SharhDoreh { get; set; }
        [Display(Name = "تصویر ")]
        [DisplayName("تصویر ")]
        public string ImageDoreh { get; set; }
        [Display(Name = "نام مدرس")]
        [DisplayName("نام مدرس")]
        [MaxLength(50)]
        public string TeacherName { get; set; }
        [Display(Name = "شروع دوره")]
        [DisplayName("شروع دوره")]
        public string ShoroDoreh { get; set; }
        [Display(Name = "پایان دوره")]
        [DisplayName("پایان دوره")]
        public string PayanDoreh { get; set; }
        [Display(Name ="وضعیت دوره")]
        [DisplayName("وضعیت دوره")]
        public bool Enabled { get; set; }
        [Display(Name = "قیمت دوره ")]
        [DisplayName("قیمت دوره ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "قیمت محصول را وارد کنید")]
        [Range(1, int.MaxValue, ErrorMessage = "قیمت نا معتبر است")]
        public decimal Price { get; set; }
    }
}
