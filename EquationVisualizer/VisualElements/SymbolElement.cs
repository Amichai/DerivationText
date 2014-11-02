using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EquationVisualizer.VisualElements {
    class SymbolElement : VisualElement {
        public SymbolElement()
            : base("", 2) {
        }

        public override FrameworkElement Render() {
            if (this.Children.Count() > this.ChildCount || this.ChildCount < 1) {
                throw new Exception("One or two children required");
            }
            var c = this.Children[0];
            string s ;
            if (this.Children.Count() == 2) {
                s = this.Children[1].UnadjustedValue;
            } else {
                s = c.UnadjustedValue;
            }
            var symbolData = SymbolData.Symbols.Single(i => i.Identifier == s);
            c.SymbolData = symbolData;
            var rendered = c.Render();
            rendered = EquationDecorator.Decorate(rendered, symbolData);
            return rendered;
        }
    }
}
