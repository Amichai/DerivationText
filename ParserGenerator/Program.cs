using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserGenerator {
    class Program {
        static void Main(string[] args) {
            var g = new EquationParser();
            var p = new Parser(g);
            var tree = p.Parse(@"
test+\testing{2.3}{t1}{t2}{\test3{44.0}} test
");
            var s = tree.ToString();
            Debug.Print(tree.ToXml());
        }

    }
}
