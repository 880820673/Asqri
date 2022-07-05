using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DominClass;
namespace Asqri.ViewModels
{
    public class HomeViewModels
    {
        public IEnumerable<Teacher> Teachers { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<Users> Users { get; set; }
        public Users User { get; set; }
        public IEnumerable<Slid> Slids { get; set; }
        public Slid Slid { get; set; }
        public IEnumerable<News> News { get; set; }
        public News news { get; set; }
        public IEnumerable<Nazar> Nazars { get; set; }
        public Nazar Nazar { get; set; }
        public IEnumerable<Doreh> Dorehs { get; set; }
        public Doreh Doreh { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public Group Group { get; set; }

    }
}