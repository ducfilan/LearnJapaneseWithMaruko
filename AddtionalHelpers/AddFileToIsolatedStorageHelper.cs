using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection;
using System.Windows;
using Hoc_tieng_Nhat_cung_Maruko.Controller;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    class AddFileToIsolatedStorageHelper
    {
        public static void CopyFileToIsolatedStorage(string sourceFilePath, string destinationFile)
        {
            var ISF = IsolatedStorageFile.GetUserStoreForApplication();
            var versionAttribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), true).FirstOrDefault() as AssemblyFileVersionAttribute;

            string version = versionAttribute != null ? versionAttribute.Version : "";

            if (!Common.PreviousAppVersion.Equals(version) &&
                ISF.FileExists(destinationFile))
            {
                ISF.DeleteFile(destinationFile);
                Common.PreviousAppVersion = version;
            }

            if (!ISF.FileExists(destinationFile))
            {
                CopyFromContentToStorage(ISF, sourceFilePath, destinationFile);
            }
        }

        private static void CopyFromContentToStorage(IsolatedStorageFile ISF, String sourceFile, String destinationFile)
        {
            Stream stream = Application.GetResourceStream(new Uri(sourceFile, UriKind.Relative)).Stream;
            var ISFS = new IsolatedStorageFileStream(destinationFile, FileMode.Create, FileAccess.Write, ISF);
            CopyStream(stream, ISFS);
            ISFS.Flush();
            ISFS.Close();
            stream.Close();
            ISFS.Dispose();
        }

        private static void CopyStream(Stream input, IsolatedStorageFileStream output)
        {
            Byte[] buffer = new Byte[5120];
            Int32 readCount = input.Read(buffer, 0, buffer.Length);
            while (readCount > 0)
            {
                output.Write(buffer, 0, readCount);
                readCount = input.Read(buffer, 0, buffer.Length);
            }
        }

    }
}
