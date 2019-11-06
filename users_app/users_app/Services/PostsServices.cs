using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using users_app.Models;

namespace users_app.Services
{
    public class PostsServices
    {

        public List<User> GetUsers()
        {
            var list = new List<User>
            {
                new User
                {
                   Id=1,
                   Name="Palermo"

                },
               new User
                {
                   Id=2,
                   Name="Tokyo"

                },
                new User
                {
                   Id=3,
                   Name="nairobi"

                },
                new User
                {
                   Id=4,
                   Name="Berlin"

                },
                new User
                {
                   Id=5,
                   Name="helsinki"

                },
            };
            return list;
        }
        public string Enregistrer(string id, string titre, string body, string userid)
        {
            //var data = new FormUrlEncodedContent(new[]
            //{
            //    new KeyValuePair<string,string>("username",username),
            //    new KeyValuePair<string,string>("password",password)
            //});
            var res = "";
            using (var wb = new WebClient())
            {
                wb.Headers.Add("Content-Type: application/x-www-form-urlencoded");
                var data = new NameValueCollection
                {
                    ["id"] = id,
                    ["title"] = titre,
                    ["body"] = body,
                    ["userId"] = userid

                };
                
                var response = wb.UploadValues("https://jsonplaceholder.typicode.com/posts/", "POST", data);
                res = Encoding.UTF8.GetString(response);
            }
            return res;
        }
    }
}