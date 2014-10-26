using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationVisualizer.Elements {
    public class Frac : TokenElement {
        public Frac() {
            this.Definition = new List<TokenElement>() {
                TextElement.Create("\\frac{"),
                ExpressionToken.Create(),
                TextElement.Create("}{"),
                ExpressionToken.Create(),
                TextElement.Create("}"),
            };
        }


        public override bool Consume(InputStream test) {
            foreach (var d in this.Definition) {
                if (!d.Consume(test)) {
                    return false;
                } else {
                    this.Children.Add(d);
                }
            }
            return true;
        }
    }
}
