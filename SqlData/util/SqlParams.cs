using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WpfAppNetCore.SqlData.util
{
    class SqlParams
    {
        public class MainTable {
            public const string TABLE_NAME = "finalance";
            public const string TABLE_KEY = "index_key";
            public const string NAME = "name";
            public const string INSTO = "insto";
            public const string DATE = " data";
            public const string DESCRIPTION = "description";

            public const string SQL_CREATE_TABLE =
                @"create table  IF NOT EXISTS " + TABLE_NAME + "("
                + TABLE_KEY + " integer primary key autoincrement,"
                + NAME + " varchar(64) not null,"
                + INSTO + " real,"
                + DATE + " varchar(32),"
                + DESCRIPTION + " text"
                + ")";
        }
    }
}