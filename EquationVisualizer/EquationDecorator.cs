using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EquationVisualizer {
    public class EquationDecorator {
        public static Subject<FrameworkElement> ClickEvent = new Subject<FrameworkElement>();
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
            g.PreviewMouseDown += (s, e) => {
                ClickEvent.OnNext(s as FrameworkElement);
            };
            g.Tag = symbolData.Identifier;
            return g;
        }
    }
}
