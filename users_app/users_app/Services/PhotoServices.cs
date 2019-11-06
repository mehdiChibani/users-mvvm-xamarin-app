using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using users_app.Models;

namespace users_app.Services
{
    class PhotoServices
    {
        public List<Photo> GetphotoList()
        {
            string var;
            List<Photo> PhotoList;
            using (var wb = new WebClient())
            {
                wb.Headers.Add("Content-Type: application/x-www-form-urlencoded");
                var response = wb.DownloadData("https://jsonplaceholder.typicode.com/photos?_limit=6");

                var res = Encoding.UTF8.GetString(response);
                var = res;
                PhotoList = JsonConvert.DeserializeObject<List<Photo>>(res); ;
            }
            /*var apiClient = new HttpClient();
            using (var response = await apiClient.GetAsync("api/Appointements"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<RootObject>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }*/

            return PhotoList;
        }

    }
}
