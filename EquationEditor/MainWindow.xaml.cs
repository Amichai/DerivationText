using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace EquationEditor {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged {
        public MainWindow() {
            InitializeComponent();
            this.InputText = @"i \hbar \partial / (\partial t) \psi = \hat(H) \psi";
            //this.InputText = @"i \hbar \partial / t";

            this.add(this.InputText);
        }

        private string _InputText;
        public string InputText {
            get { return _InputText; }
            set {
                _InputText = value;
                NotifyPropertyChanged();
            }
        }


        private void add(string toProcess) {
            var p = new Editor().Process(toProcess);
            this.root.Children.Add(p);
        }
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion INotifyPropertyChanged Implementation

        private void Add_Click(object sender, RoutedEventArgs e) {
            this.add(this.InputText);
        }
    }
}
