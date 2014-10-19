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

namespace MathBookProject.LineTypes {
    /// <summary>
    /// Interaction logic for ParagraphLine.xaml
    /// </summary>
    public partial class ParagraphLine : UserControl, INotifyPropertyChanged {
        public ParagraphLine() {
            InitializeComponent();
        }

        public ParagraphLine(string p) : this() {
            this.TextVal = p;
        }

        private string _TextVal;
        public string TextVal {
            get { return _TextVal; }
            set {
                _TextVal = value;
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
    }
}
