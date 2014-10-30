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
            : base("", -1) {
            var v = node.Token.Value.ToString();
            if (mapping.ContainsKey(v)) {
                this.Value = mapping[v];
            } else {
                this.Value = v;
            }
        }

        public override FrameworkElement Render() {
            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.Text = this.Value;
            return tb;
        }
        private static Dictionary<string, string> mapping = new Dictionary<string, string>() {
            {@"hbar",  @"ℏ" },
            {@"partial", "∂"},
            {@"psi", "Ψ"},
        };
    }
}
