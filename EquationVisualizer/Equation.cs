using EquationVisualizer.Elements;
using EquationVisualizer.VisualElements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EquationVisualizer {
    public class Equation {
        public static void Visualize(string input) {
            var e = new ExpressionToken();
            var stream = new InputStream(input);
            var taken = e.Consume(stream);
            Debug.Print(e.Print());
        }

        public static ExpressionToken GetExpression(string input) {
            var e = new ExpressionToken();
            var stream = new InputStream(input);
            var taken = e.Consume(stream);
            Debug.Print("taken: " + taken.ToString());
            return e;
        }

        private static FrameworkElement render(List<VisualElement> elements) {
            StackPanel toReturn = new StackPanel();
            toReturn.Orientation = Orientation.Horizontal;
            foreach (var e in elements) {
                toReturn.Children.Add(e.Render());
            }
            return toReturn;
        }

        internal static List<TokenElement> elements = new List<TokenElement>() { TokenElement.Frac };
        private static Dictionary<string, TokenElement> elementsLib = new Dictionary<string, TokenElement>() {
            { "\\frac", TokenElement.Frac }
        };
    }
    public enum ElementTypes {
        Expression, Frac
    }


}
