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
            if (this.Children.Count() != this.ChildCount) {
                throw new Exception("One child required");
            }
            var c = this.Children[0];
            var s = this.Children[1].UnadjustedValue;
            var symbolData = SymbolData.Symbols.Single(i => i.Identifier == s);
            c.SymbolData = symbolData;
            var rendered = c.Render();
            rendered = EquationDecorator.Decorate(rendered, symbolData);
            return rendered;
        }
    }
}
