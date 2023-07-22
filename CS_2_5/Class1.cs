using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_2_5
{
    public class CheckedElem
    {
        public string path;
        public string name;
        public bool ch_;
        public CheckedElem() { }
        public CheckedElem(string name, string path)
        {
            this.path = path;
            this.name = name;
            ch_ = false;
        }
    }
    public class CheckedElems
    {
        public DateTime date;
        public List<CheckedElem> elements;
        public List<int> indexes;
        public CheckedElems() { }
        public CheckedElems(DateTime date, List<CheckedElem> elements, List<int> indexes)
        {
            this.date = date;
            this.elements = elements;
            this.indexes = indexes;
        }
    }
}
