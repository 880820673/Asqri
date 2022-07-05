using DominClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asqri.ViewModels
{
    public class MarketerViewModels
    {
        public IEnumerable<Marketer> Marketers { get; set; }
        public Marketer Marketer { get; set; }
        public IEnumerable<Users> Users { get; set; }
        public Users User { get; set; }
    }
}