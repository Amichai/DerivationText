using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationEditor.Tokens {
    [DebuggerDisplay("{Value}")]
    class Number : IToken {
        public Number(string asString, double numericalVal) {
            this.Value = asString;
            this.numericalVal = numericalVal;
            this.Type = TokenType.number;
        }

        public double numericalVal { get; private set; }
        public int NumberOfChildren { get; set; }

        public TokenType Type { get; set; }
        public bool IsHidden { get; set; }

        public string Value { get; set; }

        public IToken Clone() {
            return new Number(Value, numericalVal) { NumberOfChildren = this.NumberOfChildren };
        }
    }
}
