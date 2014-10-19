using EquationEditor.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationEditor {
    class ParseTree {
        public void BuildTree(List<IToken> TokenQueue) {
            Stack<Node> stackBuffer = new Stack<Node>();
            foreach (var t in TokenQueue) {
                if (t.Type == TokenType.infixOperator) {
                    //Debug.Print("Infix: " + t.Value);
                    Node n = new Node(t);
                    n.Children.Add(stackBuffer.Pop());
                    n.Children.Add(stackBuffer.Pop());
                    n.TextRepresentation = n.Children[0].AsText() + t.Value + n.Children[1].AsText();
                    stackBuffer.Push(n);
                } else if (t.Type == TokenType.function) {
                    //Debug.Print("function: " + t.Value);
                    Node n = new Node(t);
                    n.TextRepresentation = t.Value;
                    for (int i = 0; i < t.NumberOfChildren; i++) {
                        n.Children.Add(stackBuffer.Pop());
                        n.TextRepresentation += " " + n.Children.Last().TextRepresentation;
                    }
                    stackBuffer.Push(n);
                } else {
                    stackBuffer.Push(new Node(t));
                }
            }
            var c = stackBuffer.Count();
            if (c > 0) {
                //Debug.Print("Excess Stack count: " + c);
                var op = new ImpliedMultiplication();
                Node implied = new Node(op);
                while (stackBuffer.Count() > 0) {
                    implied.Children.Add(stackBuffer.Pop());
                }
                implied.Children.Reverse();
                //Root = stackBuffer.First();
                Root = implied;
            } else {
                Root = new Node(new Keyword(""));
            }
        }

        public Node Root;
    }
}
