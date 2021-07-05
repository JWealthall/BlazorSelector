using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSelector.Data
{
    public class NameStyle
    {
        public NameStyle(string name, string style) { Name = name; Style = style; }
        public string Name { get; }
        public string Style { get; set; }
    }
}
