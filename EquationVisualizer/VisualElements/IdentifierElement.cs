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
            var key = node.Token.Value.ToString();
            string val;
            if (mapping.TryGetValue(key, out val)) {
                this.Value = val;
            } else {
                this.Value = key;
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
