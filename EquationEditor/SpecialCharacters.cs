using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationEditor {
    class SpecialCharacters {

        public static string Get(string s, out bool matched) {
            matched = false;
            if (!mapping.ContainsKey(s)) {
                return s;
            } else {
                matched = true;
                return mapping[s];
                //return System.Text.RegularExpressions.Regex.Unescape();
            }
        }
        private static Dictionary<string, string> mapping = new Dictionary<string, string>() {
            {@"\hbar",  @"ℏ" },
            {@"\partial", "∂"},
            {@"\psi", "Ψ"},

        };
    }
}
