using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DominClass;

namespace Asqri.ViewModels
{
    public class NewsViewModels
    {
        public IEnumerable<News> News { get; set; }
        public News news { get; set; }
    }
}