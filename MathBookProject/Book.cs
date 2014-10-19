using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;

namespace MathBookProject {
    public class Book : INotifyPropertyChanged {
        public Book() {
        }

        public XElement ToXml() {
            XElement root = new XElement("Book");
            XElement linesElement = new XElement("Lines");
            foreach (var l in this.Lines) {
                linesElement.Add(l.ToXml());
            }
            root.Add(linesElement);
            return root;
        }


        public static ObservableCollection<ContentLine> AllLines = new ObservableCollection<ContentLine>();
        public ObservableCollection<ContentLine> Lines {
            get { return AllLines; }
        }

        public static Book FromXml(XElement xml) {
            Book toReturn = new Book();
            foreach (var l in xml.Element("Lines").Elements()) {
                toReturn.Lines.Add(ContentLine.FromXml(l));
            }
            
            return toReturn;
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
