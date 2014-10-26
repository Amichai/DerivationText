using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EquationVisualizer.VisualElements {
    class TextElement : VisualElement {
        public TextElement(string val) : base(val, 0) {

        }

        public override FrameworkElement Render() {
            TextBlock t = new TextBlock();
            t.Text = this.Value;
            return t;
        }
    }
}
