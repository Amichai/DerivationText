using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationEditor.Tokens {
    class ImpliedMultiplicationInfix : InfixOperator {
        public ImpliedMultiplicationInfix() : base("", 3, Associativity.left) {
            this.IsHidden = true;
        }
    }
}
