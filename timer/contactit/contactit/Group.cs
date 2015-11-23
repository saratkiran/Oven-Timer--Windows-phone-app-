using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace contactit
{
    class Group<T>
    {
        private string p;
        private IGrouping<string, MyContacts> c;

        public Group(string p, IGrouping<string, MyContacts> c)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.c = c;
        }
    }
}
