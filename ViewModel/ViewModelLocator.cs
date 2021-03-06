/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Hoc_tieng_Nhat_cung_Maruko"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Hoc_tieng_Nhat_cung_Maruko.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
            {
                SimpleIoc.Default.Register<INavigationService, NavigationService>();
            }

            if (!SimpleIoc.Default.IsRegistered<IMarketplaceReviewService>())
            {
                SimpleIoc.Default.Register<IMarketplaceReviewService, MarketplaceReviewService>();
            }

            if (!SimpleIoc.Default.IsRegistered<IShareLinkService>())
            {
                SimpleIoc.Default.Register<IShareLinkService, ShareLinkService>();
            }

            if (!SimpleIoc.Default.IsRegistered<IApplicationManifestService>())
            {
                SimpleIoc.Default.Register<IApplicationManifestService, ApplicationManifestService>();
            }

            if (!SimpleIoc.Default.IsRegistered<IEmailComposeService>())
            {
                SimpleIoc.Default.Register<IEmailComposeService, EmailComposeService>();
            }

            SimpleIoc.Default.Register<AboutViewModel>();

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
        }
        public AboutViewModel AboutViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AboutViewModel>();
            }
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}