using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EquationVisualizer.VisualElements {
    class EquationElement : VisualElement {
        public EquationElement(ParseTreeNode node) : base("", -1) {
            foreach (var c in node.ChildNodes) {
                var v = c.ToVisualElement();
                if (v == null) {
                    continue;
                }
                this.Children.Add(v);
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
