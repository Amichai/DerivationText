using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DerivationViewer {
    class Frame {
        public string Content { get; private set; }
        public string Description { get; set; }
        public static Frame Parse(XElement xml) {
            Frame toReturn = new Frame();
            toReturn.Content = xml.Attribute("Content").Value;
            toReturn.Description = xml.Attribute("Description").Value;
            return toReturn;
        }
    }
}
