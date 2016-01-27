using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Tasks;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    public class ShareHelper
    {
        static readonly CameraCaptureTask CameraCaptureTask = new CameraCaptureTask();
        public static void ShareStatus(string status)
        {
            var shareStatusTask = new ShareStatusTask
            {
                Status = status
            };

            shareStatusTask.Show();
        }

        public static void ShareLink(string title, string linkUrl, string message)
        {
            var shareLinkTask = new ShareLinkTask
            {
                Title = title,
                LinkUri = new Uri(linkUrl, UriKind.Absolute),
                Message = message
            };

            shareLinkTask.Show();
        }

        public static void ShareMedia()
        {
            CameraCaptureTask.Show();
            CameraCaptureTask.Completed += cameraCaptureTask_Completed;
        }

        public static void cameraCaptureTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                ShowShareMediaTask(e.OriginalFileName);
            }
        }

        static void ShowShareMediaTask(string path)
        {
            var shareMediaTask = new ShareMediaTask {FilePath = path};
            shareMediaTask.Show();
        }
    }
}
