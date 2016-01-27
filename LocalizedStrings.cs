using Hoc_tieng_Nhat_cung_Maruko.Resources;

namespace Hoc_tieng_Nhat_cung_Maruko
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}