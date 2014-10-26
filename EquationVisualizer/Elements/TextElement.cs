using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationVisualizer.Elements {
    class TextElement : TokenElement {
        public TextElement(string val) {
            this.Val = val;
        }
        public string Val { get; private set; }
        public override bool Consume(InputStream test) {
            return test.StartsWith(this.Val);
        }

        public static TextElement Create(string s) {
            return new TextElement(s);
        }

        public override string Print(int level = 1) {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.GetType().Name + ", " + this.Val);
            int count = 0;
            foreach (var c in this.Children) {
                if (count++ == 0) {
                    sb.AppendLine();
                }
                for (int i = 0; i < level; i++) {
                    sb.Append("-");
                }
                sb.AppendFormat(c.Print(level + 1) + "\n");
            }
            return sb.ToString();
        }
    }
}
