using System;
using System.Collections.Generic;
using System.Text;

namespace Name_Sorter_Console.Services
{
    public interface IValidator<T>
    {
        public void Validate(T t);
    }
}
