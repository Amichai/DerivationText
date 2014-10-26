using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EquationVisualizer.VisualElements {
    class FracElement : VisualElement {
        public FracElement()
            : base("", 2) {
        }
        public override FrameworkElement Render() {
            if (this.Children.Count() != this.ChildCount) {
                throw new Exception("Two children required for \frac{}{}");
            }
            StackPanel sp = new StackPanel() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            sp.Orientation = Orientation.Vertical;
            var a = this.Children[0].Render();
            a.HorizontalAlignment = HorizontalAlignment.Center;
            sp.Children.Add(a);
            sp.Children.Add(new Separator());
            var b = this.Children[1].Render();
            b.HorizontalAlignment = HorizontalAlignment.Center;
            sp.Children.Add(b);

            return sp;
        }
    }
}
