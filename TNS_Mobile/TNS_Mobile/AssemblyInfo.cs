using Android.App;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: Application(UsesCleartextTraffic = true)]
