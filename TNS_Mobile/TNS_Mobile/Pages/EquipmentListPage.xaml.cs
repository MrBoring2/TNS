using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TNS_Mobile.POCO_Models;
using TNS_Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TNS_Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquipmentListPage : ContentPage
    {
        private string selectedType;


        public EquipmentListPage()
        {
            InitializeComponent();
            Initialize();
            BindingContext = this;
        }
        private void Initialize()
        {  var handler = new HttpClientHandler();
           //handler.Proxy = new WebProxy { Address = new Uri("http://172.20.1.3:8080"), BypassProxyOnLocal = false, UseDefaultCredentials = false, Credentials = new NetworkCredential(userName: "serg", password: "7376") };
            ClientService.Instance.HttpClient = new System.Net.Http.HttpClient(handler);
            Types = new List<string>
            {
                "Магистрали",
                "Сети доступа",
                "Оборудование абонентов"
            };
            SelectedType = Types.FirstOrDefault();
        }

        public List<string> Types { get; set; }
        public string SelectedType { get => selectedType; set { selectedType = value; OnPropertyChanged(); LoadData(); } }


        private async void LoadData()
        {
            switch (SelectedType)
            {
                case "Магистрали":
                    {
                        try
                        {
                            var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, $"{ClientService.APIUrl}api/Equipment/Magistral");
                            //request.Headers.Add("Connection", "close");
                            var response = await ClientService.Instance.HttpClient.SendAsync(request);
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                var result = JsonSerializer.Deserialize<List<Magistral>>(await response.Content.ReadAsStringAsync());
                                MyListView.ItemsSource = result;
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    break;
                case "Сети доступа":
                    {
                        var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, $"{ClientService.APIUrl}api/Equipment/SetiDostupa");
                        // request.Headers.Add("Connection", "close");
                        var response = await ClientService.Instance.HttpClient.SendAsync(request);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var result = JsonSerializer.Deserialize<List<SetiDostupa>>(await response.Content.ReadAsStringAsync());
                            MyListView.ItemsSource = result;
                        }
                    }
                    break;
                case "Оборудование абонентов":
                    {
                        try
                        {
                            var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, $"{ClientService.APIUrl}api/Equipment/AbonentEquipment");
                            //request.Headers.Add("Connection", "close");
                            var response = await ClientService.Instance.HttpClient.SendAsync(request);
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                var result = JsonSerializer.Deserialize<List<AbonentEquipment>>(await response.Content.ReadAsStringAsync());

                                MyListView.ItemsSource = result;
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    break;
                default:
                    {

                    }
                    break;
            }
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            if (e.Item is Magistral magistral)
            {

            }
            else if (e.Item is SetiDostupa setiDostupa)
            {

            }
            else if (e.Item is AbonentEquipment abonentEquipment)
            { 

            }
            else
            {
                await DisplayAlert("Неверное оборудование", "Внимание", "ОК");
            }

            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }
    }
}
