using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EquationVisualizer.VisualElements {
    class IdentifierElement : VisualElement {
        public IdentifierElement(ParseTreeNode node)
            : base(node.Token.Value.ToString(), -1) {
            var key = this.Value;
            var match =  SymbolData.Symbols.Where(i => i.Identifier == key).SingleOrDefault();
            if (match != null) {
                this.Value = match.SymbolVal;
            }
        }

        public override FrameworkElement Render() {
            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.Text = this.Value;
            return tb;
        }
    }
}
