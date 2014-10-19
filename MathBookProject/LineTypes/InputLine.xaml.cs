using CommonUtil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Subjects;
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

namespace MathBookProject.LineTypes {
    /// <summary>
    /// Interaction logic for InputLine.xaml
    /// </summary>
    public partial class InputLine : UserControl, INotifyPropertyChanged {
        public InputLine() {
            InitializeComponent();
        }

        private string _TextVal;
        public string TextVal {
            get { return _TextVal; }
            set {
                _TextVal = value;
                NotifyPropertyChanged();
            }
        }

        public InputLine(string p) : this() {
            this.TextVal = p;
        }

        private void Add_Click(object sender, RoutedEventArgs e) {
            ContentLine toAdd = new ContentLine(LineType.Equation, this.TextVal);
            Book.AllLines.Add(toAdd);
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion INotifyPropertyChanged Implementation
    }

}
