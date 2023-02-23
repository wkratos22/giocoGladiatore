using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace giocoGladiatore
{
    public class row
    {
        [XmlElement("phrase")]
        public string phrase { get; set; }
        [XmlElement("IsEvil")]
        public bool IsEvil { get; set; }
    }
}
