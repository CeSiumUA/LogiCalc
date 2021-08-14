using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogiCalc.Core
{
    public interface IStorageProvider
    {
        public void Save<T>(T obj);
        public T Load<T>();
    }
}
