using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopForEver.Service.Models
{
    public class ImageUploadModel
    {
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
    }
}
