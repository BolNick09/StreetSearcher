using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearcherServer
{
    internal class StreetIndex
    {
        public int Index { get; }
        private List<string> streets;

        public StreetIndex(int index)
        {
            Index = index;
            streets = new List<string>();
        }
        public void AddStreet(string street)
        {
            streets.Add(street);
        }
        public List<string> GetStreets(int index)
        {
            if (index == Index)
                return streets;
            else
                return null;
        }
    }
}
