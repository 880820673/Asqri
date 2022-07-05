using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominClass
{
    public class Nazar
    {
        public Nazar()
        {

        }
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int Id { get; set; }
        [Display(Name = "نام")]
        [DisplayName("نام")]
        [Required(ErrorMessage = "نام  را وارد کنید", AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Display(Name = "موضوع ")]
        [DisplayName("موضوع ")]
        [Required(ErrorMessage = "موضوع  را وارد کنید", AllowEmptyStrings = false)]
        public string Title { get; set; }
        [Display(Name = "شرح نظر   ")]
        [DisplayName("شرح نظر ")]
        [Required(ErrorMessage = "شرح  را وارد کنید", AllowEmptyStrings = false)]
        public string Summary { get; set; }
        public DateTime Times { get; set; }
        public bool Enabled { get; set; }
    }
}
