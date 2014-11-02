using ParserGenerator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Irony.Parsing;
using EquationVisualizer.VisualElements;

namespace EquationVisualizer {
    public class Equation {
        public static FrameworkElement Visualize(string input) {
            var tree = EquationParser.Parse(input);
            //Debug.Print(tree.ToXml());
            if (tree.ParserMessages.Count() > 0) {
                var msg = string.Join(", ", tree.ParserMessages.Select(i => i.Message));
                Debug.Print(msg);
                return null;
            }
            return render(tree);

        }

        private static FrameworkElement render(ParseTree elements) {
            var vis = elements.Root.ToVisualElement();
            return vis.Render();
        }
    }

    static class Ext {
        private static Stack<VisualElement> waitingForArguments = new Stack<VisualElement>();
        public static VisualElement ToVisualElement(this ParseTreeNode node) {
            string name = node.Term.Name;
            switch (name) {
                case "Equation":
                    return new EquationElement(node);
                case "IdentifierList":
                case "ExpressionList":
                    if (node.ChildNodes.Count() == 1) {
                        return node.ChildNodes.Single().ToVisualElement();
                    }
                    return new ExpressionList(node);
                case "Op":
                case "InclusiveIdentifier":
                case "Expression":
                    return node.ChildNodes.Single().ToVisualElement();
                case "Identifier":
                    VisualElement toReturn;
                    string n2 = node.Token.Value.ToString();
                    switch (n2) {
                        case "frac":
                            toReturn = new FracElement();
                            break;
                        case "sup":
                            toReturn = new SupElement();
                            break;
                        case "sub":
                            toReturn = new SubElement();
                            break;
                        case "hat":
                            toReturn = new HatElement();
                            break;
                        case "_":
                            toReturn = new SymbolElement();
                            break;
                        default:
                            toReturn = new IdentifierElement(node);
                            break;
                    }
                    if (toReturn.ChildCount > 0) {
                        waitingForArguments.Push(toReturn);
                    }
                    return toReturn;
                case "ArgumentList":
                    waitingForArguments.Pop().SetChildren(node);
                    return null;
                case "ArgumentVal":
                case "Argument":
                    if (node.ChildNodes.Count() == 1) {
                        return node.ChildNodes.Single().ToVisualElement();
                    }
                    return new ExpressionList(node);
                case "SpecialChar":
                    return node.ChildNodes.Single().ToVisualElement();
                case "*":
                case "-":
                case "/":
                case "+":
                case "=":
                case "**":

                case "Number":
                    return new IdentifierElement(node);
                default:
                    Debug.Print(name);
                    break;
            }
            throw new Exception();
        }
    }
}
