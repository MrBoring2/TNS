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
    public partial class MagistralOptionsPage : ContentPage
    {
        private string name;
        private double chastota;
        private string koefficient;
        private string technology;
        private string address;
        private Magistral equipment;
        public MagistralOptionsPage(Magistral _equipment)
        {
            InitializeComponent();
            Title = "Оборудование магистральных сетей";
            equipment = _equipment;
            EquipmentName = equipment.Name;
            Chastota = equipment.Chastota;
            Technology = equipment.Technology;
            Koefficient = equipment.Koeffisient;
            Address = equipment.Address;
            BindingContext = this;
        }
        public string EquipmentName { get => name; set { name = value; OnPropertyChanged(); } }
        public double Chastota { get => chastota; set { chastota = value; OnPropertyChanged(); } }
        public string Koefficient { get => koefficient; set { koefficient = value; OnPropertyChanged(); } }
        public string Technology { get => technology; set { technology = value; OnPropertyChanged(); } }
        public string Address { get => address; set { address = value; OnPropertyChanged(); } }
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            if (Validate())
            {
                equipment.Koeffisient = Koefficient;
                equipment.Name = EquipmentName;
                equipment.Technology = Technology;
                equipment.Address = Address;
                equipment.Chastota = Chastota;
                var request = new HttpRequestMessage(HttpMethod.Put, $"{ClientService.APIUrl}api/Equipment/Magistral/{equipment.Id}");
                request.Content = new StringContent(JsonSerializer.Serialize(equipment), Encoding.UTF8, "application/json");
                var response = await ClientService.Instance.HttpClient.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await DisplayAlert("Оборудование магистральных сетей успешно настроено!", "Оповещение", "ОК");
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
                Chastota > 0 &&
                !string.IsNullOrEmpty(Technology) &&
                !string.IsNullOrEmpty(Koefficient) &&
                !string.IsNullOrEmpty(Address))
                return true;
            else return false;
        }
    }
}