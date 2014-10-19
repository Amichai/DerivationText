using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EquationEditor.Tokens {
    interface IArrange {
        FrameworkElement Arrange(List<Node> children);
    }
}
