using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RoundTheCorner.BL.Models
{
    public class MenuSectionModel
    {
        public int MenuSectionID { get; set; }

        public string MenuSectionName { get; set; }
        public int MenuID { get; set; }
        public int DisplayOrderNum { get; set; }
    }
}
