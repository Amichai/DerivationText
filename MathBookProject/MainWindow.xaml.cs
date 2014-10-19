using MathBookProject.LineTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;
using CommonUtil;

namespace MathBookProject {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged {
        public MainWindow() {
            InitializeComponent();
            this.load();
            this.Book.Lines.CollectionChanged += Lines_CollectionChanged;

        }

        void Lines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            updateUI();
        }

        private StackPanel linesControl = null;

        private void updateUI() {
            var lines = this.Book.Lines.Select(i => i.Control).ToObservableCollection();
            if (linesControl == null) {
                linesControl = new StackPanel() {
                    VerticalAlignment = System.Windows.VerticalAlignment.Stretch
                };
            }
            foreach (var l in lines) {
                if (linesControl != null && linesControl.Children.Contains(l)) {
                    continue;
                }
                linesControl.Children.Add(l);
            }
            this.root.Content = null;
            this.root.Content = linesControl;
        }

        private void add() {
            var c = new ContentLine(LineType.Input, "");
            this.Book.Lines.Add(c);
        }

        private void load() {
            this.Book = Book.FromXml(XElement.Load(this.savePath));
            this.updateUI();
        }
        private Book _Book;
        public Book Book {
            get { return _Book; }
            set {
                _Book = value;
                NotifyPropertyChanged();
            }
        }

        private string savePath = @"..\..\content.xml";

        private void Save_Click(object sender, RoutedEventArgs e) {
            var xml = this.Book.ToXml();
            xml.Save(this.savePath);
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
    public enum LineType { Input, Paragraph };
}
