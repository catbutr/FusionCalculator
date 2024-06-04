using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionCalculator.Resources.Constants
{
    public static class Constants
    {
        public const string DatabaseFilename = "FusionData.db";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        //public static string DatabasePath => Path.Combine(FileSystem.Current.AppDataDirectory, DatabaseFilename);
        public static string DatabasePath = "E:\\FusionCalculator\\FusionData.db";
    }
}
