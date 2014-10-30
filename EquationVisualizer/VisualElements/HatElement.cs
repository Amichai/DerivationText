using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EquationVisualizer.VisualElements {
    class HatElement : VisualElement {
        public HatElement()
            : base("", 1) {

        }

        public override FrameworkElement Render() {
            if (this.Children.Count() != this.ChildCount) {
                throw new Exception("One child required");
            }
            StackPanel sp = new StackPanel() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            sp.Margin = new Thickness(0, -6, 0, 0);
            sp.Orientation = Orientation.Vertical;

            var t = this.getTextBlock("^");
            t.Margin = new Thickness(0, 0, 0, -10);
            sp.Children.Add(t);
            sp.Children.Add(this.Children[0].Render());


            return sp;
        }
    }
}
