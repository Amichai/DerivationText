using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationVisualizer {
    public class SymbolData {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SymbolVal { get; set; }
        public SymbolData(string identifier, string name, string description, string symbol) {
            this.Identifier = identifier;
            this.Name = name;
            this.Description = description;
            this.SymbolVal = symbol;
        }

        public static SymbolData Create(string identifier, string name, string description, string symbol) {
            SymbolData toReturn = new SymbolData(identifier, name, description, symbol);
            return toReturn;
        }

        public static List<SymbolData> Symbols = new List<SymbolData>() {
            SymbolData.Create("hbar", 
            "Reduced Planck Constant", 
            "The Planck constant (denoted h, also called Planck's constant) is a physical constant that is the quantum of action in quantum mechanics. Published in 1900, it originally described the proportionality constant between the energy, E, of a charged atomic oscillator in the wall of a black body, and the frequency, ν, of its associated electromagnetic wave. Its relevance is now integral to the field of quantum mechanics, describing the relationship between energy and frequency, known as the Planck–Einstein relation:",
            "ℏ"),

            SymbolData.Create("partial", 
            "Partial", 
            "Partial",
            "∂"),

            SymbolData.Create("psi", 
            "Psi", 
            "Psi",
            "Ψ"),
        };
    }
}
