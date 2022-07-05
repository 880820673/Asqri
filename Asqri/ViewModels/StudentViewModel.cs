using DominClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asqri.ViewModels
{
    public class StudentViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public Student Student { get; set; }
        public IEnumerable<Users> Users { get; set; }
        public Users User { get; set; }
    }
}