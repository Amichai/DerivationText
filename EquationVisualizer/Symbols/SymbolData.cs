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
        public SymbolData(string identifier, string name, string description) {
            this.Identifier = identifier;
            this.Name = name;
            this.Description = description;
        }

        public static SymbolData Create(string identifier, string name, string description) {
            SymbolData toReturn = new SymbolData(identifier, name, description);
            return toReturn;
        }
    }
}
