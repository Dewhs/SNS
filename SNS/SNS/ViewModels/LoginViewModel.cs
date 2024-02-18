using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using SNS.Views;
using SNS.Models;
using SNS.Services;
using System.Threading.Tasks;
using SNS.Proprietes;
namespace SNS.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        //Version
        public string App_Version { get; set; }
        //Design
        public Color BG_BTN_Connect { get; set; }

        //Information
        public string Invalid_id_pass { get; set; }
        public string Identifiant { get; set; }
        public string Password { get; set; }


        //Command
        public ICommand BTN_Connect_click { get; set; }
        public ICommand Configuration_adresse_page_click { get; set; }

        // --------------------------------------- CONSTRUCTEUR -----------------------------------------
        public LoginViewModel()
        {
            App_Version = "V" + Preferences.Get("App_Version", "");

            // ------------------------ INFO SAVED -------------------------
            //Verifie si les login info son enregistrer


            if (!Preferences.ContainsKey("API_Url") || Preferences.Get("API_Url", "") == "")
            {
               
                Preferences.Set("API_Url", Proprietes.Resource.IP_API);
            }


            if (Preferences.ContainsKey("identifiant"))
            {
                Identifiant = Preferences.Get("identifiant", "");
                Password = Preferences.Get("password", "");

                Authentifier_utilisateur();
            }
            else
            {
                BG_BTN_Connect = Color.FromHex("B2FFC8");
            }
            // ------

            BTN_Connect_click = new Command(() =>
            {
                Authentifier_utilisateur();
                               
            });





            // ------------------ Configuration_adresse_page_click -------------------

            Configuration_adresse_page_click = new Command(async () =>
            {
                await Shell.Current.GoToAsync("Configuration_AdressePage");
            });
            
            // ------
        }


        // --------------------------------------- CONNECT -----------------------------------------
        public async void Authentifier_utilisateur()
        {
            if (Preferences.ContainsKey("API_Url", "") && Preferences.Get("API_Url", "") != "")
            {                               
                if (!await MockDataStore.CheckAPIConnection(Preferences.Get("API_Url", "")))
                {
                    BG_BTN_Connect = Color.FromHex("FF6666"); //Color App_Red
                    Invalid_id_pass = "Bad API Url change this in settings !";

                    OnPropertyChanged("BG_BTN_Connect");
                    OnPropertyChanged("Invalid_id_pass");
                }
                else
                {
                    //Creation de l'objet usr de type User
                    User usr = new User();

                    //Affecte les information de connexion a l'objet
                    usr.identifiant = Identifiant;
                    usr.password = Password;

                    //Recuperation des information de l'utilisateur
                    usr = await MockDataStore.PostAsync_login(usr);


                    if (usr.prenom != null) //Login Valide
                    {
                        //Enregistrement des informations de l'utilisateur dans les preferences
                        Preferences.Set("identifiant", usr.identifiant); //Add login info in Preference
                        Preferences.Set("password", usr.password);
                        Preferences.Set("name", usr.prenom + ' ' + usr.nom);
                        Preferences.Set("image", usr.image);
                        Preferences.Set("status", usr.auth);
                        Preferences.Set("token", usr.token);

                        //Navigue jusqu'a la Home Page
                        await Shell.Current.GoToAsync("HomePage");

                        BG_BTN_Connect = Color.FromHex("B2FFC8");//Color App_Green
                        Invalid_id_pass = "";


                    }
                    else//Login Invalide
                    {
                        BG_BTN_Connect = Color.FromHex("FF6666"); //Color App_Red
                        Invalid_id_pass = "Invalid Identifant or Password";

                        string API_Url = Preferences.Get("API_Url", "");
                        Preferences.Clear(); //CLEAR Save
                        Preferences.Set("API_Url", API_Url);
                    }

                    //Refresh UI
                    OnPropertyChanged("BG_BTN_Connect");
                    OnPropertyChanged("Invalid_id_pass");
                    // ------
                }
            }
            else
            {
                BG_BTN_Connect = Color.FromHex("FF6666"); //Color App_Red
                Invalid_id_pass = "API Url desn't exist input this in settings !";
                OnPropertyChanged("BG_BTN_Connect");
                OnPropertyChanged("Invalid_id_pass");
            }
        }
        ~LoginViewModel() { }
    }
}
