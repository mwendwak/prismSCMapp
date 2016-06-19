using SQLite;
using com.kinetics.prism.Models;
using Android.Util;

namespace com.kinetics.prism.DBstorage
{
    class DBCreateTables
    {
        public SQLiteAsyncConnection currDBConn;  
        
        public DBCreateTables()
        {
            DatabaseHelper dbHelper = DatabaseHelper.GetDBSingleton();
            currDBConn = dbHelper.getConn ();
        }

        public string createTables()
        {
            string DBCreatedStatus = "";
            string tag = "DBStructActivity: ";
            try
            {
                currDBConn.CreateTableAsync<Product>();
                DBCreatedStatus = "DBCreateSucccess";
                Log.Info(tag, "Create Products Table");               
                               
                return DBCreatedStatus;
            }catch (SQLiteException sqlEx)
            {
                DBCreatedStatus = "DBCreateFail: " + sqlEx.Message;
                Log.Error(tag, "Problem DB Struct. " + DBCreatedStatus);

                return DBCreatedStatus;
            }
        }

        public void clearTables()
        {
            string DBCreatedStatus = "";
            string tag = "DBTruncateActivity: ";
            try
            {
                var clearProducts = currDBConn.QueryAsync<Product>("DELETE FROM Products");
                Log.Info(tag, "Clear Products Table");
            }
            catch (SQLiteException sqlEx)
            {
                DBCreatedStatus = "DBClearFail: " + sqlEx.Message;
                Log.Error(tag, "Problem DB Struct. " + DBCreatedStatus);
            }
        }
    }
}