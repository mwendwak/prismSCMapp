using com.kinetics.prism.DBstorage;
using SQLite;
using System.Globalization;

namespace com.kinetics.prism.Models

{
    public class BaseModel
    {
        public SQLiteAsyncConnection currDBConn;
        public static readonly object locker = new object();

        public BaseModel ()
        {
            DatabaseHelper dbHelper = DatabaseHelper.GetDBSingleton();
            currDBConn = dbHelper.getConn();
        }        

    }
}