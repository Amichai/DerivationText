﻿using EquationVisualizer;
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

namespace DerivationViewer.Pages {
    /// <summary>
    /// Interaction logic for EquationViewer.xaml
    /// </summary>
    public partial class EquationViewer : Page, INotifyPropertyChanged {
        public EquationViewer(Derivation d) {
            InitializeComponent();
            this.derviation = d;
            this.render(0);
        }

        private void normalizeFrameIdx() {
            if (this.frameIdx < 0) {
                this.frameIdx += this.frameCount;
            } else if (this.frameIdx >= this.frameCount) {
                this.frameIdx -= this.frameCount;
            }
        }

        private void render(int idx) {
            var c = derviation.frames[idx];
            this.visualizationGrid.Children.Clear();
            this.visualizationGrid.Children.Add(Equation.Visualize(c.Content));
            this.CurrentDescription = c.Description;
        }


        private int frameCount {
            get {
                return this.derviation.frames.Count();
            }
        }

        private Derivation derviation;
        private int frameIdx = 0;

        private void Forward_Click(object sender, RoutedEventArgs e) {
            this.frameIdx++;
            this.normalizeFrameIdx();
            render(this.frameIdx);
        }

        private string _CurrentDescription;
        public string CurrentDescription {
            get { return _CurrentDescription; }
            set {
                _CurrentDescription = value;
                NotifyPropertyChanged();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e) {
            this.frameIdx--;
            this.normalizeFrameIdx();
            render(this.frameIdx);
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
