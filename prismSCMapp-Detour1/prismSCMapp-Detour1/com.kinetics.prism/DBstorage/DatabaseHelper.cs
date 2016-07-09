using Path = System.IO.Path;
using SQLite;
using Android.Util;

namespace com.kinetics.prism.DBstorage
{
    public class DatabaseHelper
    {
        static string DbName = "PriscmDB.db"; //Make this to derive from a string resource
        static string DocumentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        static string DbPath = Path.Combine(DocumentPath, DbName);

        public static SQLiteAsyncConnection dbConnAsync;
        private static DatabaseHelper dbInstance;

        public static SQLiteConnection DBConnTemp;

        private static readonly object padlock = new object();

        public static string getDbPath() { return DbPath; }

        protected DatabaseHelper ()
        {
            createDBConnection();
        }

        private static void createDBConnection ()
        {
            string tag = "DBCreate:";
            try
            {
                dbConnAsync = new SQLiteAsyncConnection(DbPath, false);
                Log.Info(tag, "Created a DB Conn");
            }catch (SQLiteException ex)
            {
                Log.Error(tag, "Problem on DB Conn " + ex.Message);
            }
        }

        public static DatabaseHelper GetDBSingleton ()
        {
            if (dbInstance == null)
            {
                lock (padlock)
                {
                    if (dbInstance == null)
                    {
                        dbInstance = new DatabaseHelper();

                    }
                }
            }
            return dbInstance;
        }

        public SQLiteAsyncConnection getConn()
        {
                return dbConnAsync;
        }

        public SQLiteConnection getTempDBConn()
        {
            SQLiteConnection dbTempConn = new SQLiteConnection (DbPath);
            return dbTempConn;
        }

    }

}