using SQLite;
using com.kinetics.prism.Models;

namespace com.kinetics.prism.DBstorage
{
    class DBCreateTables
    {
        public void createTable(SQLiteAsyncConnection dbConn)
        {
            dbConn.CreateTableAsync<Product> ();
        }
    }
}