using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace DominClass
{
  public  class News
    {
        public News()
        {

        }
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int Id { get; set; }
        [Display(Name = "تیتر")]
        [DisplayName("تیتر")]
        [Required(ErrorMessage = "تیتر  را وارد کنید", AllowEmptyStrings = false)]
        public string Title { get; set; }
        [Display(Name = "خلاصه خبر")]
        [DisplayName("خلاصه خبر")]
        [Required(ErrorMessage = "خلاصه خبر  را وارد کنید", AllowEmptyStrings = false)]
        [AllowHtml]

        public string Summary { get; set; }
      
        [Display(Name = "شرح خبر")]
        [DisplayName("شرح خبر")]
        [Required(ErrorMessage = "شرح خبر  را وارد کنید", AllowEmptyStrings = false)]
        [DataType(DataType.Html, ErrorMessage = "فرمت متن نا معتبر است")]
        [AllowHtml]

        public string Description { get; set; }

        [Display(Name = "تصویر")]
        [DisplayName("تصویر")]
      

        public string Image { get; set; }
        [Display(Name = "کلمات کلیدی")]
        [DisplayName("کلمات کلیدی")]
        public string Keywords { get; set; }
        [Display(Name = "تاریخ")]
        [DisplayName("تاریخ ")]
        public DateTime times { get; set; }
    }
 

   
}
