using Name_Sorter_Console.Model;
using Name_Sorter_Console.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Name_Sorter_Console.Services
{
    public class ReverseSortPersonService : ISortService<Person>
    {
        public List<Person> Sort(List<Person> unsortedList)
        {
            return BubbleSort(unsortedList);
        }

        public List<T> BubbleSort<T>(List<T> unsortedList) where T : IComparable<T>
        {
            int n = unsortedList.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (unsortedList[j].CompareTo(unsortedList[j + 1]) < 0)
                    {
                        // swap temp and arr[i]
                        T temp = unsortedList[j];
                        unsortedList[j] = unsortedList[j + 1];
                        unsortedList[j + 1] = temp;
                    }
                }
            }

            return unsortedList;
        }
    }
}
