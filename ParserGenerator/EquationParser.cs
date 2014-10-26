using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserGenerator {
    public class EquationParser {
        private static EquationParserGrammar grammar = new EquationParserGrammar();
        private static Parser parser = new Parser(grammar);
        public static ParseTree Parse(string input) {
            var tree = parser.Parse(input);
            return tree;
        }
    }
}
