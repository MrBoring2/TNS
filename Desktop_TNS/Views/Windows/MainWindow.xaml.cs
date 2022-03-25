using Desktop_TNS.Data;
using Desktop_TNS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desktop_TNS.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : BaseWindow
    {
        private readonly TNS_Context context;
        private byte[] employeeImage;
        private Employee selectedEmployee;
        private ObservableCollection<ItemMenu> menuItems;
        private ItemMenu selectedMenuItem;
        public MainWindow()
        {
            context = App.context;
            InitializeComponent();
            Initialize();
            //using (var db = new TNS_Context())
            //{
            //    var files = Directory.GetFiles(@"C:\Users\user452.CHENK\Desktop\worldskills 2021\2_Основные\Сессия 2\Сотрудники");
            //    var employees = db.Employee;
            //    foreach (var item in employees)
            //    {
            //        if (files.FirstOrDefault(p => p.Contains(item.img)) != null)
            //        {
            //            item.Image = File.ReadAllBytes(files.FirstOrDefault(p => p.Contains(item.img)));
            //        }
            //    }
            //    db.SaveChanges();
            //}
            DataContext = this;
        }
        public Employee SelectedEmployee { get => selectedEmployee; set { selectedEmployee = value; OnPropertyChanged(); LoadMenu(); } }
        public ObservableCollection<ItemMenu> MenuItems { get => menuItems; set { menuItems = value; OnPropertyChanged(); } }
        public ItemMenu MenuItem { get => selectedMenuItem; set { selectedMenuItem = value; OnPropertyChanged(); } }
        public byte[] EmployeeImage { get => employeeImage; set { employeeImage = value; OnPropertyChanged(); } }
        private void LoadMenu()
        {
            if (SelectedEmployee != null)
            {
                LoadImage(SelectedEmployee);


                MenuItems = new ObservableCollection<ItemMenu>();
                MenuItems.Add(new ItemMenu("Абоненты", null));
                switch (SelectedEmployee.RoleId)
                {
                    case 1:
                        {
                            MenuItems.Add(new ItemMenu("CRM", null));
                            MenuItems.Add(new ItemMenu("Биллинг", null));
                        }
                        break;
                    case 2:
                        {
                            MenuItems.Add(new ItemMenu("Поддержка пользователей", null));
                            MenuItems.Add(new ItemMenu("CRM", null));
                            MenuItems.Add(new ItemMenu("Управление оборудованием", null));
                        }
                        break;
                    case 3:
                        {
                            MenuItems.Add(new ItemMenu("Поддержка пользователей", null));
                            MenuItems.Add(new ItemMenu("CRM", null));
                            MenuItems.Add(new ItemMenu("Управление оборудованием", null));
                        }
                        break;
                    case 4:
                        {
                            MenuItems.Add(new ItemMenu("Поддержка пользователей", null));
                            MenuItems.Add(new ItemMenu("CRM", null));
                            MenuItems.Add(new ItemMenu("Управление оборудованием", null));
                            MenuItems.Add(new ItemMenu("Биллинг", null));
                            MenuItems.Add(new ItemMenu("Активы", null));
                        }
                        break;
                    case 5:
                        {
                            MenuItems.Add(new ItemMenu("Активы", null));
                            MenuItems.Add(new ItemMenu("Управление оборудованием", null));
                            MenuItems.Add(new ItemMenu("CRM", null));
                        }
                        break;
                    case 6:
                        {
                            MenuItems.Add(new ItemMenu("Биллинг", null));
                            MenuItems.Add(new ItemMenu("Активы", null));
                        }
                        break;
                    default:
                        {

                        }
                        break;
                }
            }
        }

        private void LoadImage(Employee employee)
        {
            if (employee.Image != null)
            {
                EmployeeImage = employee.Image;
            }
            else
            {
                var image = new BitmapImage(new Uri("pack://application:,,,/Resources/empty.jpg"));
                using (var ms = new MemoryStream())
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(image));
                    encoder.Save(ms);
                    EmployeeImage = ms.ToArray();
                }

            }
        }

        public List<Employee> Employees { get; set; }


        private void Initialize()
        {
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            Employees = context.Employee.ToList();
            SelectedEmployee = Employees.FirstOrDefault();
        }
    }
}
