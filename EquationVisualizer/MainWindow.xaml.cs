using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace EquationVisualizer {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged {
        public MainWindow() {
            InitializeComponent();
            //this.Input = "\\frac{t}{3}";
            //this.Input = @"\frac{4 + 3}{4} \sup{3}3\sub{3}";
            //this.Input = @"i \hbar \partial / \partial t \psi  \hat{H} \psi";
            this.Input = @"i \hbar \frac{\partial}{\partial t} \psi = \hat{H} \psi";
            Debug.Print(this.Input);
            this.update();
        }

        private string _Input;
        public string Input {
            get { return _Input; }
            set {
                _Input = value;
                NotifyPropertyChanged();
            }
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion INotifyPropertyChanged Implementation

        private void Update_Click(object sender, RoutedEventArgs e) {
            update();
        }

        private void update() {
            var toAdd = Equation.Visualize(this.Input);
            if (toAdd == null) {
                return;
            }
            this.root.Children.Add(toAdd);
        }
    }
}
