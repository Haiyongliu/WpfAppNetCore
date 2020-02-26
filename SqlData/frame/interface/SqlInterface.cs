using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAppNetCore.SqlData.frame.SqlInterface
{
    interface ISqlInterface<T>
    {
        void Insert(string sql);
        void Delete(string sql);
        void Update(string sql);
        LinkedList<T> Get(string sql);
    }
}
