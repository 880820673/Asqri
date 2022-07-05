using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominClass
{
   public class Slid
    {


        public Slid()
        {

        }
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int Id { get; set; }
        [Display(Name = "نام تصویر")]
        [DisplayName("نام تصویر")]
        [Required(ErrorMessage = "نام تصویر  را وارد کنید", AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Display(Name = "توضیحات")]
        [DisplayName("توضیحات")]
        public string Description { get; set; }
        [Display(Name = "کلمات کلیدی")]
        [DisplayName("کلمات کلیدی")]

        public string Keywords { get; set; }
        [Display(Name = "تصویر")]
        [DisplayName("نصویر")]
        public string File { get; set; }

    }
}
