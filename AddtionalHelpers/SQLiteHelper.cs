using System.Collections.Generic;
using System.IO;
using Windows.Storage;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    public class SqLiteHelper
    {
        private static SQLiteAsyncConnection _asyncConnection;
        private static SQLiteConnection _sqLiteConnection;

        public static SQLiteConnection SqLiteConnection(string databaseFileName)
        {
            _sqLiteConnection = new SQLiteConnection(Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFileName));
            return _sqLiteConnection;
        }

        public static SQLiteAsyncConnection SqLiteAsyncConnection(string databaseFileName)
        {
            _asyncConnection = new SQLiteAsyncConnection(Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFileName),
                true);

            return _asyncConnection;
        }
    }
}
