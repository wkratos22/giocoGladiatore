using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace giocoGladiatore
{
    public class root
    {
        [XmlElement("row")]
        public row[] rows { get; set; }
    }
}
