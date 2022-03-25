using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TNS_Mobile.POCO_Models;
using TNS_Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TNS_Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetiDostupaOprtionsPage : ContentPage
    {
        private string name;
        private int portsCount;
        private string standart;
        private double chastota;
        private string interfaces;
        private double speed;
        private string address;
        private SetiDostupa equipment;
        public SetiDostupaOprtionsPage(SetiDostupa _equipment)
        {
            InitializeComponent();
            equipment = _equipment;
            Title = "Оборудование сетей доступа";
            EquipmentName = equipment.Name;
            PortsCount = equipment.Count;
            Interfaces = equipment.Interfaces;
            Chastota = equipment.Chastota;
            Standart = equipment.Standart;
            Speed = Convert.ToDouble(equipment.Speed);
            Address = equipment.Address;
            BindingContext = this;
        }
        public string EquipmentName { get => name; set { name = value; OnPropertyChanged(); } }
        public int PortsCount { get => portsCount; set { portsCount = value; OnPropertyChanged(); } }
        public double Chastota { get => chastota; set { chastota = value; OnPropertyChanged(); } }
        public string Standart { get => standart; set { standart = value; OnPropertyChanged(); } }
        public string Interfaces { get => interfaces; set { interfaces = value; OnPropertyChanged(); } }
        public double Speed { get => speed; set { speed = value; OnPropertyChanged(); } }
        public string Address { get => address; set { address = value; OnPropertyChanged(); } }
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            if (Validate())
            {
                equipment.Address = Address;
                equipment.Chastota = Chastota;
                equipment.Count = PortsCount;
                equipment.Interfaces = Interfaces;
                equipment.Speed = Speed.ToString(); ;
                equipment.Standart = Standart;
                equipment.Name = EquipmentName;
                var request = new HttpRequestMessage(HttpMethod.Put, $"{ClientService.APIUrl}api/Equipment/SetiDostupa/{equipment.Id}");
                request.Content = new StringContent(JsonSerializer.Serialize(equipment), Encoding.UTF8, "application/json"); 
                var response = await ClientService.Instance.HttpClient.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await DisplayAlert("Оборудование сетей доступа успешно настроено!", "Оповещение", "ОК");
                    await Navigation.PopAsync();
                }
            }
            else
            {
                await DisplayAlert("Введены некорректные данные!", "Внимание", "ОК");
            }
        }
        private bool Validate()
        {
            if (!string.IsNullOrEmpty(EquipmentName) &&
                PortsCount > 0 &&
                !string.IsNullOrEmpty(Standart) &&
                Speed > 0 &&
                Chastota > 0 &&
                !string.IsNullOrEmpty(Address) &&
                !string.IsNullOrEmpty(Interfaces))
                return true;
            else return false;
        }
    }
}