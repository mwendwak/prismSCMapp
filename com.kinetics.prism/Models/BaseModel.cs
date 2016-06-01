using com.kinetics.prism.DBstorage;
using SQLite;

namespace com.kinetics.prism.Models

{
    public class BaseModel
    {
        public SQLiteAsyncConnection currDBConn;

        public SQLiteAsyncConnection getDBConn()
        {
            DatabaseHelper DBHelper = new DatabaseHelper();
            currDBConn = DBHelper.createDBConnection();
            return currDBConn;
        }
    }
}