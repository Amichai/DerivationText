using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationEditor.Tokens {
    class ImpliedMultiplication : IToken {
        public ImpliedMultiplication() {
            this.Value = "";
            this.Type = TokenType.function;
            this.IsHidden = true;
        }
        public int NumberOfChildren { get; set; }

        public TokenType Type { get; set; }

        public bool IsHidden { get; set; }

        public string Value { get; set; }

        public IToken Clone() {
            return new ImpliedMultiplication() { 
                NumberOfChildren = this.NumberOfChildren 
            };
        }
    }
}
