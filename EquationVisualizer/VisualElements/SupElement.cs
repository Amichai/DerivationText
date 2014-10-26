using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EquationVisualizer.VisualElements {
    class SupElement : VisualElement {
        public SupElement()
            : base("", 1) {

        }

        public override FrameworkElement Render() {
            if (this.Children.Count() != this.ChildCount) {
                throw new Exception("Two children required for \frac{}{}");
            }
            StackPanel sp = new StackPanel() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            sp.Orientation = Orientation.Vertical;
            var a = this.Children[0].Render();
            if (a is TextBlock) {
                (a as TextBlock).FontSize -= 3;
            }
            a.HorizontalAlignment = HorizontalAlignment.Center;
            a.Margin = new Thickness(0, 0, 0, 8);
            sp.Children.Add(a);
            return sp;
        }
    }
}
