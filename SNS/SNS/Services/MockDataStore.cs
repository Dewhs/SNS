using SNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Xamarin.Essentials;
namespace SNS.Services
{
    public class MockDataStore
    {//http://172.31.254.102/api/v1/
     //http://172.31.254.102/api/v1/

        public MockDataStore()
        {

        }


        public static async Task<User> PostAsync_login(User _usr)
        {
            //recupere l'url de l'API depuis les preferences
            string url = "http://" + Preferences.Get("API_Url", "") + "/connect";

            //Serialize API's URI
            Uri uri = new Uri(url);

            //Serialize le contenue a Poster
            StringContent content = new StringContent(JsonConvert.SerializeObject(_usr), UnicodeEncoding.UTF8, "application/json");

            //recupere le retour de methode de PostAsync_REST en Json mais de type string
            string result = await Cls_Com_API_REST.PostAsync_REST(uri, content);

            //Deserialize l'objet JSON de type string en Objet usr de type USER
            User usr = JsonConvert.DeserializeObject<User>(result);

            //Reaffecte les informations de connexion
            usr.identifiant = _usr.identifiant;
            usr.password = _usr.password;

            //retourne l'objet usr
            return usr;
        }

        public static async Task<API_Info> PostAsync_Palier(string token)
        {
            string url = "http://" + Preferences.Get("API_Url", "") + "/palier";
            API_Info _Api_info = new API_Info();

            _Api_info.token = token;
            //Serialize le contenue a Poster
            StringContent content = new StringContent(JsonConvert.SerializeObject(_Api_info), UnicodeEncoding.UTF8, "application/json");

            //API's URI
            Uri uri = new Uri(url);

            string result = await Cls_Com_API_REST.PostAsync_REST(uri, content).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<API_Info>(result);
        }

        public static async Task<bool> CheckAPIConnection(string _url)
        {
            API_Info API_info = new API_Info();
            string url = "http://" + _url + "/version";
            bool result = false;
            try
            {
                Uri uri = new Uri(url);
                API_info = JsonConvert.DeserializeObject<API_Info>(await Cls_Com_API_REST.GetAsync_REST(uri));
                result = API_info.version == "1.1";
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        // ----


        public static async Task<API_Info> PostAsync_Sound_value(string token)
        {
            string url = "http://" + Preferences.Get("API_Url", "") + "/son";
            API_Info _Api_info = new API_Info();

            _Api_info.token = token;
            //Serialize le contenue a Poster
            StringContent content = new StringContent(JsonConvert.SerializeObject(_Api_info), UnicodeEncoding.UTF8, "application/json");

            //API's URI
            Uri uri = new Uri(url);

            var result = Cls_Com_API_REST.PostAsync_REST(uri, content).Result;

            //Deserialize l'objet JSON en Objet usr de type USER
            _Api_info = JsonConvert.DeserializeObject<API_Info>(result);

            //retourne l'objet usr
            return _Api_info;
        }





        public static async Task<API_Info> PutAsync_Palier(string token, string min, string max)
        {
            string url = "http://" + Preferences.Get("API_Url", "") + "/palier";
            API_Info _Api_info = new API_Info();

            _Api_info.token = token;
            _Api_info.minimum = min;
            _Api_info.maximum = max;

            //Serialize le contenue a Poster
            StringContent content = new StringContent(JsonConvert.SerializeObject(_Api_info), UnicodeEncoding.UTF8, "application/json");

            //API's URI
            Uri uri = new Uri(url);

            var result = Cls_Com_API_REST.PutAsync_REST(uri, content).Result;

            //Deserialize l'objet JSON en Objet usr de type USER
            _Api_info = JsonConvert.DeserializeObject<API_Info>(result);

            //retourne l'objet usr
            return _Api_info;
        }

        public static async Task<User> PutAsync_Password(string token, string pass)
        {
            string url = "http://" + Preferences.Get("API_Url", "") + "/password";
            User usr = new User();

            usr.token = token;
            usr.password = pass;

            //Serialize le contenue a Poster
            StringContent content = new StringContent(JsonConvert.SerializeObject(usr), UnicodeEncoding.UTF8, "application/json");

            //API's URI
            Uri uri = new Uri(url);

            var result = Cls_Com_API_REST.PutAsync_REST(uri, content).Result;

            //Deserialize l'objet JSON en Objet usr de type USER
            usr = JsonConvert.DeserializeObject<User>(result);

            //retourne l'objet usr
            return usr;
        }

   

        public static async Task<string> GetAsync_Version(string _url)
        {
            API_Info _API_info = new API_Info();
            //string url = Preferences.Get("API_Url", "") + "/version";
            string url = "http://" + _url + "/version";
            //API's URI
            Uri uri = new Uri(url);

            string result = Cls_Com_API_REST.GetAsync_REST(uri).Result;
            _API_info = JsonConvert.DeserializeObject<API_Info>(result);


            return _API_info.version;
        }



        /*public static async Task<bool> CheckBDDConnection(string _url)
        {
            string url = _url + "/verification";
            Uri uri = new Uri(url);
            bool result = false;
            try
            {
                result = await Cls_Com_API_REST.CheckGet(uri) == System.Net.HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }*/


        /* public async Task<bool> AddItemAsync(User item)
         {
             items.Add(item);

             return await Task.FromResult(true);
         }

         public async Task<bool> UpdateItemAsync(User item)
         {
             var oldItem = items.Where((User arg) => arg.Id == item.Id).FirstOrDefault();
             items.Remove(oldItem);
             items.Add(item);

             return await Task.FromResult(true);
         }

         public async Task<bool> DeleteItemAsync(string id)
         {
             var oldItem = items.Where((User arg) => arg.Id == id).FirstOrDefault();
             items.Remove(oldItem);

             return await Task.FromResult(true);
         }

         public async Task<User> GetItemAsync(string id)
         {
             return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
         }

         public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
         {
             return await Task.FromResult(items);
         }*/
    }
}