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
            foreach (var c in node.ChildNodes) {
                this.Children.Add(c.ToVisualElement());
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
