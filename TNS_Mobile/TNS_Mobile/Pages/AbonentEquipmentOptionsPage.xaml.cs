using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TNS_Mobile.POCO_Models;
using TNS_Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TNS_Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AbonentEquipmentOptionsPage : ContentPage
    {
        private string name;
        private string ports;
        private string standart;
        private int speed;
        private string address;
        private AbonentEquipment equipment;
        public AbonentEquipmentOptionsPage(AbonentEquipment _equipment)
        {
            InitializeComponent();
            equipment = _equipment;
            Title = "Оборудование абонентов";
            EquipmentName = equipment.Name;
            Ports = equipment.Ports;
            Standart = equipment.Standart;
            Speed = Convert.ToInt32(equipment.Speed);
            Address = equipment.Address;
            BindingContext = this;
        }
        public string EquipmentName { get => name; set { name = value; OnPropertyChanged(); } }
        public string Ports { get => ports; set { ports = value; OnPropertyChanged(); } }
        public string Standart { get => standart; set { standart = value; OnPropertyChanged(); } }
        public int Speed { get => speed; set { speed = value; OnPropertyChanged(); } }
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
                equipment.Name = EquipmentName;
                equipment.Ports = Ports;
                equipment.Speed = Speed.ToString();
                equipment.Standart = Standart;
                
                var request = new HttpRequestMessage(HttpMethod.Put, $"{ClientService.APIUrl}api/Equipment/AbonentEquipment/{equipment.Id}");
                request.Content = new StringContent(JsonSerializer.Serialize(equipment), Encoding.UTF8, "application/json");
                var response = await ClientService.Instance.HttpClient.SendAsync(request);
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await DisplayAlert("Оборудование абонента успешно настроено!", "Оповещение", "ОК");
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
                !string.IsNullOrEmpty(Ports) &&
                !string.IsNullOrEmpty(Standart) &&
                Speed > 0 &&
                !string.IsNullOrEmpty(Address))
                return true;
            else return false;
        }
    }
}