using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EquationVisualizer.VisualElements {
    class SymbolElement : VisualElement {
        public SymbolElement()
            : base("", 2) {
        }

        public override FrameworkElement Render() {
            if (this.Children.Count() != this.ChildCount) {
                throw new Exception("One child required");
            }
            var c = this.Children[0];
            var s = this.Children[1].UnadjustedValue;
            var symbolData = Symbols.Single(i => i.Identifier == s);
            c.SymbolData = symbolData;
            var rendered = c.Render();
            rendered = EquationDecorator.Decorate(rendered, symbolData);
            return rendered;
        }


        public static List<SymbolData> Symbols = new List<SymbolData>() {
            SymbolData.Create("hbar", "Reduced Planck Constant", "The Planck constant (denoted h, also called Planck's constant) is a physical constant that is the quantum of action in quantum mechanics. Published in 1900, it originally described the proportionality constant between the energy, E, of a charged atomic oscillator in the wall of a black body, and the frequency, ν, of its associated electromagnetic wave. Its relevance is now integral to the field of quantum mechanics, describing the relationship between energy and frequency, known as the Planck–Einstein relation:"),
        };
        //public static Dictionary<string, SymbolData> Symbols = new Dictionary<string, SymbolData>() {
        //    {"hbar", new SymbolData()}

        //};
    }
}
