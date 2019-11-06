using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users_app.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace users_app.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPage : ContentPage
	{
		public AddPage ()
		{
			InitializeComponent ();
            this.BindingContext = new PostsViewModel();
        }

        
    }
}