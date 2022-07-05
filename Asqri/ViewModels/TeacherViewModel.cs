using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominClass;

namespace Asqri.ViewModels
{
  public  class TeacherViewModel
    {
        public IEnumerable<Teacher> Teachers { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<Users> Users { get; set; }
        public Users User { get; set; }
    }
}
