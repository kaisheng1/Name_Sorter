using System;
using System.Collections.Generic;
using System.Text;

namespace Name_Sorter_Console.Service
{
    public interface ISortService<T>
    {
        public List<T> Sort(List<T> unsortedList);
        
    }
}
