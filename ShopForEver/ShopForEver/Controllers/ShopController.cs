using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Firebase.Database;
using Firebase.Database.Query;
using ShopForEver.Data.Entitys;
using System.IO;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ShopForEver.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopController : ControllerBase
    {

        //Get: api/shop
        [HttpGet]
        public async Task<string> Get()
        {
            var firebaseClient = new FirebaseClient("https://shopforever-11ffa.firebaseio.com/");
            var dbImageUrls = await firebaseClient
                .Child("ImageUrls")
                .OnceAsync<List<ImageUrl>>();

            //var images = new List<ImageUrl>();

            //Convert JSON data to original datatype
            //foreach (var img in dbImageUrls)
            //{
            //    images.Add(img);
            //}

            return "hello";
        }

        public string getImages()
        {
            return "Test";
        }


        // GET: api/Shop/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Shop
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Shop/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // Seed images to firebase
        [HttpGet]
        public async void SeedImages()
        {


            List<ImageUrl> Images = new List<ImageUrl>();

            Images.Add(new ImageUrl()
            {
                id = 1,
                Name = "Chelsea",
                Url = @"assets\Football\chelsea.jpg"
            });

            Images.Add(new ImageUrl()
            {
                id = 2,
                Name = "atletico-de-madrid.jpg",
                Url = @"assets\Football\atletico-de-madrid.jpg"
            });

            Images.Add(new ImageUrl()
            {
                id = 3,
                Name = "inter-milan.jpg",
                Url = @"assets\Football\inter-milan.jpg"
            });

            Images.Add(new ImageUrl()
            {
                id = 4,
                Name = "liverpool.jpg",
                Url = @"assets\Football\liverpool.jpg"
            });


            var firebaseClient = new FirebaseClient("https://shopforever-11ffa.firebaseio.com/");


            foreach (var item in Images)
            {
                var img = new ImageUrl() { id = item.id, Name = item.Name, Url = item.Url };
                var result = await firebaseClient
                    .Child("ImageUrls")
                    .PostAsync(img);
            }
        }

    }
}
