using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DominClass;
namespace Asqri.ViewModels
{
    public class ClassViewModels
    {
        public IEnumerable<Group> Groups { get; set; }
        public Group Group { get; set; }
        public IEnumerable<Doreh> Dorehs { get; set; }
        public Doreh Doreh { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Listt> Listts { get; set; }
        public Listt Listt { get; set; }
    }
}