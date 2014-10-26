using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserGenerator {
    public class EquationParser : Grammar {
        public EquationParser() {
            var program = new NonTerminal("Equation");

            var number = new NumberLiteral("number");
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

            expressionList.Rule = MakePlusRule(expressionList, null, expression);
            expression.Rule = equation | identifier | number | op;
            op.Rule = ToTerm("+") | "-" | "*" | "/" | "**";
            program.Rule = expressionList;
            equation.Rule = e + identifier + argumentList;
            argument.Rule = l + argumentVal + r;
            argumentList.Rule = MakePlusRule(argumentList, null, argument);
            argumentVal.Rule = identifier | number | equation;
            this.Root = program;
            //this.RegisterBracePair("{", "}");
            this.MarkPunctuation("{", "}", @"\");
        }
    }
}
