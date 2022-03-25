using System;
using TNS_Mobile.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TNS_Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new EquipmentListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
