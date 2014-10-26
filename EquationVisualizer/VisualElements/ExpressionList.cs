using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EquationVisualizer.VisualElements {
    class ExpressionList : VisualElement {
        public ExpressionList(ParseTreeNode node)
            : base("", -1) {
            foreach (var c in node.ChildNodes) {
                this.Children.Add(c.ToVisualElement());
            }

        }
        public override FrameworkElement Render() {
            StackPanel p = new StackPanel();
            p.Orientation = Orientation.Horizontal;
            foreach (var c in this.Children) {
                p.Children.Add(c.Render());
            }
            return p;
        }
    }
}
