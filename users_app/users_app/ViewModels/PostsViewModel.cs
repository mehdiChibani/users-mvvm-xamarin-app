using System;
using System.Collections.Generic;
using System.Text;
using users_app.Models;
using users_app.Services;
using users_app.Views;
using Xamarin.Forms;

namespace users_app.ViewModels
{
    class PostsViewModel : ViewModalBase
    {
        private List<User> usersList;
        public List<User> UsersList
        {
            get
            {
                return usersList;
            }
            set
            {
                SetProperty(ref usersList, value);
            }
        }


        public PostsViewModel()
        {
            var postServices = new PostsServices();
            UsersList = postServices.GetUsers();
        }
        public User user = new User()
        {
            Id = 6,
            Name = "Profesor"
        };
        public User GetValuesUser
        {
            get
            {
                return user;
            }
        }

        public User User
        {
            get
            {
                return user;
            }
            set
            {
                SetProperty(ref user, value);
                OnPropertyChanged(nameof(GetValuesUser));
            }
        }
        private bool en;
        public bool GetValuesEn
        {
            get
            {
                return en;
            }
        }
        public bool En
        {
            get
            {
                return !String.IsNullOrEmpty(id)
                       && !String.IsNullOrEmpty(titre)
                        && !String.IsNullOrEmpty(contenu)
                ;
            }
            set
            {
                SetProperty(ref en, value);
                OnPropertyChanged(nameof(En));
            }
        }


        public string id;
        public string GetValuesId
        {
            get
            {
                return id;
            }
        }
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                SetProperty(ref id, value);
                OnPropertyChanged(nameof(En));



            }
        }
        public string titre;
        public string GetValuesTitre
        {
            get
            {
                return titre;
            }
        }
        public string Titre
        {
            get
            {
                return titre;
            }
            set
            {
                SetProperty(ref titre, value);
                OnPropertyChanged(nameof(En));



            }
        }
        public string contenu;
        public string GetValuesContenu
        {
            get
            {
                return contenu;
            }
        }
        public string Contenu
        {
            get
            {
                return contenu;
            }
            set
            {
                SetProperty(ref contenu, value);
                OnPropertyChanged(nameof(En));



            }
        }
        public Command Enregistrer
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {

                        var postServices = new PostsServices();
                        string response = postServices.Enregistrer(Id, Titre, Contenu, User.Id.ToString());
                        await App.Current.MainPage.DisplayAlert("Ajouté Avec Succées", response, "OK");


                    }
                    catch (Exception)
                    {
                        await App.Current.MainPage.DisplayAlert("Connexion refusé", "verifier vos champs ou votre Connexion", "OK");
                    }
                });
            }
        }
        public Command Back
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {

                        await Application.Current.MainPage.Navigation.PushModalAsync(new Home());


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
        

