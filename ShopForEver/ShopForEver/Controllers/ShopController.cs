using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Firebase.Database;
using Firebase.Database.Query;
using Data.Entitys;
using System.IO;

namespace ShopForEver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        // GET: api/Shop
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
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

            var dbImageUrls = await firebaseClient
                .Child("ImageUrls")
                .OnceAsync<List<ImageUrl>>();


            //Save non identifying data to Firebase
            //var barcelonaImg = new ImageUrl() { id = imgId, Name = name, Url = url };
            //var firebaseClient = new FirebaseClient("https://shopforever-11ffa.firebaseio.com/");
            //var result = await firebaseClient
            //.Child("ImageUrls")
            //.PostAsync(barcelonaImg);



            //var images = new List<ImageUrl>();

            //Convert JSON data to original datatype
            //foreach (var img in dbImageUrls)
            //{
            //    images.Add(img);
            //}

            return new string[] { "value1", "value2" };
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

    }
}
