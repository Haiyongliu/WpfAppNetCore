using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.IO;

namespace WpfAppNetCore.SqlData.util
{
    class SqliteHelper
    {
        public static bool CreateDBFile (string fileName) {

            if ( !File.Exists(fileName) ) {
                SQLiteConnection.CreateFile(fileName);
            }
            return true;
        }

        public static SQLiteConnection GetConnection(string fileName, int version) {
            SQLiteConnection sqliteConn;
            try
            {
                sqliteConn = new SQLiteConnection("Data Source=" + fileName + ";Version=" + version + ";");

            }
            catch (Exception exception)
            {
                throw new Exception("create DataBase " + fileName + " failed message:" + exception.Message);
            }
            return sqliteConn;
        }

        public static void CreateTable(SQLiteConnection conn, string sql) {
            try
            {
                SQLiteCommand sQLiteCommand = new SQLiteCommand(sql, conn);
                conn.Open();
                sQLiteCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception("create table failed " + " failed message:" + exception.Message);
            }
            finally {
                conn.Close();
            }
        }
    }
}
