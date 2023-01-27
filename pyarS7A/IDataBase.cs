using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace pyarS7A
{
    public interface IDataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
