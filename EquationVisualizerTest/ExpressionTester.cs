using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EquationVisualizer;
using System.Diagnostics;
using System.Collections.Generic;

namespace EquationVisualizerTest {
    [TestClass]
    public class ExpressionTester {
        [TestMethod]
        public void ExpressionTest1() {
            this.testExpression("\\frac{t}{3}",
@"ExpressionToken
-Frac
--TextElement, \frac{
--ExpressionToken
--TextElement, }{
--ExpressionToken
--TextElement, }");
        }


        private void testExpression(string input, string target) {
            var e = Equation.GetExpression(input);
            var result = e.Print();
            Debug.Print(result);
            Assert.IsTrue(areEqual(target, result));
        }

        private List<string> toStrip = new List<string>() { "\n", "\r" };

        private bool areEqual(string s1, string s2) {
            foreach (var c in toStrip) {
                s1 = s1.Replace(c, "");
                s2 = s2.Replace(c, "");
            }
            return s1 == s2;
        }
    }
}
