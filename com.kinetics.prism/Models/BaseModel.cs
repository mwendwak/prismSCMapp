using com.kinetics.prism.DBstorage;
using SQLite;

namespace com.kinetics.prism.Models

{
    public class BaseModel
    {
        public SQLiteAsyncConnection currDBConn;

        public BaseModel ()
        {
            DatabaseHelper dbHelper = DatabaseHelper.GetDBSingleton();
            currDBConn = dbHelper.getConn();
        }

    }
}