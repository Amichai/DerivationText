using EquationVisualizer.VisualElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EquationVisualizer {
    abstract class VisualElement {
        public VisualElement(string val, int childCount) {
            this.Value = val;
            this.ChildCount = childCount;
        }
        public string Value { get; set; }
        public int ChildCount { get; set; }
        public List<VisualElement> Children { get; set; }
        public abstract FrameworkElement Render();
        public static VisualElement Frac = new FracElement();
        public List<ElementTypes> Definition { get; set; }
    }
}
