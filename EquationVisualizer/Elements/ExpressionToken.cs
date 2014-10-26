using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationVisualizer.Elements {
    public class ExpressionToken : TokenElement {
        public override bool Consume(InputStream stream) {
            foreach (var e in Equation.elements) {
                var taken = e.Consume(stream);
                if (!taken) {
                    continue;
                } else {
                    this.Children.Add(e);
                }
            }
            return true;
        }

        public static TokenElement Create() {
            return new ExpressionToken();
        }
    }
}
