using System;
using System.Collections.Generic;
using System.Text;
using users_app.Models;
using users_app.Services;
using users_app.Views;
using Xamarin.Forms;

namespace users_app.ViewModels
{
    class PostViewModel:ViewModalBase
    {
        private List<Photo> photoList;
        public List<Photo> PhotoList
        {
            get
            {
                return photoList;
            }
            set
            {
                SetProperty(ref photoList, value);
            }
        }


        public PostViewModel()
        {
            var rootServices = new PhotoServices();
            PhotoList = rootServices.GetphotoList();
        }
        public Command AddButton
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {

                        await Application.Current.MainPage.Navigation.PushModalAsync(new AddPage());


                    }
                    catch (Exception)
                    {
                        await App.Current.MainPage.DisplayAlert("Connexion refusé", "verifier vos champs ou votre Connexion", "OK");
                    }
                });
            }

        }
    }
}

