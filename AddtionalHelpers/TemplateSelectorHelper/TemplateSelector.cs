using System.Windows;
using System.Windows.Controls;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers.TemplateSelectorHelper
{
    public abstract class TemplateSelector : ContentControl
    {
        public abstract DataTemplate SelectTemplate(object item, DependencyObject container);

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);

            ContentTemplate = SelectTemplate(newContent, this);
        }
    }
}
