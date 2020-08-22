using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Firebase.Database;
using Firebase.Database.Query;
using Data.Entitys;

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
            //Simulate test img data
            var userId = "12345";
            var imgId = 1;
            var name = "Barcelona";
            var url = @"assets\Football\fc-barcelona2.jpg";

            //Save non identifying data to Firebase
            var barcelonaImg = new ImageUrl() {id = imgId, Name = name, Url = url };
            var firebaseClient = new FirebaseClient("https://shopforever-11ffa.firebaseio.com/");
            var result = await firebaseClient
                .Child("Users/" + userId + "/Logins")
                .PostAsync(barcelonaImg);

            var dbImageUrls = await firebaseClient
                .Child("Users")
                .Child(userId)
                .Child("Logins")
                .OnceAsync<ImageUrl>();

            var images = new List<ImageUrl>();

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
