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
            var g = new EquationParserGrammar();
            var p = new Parser(g);
//            var tree = p.Parse(@"
//test+\testing{2.3}{t1}{t2}{\test3{44.0}} test
//");
            //var tree = p.Parse(@"\frac{3 + 3}{4}");
            var input = @"\frac{4 + 3}{4} * te";
            var tree = p.Parse(input);
            var s = tree.ToString();
            Debug.Print(tree.ToXml());
        }

    }
}
