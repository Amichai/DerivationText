using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EquationVisualizer {
    class Decorator {
        public static FrameworkElement Decorate(FrameworkElement f, SymbolData symbolData) {
            Grid g = new Grid();
            g.VerticalAlignment = VerticalAlignment.Center;
            g.Children.Add(f);
            f.ToolTip = symbolData.Name;
            g.MouseEnter += (s, e) => {
                (s as Grid).Background = Brushes.DarkGray;
            };
            g.MouseLeave += (s, e) => {
                (s as Grid).Background = Brushes.Transparent;
            };
            return g;
        }
    }
}
