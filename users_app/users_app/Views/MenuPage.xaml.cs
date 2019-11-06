using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users_app.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace users_app.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MenuPage ()
		{
			InitializeComponent ();
            Detail = new NavigationPage(new Home())
            {
                BarBackgroundColor = Color.FromHex("#0059b3"),
                BarTextColor = Color.White,
            }; menuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Accueil", Icon = "home.png", TargetType = typeof(Home) };
            var page2 = new MasterPageItem() { Title = "Mon Compte", Icon = "profiles.png", TargetType = typeof(Profil) };
            
            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
           

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

        }
        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page))
            {
                BarBackgroundColor = Color.FromHex("#0059b3"),
                BarTextColor = Color.White,
            };

            IsPresented = false;

        }
    }
}
