using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathBookProject.LineTypes {
    /// <summary>
    /// Interaction logic for EquationLine.xaml
    /// </summary>
    public partial class EquationLine : UserControl {
        public EquationLine() {
            InitializeComponent();
        }

        public string Val { get; set; }

        public EquationLine(string val)
            : this() {
                this.Val = val;
                this.root.Children.Add(new EquationEditor.Editor().Process(this.Val));
        }
    }
}
