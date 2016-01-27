using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Media.Imaging;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    public class SaveBmpToIsolatedStorageHelper
    {
        public static void SaveImage(Stream imageStream, string fileName, int orientation, int quality)
        {
            using (var isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isolatedStorage.FileExists(fileName))
                    isolatedStorage.DeleteFile(fileName);

                var fileStream = isolatedStorage.CreateFile(fileName);
                var bitmap = new BitmapImage();
                bitmap.SetSource(imageStream);

                var wb = new WriteableBitmap(bitmap);
                wb.SaveJpeg(fileStream, wb.PixelWidth, wb.PixelHeight, orientation, quality);
                fileStream.Close();
            }
        }
    }
}
