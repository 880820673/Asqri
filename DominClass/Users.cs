using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominClass
{
    public class Users
    {
        public Users()
        {

        }
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int Id { get; set; }
        
        //[Required(ErrorMessage = "نام کاربری خود را وارد کنید")]
        [Display(Name = "نام کاربری")]
        [DisplayName("نام کاربری")]

        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public String Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "رمز عبور خود را وارد کنید")]
        [DisplayName("رمز عبور")]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "رمز عبور خود را تکرار کنید")]
        [DisplayName("تکرار رمز عبور")]
        [Display(Name = "تکرار رمز عبور")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "تکرار پسورد یکسان نیست")]
        public string ConfirmPassword { get; set; }
        public String Stdus { get; set; }
    }
}
