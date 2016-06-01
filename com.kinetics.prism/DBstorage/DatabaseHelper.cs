using Path = System.IO.Path;
using SQLite;

namespace com.kinetics.prism.DBstorage
{
    public class DatabaseHelper
    {
         static string DbName = "PriscmDB"; //Make this to derive from a string resource
         static string DocumentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
         static string DbPath = Path.Combine(DocumentPath, DbName);
         SQLiteAsyncConnection dbConnAsync;

        public SQLiteAsyncConnection createDBConnection ()
        {
            var prscmPlatform = new SQLite.Net.Platform.XamarinAndroid.SQLiteApiAndroid ();       
            dbConnAsync = new SQLiteAsyncConnection(DbPath,false);
            return dbConnAsync;
        }



    }

}