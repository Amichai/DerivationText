using DerivationViewer.Pages;
using EquationVisualizer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;

namespace DerivationViewer {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged {
        public MainWindow() {
            InitializeComponent();
            this.parse();
            this.Symbols = new ObservableCollection<SymbolData>();
            foreach (var s in SymbolData.Symbols) {
                this.Symbols.Add(s);
            }
            EquationDecorator.ClickEvent.Subscribe(i => {
                var symbol = i.Tag as SymbolData;
                this.navRoot.Navigate(new SymbolViewer(symbol));
            });
        }

        private ObservableCollection<SymbolData> _Symbols;
        public ObservableCollection<SymbolData> Symbols {
            get { return _Symbols; }
            set {
                _Symbols = value;
                NotifyPropertyChanged();
            }
        }

        string path = @"..\..\Library.xml";

        private void parse() {
            XElement xml = XElement.Load(path);
            var toParse = xml.Element("Derivations").Elements().First();
            var derivation = Derivation.Parse(toParse);
            this.navRoot.Navigate(new EquationViewer(derivation));
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
