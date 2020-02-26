using System.Collections.Generic;
using WpfAppNetCore.SqlData.frame.SqlInterface;
using System.Data.SQLite;
using WpfAppNetCore.SqlData.util;
using System;
using System.Collections.Specialized;

namespace WpfAppNetCore.SqlData.frame
{
    class SqliteImpl : ISqlInterface<NameValueCollection>
    {
        private SQLiteConnection conn;

        public SqliteImpl() {
            string fileName = System.Environment.CurrentDirectory + "\\test.db";
            SqliteHelper.CreateDBFile(fileName);
            conn = SqliteHelper.GetConnection(fileName, 3);
            SqliteHelper.CreateTable( conn , SqlParams.MainTable.SQL_CREATE_TABLE);
        }

        public void Delete(string sql)
        {
            throw new System.NotImplementedException();
        }

        public LinkedList<NameValueCollection> Get(string sql)
        {
            LinkedList<NameValueCollection> returnValue = new LinkedList<NameValueCollection>();
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                SQLiteDataReader reader = cmd.ExecuteReader();
                while ( reader.Read()) {
                    NameValueCollection values = reader.GetValues();
/*                    for (int i = 0;i < values.Count;i++) {
                        string key = values.GetKey(i);
                        string value = values.Get(i);
                        System.Diagnostics.Debug.WriteLine("数据 key:" + key + " value:" + value);
                    }*/
                    returnValue.AddLast(values);


                }
            }
            catch (Exception e)
            {
                throw new Exception("exec sql command failed," + e.Message);
            }
            finally
            {
                conn.Close();
            }
            return returnValue;
        }
        //insert into finalance (name,insto,data,description) values("lhy",33,"2020.2.18","description test")
        public void Insert(string sql)
        {
            Excute(sql);
        }

        public void Update(string sql)
        {
            throw new System.NotImplementedException();
        }

        private void Excute(string sql ) {
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("exec sql command failed," + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}