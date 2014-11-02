using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DerivationViewer {
    public class Derivation {
        public List<Frame> frames = new List<Frame>();

        public static Derivation Parse(XElement xml) {
            Derivation toReturn = new Derivation();
            foreach (var e in xml.Elements()) {
                toReturn.frames.Add(Frame.Parse(e));
            }
            return toReturn;
        }
    }
}
