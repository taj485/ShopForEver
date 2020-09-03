using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopForEver.Service.Models;

namespace ShopForEver.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManageItemController : ControllerBase
    {
        private readonly IWebHostEnvironment hostEnvironment;

        public ManageItemController(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public string getTest()
        {
            return "Hello";
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult UploadItem()
        {
            try
            {
                var imageFile = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if(imageFile.Length > 0)
                {
                    var imageName = ContentDispositionHeaderValue.Parse(imageFile.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, imageName);
                    var dbPath = Path.Combine(folderName, imageName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}