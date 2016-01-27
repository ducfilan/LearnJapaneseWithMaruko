using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Model.Conversation;
using Telerik.Windows.Controls;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers.Converters
{
    public class ChatAvatarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var senderSide = value as ConversationViewMessageType?;

            var bmpSenderAvatar = new BitmapImage(new Uri("/Assets/UIImages/default avatar.jpg", UriKind.Relative));
            if (senderSide != ConversationViewMessageType.Outgoing) return bmpSenderAvatar;
            using (var myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (Common.AvatarOfUser == null) return bmpSenderAvatar;
                using (var fileStream = myIsolatedStorage.OpenFile(Common.AvatarOfUser, FileMode.Open, FileAccess.Read))
                {
                    bmpSenderAvatar.SetSource(fileStream);
                }
            }

            return bmpSenderAvatar;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
