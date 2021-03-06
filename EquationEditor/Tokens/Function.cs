﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EquationEditor.Tokens {
    [DebuggerDisplay("{Value}")]
    class Function : IToken, IFunction, IArrange {
        public Function(string val) {
            this.Value = val;
            this.Type = TokenType.function;
            this.NumberOfChildren = 1;
        }
        public int NumberOfChildren { get; set; }

        public TokenType Type { get; set; }

        public string Value { get; set; }

        public bool IsHidden { get; set; }

        public IToken Clone() {
            return new Function(Value) { NumberOfChildren = this.NumberOfChildren };
        }

        public FrameworkElement Arrange(List<Node> children) {
            throw new NotImplementedException();
        }
    }
}
