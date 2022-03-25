using Desktop_TNS.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class ItemMenu
    {
        public ItemMenu(string title, BasePage destinationPage)
        {
            Title = title;
            DestinationPage = destinationPage;
        }

        public string Title { get; set; }
        public BasePage DestinationPage { get; set; }

    }
}
