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
                this.Definition = new List<ElementTypes>() {
                    ElementTypes.Expression, 
                };
        }
        public override FrameworkElement Render() {
            if (this.Children.Count() != this.ChildCount) {
                throw new Exception("Two children required for \frac{}{}");
            }
            StackPanel sp = new StackPanel() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            sp.Orientation = Orientation.Vertical;
            sp.Children.Add(this.Children[1].Render());
            sp.Children.Add(new Separator());
            sp.Children.Add(this.Children[0].Render());

            return sp;
        }
    }
}
