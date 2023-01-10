using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL
{
    public class ImageConfiguration:BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string ImagePosition { get; set; } //RequestCatalog, Social Impact, MemberShip
        public string DetailsText { get; set; }
    }
}
