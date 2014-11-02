using EquationVisualizer.VisualElements;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EquationVisualizer {
    abstract class VisualElement {
        public VisualElement(string val, int childCount) {
            this.Value = val;
            this.UnadjustedValue = val;
            this.ChildCount = childCount;
            this.Children = new List<VisualElement>();
        }
        public string Value { get; set; }
        public string UnadjustedValue { get; set; }
        public int ChildCount { get; set; }
        public List<VisualElement> Children { get; set; }
        public abstract FrameworkElement Render();

        public SymbolData SymbolData = null;


        public void SetChildren(ParseTreeNode node) {
            foreach (var c in node.ChildNodes) {
                this.Children.Add(c.ToVisualElement());
            }
        }

        protected FrameworkElement getTextBlock(string text) {
            return new TextBlock() { Text = text, TextAlignment = TextAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
        }
    }
}
