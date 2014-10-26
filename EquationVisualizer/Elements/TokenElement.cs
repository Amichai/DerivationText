using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationVisualizer.Elements {
    public abstract class TokenElement {
        public List<TokenElement> Definition { get; set; }
        public abstract bool Consume(InputStream test);
        public static Frac Frac = new Frac();
        public virtual string Print(int level = 1) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}", this.GetType().Name);
            int count = 0;
            foreach (var c in this.Children) {
                if (count++ == 0) {
                    sb.AppendLine();
                }
                for (int i = 0; i < level; i++) {
                    sb.Append("-");
                }
                sb.Append(c.Print(level + 1) + "\n");
            }
            return sb.ToString();
        }

        public List<TokenElement> Children = new List<TokenElement>();
    }
}
