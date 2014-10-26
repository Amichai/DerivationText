using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationVisualizer {
    public class InputStream {
        private string val;
        public InputStream(string val) {
            this.val = val;
        }

        public bool StartsWith(string v) {
            var idx = this.val.IndexOf(v, consumed);
            if (idx == -1) {
                return false;
            } else {
                consumed += v.Length;
                return true;
            }
        }

        private int consumed = 0;
    }
}
