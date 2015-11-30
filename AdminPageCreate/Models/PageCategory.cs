using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPageCreate.Models
{
    public class PageCategory:BaseModel
    {
        public string Name { get; set; }
        public PageCategory Parent { get; set; }
        public List<Page> Chields { get; set; }
    }
}