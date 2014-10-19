using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CommonUtil;
using System.Windows.Controls;
using MathBookProject.LineTypes;

namespace MathBookProject {
    public class ContentLine {
        public ContentLine(LineType type, string val) {
            UserControl line;
            this.LineType = type;
            this.Val = val;
            switch (type) {
                case LineType.Input:
                    line = new InputLine(val);
                    break;
                case LineType.Paragraph:
                    line = new ParagraphLine(val);
                    break;
                case LineType.Equation:
                    line = new EquationLine(val);
                    break;
                default:
                    throw new Exception("Unknown line type");
            }
            this.Control = line;
        }

        public string Val { get; private set; }
        public LineType LineType { get; set; }

        internal XElement ToXml() {
            XElement toReturn = new XElement("Line");
            toReturn.Add(new XAttribute("Value", this.Val));
            toReturn.Add(new XAttribute("Type", this.LineType.ToString()));
            return toReturn;
        }

        public UserControl Control { get; set; }

        internal static ContentLine FromXml(XElement xml) {
            var type = xml.Attribute("Type").Value.ToEnum<LineType>();
            var val = xml.Attribute("Value").Value;
            ContentLine toReturn = new ContentLine(type, val);
            return toReturn;
        }
    }
}
