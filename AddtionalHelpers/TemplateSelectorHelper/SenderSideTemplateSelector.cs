using System.Windows;
using Hoc_tieng_Nhat_cung_Maruko.Model.Conversation;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers.TemplateSelectorHelper
{
    public class SenderSideTemplateSelector : TemplateSelector
    {
        public DataTemplate SenderTemplate { get; set; }
        public DataTemplate ReceiverTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var message = item as Message;

            return message != null && message.SenderSide == SenderSide.Receiver ? ReceiverTemplate : SenderTemplate;
        }
    }
}
