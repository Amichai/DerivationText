using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserGenerator {
    internal class EquationParserGrammar : Grammar {
        public EquationParserGrammar() {
            var program = new NonTerminal("Equation");

            var number = new NumberLiteral("Number");
            KeyTerm l = ToTerm(@"{");
            KeyTerm r = ToTerm(@"}");
            KeyTerm e = ToTerm(@"\");
            IdentifierTerminal identifier = TerminalFactory.CreateCSharpIdentifier("Identifier");
            NonTerminal argument = new NonTerminal("Argument");
            NonTerminal argumentList = new NonTerminal("ArgumentList");
            NonTerminal argumentVal = new NonTerminal("ArgumentVal");
            NonTerminal equation = new NonTerminal("Equation");
            NonTerminal expression = new NonTerminal("Expression");
            NonTerminal expressionList = new NonTerminal("ExpressionList");
            NonTerminal op = new NonTerminal("Op");

            program.Rule = expressionList;
            expressionList.Rule = MakePlusRule(expressionList, null, expression);
            expression.Rule = equation | identifier | number | op;
            op.Rule = ToTerm("+") | "-" | "*" | "/" | "**";
            equation.Rule = e + identifier + argumentList;
            argument.Rule = l + argumentVal + r;
            argumentList.Rule = MakePlusRule(argumentList, null, argument);
            argumentVal.Rule = identifier | number | equation | argumentVal +  op + argumentVal;
            this.Root = program;
            //this.RegisterBracePair("{", "}");
            this.MarkPunctuation("{", "}", @"\");
        }
    }
}
